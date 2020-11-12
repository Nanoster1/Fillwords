using System;
using System.Collections.Generic;
using System.Text;

namespace Fillwords
{
    class MenuNewGame
    {
        public static void Head()
        {
            string name = Greetings();
        }
        static string Greetings()
        {   
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string a = "I welcome You, sir. Tell me your name:";
            Console.SetCursorPosition(Console.WindowWidth / 2 - a.Length / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(a);
            Console.SetCursorPosition(Console.WindowWidth / 2 - a.Length / 2, Console.WindowHeight / 2 + 1);
            string name = Console.ReadLine();
            return name;
        }
    }
}
