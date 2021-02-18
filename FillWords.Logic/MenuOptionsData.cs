using System;

namespace FillWords.Logic
{
    public static class MenuOptionsData
    {
        public static ConsoleColor TableColor { get; private set; } = ConsoleColor.Black;
        public static ConsoleColor CursorColor { get; private set; } = ConsoleColor.Red;
        public static ConsoleColor WordColor { get; private set; } = ConsoleColor.White;
        public static ConsoleColor TrueWordColor { get; private set; } = ConsoleColor.Green;
        public static int TableHeight { get; private set; } = 5;
        public static int TableWidth { get; private set; } = 5;
        public static void EnterColorTable(ConsoleColor color)
        {
            TableColor = color;
        }
        public static void EnterCursorColor(ConsoleColor color)
        {
            CursorColor = color;
        }
        public static void EnterWordColor(ConsoleColor color)
        {
            WordColor = color;
        }
        public static void EnterTrueWordColor(ConsoleColor color)
        {
            TrueWordColor = color;
        }
        public static void EnterTableHeight(int num)
        {
            TableHeight = num;
        }
        public static void EnterTableWidth(int num)
        {
            TableWidth = num;
        }
    }
}