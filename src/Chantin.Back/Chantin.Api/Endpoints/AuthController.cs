using Chantin.Application.Interfaces.Repository;
using Chantin.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chantin.Api.EndPoints;

public class AuthController
{
    private readonly ILogger<AuthController> logger;
	public AuthController(ILogger<AuthController> _logger)
    {
        logger = _logger;
    }

	public static void Map(WebApplication app)
    {
        var mapName = app.MapGroup("/Auth").WithTags("Autenticación");

        // Login
        mapName.MapPost("/login", async (LoginModel login, [FromServices] IAuthRepository authRepository) =>
        {
            var response = await authRepository.LoginAsync(login.UserName, login.Password);
			return Results.Ok(response);
        }).WithName("Login");
        
        // Register
        mapName.MapPost("/register", async (RegisterModel register, [FromServices] IAuthRepository authRepository) =>
        {
            var response = await authRepository.RegisterAsync(register);
            return Results.Ok(response);
        }).WithName("Register");
        
        // Verify OTP
        mapName.MapPost("/verify-otp", async (VerifyOtpModel model, [FromServices] IAuthRepository authRepository) =>
        {
            var response = await authRepository.VerifyOtpAsync(model.Email, model.Code);
            return Results.Ok(response);
        }).WithName("VerifyOtp");
        
        // Forgot Password - Send OTP
        mapName.MapPost("/forgot-password", async (ForgotPasswordModel model, [FromServices] IAuthRepository authRepository) =>
        {
            var response = await authRepository.ForgotPasswordAsync(model.Email);
            return Results.Ok(response);
        }).WithName("ForgotPassword");
        
        // Reset Password
        mapName.MapPost("/reset-password", async (ResetPasswordModel model, [FromServices] IAuthRepository authRepository) =>
        {
            var response = await authRepository.ResetPasswordAsync(model.Email, model.Code, model.NewPassword);
            return Results.Ok(response);
        }).WithName("ResetPassword");
        
        // Generate OTP (for 2FA)
        mapName.MapPost("/generate-otp", async (GenerateOtpModel model, [FromServices] IAuthRepository authRepository) =>
        {
            var response = await authRepository.GenerateOtpAsync(model.Email);
            return Results.Ok(response);
        }).WithName("GenerateOtp");

    }
}
