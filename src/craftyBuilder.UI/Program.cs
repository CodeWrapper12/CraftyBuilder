using craftyBuider.UI;
using craftyBuilder.Application.CheckOs;
using craftyBuilder.Domain.Interfaces;
using craftyBuilder.Domain.Logging;
using craftyBuilder.UI.AppData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
              services.AddInfrastructureServices(hostContext.Configuration);
              var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
              services.AddTransient<IStartUp, StartUp>();
            }).Build();
// var aiService = host.Services.GetRequiredService<IHostedService>();

// Manually invoke StartAsync
// await aiService.StartAsync(CancellationToken.None);

// The rest of your application logic goes here
var app = host.Services.GetRequiredService<IStartUp>();
await app.StartAsync();

// int selectedIndex = 0;
// string[] options = { "Option 1", "Option 2", "Option 3", "Exit" };
// while (true)
// {
//   Console.Clear();
//   System.Console.WriteLine(a);
//   // Display the menu options
//   for (int i = 0; i < options.Length; i++)
//   {
//     if (i == selectedIndex)
//     {
//       Console.BackgroundColor = ConsoleColor.Gray;
//       Console.ForegroundColor = ConsoleColor.Black;
//     }

//     Console.WriteLine($"{i + 1}. {options[i]}");

//     Console.ResetColor();
//   }

//   ConsoleKeyInfo key = Console.ReadKey();

//   switch (key.Key)
//   {
//     case ConsoleKey.UpArrow:
//       selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
//       break;
//     case ConsoleKey.DownArrow:
//       selectedIndex = (selectedIndex + 1) % options.Length;
//       break;
//     case ConsoleKey.Enter:
//       if (selectedIndex == options.Length - 1)
//       {
//         Console.WriteLine("Exiting program...");
//         return;
//       }
//       else
//       {
//         Console.WriteLine($"You selected {options[selectedIndex]}");
//         // Add your logic for the selected option
//       }
//       break;
//   }
// }



// host.Run();


// System.Console.WriteLine("Ai Started outside");