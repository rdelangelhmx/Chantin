using Chantin.Domain.Config;
using Chantin.Api.EndPoints;
using Chantin.Api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var Log = LoggerFactory.Create(config =>
{
	config.AddConsole();
	config.AddDebug();
	config.AddEventLog();
	config.AddEventSourceLogger();
}).CreateLogger("Program");

Log.LogInformation("Starting Api application...");

// Add Configuration
IConfiguration AppConfiguration = builder.Configuration;
var configApp = AppConfiguration.GetSection("Configuration").Get<ConfigApp>();
builder.Services.Configure<ConfigApp>(AppConfiguration.GetSection("Configuration"));
builder.Services.AddSingleton(s => s.GetRequiredService<IOptions<ConfigApp>>().Value);

// Add Chache Management
builder.Services.AddMemoryCache();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// 1. Add the Authentication services
builder.Services
	.AddAuthorization()
	.AddAuthentication()
	.AddJwtBearer(options => {
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = configApp!.AuthSecurity!.Issuer,
			ValidAudience = configApp.AuthSecurity.Audience,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configApp.AuthSecurity.SecurityKey!))
		};
	})
	.AddGoogle(googleOptions =>
	{
		// It is best practice to pull these from appsettings.json or Secret Manager
		googleOptions.ClientId = configApp!.ExternalAuth?.FirstOrDefault(e => e.Provider == "Google")?.ClientId!;
		googleOptions.ClientSecret = configApp!.ExternalAuth?.FirstOrDefault(e => e.Provider == "Google")?.ClientSecret!;
	})
	.AddMicrosoftAccount(microsoftOptions =>
	{
		microsoftOptions.ClientId = configApp!.ExternalAuth?.FirstOrDefault(e => e.Provider == "Microsoft")?.ClientId!;
		microsoftOptions.ClientSecret = configApp!.ExternalAuth?.FirstOrDefault(e => e.Provider == "Microsoft")?.ClientSecret!;
	})
	.AddApple(appleOptions =>
	{
		appleOptions.ClientId = configApp!.ExternalAuth?.FirstOrDefault(e => e.Provider == "Apple")?.ClientId!;
		appleOptions.TeamId = configApp!.ExternalAuth?.FirstOrDefault(e => e.Provider == "Apple")?.TeamId!;
		appleOptions.KeyId = configApp!.ExternalAuth?.FirstOrDefault(e => e.Provider == "Apple")?.KeyId!;

		// The private key can be loaded from a local file, Azure Key Vault, or a raw string.
		// For local development, pointing to the .p8 file path is easiest:
		appleOptions.UsePrivateKey((keyId) =>
			builder.Environment.ContentRootFileProvider.GetFileInfo($"AuthKey_{keyId}.p8"));
	});

// Add Swagger
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc($"v{configApp!.Application!.Version}", new OpenApiInfo
	{
		Title = configApp.Application.Name,
		Version = $"v{configApp.Application.Version}",
		Description = configApp.Application.Description,
		Contact = new OpenApiContact
		{
			Name = configApp.Application.Company,
			Email = configApp.Application.Email,
			Url = new Uri(configApp.Application.WebPage!),
		}
	});
	options.AddSecurityDefinition(configApp.Application.CacheKey, new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = JwtBearerDefaults.AuthenticationScheme,
		In = ParameterLocation.Header,
		Description = $"{configApp.Application.Name} Api Auth",
		Name = HeaderNames.Authorization,
	});
	options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
	{
		[new OpenApiSecuritySchemeReference("bearer", document)] = []
	});
});

builder.Services.AddCors();

// Add Application services

// Add Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.MapOpenApi();

app.UseCors(builder => builder
	.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod());

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options => {
	options.SwaggerEndpoint($"v{configApp!.Application!.Version}/swagger.json", $"{configApp.Application.Name} API v{configApp.Application.Version}");
});
app.UseReDoc(c =>
{
	c.RoutePrefix = "api-docs"; // URL path to access ReDoc (e.g., /api-docs)
	if (app.Environment.IsDevelopment())
		c.SpecUrl = $"/swagger/v{configApp!.Application!.Version}/swagger.json"; // Path to the generated OpenAPI JSON
	else
		c.SpecUrl = $"/api/swagger/v{configApp!.Application!.Version}/swagger.json"; // Path to the generated OpenAPI JSON
	c.DocumentTitle = $"{configApp.Application.Name} API Documentation";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

// 2. Add Authentication and Authorization to the HTTP pipeline
app.UseAuthentication();
app.UseAuthorization();

// Map End Points
AuthController.Map(app);
OauthController.Map(app);
ResidenteController.Map(app);

app.Run();
