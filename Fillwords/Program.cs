using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;


namespace Fillwords
{
    class Program
    {
        static void Main()
        {
            File.AppendAllText("\\Dictionary.txt", "");
            Console.CursorVisible = false;
            Console.SetWindowSize(150, 40);
            Title.DrawTitle();
            Title.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
            MenuSelect.UseMenu();
        }
    }

}

