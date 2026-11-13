namespace Chantin.Domain.Config;

public partial class ConfigApp
{
	public CfgMailServer? MailServer { get; set; }

	public class CfgMailServer
	{
		public string? Server { get; set; }
		public int Port { get; set; } = 587;
		public string? User { get; set; }
		public string? Pwd { get; set; }
		public bool SSL { get; set; }
		public bool IsGoogle { get; set; }
	}

}