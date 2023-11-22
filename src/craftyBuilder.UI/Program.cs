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
int selectedIndex = 0;
string[] options = { "Option 1", "Option 2", "Option 3", "Exit" };

while (true)
{
  Console.Clear();

  // Display the menu options
  for (int i = 0; i < options.Length; i++)
  {
    if (i == selectedIndex)
    {
      Console.BackgroundColor = ConsoleColor.Gray;
      Console.ForegroundColor = ConsoleColor.Black;
    }

    Console.WriteLine($"{i + 1}. {options[i]}");

    Console.ResetColor();
  }

  ConsoleKeyInfo key = Console.ReadKey();

  switch (key.Key)
  {
    case ConsoleKey.UpArrow:
      selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
      break;
    case ConsoleKey.DownArrow:
      selectedIndex = (selectedIndex + 1) % options.Length;
      break;
    case ConsoleKey.Enter:
      if (selectedIndex == options.Length - 1)
      {
        Console.WriteLine("Exiting program...");
        return;
      }
      else
      {
        Console.WriteLine($"You selected {options[selectedIndex]}");
        // Add your logic for the selected option
      }
      break;
  }
}

// host.Run();


// System.Console.WriteLine("Ai Started outside");