using Chantin.Application.Interfaces;
using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Entities;
using Chantin.Domain.Enums;
using Chantin.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Roles = Chantin.Domain.Enums.Roles;

namespace Chantin.Application.Features.Auth.Commands;

public class RegisterUserHandler : IRequestHandler<Register, ResultModel<LoginModel>>
{
	readonly IChantinCtx ctx;
	readonly ILogger log;
	readonly ITwoFactorAuthService twoFactorAuthService;
	readonly IMessageService messageService;

	public RegisterUserHandler(IChantinCtx _ctx, ILogger<RegisterUserHandler> _log,
		ITwoFactorAuthService _twoFactorAuthService, IMessageService _messageService)
	{
		ctx = _ctx;
		log = _log;
		twoFactorAuthService = _twoFactorAuthService;
		messageService = _messageService;
	}

	public async Task<ResultModel<LoginModel>> Handle(Register request, CancellationToken cancellationToken)
	{
		try
		{
			ctx.AddAudit(ActionForm.Create.ToString().Substring(0, 1), 1, null, $"Register User {request.UserRegister?.Correo!}");

			// Check if user already exists
			var existingUser = await ctx.Usuarios.FirstOrDefaultAsync(w => w.Correo == request.UserRegister!.Correo);
			if (existingUser != null)
			{
				if (existingUser.Estatus == true)
					throw new Exception("El usuario ya está registrado y activo");
				else
					throw new Exception("El usuario ya está registrado pero no ha activado su cuenta");
			}

			// Generate OTP for email verification
			var otpCode = twoFactorAuthService.GenerateOtpCode();
			var expiresAt = DateTime.Now.AddMinutes(10);

			// Save OTP to database
			var otp = new Otps
			{
				Correo = request.UserRegister?.Correo,
				Code = otpCode,
				ExpiresAt = expiresAt,
				IsUsed = false,
				Purpose = "Registration"
			};
			ctx.Otps.Add(otp);

			// Create new user (inactive until OTP verified)
			var newUser = new Usuarios
			{
				IdEmpresa = request.UserRegister?.IdEmpresa ?? 1,
				IdAsociacion = request.UserRegister?.IdAsociacion,
				Correo = request.UserRegister?.Correo!,
				Password = request.UserRegister?.Password!, // TODO: Hash password before saving
				Nombre = request.UserRegister?.Nombre,
				Apellidos = request.UserRegister?.Apellidos,
				IdRol = (int)(request.UserRegister?.IdRol ?? Roles.Residente), // Default to Residente role
				Telefono = request.UserRegister?.Telefono,
				Activo = false,
				Estatus = false,
				fAlta = DateTime.Now
			};

			ctx.Usuarios.Add(newUser);
			await ctx.SaveChangesAsync(cancellationToken);

			// Send OTP email
			var emailSent = await twoFactorAuthService.SendOtpEmailAsync(request.UserRegister!.Correo!, otpCode);
			if (!emailSent) throw new Exception("No se pudo enviar el correo de verificación");

			return ResultModel<LoginModel>.Success(new LoginModel
			{
				Email = request.UserRegister?.Correo!,
				RequiresVerification = true,
				ExpiresAt = expiresAt
			});
		}
		catch (Exception ex)
		{
			log.LogError(ex, this.GetType().Name);
			return ResultModel<LoginModel>.Failure($"Error al registrar usuario: {ex.Message}");
		}
	}
}
