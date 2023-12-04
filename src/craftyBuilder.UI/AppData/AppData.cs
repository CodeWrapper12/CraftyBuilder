using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace craftyBuilder.UI.AppData
{
    public static class AppData
    {
        private static readonly string AppImage = @"
 ▄████▄      ██▀███      ▄▄▄           █████▒   ▄▄▄█████▓   ▓██   ██▓       ▄▄▄▄       █    ██     ██▓    ██▓       ▓█████▄    ▓█████     ██▀███  
▒██▀ ▀█     ▓██ ▒ ██▒   ▒████▄       ▓██   ▒    ▓  ██▒ ▓▒    ▒██  ██▒      ▓█████▄     ██  ▓██▒   ▓██▒   ▓██▒       ▒██▀ ██▌   ▓█   ▀    ▓██ ▒ ██▒
▒▓█    ▄    ▓██ ░▄█ ▒   ▒██  ▀█▄     ▒████ ░    ▒ ▓██░ ▒░     ▒██ ██░      ▒██▒ ▄██   ▓██  ▒██░   ▒██▒   ▒██░       ░██   █▌   ▒███      ▓██ ░▄█ ▒
▒▓▓▄ ▄██▒   ▒██▀▀█▄     ░██▄▄▄▄██    ░▓█▒  ░    ░ ▓██▓ ░      ░ ▐██▓░      ▒██░█▀     ▓▓█  ░██░   ░██░   ▒██░       ░▓█▄   ▌   ▒▓█  ▄    ▒██▀▀█▄  
▒ ▓███▀ ░   ░██▓ ▒██▒    ▓█   ▓██▒   ░▒█░         ▒██▒ ░      ░ ██▒▓░      ░▓█  ▀█▓   ▒▒█████▓    ░██░   ░██████▒   ░▒████▓    ░▒████▒   ░██▓ ▒██▒
░ ░▒ ▒  ░   ░ ▒▓ ░▒▓░    ▒▒   ▓▒█░    ▒ ░         ▒ ░░         ██▒▒▒       ░▒▓███▀▒   ░▒▓▒ ▒ ▒    ░▓     ░ ▒░▓  ░    ▒▒▓  ▒    ░░ ▒░ ░   ░ ▒▓ ░▒▓░
  ░  ▒        ░▒ ░ ▒░     ▒   ▒▒ ░    ░             ░        ▓██ ░▒░       ▒░▒   ░    ░░▒░ ░ ░     ▒ ░   ░ ░ ▒  ░    ░ ▒  ▒     ░ ░  ░     ░▒ ░ ▒░
░             ░░   ░      ░   ▒       ░ ░         ░          ▒ ▒ ░░         ░    ░     ░░░ ░ ░     ▒ ░     ░ ░       ░ ░  ░       ░        ░░   ░ 
░ ░            ░              ░  ░                           ░ ░            ░            ░         ░         ░  ░      ░          ░  ░      ░      v.1.0.0
░                                                            ░ ░                 ░                                   ░                            
";



        private static readonly string AppInfo = "Crafty Builder is your guide to streamlined application development. This console app focuses on providing clear instructions and valuable resources for installing languages and frameworks. Whether you're venturing into React, Angular, or Dotnet, Crafty Builder ensures a user-friendly experience, offering precise instructions and curated resources to simplify your development process. Stay in control of your projects with Crafty Builder – your go-to tool for straightforward instructions and helpful resources";

        public static void GetAppImage()
        {
            Console.WriteLine(AppImage);
        }

        public static void GetAppInfo()
        {
            Console.WriteLine(AppImage);
            Console.WriteLine(AppInfo);
        }



    }
}