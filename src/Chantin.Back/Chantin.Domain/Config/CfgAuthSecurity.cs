namespace Chantin.Domain.Config;

public partial class ConfigApp
{
	public CfgAuthSecurity? AuthSecurity { get; set; }
	public class CfgAuthSecurity
	{
		public string? Policy { get; set; }
		public string? Cors { get; set; }
		public string? SecurityKey { get; set; }
		public string? Audience { get; set; }
		public string? Issuer { get; set; }
		public int Duration { get; set; } = 720;
	}
}