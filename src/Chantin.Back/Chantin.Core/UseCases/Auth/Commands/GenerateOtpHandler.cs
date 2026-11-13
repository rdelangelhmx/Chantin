using Chantin.Application.Interfaces;
using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Entities;
using Chantin.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Chantin.Application.Features.Auth.Commands;

public class GenerateOtpHandler : IRequestHandler<GenerateOtp, ResultModel<LoginModel>>
{
	readonly IChantinCtx ctx;
	readonly ILogger log;
	readonly ITwoFactorAuthService twoFactorAuthService;

	public GenerateOtpHandler(IChantinCtx _ctx, ILogger<GenerateOtpHandler> _log,
		ITwoFactorAuthService _twoFactorAuthService)
	{
		ctx = _ctx;
		log = _log;
		twoFactorAuthService = _twoFactorAuthService;
	}

	public async Task<ResultModel<LoginModel>> Handle(GenerateOtp request, CancellationToken cancellationToken)
	{
		try
		{
			// Find user by email
			var user = await ctx.Usuarios.FirstOrDefaultAsync(w => w.Correo == request.Email && w.Estatus == true);

			if (user == null)
			{
				throw new Exception("Usuario no encontrado o no activo");
			}

			// Generate OTP
			var otpCode = twoFactorAuthService.GenerateOtpCode();
			var expiresAt = DateTime.Now.AddMinutes(10);

			// Save OTP to database
			var otp = new Otps
			{
				Correo = request.Email,
				Code = otpCode,
				ExpiresAt = expiresAt,
				IsUsed = false,
				Purpose = "TwoFactorAuth"
			};
			ctx.Otps.Add(otp);
			await ctx.SaveChangesAsync(cancellationToken);

			// Send OTP email
			var emailSent = await twoFactorAuthService.SendOtpEmailAsync(request.Email!, otpCode);
			if (!emailSent) throw new Exception("No se pudo enviar el correo de verificación");

			return ResultModel<LoginModel>.Success(new LoginModel
			{
				Email = request.Email!,
				RequiresVerification = true,
				ExpiresAt = expiresAt
			});
		}
		catch (Exception ex)
		{
			log.LogError(ex, this.GetType().Name);
			return ResultModel<LoginModel>.Failure($"Error al iniciar sesión: {ex.Message}");
		}
	}
}
