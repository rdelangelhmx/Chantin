using Chantin.Application.Dto;

namespace Chantin.Application.Interfaces.Common;

public interface IJwtTokenService
{
	string GenereateToken(UsuariosDto user);
	bool VerifyToken(string token);
	UsuariosDto? GetUserFromToken(string token);
}
