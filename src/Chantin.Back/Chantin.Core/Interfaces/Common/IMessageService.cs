using Chantin.Domain.Models;

namespace Chantin.Application.Interfaces.Common;

public interface IMessageService
{

	bool SendSMS(string phone, string message);
	Task<bool> SendWhatsappAsync(WhatsappModel whatsapp);
	Task<bool> SendGMailAsync(EmailModel eMail);
	Task<bool> SendMailAsync(EmailModel eMail);
}
