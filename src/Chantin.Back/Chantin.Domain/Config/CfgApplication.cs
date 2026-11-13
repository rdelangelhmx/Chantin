namespace Chantin.Domain.Config;

public partial class ConfigApp
{
	public CfgApplication? Application { get; set; }
	public class CfgApplication
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Version { get; set; }
		public string? Company { get; set; }
		public string? TermsAndConditions { get; set; }
		public string? PrivacyPolicy { get; set; }
		public string? Email { get; set; }
		public string? WebPage { get; set; }
		public string? Licence { get; set; }
		public string? LicenceType { get; set; }
		public string? Language { get; set; }
		public string? CacheKey { get; set; }
		public int? CacheTimeout { get; set; } = 5;
		public string? Resources { get; set; }
		public string? MediarTLicence { get; set; }
	}
}