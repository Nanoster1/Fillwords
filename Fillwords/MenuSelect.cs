using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Fillwords
{
    public class MenuSelect
    {
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
                            Title.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red);
                            i = 4;
                        }
                        else if (i == 2)
                        {
                            Title.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
                            i--;
                        }
                        else if (i == 3)
                        {
                            Title.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green);
                            i--;
                        }
                        else if (i == 4)
                        {
                            Title.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green);
                            i--;
                        }
                    }
                    else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                    {
                        if (i == 1)
                        {
                            Title.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green);
                            i++;
                        }
                        else if (i == 2)
                        {
                            Title.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green);
                            i++;
                        }
                        else if (i == 3)
                        {
                            Title.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red);
                            i++;
                        }
                        else if (i == 4)
                        {
                            Title.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
                            i = 1;
                        }
                }
                    Key = Console.ReadKey();
                }
            return i;
        }
        public static void UseMenu()
        {
            int menuNum = MenuSelect.SelectMenu();
            switch (menuNum)
            {
                case 1:
                    MenuNewGame.Head();
                    break;
                case 2:
                    MenuResume.Head();
                    break;
                case 3:
                    MenuRecords.Head();
                    break;
                case 4:
                    MenuOptions.Head();
                    break;
            }
        }
    }
}
