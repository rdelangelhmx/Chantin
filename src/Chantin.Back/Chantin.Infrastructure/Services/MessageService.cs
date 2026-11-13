using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Config;
using Chantin.Domain.Enums;
using Chantin.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TSM.Shared.Tools;

namespace Chantin.Infrastructure.Services;

public class MessageService : IMessageService
{
	private readonly ILogger<MessageService> log;
	private readonly ConfigApp configApp;

	public MessageService(ILogger<MessageService> _log, ConfigApp _configApp)
	{
		log = _log;
		configApp = _configApp;
	}

	#region Gmail
	/// <summary>
	/// Send Mail via GMail Account
	/// </summary>
	/// <returns></returns>
	public async Task<bool> SendGMailAsync(EmailModel eMail)
	{
		try
		{
			using (SmtpClient sServer = new SmtpClient())
			{
				sServer.Host = configApp.MailServer!.Server!;
				sServer.Port = configApp.MailServer.Port == 0 ? 25 : configApp.MailServer.Port;
				sServer.EnableSsl = configApp.MailServer.SSL;
				sServer.DeliveryMethod = SmtpDeliveryMethod.Network;
				sServer.Credentials = new NetworkCredential(configApp.MailServer.User, Encryption.Decrypt(configApp.MailServer.Pwd!));
				await sServer.SendMailAsync(GetMailMessage(eMail));
			}
			return true;
		}
		catch (SmtpException ex)
		{
			log.LogError(ex, "Messaging => SendGMail");
			return false;
		}
		catch (Exception ex)
		{
			log.LogError(ex, "Messaging => SendGMail");
			return false;
		}
	}

	#endregion

	#region Common
	public async Task<bool> SendMailAsync(EmailModel eMail)
	{
		try
		{
			using (SmtpClient sServer = new SmtpClient())
			{
				sServer.Host = configApp.MailServer!.Server!;
				sServer.Port = configApp.MailServer.Port == 0 ? 25 : configApp.MailServer.Port;
				sServer.EnableSsl = configApp.MailServer.SSL;
				sServer.Credentials = new NetworkCredential(configApp.MailServer.User, configApp.MailServer.Pwd);
				await sServer.SendMailAsync(GetMailMessage(eMail));
			}
			return true;
		}
		catch (Exception ex)
		{
			log.LogError(ex, "Messaging => SendMail");
			throw;
		}
	}

	#region SMS / Whatsapp  
	public bool SendSMS(string phone, string message)
	{
		try
		{
			Console.WriteLine($"Sending SMS to {phone} with the message: {message}");
			return true;
		}
		catch (Exception ex)
		{
			log.LogError(ex, "Messaging => Send");
			return false;
		}
	}

	public async Task<bool> SendWhatsappAsync(WhatsappModel whatsapp)
	{
		try
		{
			var button1 = "";
			var button2 = "";
			var button3 = "";

			TextMeBotModel msgModel = new TextMeBotModel
			{
				Recipient = $"{configApp.Messaging.Lada}{whatsapp.PhoneNumber}",
				ApiKey = configApp.Messaging.ApiKey,
				Text = whatsapp.Message,
				FileUrl = whatsapp.TipoDocumento == TipoDocumento.Imagenes ? whatsapp.FileUrl : null,
				DocumentUrl = whatsapp.TipoDocumento != TipoDocumento.Imagenes ? whatsapp.FileUrl : null,
				Button1 = whatsapp.Button1,
				Button1Id = whatsapp.Button1Id,
				Button2 = whatsapp.Button2,
				Button2Id = whatsapp.Button2Id,
				Button3 = whatsapp.Button3,
				Button3Id = whatsapp.Button3Id
			};

			// Create the full BODY with parameters
			string body = JsonSerializer.Serialize(msgModel, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true });

			using (HttpClient client = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await client.PostAsync(configApp.Messaging.ApiUrl, new StringContent(body, Encoding.UTF8, "application/json"));
					response.EnsureSuccessStatusCode();
					string responseBody = await response.Content.ReadAsStringAsync();
					log.LogInformation("Message Sent! Response: " + responseBody);
					var responseObj = JsonSerializer.Deserialize<WhatsappResponse>(responseBody);
					if (responseObj.Estatus != "success")
					{
						log.LogError("Failed to send WhatsApp message. Response: " + responseBody);
						throw new Exception("Failed to send WhatsApp message. Response: " + responseBody);
					}
				}
				catch (HttpRequestException e)
				{
					log.LogError($"Request error: {e.Message}");
					throw;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			log.LogError(ex, "Whatsapp => Not Send");
			return false;
		}
	}
	#endregion

	private MailMessage GetMailMessage(EmailModel eMail)
	{
		Attachment FileAttach;
		MailMessage msgMail = new MailMessage();
		msgMail.From = new MailAddress(eMail.From);
		foreach (string mailTo in eMail.To)
		{
			msgMail.To.Add(mailTo);
		}
		if (eMail.FileAtt != null)
		{
			foreach (string oFile in eMail.FileAtt)
			{
				FileAttach = new Attachment(oFile);
				msgMail.Attachments.Add(FileAttach);
			}
		}
		msgMail.Subject = eMail.Subject;
		msgMail.IsBodyHtml = true;
		msgMail.Body = eMail.Body;
		msgMail.Priority = MailPriority.Normal;
		return msgMail;
	}
	#endregion
}
