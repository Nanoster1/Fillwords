namespace Fillwords.Console
{
    using System;
    using FillWords.Logic;
    static class Menu
    {
        static readonly string[] menu1 = {"█▄ █ █▀▀ █ █ █  █▀▀ ▄▀█ █▀▄▀█ █▀▀",
                                          "█ ▀█ ██▄ ▀▄▀▄▀  █▄█ █▀█ █ ▀ █ ██▄",};
        static readonly string[] menu2 = {"█▀█ █▀▀ █▀ █ █ █▀▄▀█ █▀▀",
                                          "█▀▄ ██▄ ▄█ █▄█ █ ▀ █ ██▄",};
        static readonly string[] menu3 = {"█▀█ ▄▀█ ▀█▀ █ █▄ █ █▀▀",
                                          "█▀▄ █▀█  █  █ █ ▀█ █▄█",};
        static readonly string[] menu4 = {"█▀█ █▀█ ▀█▀ █ █▀█ █▄ █ █▀",
                                          "█▄█ █▀▀  █  █ █▄█ █ ▀█ ▄█",};
        public static void UseMenu()
        {
            Drawer.DrawTitle();
            Drawer.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
            int menuNum = SelectMenu();
            switch (menuNum)
            {
                case 1:
                    VisualGame.StartGame(new NewGame(new GamerInfo(VisualGame.Greetings(), 0, GameTable.CreateTable())));
                    break;
                case 2:
                    MenuResume.ContinueGame();
                    break;
                case 3:
                    MenuRecords.DrawRecords();
                    break;
                case 4:
                    MenuSelectOpt.Head();
                    break;
            }
        }

        public static int SelectMenu()
        {
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleKeyInfo Key = Console.ReadKey();
            while (Key.Key != ConsoleKey.Enter)
            {
                if (Key.Key == ConsoleKey.W || Key.Key == ConsoleKey.UpArrow)
                {
                    if (i == 1)
                    {
                        Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, menu1, menu2, menu3, menu4);
                        i = 4;
                    }
                    else if (i == 2)
                    {
                        Drawer.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                        i--;
                    }
                    else if (i == 3)
                    {
                        Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                        i--;
                    }
                    else if (i == 4)
                    {
                        Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                        i--;
                    }
                }
                else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                {
                    if (i == 1)
                    {
                        Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                        i++;
                    }
                    else if (i == 2)
                    {
                        Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                        i++;
                    }
                    else if (i == 3)
                    {
                        Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, menu1, menu2, menu3, menu4);
                        i++;
                    }
                    else if (i == 4)
                    {
                        Drawer.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                        i = 1;
                    }
                }
                Key = Console.ReadKey();
                if (char.TryParse(Key.Key.ToString(), out _))
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
            }
            return i;
        }
    }
}
