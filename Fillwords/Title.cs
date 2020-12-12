using System;
using System.Collections.Generic;
using System.Text;

namespace Fillwords
{
    public class Title
    {
        public static void SwapColor(ConsoleColor f)
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
                Console.SetCursorPosition(Console.WindowWidth / 2 - name[3].Length / 2, i);
                Console.WriteLine(name[i]);
            }
        }
        public static void DrawMenu(ConsoleColor ccRam1, ConsoleColor ccRam2, ConsoleColor ccRam3, ConsoleColor ccRam4, ConsoleColor ccNg, ConsoleColor ccRes, ConsoleColor ccRat, ConsoleColor ccEx)
        {
            SwapColor(ConsoleColor.Green);
            string[] ng =  {"█▄ █ █▀▀ █ █ █  █▀▀ ▄▀█ █▀▄▀█ █▀▀",
                            "█ ▀█ ██▄ ▀▄▀▄▀  █▄█ █▀█ █ ▀ █ ██▄",};
            string[] res = {"█▀█ █▀▀ █▀ █ █ █▀▄▀█ █▀▀",
                            "█▀▄ ██▄ ▄█ █▄█ █ ▀ █ ██▄",};
            string[] rat = {"█▀█ ▄▀█ ▀█▀ █ █▄ █ █▀▀",
                            "█▀▄ █▀█  █  █ █ ▀█ █▄█",};
            string[] opt = {"█▀█ █▀█ ▀█▀ █ █▀█ █▄ █ █▀",
                            "█▄█ █▀▀  █  █ █▄█ █ ▀█ ▄█",};              
            SwapColor(ccNg);
            WriteMenu(ng, 15);
            SwapColor(ccRes);
            WriteMenu(res, 19);
            SwapColor(ccRat);
            WriteMenu(rat, 23);
            SwapColor(ccEx);
            WriteMenu(opt, 27);
            string[] ram = { "┌" + new string('─', ng[1].Length) + "┐", "", "", "└" + new string('─', ng[1].Length) + "┘" };
            SwapColor(ccRam1);
            WriteMenu(ram, 14);
            SwapColor(ccRam2);
            WriteMenu(ram, 18);
            SwapColor(ccRam3);
            WriteMenu(ram, 22);
            SwapColor(ccRam4);
            WriteMenu(ram, 26);
        }
        public static void WriteMenu(string[] ng, int y)
        {
            for (int i = 0; i < ng.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - ng[0].Length / 2, i + y);
                Console.WriteLine(ng[i]);
            }
        }
    }
}
