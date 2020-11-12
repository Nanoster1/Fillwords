using System;
using System.Collections.Generic;
using System.Text;

namespace Fillwords
{
    public class MenuSelect
    {
        public static void SelectMenu()
        {
            ConsoleKeyInfo Key = Console.ReadKey();
            int i = 1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Key = Console.ReadKey();
                if (Key.Key == ConsoleKey.W || Key.Key == ConsoleKey.UpArrow)
                {
                    if (i == 2)
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
                    else
                        continue;
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
                    else
                        continue;
                }
            }
            while (Key.Key != ConsoleKey.Enter);
        }
    }
}
