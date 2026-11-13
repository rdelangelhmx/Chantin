namespace Chantin.Domain.Config;
public partial class ConfigApp
{
	public CfgPolly? Polly { get; set; }

	public class CfgPolly
	{
		public int RetryAttempt { get; set; } = 2;
		public int AwaitSeconds { get; set; } = 3;
		public bool Enable { get; set; }
	}
}