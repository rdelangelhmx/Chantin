using Chantin.Domain.Models;

namespace Chantin.Application.Interfaces.Common;

public interface ITwoFactorAuthService
{
    string GenerateBase32Secret();
    byte[] GenerateQrCode(string email, string base32Secret, string issuer = "ChantinApp");
    bool VerifyUserCode(string base32Secret, string userInputCode);
    string GenerateOtpCode();
    Task<bool> SendOtpEmailAsync(string email, string otpCode);
}
