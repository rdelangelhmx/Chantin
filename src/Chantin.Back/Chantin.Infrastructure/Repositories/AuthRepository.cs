using Chantin.Application.Features.Auth;
using Chantin.Application.Features.Security;
using Chantin.Application.Interfaces.Repository;
using Chantin.Domain.Config;
using Chantin.Domain.Models;
using MediatR;

namespace Chantin.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
	private readonly IMediator mediator;
	private readonly ConfigApp configApp;

	public AuthRepository(IMediator _mediator, ConfigApp _configApp)
	{
		mediator = _mediator;
		configApp = _configApp;
	}

	public async Task<ForgotPasswordResponse> ForgotPasswordAsync(string email)
	{
		return await mediator.Send(new ForgotPassword { Email = email });
	}

	public async Task<ResetPasswordResponse> ResetPasswordAsync(string email, string code, string newPassword)
	{
		return await mediator.Send(new ResetPassword { Email = email, Code = code, NewPassword = newPassword });
	}

	public async Task<GenerateOtpResponse> GenerateOtpAsync(string email)
	{
		return await mediator.Send(new GenerateOtp { Email = email });
	}

	public async Task<VerifyOtpResponse> VerifyOtpAsync(string email, string otp)
	{
		return await mediator.Send(new VerifyOtp { Email = email, Code = otp });
	}

	public async Task<AuthModel> LoginAsync(string email, string password)
	{
		return await mediator.Send(new Login { UserLogin = new LoginModel { UserName = email, Password = password }, Duration = configApp.AuthSecurity!.Duration });
	}

	public async Task<RegisterResponse> RegisterAsync(RegisterModel userRegister)
	{
		return await mediator.Send(new Register { UserRegister = userRegister});
	}

	public Task<AuthModel> LoginOAuthAsync(string email, string provider)
	{
		throw new NotImplementedException();
	}
}
