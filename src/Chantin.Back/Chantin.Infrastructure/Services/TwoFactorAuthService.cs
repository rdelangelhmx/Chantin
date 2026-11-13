using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Models;
using Microsoft.Extensions.Logging;
using OtpNet;
using TSM.Shared.Tools;

namespace Chantin.Infrastructure.Services;

public class TwoFactorAuthService : ITwoFactorAuthService
{
    private readonly IMessageService _messageService;
    private readonly ILogger<TwoFactorAuthService> _logger;

    public TwoFactorAuthService(IMessageService messageService, ILogger<TwoFactorAuthService> logger)
    {
        _messageService = messageService;
        _logger = logger;
    }

    // Step 1: Generate a new secret for the user
    public string GenerateBase32Secret()
    {
        // Generates a random 20-byte key
        var key = KeyGeneration.GenerateRandomKey(20);

        // Convert to Base32 string (this is what is saved in your database)
        return Base32Encoding.ToString(key);
    }

    // Step 2: Generate the QR Code for Google/Microsoft Authenticator
    public byte[] GenerateQrCode(string email, string base32Secret, string issuer = "ChantinApp")
    {
        // Format required by authenticator apps: otpauth://totp/{issuer}:{email}?secret={secret}&issuer={issuer}
        return Utils.Barcode($"otpauth://totp/{issuer}:{email}?secret={base32Secret}&issuer={issuer}", ZXing.BarcodeFormat.QR_CODE, 20, 20);
    }

    public bool VerifyUserCode(string base32Secret, string userInputCode)
    {
        // 1. Convert the saved Base32 string back to bytes
        var secretBytes = Base32Encoding.ToBytes(base32Secret);
        var totp = new Totp(secretBytes);

        // 2. Verify the code
        // VerificationWindow allows for clock drift. 
        // previous: 1, future: 1 means we accept codes from the previous 30s, current 30s, and next 30s.
        bool isValid = totp.VerifyTotp(
            userInputCode,
            out long timeStepMatched,
            window: new VerificationWindow(previous: 1, future: 1)
        );

        return isValid;
    }

    /// <summary>
    /// Generate a 6-digit OTP code
    /// </summary>
    public string GenerateOtpCode()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    /// <summary>
    /// Send OTP via email
    /// </summary>
    public async Task<bool> SendOtpEmailAsync(string email, string otpCode)
    {
        try
        {
            var emailModel = new EmailModel
			{
                To = new string[] { email },
                From = "noreply@chantin.com",
                Subject = "Código de Verificación - Chantin",
                Body = $@"
                    <html>
                        <body style='font-family: Arial, sans-serif;'>
                            <h2>Código de Verificación</h2>
                            <p>Su código de verificación es:</p>
                            <h1 style='color: #4CAF50; letter-spacing: 5px;'>{otpCode}</h1>
                            <p>Este código expirará en 10 minutos.</p>
                            <p>Si no solicitó este código, ignore este mensaje.</p>
                            <hr/>
                            <p><small>Chantin - Sistema de Gestión</small></p>
                        </body>
                    </html>"
            };

            return await _messageService.SendMailAsync(emailModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending OTP email");
            return false;
        }
    }
}
