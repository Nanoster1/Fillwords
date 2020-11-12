using System;
using System.Drawing;
using System.IO;


namespace Fillwords
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(150, 40);
            Title.DrawTitle();
            Title.DrawMenu(ConsoleColor.Black);
        }
    }
    public class Title
    {
        static void SwapColor(ConsoleColor f)
        {
            Console.ForegroundColor = f;
        }
        public static void DrawTitle()
        {
            string[] name = {"██████████  ████  ████       ████      ████   ████   ████   ██████████   ███████████  ███████████    █████",
                            "██████████  ████  ████       ████      ████   ████   ████  ████████████  ████████████ ████   █████  █████  ",
                            "██████      ████  ████       ████      ████   ████   ████ ████      ████ ████    ████ ████     ████  ████  ",
                            "██████████  ████  ████       ████       ████ ██████ ████  ████      ████ ███████████  ████     ████   █████",
                            "██████████  ████  ████       ████        ██████████████   █████    █████ ██████████   ████    █████    ████",
                            "██████      ████  █████████  ██████████   █████  █████     ████████████  █████  ████  ████████████  ███████",
                            "██████      ████  █████████  ██████████    ████  ████        ████████    █████   ████ ██████████     ████  "};
            for (int i = 0; i < name.Length; i++)
            {

                SwapColor((ConsoleColor)(i + 3));
                Console.SetCursorPosition(Console.WindowWidth/2 - name[3].Length/2, i);
                Console.WriteLine(name[i]);
            }
        }
        public static void DrawMenu(ConsoleColor cc)
        {
            SwapColor(ConsoleColor.Green);
            string[] ng =  {"█▄ █ █▀▀ █ █ █  █▀▀ ▄▀█ █▀▄▀█ █▀▀",
                            "█ ▀█ ██▄ ▀▄▀▄▀  █▄█ █▀█ █ ▀ █ ██▄",};
            string[] res = {"█▀█ █▀▀ █▀ █ █ █▀▄▀█ █▀▀",
                            "█▀▄ ██▄ ▄█ █▄█ █ ▀ █ ██▄",};
            string[] rat = {"█▀█ ▄▀█ ▀█▀ █ █▄ █ █▀▀",
                            "█▀▄ █▀█  █  █ █ ▀█ █▄█",};
            string[] ex =  {"█▀▀ ▀▄▀ █ ▀█▀",
                            "██▄ █ █ █  █",};
            WriteMenu(ng, 15);
            WriteMenu(res, 19);
            WriteMenu(rat, 23);
            WriteMenu(ex, 27);
            string[] ram = { "┌" + new string('─', ng[1].Length) + "┐", "" ,"" ,"└" + new string('─', ng[1].Length) + "┘"};
            SwapColor(cc);
            WriteMenu(ram, 14);
            WriteMenu(ram, 18);
            WriteMenu(ram, 22);
            WriteMenu(ram, 26);
        }
        static void WriteMenu(string[] ng, int x)
        {
            for (int i = 0; i < ng.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - ng[0].Length / 2, i + x);
                Console.WriteLine(ng[i]);
            }
        }
    }
}

