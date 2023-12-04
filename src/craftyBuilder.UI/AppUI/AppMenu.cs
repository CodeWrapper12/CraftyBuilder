using craftyBuilder.UI.AppData;

namespace craftyBuider.UI.AppUI;

public static class AppMenu
{
  public static string DiplayMenu(string appType)
  {
    int selectedIndex = 0;
    appType = char.ToUpper(appType[0]) + appType[1..];
    string[] options = [$"How I install {appType}", $"Varoius Resource for {appType}", "Exit"];
    while (true)
    {
      Console.Clear();
      AppData.GetAppImage();  // Display the menu options
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
            Environment.Exit(0);
            break;
          }
          else
          {
            return options[selectedIndex];
          }
      }
    }

  }
}