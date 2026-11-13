using Chantin.Domain.Enums;
using System.Text.Json.Serialization;

namespace Chantin.Domain.Models;

public class WhatsappModel
{
	public string PhoneNumber { get; set; }
	public string Message { get; set; }
	public string? FileUrl { get; set; } = null!;
	public TipoDocumento? TipoDocumento { get; set; } = null;
	public string? Button1 { get; set; } = null;
	public string? Button1Id { get; set; } = null;
	public string? Button2 { get; set; } = null;
	public string? Button2Id { get; set; } = null;
	public string? Button3 { get; set; } = null;
	public string? Button3Id { get; set; } = null;
}

public class TextMeBotModel
{
	[JsonPropertyName("recipient")]
	public string Recipient { get; set; }
	[JsonPropertyName("apikey")]
	public string ApiKey { get; set; }
	[JsonPropertyName("text")]
	public string Text { get; set; }
	[JsonPropertyName("file")]
	public string? FileUrl { get; set; } = null;
	[JsonPropertyName("document")]
	public string? DocumentUrl { get; set; } = null;
	[JsonPropertyName("button1")]
	public string? Button1 { get; set; } = null;
	[JsonPropertyName("button1Id")]
	public string? Button1Id { get; set; } = null;
	[JsonPropertyName("button2")]
	public string? Button2 { get; set; } = null;
	[JsonPropertyName("button2Id")]
	public string? Button2Id { get; set; } = null;
	[JsonPropertyName("button3")]
	public string? Button3 { get; set; } = null;
	[JsonPropertyName("button3Id")]
	public string? Button3Id { get; set; } = null;
}

public class WhatsappResponse
{
	[System.Text.Json.Serialization.JsonPropertyName("status")]
	public string? Estatus { get; set; } = null!;
	[System.Text.Json.Serialization.JsonPropertyName("comment")]
	public string? Comentarios { get; set; } = null!;	
}