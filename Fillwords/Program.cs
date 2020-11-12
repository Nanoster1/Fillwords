using System;
using System.Drawing;
using System.IO;


namespace Fillwords
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(150, 40);
            Title.DrawTitle();
            Title.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
            MenuSelect.SelectMenu();
        }
    }

}

