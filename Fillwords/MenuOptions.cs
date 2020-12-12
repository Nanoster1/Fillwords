using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Fillwords
{
    class MenuOptions
    {
        public static ConsoleColor colorTable = ConsoleColor.Black;
        public static ConsoleColor cursorColor = ConsoleColor.Red;
        public static ConsoleColor wordColor = ConsoleColor.White;
        public static ConsoleColor trueWordColor = ConsoleColor.Green;
        public static int tableHeight = 5;
        public static int tableWidth = 5;
        public static void Head()
        {
            Console.Clear();
            DrawTitle();
            DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
            MenuSelectOpt.UseMenu();

        }
        public static void DrawTitle()
        {
            string[] name ={"█▀█ █▀█ ▀█▀ █ █▀█ █▄ █ █▀",
                            "█▄█ █▀▀  █  █ █▄█ █ ▀█ ▄█"};
            Title.WriteMenu(name, 4);
        }
        public static void DrawMenu(ConsoleColor ccRam1, ConsoleColor ccRam2, ConsoleColor ccRam3, ConsoleColor ccRam4, ConsoleColor ccNg, ConsoleColor ccRes, ConsoleColor ccRat, ConsoleColor ccEx)
        {
            SwapColor(ConsoleColor.Green);
            string[] ng =  {"█▀▀ █ █▀▀ █   █▀▄   █▀ █ ▀█ █▀▀",
                            "█▀  █ ██▄ █▄▄ █▄▀   ▄█ █ █▄ ██▄"};
            string[] res = {"█▀▀ █ █ █▀█ █▀ █▀█ █▀█   █▀▀ █▀█ █   █▀█ █▀█",
                            "█▄▄ █▄█ █▀▄ ▄█ █▄█ █▀▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
            string[] rat = {"█ █ █ █▀█ █▀█ █▀▄ █▀   █▀▀ █▀█ █   █▀█ █▀█",
                            "▀▄▀▄▀ █▄█ █▀▄ █▄▀ ▄█   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
            string[] opt = {"█▀▀ █ █ █▀█ █ █▀▀ █▀▀   █▀▀ █▀█ █   █▀█ █▀█",
                            "█▄▄ █▀█ █▄█ █ █▄▄ ██▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
            Title.SwapColor(ccNg);
            Title.WriteMenu(ng, 15);
            Title.SwapColor(ccRes);
            Title.WriteMenu(res, 19);
            Title.SwapColor(ccRat);
            Title.WriteMenu(rat, 23);
            Title.SwapColor(ccEx);
            Title.WriteMenu(opt, 27);
            string[] ram = { "┌" + new string('─', res[0].Length) + "┐", "", "", "└" + new string('─', res[0].Length) + "┘" };
            Title.SwapColor(ccRam1);
            Title.WriteMenu(ram, 14);
            Title.SwapColor(ccRam2);
            Title.WriteMenu(ram, 18);
            Title.SwapColor(ccRam3);
            Title.WriteMenu(ram, 22);
            Title.SwapColor(ccRam4);
            Title.WriteMenu(ram, 26);
        }
        static void SwapColor(ConsoleColor f)
        {
            Console.ForegroundColor = f;
        }
    }
    public class MenuSelectOpt
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
                        MenuOptions.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red);
                        i = 4;
                    }
                    else if (i == 2)
                    {
                        MenuOptions.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
                        i--;
                    }
                    else if (i == 3)
                    {
                        MenuOptions.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green);
                        i--;
                    }
                    else if (i == 4)
                    {
                        MenuOptions.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green);
                        i--;
                    }
                }
                else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                {
                    if (i == 1)
                    {
                        MenuOptions.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green);
                        i++;
                    }
                    else if (i == 2)
                    {
                        MenuOptions.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green);
                        i++;
                    }
                    else if (i == 3)
                    {
                        MenuOptions.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red);
                        i++;
                    }
                    else if (i == 4)
                    {
                        MenuOptions.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
                        i = 1;
                    }
                }
                else if (Key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Title.DrawTitle();
                    Title.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green);
                    MenuSelect.UseMenu();
                }
                Key = Console.ReadKey();
            }
            return i;
        }
        public static void UseMenu()
        {
            int menuNum = SelectMenu();
            switch (menuNum)
            {
                case 1:
                    Console.Clear();
                    ChangeSize();
                    break;
                case 2:
                Console.Clear();
                ChangeCursor();
                    break;
                case 3:
                    Console.Clear();
                    ChangeWords();
                    break;
                case 4:
                    Console.Clear();
                    ChangeTrueWords();
                    break;
            }
        }
        static void ChangeSize()
        {
            string[] welcome ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █▀▀ █ █▀▀ █   █▀▄   █ █ █▀▀ █ █▀▀ █ █ ▀█▀",
                               "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   █▀  █ ██▄ █▄▄ █▄▀   █▀█ ██▄ █ █▄█ █▀█  █ "};
            Console.ForegroundColor = ConsoleColor.Green;
            Title.WriteMenu(welcome, 15);
            Console.WriteLine();
            MenuOptions.tableHeight = int.Parse(Console.ReadLine()); //Мб проверка на дурака
            Console.Clear();
            string[] welcome2 ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █▀▀ █ █▀▀ █   █▀▄   █ █ █ █ █▀▄ ▀█▀ █ █",
                                "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   █▀  █ ██▄ █▄▄ █▄▀   ▀▄▀▄▀ █ █▄▀  █  █▀█"};
            Console.ForegroundColor = ConsoleColor.Green;
            Title.WriteMenu(welcome2, 15);
            MenuOptions.tableWidth = int.Parse(Console.ReadLine()); //Мб проверка на дурака
            Console.Clear();
            MenuOptions.Head();
        }
        static void ChangeCursor()
        {
            string[] welcome ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █▀▀ █▀█ █   █▀█ █▀█   █▀█ █▀▀   ▀█▀ █ █ █▀▀   █▀▀ █ █ █▀█ █▀ █▀█ █▀█",
                               "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄   █▄█ █▀     █  █▀█ ██▄   █▄▄ █▄█ █▀▄ ▄█ █▄█ █▀▄ "};
            Console.ForegroundColor = ConsoleColor.Green;
            Title.WriteMenu(welcome, 15);
            Console.WriteLine();
            int i = ChangeColor();
            switch (i)
            {
                case 1:
                    MenuOptions.cursorColor = (ConsoleColor)(1);
                    break;
                case 2:
                    MenuOptions.cursorColor = (ConsoleColor)(2);
                    break;                    
                case 3:                       
                    MenuOptions.cursorColor = (ConsoleColor)(3);
                    break;                   
                case 4:                      
                    MenuOptions.cursorColor = (ConsoleColor)(4);
                    break;                    
                case 5:                       
                    MenuOptions.cursorColor = (ConsoleColor)(5);
                    break;                    
                case 6:                       
                    MenuOptions.cursorColor = (ConsoleColor)(6);
                    break;                    
                case 7:                       
                    MenuOptions.cursorColor = (ConsoleColor)(7);
                    break;                    
                case 8:                       
                    MenuOptions.cursorColor = (ConsoleColor)(8);
                    break;                    
                case 9:                       
                    MenuOptions.cursorColor = (ConsoleColor)(9);
                    break;                    
                case 10:                      
                    MenuOptions.cursorColor = (ConsoleColor)(10);
                    break;
            }
            Console.Clear();
            MenuOptions.Head();
        }
        static void ChangeWords()
        {
            string[] welcome ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █ █ █ █▀█ █▀█ █▀▄   █▀▀ █▀█ █   █▀█ █▀█",
                               "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   ▀▄▀▄▀ █▄█ █▀▄ █▄▀   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
            Console.ForegroundColor = ConsoleColor.Green;
            Title.WriteMenu(welcome, 15);
            Console.WriteLine();
            int i = ChangeColor();
            switch (i)
            {
                case 1:
                    MenuOptions.wordColor = (ConsoleColor)(1);
                    break;
                case 2:
                    MenuOptions.wordColor = (ConsoleColor)(2);
                    break;
                case 3:
                    MenuOptions.wordColor = (ConsoleColor)(3);
                    break;
                case 4:
                    MenuOptions.wordColor = (ConsoleColor)(4);
                    break;
                case 5:
                    MenuOptions.wordColor = (ConsoleColor)(5);
                    break;
                case 6:
                    MenuOptions.wordColor = (ConsoleColor)(6);
                    break;
                case 7:
                    MenuOptions.wordColor = (ConsoleColor)(7);
                    break;
                case 8:
                    MenuOptions.wordColor = (ConsoleColor)(8);
                    break;
                case 9:
                    MenuOptions.wordColor = (ConsoleColor)(9);
                    break;
                case 10:
                    MenuOptions.wordColor = (ConsoleColor)(10);
                    break;
            }
            Console.Clear();
            MenuOptions.Head();
        }
        static void ChangeTrueWords()
        {
            string[] welcome ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █▀▀ █▀█ █   █▀█ █▀█   █▀█ █▀▀   ▀█▀ █ █ █▀▀   █▀▀ █▀█ █▀█ █▀█ █▀▀ █▀▀ ▀█▀  █ █ █ █▀█ █▀█ █▀▄ █▀",
                               "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄   █▄█ █▀     █  █▀█ ██▄   █▄▄ █▄█ █▀▄ █▀▄ ██▄ █▄▄  █   ▀▄▀▄▀ █▄█ █▀▄ █▄▀ ▄█"};
            Console.ForegroundColor = ConsoleColor.Green;
            Title.WriteMenu(welcome, 15);
            Console.WriteLine();
            int i = ChangeColor();
            switch (i)
            {
                case 1:
                    MenuOptions.trueWordColor = (ConsoleColor)(1);
                    break;
                case 2:
                    MenuOptions.trueWordColor = (ConsoleColor)(2);
                    break;
                case 3:
                    MenuOptions.trueWordColor = (ConsoleColor)(3);
                    break;
                case 4:
                    MenuOptions.trueWordColor = (ConsoleColor)(4);
                    break;
                case 5:
                    MenuOptions.trueWordColor = (ConsoleColor)(5);
                    break;
                case 6:
                    MenuOptions.trueWordColor = (ConsoleColor)(6);
                    break;
                case 7:
                    MenuOptions.trueWordColor = (ConsoleColor)(7);
                    break;
                case 8:
                    MenuOptions.trueWordColor = (ConsoleColor)(8);
                    break;
                case 9:
                    MenuOptions.trueWordColor = (ConsoleColor)(9);
                    break;
                case 10:
                    MenuOptions.trueWordColor = (ConsoleColor)(10);
                    break;
            }
            Console.Clear();
            MenuOptions.Head();
        }
        static int ChangeColor()
        {
            string[] Color1 ={"       █▀▄ ▄▀█ █▀█ █▄▀ █▄▄ █   █ █ █▀▀        ",
                              "       █▄▀ █▀█ █▀▄ █ █ █▄█ █▄▄ █▄█ ██▄        "};
            string[] Color2 ={"     █▀▄ ▄▀█ █▀█ █▄▀ █▀▀ █▀█ █▀▀ █▀▀ █▄ █     ",
                              "     █▄▀ █▀█ █▀▄ █ █ █▄█ █▀▄ ██▄ ██▄ █ ▀█     "};
            string[] Color3 ={"       █▀▄ ▄▀█ █▀█ █▄▀ █▀▀ █▄█ ▄▀█ █▄ █       ",
                              "       █▄▀ █▀█ █▀▄ █ █ █▄▄  █  █▀█ █ ▀█       "};
            string[] Color4 ={"       █▀▄ ▄▀█ █▀█ █▄▀ █▀█ █▀▀ █▀▄            ",
                              "       █▄▀ █▀█ █▀▄ █ █ █▀▄ ██▄ █▄▀            "};
            string[] Color5 ={"█▀▄ ▄▀█ █▀█ █▄▀ █▀▄▀█ ▄▀█ █▀▀ █▀▀ █▄ █ ▀█▀ ▄▀█",
                              "█▄▀ █▀█ █▀▄ █ █ █ ▀ █ █▀█ █▄█ ██▄ █ ▀█  █  █▀█"};
            string[] Color6 ={"  █▀▄ ▄▀█ █▀█ █▄▀ █▄█ █▀▀ █   █   █▀█ █ █ █   ",
                              "  █▄▀ █▀█ █▀▄ █ █  █  ██▄ █▄▄ █▄▄ █▄█ ▀▄▀▄▀   "};
            string[] Color7 ={"               █▀▀ █▀█ ▄▀█ █▄█                ",
                              "               █▄█ █▀▄ █▀█  █                 "};
            string[] Color8 ={"       █▀▄ ▄▀█ █▀█ █▄▀ █▀▀ █▀█ ▄▀█ █▄█        ",
                              "       █▄▀ █▀█ █▀▄ █ █ █▄█ █▀▄ █▀█  █         "};
            string[] Color9 ={"                █▄▄ █   █ █ █▀▀               ",
                              "                █▄█ █▄▄ █▄█ ██▄               "};
            string[] Color10={"             █▀▀ █▀█ █▀▀ █▀▀ █▄ █             ",
                              "             █▄█ █▀▄ ██▄ ██▄ █ ▀█             "};
            Console.ForegroundColor = ConsoleColor.Green;
            Title.WriteMenu(Color1, 19);
            int i = 1;
            ConsoleKeyInfo Key = Console.ReadKey();
            while (Key.Key != ConsoleKey.Enter)
            {
                if (Key.Key == ConsoleKey.A || Key.Key == ConsoleKey.LeftArrow)
                {
                    if (i == 1)
                    {
                        Console.ForegroundColor = (ConsoleColor)(10);
                        Title.WriteMenu(Color10, 19);
                        i = 10;
                    }
                    else if (i == 2)
                    {
                        Console.ForegroundColor = (ConsoleColor)(1);
                        Title.WriteMenu(Color1, 19);
                        i--;
                    }
                    else if (i == 3)
                    {
                        Console.ForegroundColor = (ConsoleColor)(2);
                        Title.WriteMenu(Color2, 19);
                        i--;
                    }
                    else if (i == 4)
                    {
                        Console.ForegroundColor = (ConsoleColor)(3);
                        Title.WriteMenu(Color3, 19);
                        i--;
                    }
                    else if (i == 5)
                    {
                        Console.ForegroundColor = (ConsoleColor)(4);
                        Title.WriteMenu(Color4, 19);
                        i--;
                    }
                    else if (i == 6)
                    {
                        Console.ForegroundColor = (ConsoleColor)(5);
                        Title.WriteMenu(Color5, 19);
                        i--;
                    }
                    else if (i == 7)
                    {
                        Console.ForegroundColor = (ConsoleColor)(6);
                        Title.WriteMenu(Color6, 19);
                        i--;
                    }
                    else if (i == 8)
                    {
                        Console.ForegroundColor = (ConsoleColor)(7);
                        Title.WriteMenu(Color7, 19);
                        i--;
                    }
                    else if (i == 9)
                    {
                        Console.ForegroundColor = (ConsoleColor)(8);
                        Title.WriteMenu(Color8, 19);
                        i--;
                    }
                    else if (i == 10)
                    {
                        Console.ForegroundColor = (ConsoleColor)(9);
                        Title.WriteMenu(Color9, 19);
                        i--;
                    }
                }
                else if (Key.Key == ConsoleKey.D || Key.Key == ConsoleKey.RightArrow)
                {
                    if (i == 1)
                    {
                        Console.ForegroundColor = (ConsoleColor)(2);
                        Title.WriteMenu(Color2, 19);
                        i = 2;
                    }
                    else if (i == 2)
                    {
                        Console.ForegroundColor = (ConsoleColor)(3);
                        Title.WriteMenu(Color3, 19);
                        i = 3;
                    }
                    else if (i == 3)
                    {
                        Console.ForegroundColor = (ConsoleColor)(4);
                        Title.WriteMenu(Color4, 19);
                        i++;
                    }
                    else if (i == 4)
                    {
                        Console.ForegroundColor = (ConsoleColor)(5);
                        Title.WriteMenu(Color5, 19);
                        i++;
                    }
                    else if (i == 5)
                    {
                        Console.ForegroundColor = (ConsoleColor)(6);
                        Title.WriteMenu(Color6, 19);
                        i++;
                    }
                    else if (i == 6)
                    {
                        Console.ForegroundColor = (ConsoleColor)(7);
                        Title.WriteMenu(Color7, 19);
                        i++;
                    }
                    else if (i == 7)
                    {
                        Console.ForegroundColor = (ConsoleColor)(8);
                        Title.WriteMenu(Color8, 19);
                        i++;
                    }
                    else if (i == 8)
                    {
                        Console.ForegroundColor = (ConsoleColor)(9);
                        Title.WriteMenu(Color9, 19);
                        i++;
                    }
                    else if (i == 9)
                    {
                        Console.ForegroundColor = (ConsoleColor)(10);
                        Title.WriteMenu(Color10, 19);
                        i++;
                    }
                    else if (i == 10)
                    {
                        Console.ForegroundColor = (ConsoleColor)(1);
                        Title.WriteMenu(Color1, 19);
                        i = 1;
                    }
                }
                Key = Console.ReadKey();
            }
            return i;
        }
    }
}