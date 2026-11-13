using Chantin.Application.Interfaces;
using Chantin.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Chantin.Application.Features.Auth;

public class VerifyOtp : IRequest<ResultModel<LoginModel>>
{
    public string? Email { get; set; }
    public string? Code { get; set; }
}

public class VerifyOtpHandler : IRequestHandler<VerifyOtp, ResultModel<LoginModel>>
{
    readonly IChantinCtx ctx;
    readonly ILogger log;

    public VerifyOtpHandler(IChantinCtx _ctx, ILogger<VerifyOtpHandler> _log)
    {
        ctx = _ctx;
        log = _log;
    }

    public async Task<ResultModel<LoginModel>> Handle(VerifyOtp request, CancellationToken cancellationToken)
    {
        try
        {
            // Find the OTP record
            var otpRecord = await ctx.Otps
                .FirstOrDefaultAsync(w => w.Correo == request.Email && w.Code == request.Code);

            if (otpRecord == null)
            {
                return ResultModel<LoginModel>.Failure("Código OTP inválido");
            }

            // Check if OTP is already used
            if (otpRecord.IsUsed == true)
            {
                return ResultModel<LoginModel>.Failure("El código OTP ya fue utilizado");
            }

            // Check if OTP is expired
            if (otpRecord.ExpiresAt < DateTime.Now)
            {
                return ResultModel<LoginModel>.Failure("El código OTP ha expirado");
            }

            // Mark OTP as used
            otpRecord.IsUsed = true;
            otpRecord.UsedAt = DateTime.Now;

            // Activate user account
            var user = await ctx.Usuarios.FirstOrDefaultAsync(w => w.Correo == request.Email);
            if (user != null)
            {
                user.Estatus = true;
                user.Activo = true;
                
                // If this was a registration verification, set fAlta if not already set
                if (otpRecord.Purpose == "Registration")
                {
                    user.fAlta = DateTime.Now;
                }
            }

            await ctx.SaveChangesAsync(cancellationToken);

            return ResultModel<LoginModel>.Success(new LoginModel
            {
                Email = request.Email!,
                RequiresVerification = false
            });
        }
        catch (Exception ex)
        {
            log.LogError(ex, this.GetType().Name);
            return ResultModel<LoginModel>.Failure("Ocurrió un error al verificar el código OTP");
		}
    }
}
