

using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<craftyBuilder.Domain.Logging.ILogger, craftyBuilder.Infrastructure.Logging.SerilogLogger>();
        services.AddSingleton<craftyBuilder.Domain.Logging.ITest, craftyBuider.Infrastructure.Ai.Test>();

        return services;
    }
}
