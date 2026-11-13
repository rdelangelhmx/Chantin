using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Chantin.Api.EndPoints;

public class OauthController
{
	public static void Map(WebApplication app)
	{
		var mapName = app.MapGroup("/oauth").WithTags("OAuth");

		mapName.MapGet("/apple/signin", async () =>
			Results.Challenge(
				new AuthenticationProperties { RedirectUri = "/oauth/apple/callback" },
				new[] { "Apple" } // Use "Microsoft" or "Apple" to trigger the other providers
		)).WithName("Apple SignIn");
		mapName.MapGet("/microsoft/signin", async () =>
			Results.Challenge(
				new AuthenticationProperties { RedirectUri = "/oauth/microsoft/callback/" },
				new[] { "Microsoft" } // Use "Microsoft" or "Apple" to trigger the other providers
		)).WithName("Microsoft SignIn");
		mapName.MapGet("/google/signin", async () => 
			Results.Challenge(
				new AuthenticationProperties { RedirectUri = "/oauth/google/callback" }, 
				new[] { "Google" })
		).WithName("Google SignIn");
		mapName.MapGet("/callback", async (HttpContext context) => {
			// Authenticate against the local Cookie scheme to read the identity established by the OAuth provider
			var result = await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			if (!result.Succeeded)
			{
				return Results.BadRequest("External authentication failed.");
			}

			// Extract the claims provided by Google, Microsoft, or Apple
			var claimsPrincipal = result.Principal;

			var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var email = claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
			var name = claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;

			// Determine which provider was used
			var provider = result.Properties.Items.ContainsKey(".AuthScheme")
				? result.Properties.Items[".AuthScheme"]
				: "Unknown";

			// --- YOUR APPLICATION LOGIC GOES HERE ---
			// 1. Check your database: Does a user with this email or userId exist?
			// 2. If no, create a new user record in your database.
			// 3. If yes, update their last login time.
			// ----------------------------------------

			// Redirect the user to your secure homepage or dashboard
			return Results.Redirect("/dashboard");
		}).WithName("Oauth Callback");
	}
}
