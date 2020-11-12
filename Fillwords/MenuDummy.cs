using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Fillwords
{
    public class MenuDummy
    {
        public static void IsPlug()
        {
            int menuNum = MenuSelect.SelectMenu();
            if (menuNum == 1)
            {
                MenuNewGame.Head();
                WritePlug("New game");
            }
            else if (menuNum == 2)
                WritePlug("Resume");
            else if (menuNum == 3)
                WritePlug("Rating");
            else if (menuNum == 4)
                WritePlug("Exit");
        }
        static void WritePlug(string b)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = $"There will be one day {b}";
            Console.SetCursorPosition(Console.WindowWidth / 2 - a.Length / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(a);
        }
    }
}
