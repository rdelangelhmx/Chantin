using Chantin.Domain.Models;

namespace Chantin.Application.Interfaces.Repository;

public interface IAuthRepository
{
	Task<ResultModel<LoginModel>> LoginAsync(string email, string password);
	Task<ResultModel<LoginModel>> RegisterAsync(AuthModel userRegister);
	Task<ResultModel<LoginModel>> VerifyOtpAsync(string email, string code);
	Task<ResultModel<LoginModel>> ForgotPasswordAsync(string email);
	Task<ResultModel<LoginModel>> ResetPasswordAsync(string email, string code, string newPassword);
	Task<ResultModel<LoginModel>> GenerateOtpAsync(string email);
}
