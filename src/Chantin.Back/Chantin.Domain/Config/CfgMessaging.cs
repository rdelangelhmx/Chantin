namespace Chantin.Domain.Config;

public partial class ConfigApp
{
	public CfgMessaging Messaging { get; set; }
	public class CfgMessaging
	{
		public string Account { get; set; }
		public string Phone { get; set; }
		public string Lada { get; set; }
		public string ApiKey { get; set; }
		public string ApiUrl { get; set; }
	}
}
