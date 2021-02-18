namespace Fillwords.Console
{
    using System;
    using FillWords.Logic;
    public static class Drawer
    {
        public static void DrawTitle()
        {
            string[] gameName = {"██████████  ████  ████       ████      ████   ████   ████   ██████████   ███████████  ███████████    █████",
                                 "██████████  ████  ████       ████      ████   ████   ████  ████████████  ████████████ ████   █████  █████  ",
                                 "██████      ████  ████       ████      ████   ████   ████ ████      ████ ████    ████ ████     ████  ████  ",
                                 "██████████  ████  ████       ████       ████ ██████ ████  ████      ████ ███████████  ████     ████   █████",
                                 "██████████  ████  ████       ████        ██████████████   █████    █████ ██████████   ████    █████    ████",
                                 "██████      ████  █████████  ██████████   █████  █████     ████████████  █████  ████  ████████████  ███████",
                                 "██████      ████  █████████  ██████████    ████  ████        ████████    █████   ████ ██████████     ████  "};
            for (int i = 0; i < gameName.Length; i++)
            {

                SwapColor((ConsoleColor)(i + 3));
                Console.SetCursorPosition(Console.WindowWidth / 2 - gameName[3].Length / 2, i);
                Console.WriteLine(gameName[i]);
            }
        }
        public static void SwapColor(ConsoleColor f)
        {
            Console.ForegroundColor = f;
        }
        public static void DrawMenu(ConsoleColor ccRam1, ConsoleColor ccRam2, ConsoleColor ccRam3, ConsoleColor ccRam4, ConsoleColor menuColor1, ConsoleColor menuColor2, ConsoleColor menuColor3, ConsoleColor menuColor4, string[] menu1, string[] menu2, string[] menu3, string[] menu4)
        {
            SwapColor(ConsoleColor.Green);
            SwapColor(menuColor1);
            WriteMenu(menu1, 15);
            SwapColor(menuColor2);
            WriteMenu(menu2, 19);
            SwapColor(menuColor3);
            WriteMenu(menu3, 23);
            SwapColor(menuColor4);
            WriteMenu(menu4, 27);
            string[] ram = { "┌" + new string('─', menu1[1].Length) + "┐", "", "", "└" + new string('─', menu1[1].Length) + "┘" };
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
        public static void DrawTop()
        {
            for (int i = 0; i < Files.Records.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 41, 6 + i);
                Console.Write(Files.Records[i]);
            }
        }
        public static void DrawRamRecords()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine('┌' + new string('─', Console.WindowWidth - 2) + '┐');
            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                Console.WriteLine('│' + new string(' ', Console.WindowWidth - 2) + '│');
            }
            Console.Write('└' + new string('─', Console.WindowWidth - 2) + '┘');
            string[] records = {"▐█▀▀▄ ▐█▀▀ ▐█▀█ ▐█▀▀█▌ ▐█▀▀▄ ▐█▀█▄ ▄█▀▀█",
                                "▐█ ▐█ ▐█▀▀ ▐█   ▐█▄ █▌ ▐█ ▐█ ▐█▌▐█ ▀▀█▄▄",
                                "▐█▀▄▄ ▐█▄▄ ▐█▄█ ▐██▄█▌ ▐█▀▄▄ ▐█▄█▀ █▄▄█▀"};
            SwapColor(ConsoleColor.Red);
            for (int i = 0; i < records.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 41, 1 + i);
                Console.WriteLine(records[i]);
            }
        }
        public static void DrawFire()
        {
            string[] fire = {"                     ███",
                             "                   █████",
                             "                  ██████",
                             "                ███████",
                             "               ████████",
                             "               ████████",
                             "              ██████████",
                             "              ██████████",
                             "              ███████████             ███",
                             "              ████████████           ████",
                             "       █      █████████████        ██████",
                             "       ████    █████████████      ███████",
                             "       █████   ██████████████    ████████",
                             "       ██████   ███████████████  ████████",
                             "       ███████  ██████████████████████████",
                             "       ███████  ██████████████████████████",
                             "      ████████  ███████████████████████████",
                             "     █████████ ██████████  █████████████████",
                             "   ██████████████████████   █████████████████",
                             "  ███████████████████████   ██████████████████",
                             "  ███████████████████████    █████████████████",
                             " ████████████████ ██████    ███████████████████",
                             " ████████████████  ███      ███ ███████████████",
                             " ███████████████   █        ██  ███████████████",
                             " ██████████████             ██  ██████████████",
                             " ██████████████             █   ███████████",
                             "  ████████████                    █████████",
                             "    ██████████                    ████████",
                             "      ████████                    ██████",
                             "         ██████                  ████",
                             "             █████              ████"};
            SwapColor(ConsoleColor.DarkYellow);
            for (int i = 0; i < fire.Length; i++)
            {
                Console.SetCursorPosition(1, Console.WindowHeight - fire.Length + i - 1);
                Console.WriteLine(fire[i]);
            }
        }
        public static void DrawLoading()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string[] welcome = {"█   █▀█ ▄▀█ █▀▄ █ █▄ █ █▀▀",
                                "█▄▄ █▄█ █▀█ █▄▀ █ █ ▀█ █▄█"};
            WriteMenu(welcome, 19);
        }
        public static void DeleteLoading()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string[] welcome = {"                          ",
                                "                          "};
            WriteMenu(welcome, 19);
        }
        public static void DrawContinueMenu()
        {
            Console.Clear();
            string[] text  = { " ██████  █████  ██    ██ ███████  ██████" ,
                               "██      ██   ██ ██    ██ ██      ██     " ,
                               " █████  ███████  ██  ██  █████    █████ " ,
                               "     ██ ██   ██   ████   ██           ██" ,
                               "██████  ██   ██    ██    ███████ ██████ " };
            Console.ForegroundColor = ConsoleColor.Red;
            WriteMenu(text, 0);
            Console.SetCursorPosition(0, 7);
            string[] saves = Files.Saves;
            int k = 10;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < saves.Length; i++)
            {
                Console.WriteLine(saves[i].Split('\\')[^1].Split('.')[0]);
                if (i != 0 && i % 8 == 0)
                {
                    Console.SetCursorPosition(k, 7);
                    k += 10;
                }
            }
            Console.SetCursorPosition(Console.WindowWidth/2 - text[0].Length / 3, 20);
            Console.Write("Enter your nickname: ");
        }
    }
}
