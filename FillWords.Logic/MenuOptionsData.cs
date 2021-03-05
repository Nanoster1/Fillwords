using System;

namespace FillWords.Logic
{
    public static class MenuOptionsData
    {
        public static ConsoleColor TableColor { get; set; } = ConsoleColor.Black;
        public static ConsoleColor CursorColor { get; set; } = ConsoleColor.Red;
        public static ConsoleColor WordColor { get; set; } = ConsoleColor.White;
        public static ConsoleColor TrueWordColor { get; set; } = ConsoleColor.Green;
        public static int TableHeight { get; set; } = 5;
        public static int TableWidth { get; set; } = 5;
    }
}