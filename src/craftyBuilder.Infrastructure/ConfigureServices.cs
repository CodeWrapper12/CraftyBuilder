

using Microsoft.Extensions.Configuration;
using craftyBuider.Infrastructure.Ai;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using Azure;
using Microsoft.Extensions.Hosting;
using craftyBuilder.Domain.Interfaces.CheckOs;
using craftyBuilder.Application.CheckOs;
using craftyBuilder.Domain.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<craftyBuilder.Domain.Logging.ILogger, craftyBuilder.Infrastructure.Logging.SerilogLogger>();

        services.Configure<Settings>(configuration.GetSection("settings"));
        services.AddSingleton(provider =>
        {
            var settings = provider.GetRequiredService<IOptions<Settings>>().Value;

            OpenAIClient client = settings.Type == OpenAIType.Azure
                ? new OpenAIClient(new Uri(settings.Endpoint!), new AzureKeyCredential(settings.Key))
                : new OpenAIClient(settings.Key!);

            System.Console.WriteLine(settings.Endpoint);
            return client;
        });

        services.AddHostedService<AIService>(); // Uncomment this line if you want to use AIService as a hosted service.
        services.AddTransient<IAiService, AIService>();
        services.AddTransient<ICheckOs, CheckOs>();

        return services;
    }
}



