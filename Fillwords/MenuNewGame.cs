using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Fillwords
{
    class MenuNewGame
    {
        public static List<string> Coords = new List<string>();
        public static List<string> Coords1 = new List<string>();
        public static int x = 0;
        public static int y = 0;
        public static void Head()
        {
            Greetings();
            Loading();
            GameTable.table = GameTable.CreateTable(MenuOptions.tableHeight, MenuOptions.tableWidth);
            WriteTable(GameTable.table, GameTable.usedWords);
            while (!CheckTable())
            {
                PlayGame();
            }
        }
        static void PlayGame()
        {
            SelectCursor(GameTable.table);
            SelectWord(GameTable.table);
        }
        static bool CheckTable()
        {
            bool c = false;
            for (int i = 0; i < Coords.Count; i++)
            {
                if (GameTable.usedWords.Contains(Coords[i]))
                    c = true;
                else
                    c = false;
            }
            return c;
        }
        static void Greetings()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string[] welcome = {"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   █▄█ █▀█ █ █ █▀█   █▄ █ ▄▀█ █▀▄▀█ █▀▀",
                                "██▄ █ ▀█  █  ██▄ █▀▄    █  █▄█ █▄█ █▀▄   █ ▀█ █▀█ █ ▀ █ ██▄"};
            Title.WriteMenu(welcome, 19);
            string name = Console.ReadLine();
            name = name.Trim();
            File.AppendAllText("\\records.txt", $"\n{name}");
            Console.Clear();
        }
        public static void Loading()
        {
            string[] welcome = {"█   █▀█ ▄▀█ █▀▄ █ █▄ █ █▀▀",
                                "█▄▄ █▄█ █▀█ █▄▀ █ █ ▀█ █▄█"};
            Title.WriteMenu(welcome, 19);
            Console.Clear();
        }
        public static void WriteTable(char[,] table, List<string> usedWords)
        {
            Console.BackgroundColor = MenuOptions.colorTable;
            for (int y1 = 0; y1 < table.GetLength(0); y1++)
            {
                for (int x1 = 0; x1 < table.GetLength(1); x1++)
                {
                    Console.ForegroundColor = MenuOptions.wordColor;
                    if (x1 == x && y1 == y)
                        Console.ForegroundColor = MenuOptions.cursorColor;
                    else if (Coords.Contains(y1.ToString() + x1.ToString()))
                        Console.ForegroundColor = MenuOptions.trueWordColor;
                    else if (Coords1.Contains(y1.ToString() + x1.ToString()))
                        Console.ForegroundColor = MenuOptions.trueWordColor;
                    Console.Write(table[y1, x1]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < usedWords.Count; i++)
            {
                Console.WriteLine(usedWords[i]);
            }
        }
        public static void SelectWord(char[,] table)
        {
            Coords1.Add(x.ToString() + y.ToString());
            string word = "";
            word += table[y, x];
            ConsoleKeyInfo Key = Console.ReadKey();
            while (Key.Key != ConsoleKey.Enter)
            {
                if (Key.Key == ConsoleKey.W || Key.Key == ConsoleKey.UpArrow)
                {
                    if (y != 0)
                    {
                        y--;
                        word += table[y, x];
                        Coords1.Add(y.ToString() + x.ToString());
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                {
                    if (y != MenuOptions.tableHeight - 1)
                    {
                        y++;
                        word += table[y, x];
                        Coords1.Add(y.ToString() + x.ToString());
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                else if (Key.Key == ConsoleKey.A || Key.Key == ConsoleKey.LeftArrow)
                {
                    if (x != 0)
                    {
                        x--;
                        word += table[y, x];
                        Coords1.Add(y.ToString() + x.ToString());
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                else if (Key.Key == ConsoleKey.D || Key.Key == ConsoleKey.RightArrow)
                {
                    if (x != MenuOptions.tableWidth - 1)
                    {
                        x++;
                        word += table[y, x];
                        Coords1.Add(y.ToString() + x.ToString());
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                else if (Key.Key == ConsoleKey.Escape)
                {
                    Coords1.Clear();
                    SelectCursor(GameTable.table);
                }
                Key = Console.ReadKey();
            }
            if (GameTable.usedWords.Contains(word))
            {
                for(int i = 0; i < Coords1.Count; i++)
                {
                    Coords.Add(Coords1[i]);
                }
                Coords1.Clear();
                Console.WriteLine("Верно   ");
            }
            else
            {
                Coords1.Clear();
                Console.WriteLine("Не верно");
            }
        }
        public static void SelectCursor(char[,] table)
        {
            ConsoleKeyInfo Key = Console.ReadKey();
            while (Key.Key != ConsoleKey.Enter)
            {
                if (Key.Key == ConsoleKey.W || Key.Key == ConsoleKey.UpArrow)
                {
                    if (y != 0)
                    {
                        y--;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                {
                    if (y != MenuOptions.tableHeight - 1)
                    {
                        y++;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                else if (Key.Key == ConsoleKey.A || Key.Key == ConsoleKey.LeftArrow)
                {
                    if (x != 0)
                    {
                        x--;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                else if (Key.Key == ConsoleKey.D || Key.Key == ConsoleKey.RightArrow)
                {
                    if (x != MenuOptions.tableWidth - 1)
                    {
                        x++;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(GameTable.table, GameTable.usedWords);
                    }
                }
                Key = Console.ReadKey();
            }
        }
    }
}
