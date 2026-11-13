using Chantin.Application.Interfaces;
using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Config;
using Chantin.Application.Dto;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TSM.Shared.Tools;

namespace Chantin.Infrastructure.Services;

public class JwtTokenService : IJwtTokenService
{
	private readonly ConfigApp configApp;
	private readonly ILogger<JwtTokenService> log;
	private readonly IChantinCtx ctx;

	public JwtTokenService(ConfigApp _configApp, ILogger<JwtTokenService> _log, IChantinCtx _ctx)
	{
		configApp = _configApp;
		log = _log;
		ctx = _ctx;
	}

	public string GenereateToken(UsuariosDto user)
	{
		try
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configApp.AuthSecurity!.SecurityKey!));
			var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
			var jwtToken = new JwtSecurityToken(
				issuer: configApp.AuthSecurity.Issuer,
				audience: configApp.AuthSecurity.Audience,
				claims: GetClaims(user),
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddMinutes(configApp.AuthSecurity.Duration), // .AddMinutes(5),
				signingCredentials: signingCredentials
			);
			return new JwtSecurityTokenHandler().WriteToken(jwtToken);
		}
		catch (Exception ex)
		{
			log.LogError(ex, this.GetType().Name);
			throw;
		}
	}

	public bool VerifyToken(string token)
	{
		try
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configApp.AuthSecurity!.SecurityKey!));
			var tokenHandler = new JwtSecurityTokenHandler();

			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = secretKey,
				ValidateIssuer = true,
				ValidIssuer = configApp.AuthSecurity.Issuer,
				ValidateAudience = true,
				ValidAudience = configApp.AuthSecurity.Audience,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero // Optional: Set to zero to enforce exact expiration
			};
			SecurityToken validatedToken;
			var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
			return principal is not null;
		}
		catch (Exception ex)
		{
			log.LogError(ex, this.GetType().Name);
			throw;
		}
	}

	public UsuariosDto? GetUserFromToken(string token)
	{
		try
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configApp.AuthSecurity!.SecurityKey!));
			var tokenHandler = new JwtSecurityTokenHandler();

			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = secretKey,
				ValidateIssuer = true,
				ValidIssuer = configApp.AuthSecurity.Issuer,
				ValidateAudience = true,
				ValidAudience = configApp.AuthSecurity.Audience,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero // Optional: Set to zero to enforce exact expiration
			};
			SecurityToken validatedToken;
			var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
			var emailUser = principal.Claims.FirstOrDefault(w => w.Type == "EMail")!.Value;
			var userInfo = ctx.Usuarios.FirstOrDefault(w => w.Correo == emailUser).MapTo(new UsuariosDto());
			return userInfo;
		}
		catch (Exception ex)
		{
			log.LogError(ex, this.GetType().Name);
			throw;
		}
	}

	public IEnumerable<Claim> GetClaims(UsuariosDto user)
	{
		var userClaims = new List<Claim>
			{
				new Claim("Email", user.Correo!),
				new Claim("Role", user.Rol!.Nombre!),
				new Claim("Jti", Guid.NewGuid().ToString())
			};
		return userClaims;
	}
}
