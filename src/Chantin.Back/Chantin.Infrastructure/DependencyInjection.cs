using Chantin.Application.Interfaces;
using Chantin.Application.Interfaces.Common;
using Chantin.Application.Interfaces.Repository;
using Chantin.Domain.Config;
using Chantin.Infrastructure.Persistence;
using Chantin.Infrastructure.Repositories;
using Chantin.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chantin.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, string licence)
	{
		// Add Assembly Services
		var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
		// Add Assembly Repository
		services.AddMediatR(cfg => {
			cfg.LicenseKey = licence;
			cfg.RegisterServicesFromAssemblies(assemblies.ToArray());
		});
		return services;
	}

	public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigApp configApp)
	{
		services.AddDbContext<ChantinCtx>(options =>
			options.UseSqlServer(configApp.ClientDB!.Conn, o => {
				o.CommandTimeout(configApp.ClientDB.TimeOut);
				o.EnableRetryOnFailure(configApp.ClientDB!.RetryAttempt);
			}));
		services.AddScoped<IChantinCtx>(provider => provider.GetService<ChantinCtx>()!);
		return services;
	}

	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		// Add Services
		services.AddScoped<ICacheService, CacheService>();
		services.AddScoped<IJwtTokenService, JwtTokenService>();
		services.AddScoped<IMessageService, MessageService>();
		services.AddScoped<ITwoFactorAuthService, TwoFactorAuthService>();

		return services;
	}

	public static IServiceCollection AddDataServices(this IServiceCollection services)
	{
		// Data Repositories
		services.AddScoped<IAuthRepository, AuthRepository>();

		return services;
	}

}
