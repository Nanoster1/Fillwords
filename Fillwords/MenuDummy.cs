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
            if (MenuSelect.SelectMenu() == 1)
                WritePlug("New game");
            else if (MenuSelect.SelectMenu() == 2)
                WritePlug("Resume");
            else if (MenuSelect.SelectMenu() == 3)
                WritePlug("Rating");
            else if (MenuSelect.SelectMenu() == 4)
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
