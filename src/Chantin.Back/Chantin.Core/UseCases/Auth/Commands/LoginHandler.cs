using Chantin.Application.Interfaces;
using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Config;
using Chantin.Application.Dto;
using Chantin.Domain.Enums;
using Chantin.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TSM.Shared.Tools;

namespace Chantin.Application.Features.Auth.Commands;

public class LoginUserHandler : IRequestHandler<Login, ResultModel<AuthModel>>
{
	readonly IChantinCtx ctx;
	readonly ILogger log;
	readonly IJwtTokenService jwtTokenService;
	readonly ConfigApp configApp;

	public LoginUserHandler(IChantinCtx _ctx, ILogger<LoginUserHandler> _log, IJwtTokenService _jwtTokenService, ConfigApp _configApp)
	{
		ctx = _ctx;
		log = _log;
		jwtTokenService = _jwtTokenService;
		configApp = _configApp;
	}

	public async Task<ResultModel<AuthModel>> Handle(Login request, CancellationToken cancellationToken)
	{
		try
		{
			AuthModel authModel = new AuthModel();
			ctx.AddAudit(ActionForm.Read.ToString().Substring(0, 1), 1, null, $"Auhtentication => Login User {request.UserLogin!.Email}");

			// Find User & Password
			var result = await ctx.Usuarios
				.Include(i => i.IdRolNavigation)
				.ThenInclude(i => i.Permisos)
				.FirstOrDefaultAsync(w => w.Correo == request.UserLogin!.Email && w.Password == request.UserLogin!.Password);
			var isRegistered = await ctx.Usuarios.AnyAsync(w => w.Estatus!.Value && w.Correo == request.UserLogin!.Email);
			if (result == null && isRegistered) throw new NullReferenceException("El usuario no está activo, active su cuenta para acceder");
			if (result == null && !isRegistered) throw new NullReferenceException("El usuario no está registrado");
			if (result != null && !isRegistered) throw new Exception("El usuario no está activo, active su cuenta para acceder");
			// Fill the User Information
			var userLogin = result.MapTo(new UsuariosDto());
			userLogin.Rol = result!.IdRolNavigation.MapTo(new RolesDto());
			userLogin.Rol.Permisos = await ctx.Permisos
				.Where(w => w.IdRol == result.IdRol)
				.Select(s => s.MapTo(new PermisosDto()))
				.ToListAsync();
			// Load Permissions
			foreach (var item in userLogin.Rol.Permisos)
			{
				item.Opcion = (await ctx.Opciones.FirstOrDefaultAsync(w => w.IdOpcion == item.IdOpcion)).MapTo(new OpcionesDto());
				item.Opcion.IdPadre = (await ctx.Opciones.FirstOrDefaultAsync(w => w.idPadre!.Value == item.Opcion.IdPadre!.Value))!.idPadre;
			}
			// Load Photo
			if (userLogin.Imagen != null)
			{
				string filePath = Path.Combine(AppContext.BaseDirectory, configApp.Application!.Resources!, "users", $"u_{userLogin.IdUsuario}.jpeg");
				if (File.Exists(filePath))
				{
					byte[] imageBytes = await File.ReadAllBytesAsync(filePath);
					userLogin.Imagen64 = Convert.ToBase64String(imageBytes);
				}
				else
				{
					log.LogWarning($"Archivo no encontrado: user_{userLogin.IdUsuario}.jpeg");
					userLogin.Imagen64 = null;
				}
			}

			return ResultModel<AuthModel>.Success(new AuthModel
			{
				ExpiresAt = DateTime.Now.AddMinutes(request.Duration),
				Token = jwtTokenService.GenereateToken(userLogin),
				User = userLogin
			});
		}
		catch (Exception ex)
		{
			log.LogError(ex, this.GetType().Name);
			return ResultModel<AuthModel>.Failure($"Error al iniciar sesión: {ex.Message}");
		}
	}
}