namespace Chantin.Domain.Config;

public partial class ConfigApp
{
	public List<CfgExternalAuth>? ExternalAuth { get; set; }
	public class CfgExternalAuth
	{
		public string? Provider { get; set; }
		public string? TokenUrl { get; set; }
		public string? ClientId { get; set; }
		public string? ClientSecret { get; set; }
		public string? TeamId { get; set; }
		public string? KeyId { get; set; }
		public string? PrivateKeyPath { get; set; }
		public string? TenantId { get; set; }

	}
}