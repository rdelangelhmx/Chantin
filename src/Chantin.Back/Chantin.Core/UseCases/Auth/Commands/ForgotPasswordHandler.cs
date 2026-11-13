using Chantin.Application.Interfaces;
using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Entities;
using Chantin.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Chantin.Application.Features.Auth.Commands;

public class ForgotPasswordHandler : IRequestHandler<ForgotPassword, ResultModel<LoginModel>>
{
    readonly IChantinCtx ctx;
    readonly ILogger log;
    readonly ITwoFactorAuthService twoFactorAuthService;

    public ForgotPasswordHandler(IChantinCtx _ctx, ILogger<ForgotPasswordHandler> _log, ITwoFactorAuthService _twoFactorAuthService)
    {
        ctx = _ctx;
        log = _log;
        twoFactorAuthService = _twoFactorAuthService;
    }

    public async Task<ResultModel<LoginModel>> Handle(ForgotPassword request, CancellationToken cancellationToken)
    {
        try
        {
            // Find user by email
            var user = await ctx.Usuarios.FirstOrDefaultAsync(w => w.Correo == request.Email && w.Estatus == true);

			// For security reasons, don't reveal if email exists or not
			if (user == null) return ResultModel<LoginModel>.Failure("Error el usuario no está registrado.");

            // Generate OTP for password reset
            var otpCode = twoFactorAuthService.GenerateOtpCode();
            var expiresAt = DateTime.Now.AddMinutes(10);

            // Save OTP to database with PasswordReset purpose
            var otp = new Otps
            {
                Correo = request.Email,
                Code = otpCode,
                ExpiresAt = expiresAt,
                IsUsed = false,
                Purpose = "PasswordReset"
            };
            ctx.Otps.Add(otp);
            await ctx.SaveChangesAsync(cancellationToken);

            // Send OTP email
            var emailSent = await twoFactorAuthService.SendOtpEmailAsync(request.Email!, otpCode);
            if (!emailSent) throw new Exception("No se pudo enviar el correo de verificación");

            return ResultModel<LoginModel>.Success(new LoginModel
			{
                Email = request.Email!, 
                Code = otpCode,
				ExpiresAt = expiresAt,
				RequiresVerification = true
			});
        }
        catch (Exception ex)
        {
            log.LogError(ex, this.GetType().Name);
			return ResultModel<LoginModel>.Failure($"Error no se pudo enviar procesar su petición: {ex.Message}");
		}
    }
}