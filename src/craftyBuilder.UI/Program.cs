using craftyBuilder.Domain.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
              services.AddInfrastructureServices(hostContext.Configuration);
            })
            .Build();

// The rest of your application logic goes here
System.Console.WriteLine("Ai Started inside");
var app = host.Services.GetRequiredService<ITest>();

app.printSomething();
host.Run();


System.Console.WriteLine("Ai Started outside");