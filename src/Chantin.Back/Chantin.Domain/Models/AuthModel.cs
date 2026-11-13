using Chantin.Application.Dto;

namespace Chantin.Domain.Models;

public class AuthModel
{
    public string Token { get; set; } = null!;
    public UsuariosDto User { get; set; } = new()!;
    public DateTime ExpiresAt { get; set; } = DateTime.Now.AddMinutes(5);
}

public class LoginModel
{
    public string Email { get; set; } = null!;
    public string? Password { get; set; } = null!;
	public string? NewPassword { get; set; } = null!;
	public string? Code { get; set; } = null!;
	public bool? RequiresVerification { get; set; }
	public DateTime? ExpiresAt { get; set; }
}
