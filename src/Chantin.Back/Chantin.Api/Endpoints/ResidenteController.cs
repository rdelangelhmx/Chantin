namespace Chantin.Api.EndPoints;

public class ResidenteController
{
	public static void Map(WebApplication app)
	{
		var mapName = app.MapGroup("/residentes").WithTags("Residentes");

		mapName.MapGet("/", async () => { return Results.Ok(); }).WithName("GetResidentes");
		mapName.MapGet("/{id}", async () => { return Results.Ok(); }).WithName("GetResidenteById");
		mapName.MapGet("/stats", async () => { return Results.Ok(); }).WithName("GetResidenteStats");
		mapName.MapGet("/stats/{id}", async () => { return Results.Ok(); }).WithName("GetResidenteStatsById");
		mapName.MapPost("/create", async () => { return Results.Ok(); }).WithName("CreateResidente");
		mapName.MapDelete("/delete", async () => { return Results.Ok(); }).WithName("DeleteResidente");
		mapName.MapPut("/update", async () => { return Results.Ok(); }).WithName("UpdateResidente");
	
	}
}
