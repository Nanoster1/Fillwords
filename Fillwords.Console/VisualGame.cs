namespace Fillwords.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using FillWords.Logic;
    public static class VisualGame
    {
        static Word SelectedWord = new Word();
        static int x = 0;
        static int y = 0;
        static List<string> usedWords = new List<string>();
        static Files files = new Files();
        public static string Greetings()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string[] welcome = {"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   █▄█ █▀█ █ █ █▀█   █▄ █ ▄▀█ █▀▄▀█ █▀▀",
                                "██▄ █ ▀█  █  ██▄ █▀▄    █  █▄█ █▄█ █▀▄   █ ▀█ █▀█ █ ▀ █ ██▄"};
            Drawer.WriteMenu(welcome, 19);
            string name = Console.ReadLine();
            CheckName(ref name);
            Console.Clear();
            Drawer.DrawLoading();
            return name;
        }

        static void CheckName(ref string name)
        {
            while (files.CheckNameInSaves(name))
            {
                string error = "The name already exists";
                Console.Write(error + "\r");
                Thread.Sleep(1200);
                Console.Write(new string(' ', error.Length));
                Console.SetCursorPosition(Console.CursorLeft - error.Length, Console.CursorTop - 1);
                Console.Write(new string(' ', name.Length) + "\r");
                name = Console.ReadLine();
            }
        }
        public static void StartGame(NewGame game)
        {
            Drawer.DeleteLoading();
            while (true)
            {
                if (GameTable.Words.Count == 0)
                {
                    Drawer.DrawLoading();
                    game.GetNextLvl();
                    Drawer.DeleteLoading();
                }
                usedWords = GameTable.UsedWords;
                Console.SetCursorPosition(0, 0);
                SelectCursor(game);
                SelectWord(game);
            }
        }
        public static void WriteTable(NewGame game)
        {
            Console.BackgroundColor = MenuOptionsData.TableColor;
            for (int y1 = 0; y1 < game.Gamer.Table.GetLength(0); y1++)
            {
                for (int x1 = 0; x1 < game.Gamer.Table.GetLength(1); x1++)
                {
                    Console.ForegroundColor = MenuOptionsData.WordColor;
                    if (x1 == x && y1 == y)
                        Console.ForegroundColor = MenuOptionsData.CursorColor;
                    else if (NewGame.CheckLetter(x1, y1, SelectedWord))
                        Console.ForegroundColor = MenuOptionsData.TrueWordColor;
                    else if (NewGame.CheckInWords(x1, y1, game))
                        Console.ForegroundColor = MenuOptionsData.TrueWordColor;
                    Console.Write(game.Gamer.Table[y1, x1]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < GameTable.UsedWords.Count; i++)
            {
                Console.WriteLine(GameTable.UsedWords[i]);
            }
            Console.SetCursorPosition(20, 10);
            Console.Write($"Scores: {game.Gamer.Scores}");
        }
        public static void SelectWord(NewGame game)
        {
            SelectedWord = new Word();
            SelectedWord.CoordsX.Add(x);
            SelectedWord.CoordsY.Add(y);
            ConsoleKeyInfo Key = Console.ReadKey();
            while (Key.Key != ConsoleKey.Enter)
            {
                if (Key.Key == ConsoleKey.W || Key.Key == ConsoleKey.UpArrow)
                {
                    if (y != 0)
                    {
                        y--;
                        SelectedWord.CoordsX.Add(x);
                        SelectedWord.CoordsY.Add(y);
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                {
                    if (y != MenuOptionsData.TableHeight - 1)
                    {
                        y++;
                        SelectedWord.CoordsX.Add(x);
                        SelectedWord.CoordsY.Add(y);
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.A || Key.Key == ConsoleKey.LeftArrow)
                {
                    if (x != 0)
                    {
                        x--;
                        SelectedWord.CoordsX.Add(x);
                        SelectedWord.CoordsY.Add(y);
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.D || Key.Key == ConsoleKey.RightArrow)
                {
                    if (x != MenuOptionsData.TableWidth - 1)
                    {
                        x++;
                        SelectedWord.CoordsX.Add(x);
                        SelectedWord.CoordsY.Add(y);
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.Escape)
                {
                    SelectedWord.CoordsX.Clear();
                    SelectedWord.CoordsY.Clear();
                    StartGame(game);
                }
                Key = Console.ReadKey();
            }
            if (game.CheckWord(SelectedWord))
            {
                SelectedWord.CoordsX.Clear();
                SelectedWord.CoordsY.Clear();
                Console.WriteLine("Верно   ");
            }
            else
            {
                SelectedWord.CoordsX.Clear();
                SelectedWord.CoordsY.Clear();
                Console.WriteLine("Не верно");
            }
        }
        public static void SelectCursor(NewGame game)
        {
            WriteTable(game);
            ConsoleKeyInfo Key = Console.ReadKey();
            while (Key.Key != ConsoleKey.Enter)
            {
                if (Key.Key == ConsoleKey.W || Key.Key == ConsoleKey.UpArrow)
                {
                    if (y != 0)
                    {
                        y--;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                {
                    if (y != MenuOptionsData.TableHeight - 1)
                    {
                        y++;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.A || Key.Key == ConsoleKey.LeftArrow)
                {
                    if (x != 0)
                    {
                        x--;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.D || Key.Key == ConsoleKey.RightArrow)
                {
                    if (x != MenuOptionsData.TableWidth - 1)
                    {
                        x++;
                        Console.SetCursorPosition(0, 0);
                        WriteTable(game);
                    }
                }
                else if (Key.Key == ConsoleKey.Escape)
                {
                    files.WriteRecord(game.Gamer);
                    files.CreateSave(game.Gamer);
                    Environment.Exit(0);
                }
                Key = Console.ReadKey();
            }
        }
    }
}
