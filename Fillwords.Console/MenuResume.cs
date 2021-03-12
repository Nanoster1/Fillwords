namespace Fillwords.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using FillWords.Logic;
    public class MenuResume
    {
        public static void ContinueGame()
        {
            Drawer.DrawContinueMenu();
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            string name = EnterName();
            while (!new FileWorker().CheckNameInSaves(name))
            {
                Console.Write("Save does not exist\r");
                Thread.Sleep(1200);
                Console.Write(new string(' ', 19) + "\r");
                Console.SetCursorPosition(x, y);
                Console.Write(new string(' ', name.Length) + "\r");
                Console.SetCursorPosition(x, y);
                name = EnterName();
            }
            Console.Clear();
            VisualGame.StartGame(GameResume.GetGame(name));
        }
        static string EnterName()
        {
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop - 1);
                Console.Write(new string(' ', name.Length) + "\r");
                name = Console.ReadLine();
            }
            return name.Replace(" ", "");
        }
    }
}
