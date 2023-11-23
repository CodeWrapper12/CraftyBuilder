

using Microsoft.Extensions.Configuration;
using craftyBuider.Infrastructure.Ai;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using Azure;
using Microsoft.Extensions.Hosting;
using craftyBuilder.Domain.Interfaces.CheckOs;
using craftyBuilder.Application.CheckOs;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<craftyBuilder.Domain.Logging.ILogger, craftyBuilder.Infrastructure.Logging.SerilogLogger>();
        services.AddSingleton<craftyBuilder.Domain.Logging.ITest, Test>();
        services.AddSingleton<IHostedService, AIService>();
        services.AddSingleton(provider =>
    {
        var settingsSection = configuration.GetSection("settings");
        services.Configure<Settings>(settingsSection);
        var settings = services.BuildServiceProvider().GetRequiredService<IOptions<Settings>>().Value;

        OpenAIClient client = settings.Type == OpenAIType.Azure
            ? new OpenAIClient(new Uri(settings.Endpoint!), new AzureKeyCredential(settings.Key))
            : new OpenAIClient(settings.Key!);
        System.Console.WriteLine(settings.Endpoint);
        return client;
    });
        services.AddHostedService<AIService>();
        services.AddTransient<ICheckOs, CheckOs>();
        return services;
    }
}
