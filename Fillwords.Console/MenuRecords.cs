namespace Fillwords.Console
{
    using System;
    static class MenuRecords
    {
        public static void DrawRecords()
        {
            Drawer.DrawRamRecords();
            Drawer.DrawTop();
            Drawer.DrawFire();
            EnterEscape();
        }
        static void EnterEscape()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                if (char.TryParse(key.Key.ToString(), out _))
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Menu.UseMenu();
        }
    }
}