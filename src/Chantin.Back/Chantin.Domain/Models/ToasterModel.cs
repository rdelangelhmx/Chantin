using Chantin.Domain.Enums;

namespace Chantin.Domain.Models;

public record ToasterModel
{
	public Guid Id = Guid.NewGuid();
	public string Title { get; init; } = string.Empty;
	public string Message { get; init; } = string.Empty;
	public Severity MessageColour { get; init; } = Severity.Primary;
	public string Ico { get; init; } = string.Empty;
	public readonly DateTimeOffset Posted = DateTimeOffset.Now;
	public DateTimeOffset TimeToBurn { get; init; } = DateTimeOffset.Now.AddSeconds(30);
	public bool IsBurnt => TimeToBurn < DateTimeOffset.Now;
	private TimeSpan elapsedTime => Posted - DateTimeOffset.Now;

	public string ElapsedTimeText =>
		elapsedTime.Seconds > 60
		? $"posted {-elapsedTime.Minutes} mins ago"
		: $"posted {-elapsedTime.Seconds} secs ago";


	public static ToasterModel NewToast(string title, string message, Severity messageColour, int secsToLive)
		=> new ToasterModel
		{
			Title = title,
			Message = message,
			MessageColour = messageColour,
			TimeToBurn = DateTimeOffset.Now.AddSeconds(secsToLive)
		};
}