
using craftyBuider.Infrastructure.Ai;
using craftyBuider.UI.AppUI;
using craftyBuilder.Domain.Interfaces;
using craftyBuilder.Domain.Interfaces.CheckOs;
using craftyBuilder.UI.AppData;

namespace craftyBuider.UI;

public class StartUp : IStartUp
{
  private readonly IAiService _aIService;
  private readonly ICheckOs checkOs;


  public StartUp(IAiService aIService, ICheckOs checkOs)
  {
    _aIService = aIService;
    this.checkOs = checkOs;
  }
  public async Task StartAsync()
  {
    bool isValidInput = false;
    string appName;
    do
    {
      Console.Clear();
      AppData.GetAppInfo();
      System.Console.Write("\n enter your App Type:");
      appName = Console.ReadLine() ?? "";
      if (string.IsNullOrEmpty(appName))
      {
        System.Console.WriteLine("please Enter A valid Stack/app type");
      }
      else
      {
        string isValidLanguage = await _aIService.SendMessageAsync($"Is {appName} a language?   Please respond with 'y' for yes or 'n' for no.", true);
        string isValidFramework = await _aIService.SendMessageAsync($"Is {appName} a framework?   Please respond with 'y' for yes or 'n' for no.", true);

        isValidLanguage = isValidLanguage.ToLowerInvariant().Trim();
        isValidFramework = isValidFramework.ToLowerInvariant().Trim();
        if ((isValidLanguage.Length < 3 || isValidFramework.Length < 3) && (isValidLanguage.Contains('y') || isValidLanguage.Contains("yes")) || isValidFramework.Contains('y') || isValidFramework.Contains("yes"))
        {
          isValidInput = true;
        }
      }

    } while (!isValidInput);
    string userOption = AppMenu.DiplayMenu(appName);
    await _aIService.SendMessageAsync($"{userOption} in {checkOs.FindOs()}", false);




  }
}