﻿namespace Fillwords.Console
{
    using System;
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(150, 40);
            Menu.UseMenu();
        }
    }
}