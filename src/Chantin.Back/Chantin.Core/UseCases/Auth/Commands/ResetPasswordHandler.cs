using Chantin.Application.Interfaces;
using Chantin.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Chantin.Application.Features.Auth.Commands;

public class ResetPasswordHandler : IRequestHandler<ResetPassword, ResultModel<LoginModel>>
{
	readonly IChantinCtx ctx;
	readonly ILogger log;

	public ResetPasswordHandler(IChantinCtx _ctx, ILogger<ResetPasswordHandler> _log)
	{
		ctx = _ctx;
		log = _log;
	}

	public async Task<ResultModel<LoginModel>> Handle(ResetPassword request, CancellationToken cancellationToken)
	{
		try
		{
			// Verify OTP
			var otpRecord = await ctx.Otps
				.FirstOrDefaultAsync(w => w.Correo == request.Email && w.Code == request.Code);

			if (otpRecord == null || otpRecord.IsUsed == true || otpRecord.ExpiresAt < DateTime.Now) return ResultModel<LoginModel>.Failure("Código de verificación inválido o expirado");

			// Find user
			var user = await ctx.Usuarios.FirstOrDefaultAsync(w => w.Correo == request.Email && w.Estatus == true);
			if (user == null) return ResultModel<LoginModel>.Failure("Usuario no encontrado");

			// Update password
			user.Password = request.NewPassword!; // TODO: Hash password before saving
			user.fModifica = DateTime.Now;

			// Mark OTP as used
			otpRecord.IsUsed = true;
			otpRecord.UsedAt = DateTime.Now;

			await ctx.SaveChangesAsync(cancellationToken);

			return ResultModel<LoginModel>.Success(new LoginModel
			{
				Email = user.Correo,
				RequiresVerification = false
			});
		}
		catch (Exception ex)
		{
			log.LogError(ex, this.GetType().Name);
			return ResultModel<LoginModel>.Failure($"Error al restablecer contraseña: {ex.Message}");
		}
	}
}