using Microsoft.Extensions.DependencyInjection;

namespace ChamberOfSecrets.CollabChamber.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddCors(options =>
        {

            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("https://example.com")
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST")
                        .AllowCredentials();
                });
        });
        return services;
    }
}