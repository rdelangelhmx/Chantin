namespace Chantin.Domain.Models;

public class EmailModel
{
	public string From { get; set; } = null!;
	public string Subject { get; set; } = null!;
	public string Body { get; set; } = null!;
	public string[] To { get; set; } = null!;
	public string[] FileAtt { get; set; } = null!;
}
