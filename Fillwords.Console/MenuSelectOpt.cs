namespace Fillwords.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FillWords.Logic;
    public static class MenuSelectOpt
        {
            readonly static string[] menu1 =  {"       █▀▀ █ █▀▀ █   █▀▄   █▀ █ ▀█ █▀▀       ",
                                           "       █▀  █ ██▄ █▄▄ █▄▀   ▄█ █ █▄ ██▄       "};
            readonly static string[] menu2 = {"█▀▀ █ █ █▀█ █▀ █▀█ █▀█   █▀▀ █▀█ █   █▀█ █▀█",
                                          "█▄▄ █▄█ █▀▄ ▄█ █▄█ █▀▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
            readonly static string[] menu3 = {"█ █ █ █▀█ █▀█ █▀▄ █▀   █▀▀ █▀█ █   █▀█ █▀█",
                                          "▀▄▀▄▀ █▄█ █▀▄ █▄▀ ▄█   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
            readonly static string[] menu4 = {"█▀▀ █ █ █▀█ █ █▀▀ █▀▀   █▀▀ █▀█ █   █▀█ █▀█",
                                          "█▄▄ █▀█ █▄█ █ █▄▄ ██▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
            public static void Head()
            {
                Console.Clear();
                DrawTitle();
                Drawer.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                UseMenu();
            }
            public static void DrawTitle()
            {
                string[] name ={"█▀█ █▀█ ▀█▀ █ █▀█ █▄ █ █▀",
                                "█▄█ █▀▀  █  █ █▄█ █ ▀█ ▄█"};
                Drawer.WriteMenu(name, 4);
            }
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
                            Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, menu1, menu2, menu3, menu4);
                            i = 4;
                        }
                        else if (i == 2)
                        {
                            Drawer.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                            i--;
                        }
                        else if (i == 3)
                        {
                            Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                            i--;
                        }
                        else if (i == 4)
                        {
                            Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                            i--;
                        }
                    }
                    else if (Key.Key == ConsoleKey.S || Key.Key == ConsoleKey.DownArrow)
                    {
                        if (i == 1)
                        {
                            Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                            i++;
                        }
                        else if (i == 2)
                        {
                            Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                            i++;
                        }
                        else if (i == 3)
                        {
                            Drawer.DrawMenu(ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, menu1, menu2, menu3, menu4);
                            i++;
                        }
                        else if (i == 4)
                        {
                            Drawer.DrawMenu(ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Green, menu1, menu2, menu3, menu4);
                            i = 1;
                        }
                    }
                    else if (Key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Menu.UseMenu();
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
                Drawer.WriteMenu(welcome, 15);
                Console.WriteLine();
                MenuOptionsData.TableHeight = int.Parse(Console.ReadLine()); //Мб проверка на дурака
                Console.Clear();
                string[] welcome2 ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █▀▀ █ █▀▀ █   █▀▄   █ █ █ █ █▀▄ ▀█▀ █ █",
                                    "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   █▀  █ ██▄ █▄▄ █▄▀   ▀▄▀▄▀ █ █▄▀  █  █▀█"};
                Console.ForegroundColor = ConsoleColor.Green;
                Drawer.WriteMenu(welcome2, 15);
                MenuOptionsData.TableWidth = int.Parse(Console.ReadLine()); //Мб проверка на дурака
                Console.Clear();
                Head();
            }
            static void ChangeCursor()
            {
                string[] welcome ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █▀▀ █▀█ █   █▀█ █▀█   █▀█ █▀▀   ▀█▀ █ █ █▀▀   █▀▀ █ █ █▀█ █▀ █▀█ █▀█",
                                   "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄   █▄█ █▀     █  █▀█ ██▄   █▄▄ █▄█ █▀▄ ▄█ █▄█ █▀▄ "};
                Console.ForegroundColor = ConsoleColor.Green;
                Drawer.WriteMenu(welcome, 15);
                Console.WriteLine();
                int i = ChangeColor();
                switch (i)
                {
                    case 1:
                        MenuOptionsData.CursorColor = 1;
                        break;
                    case 2:
                        MenuOptionsData.CursorColor = 2;
                        break;
                    case 3:
                        MenuOptionsData.CursorColor = 3;
                        break;                      
                    case 4:                         
                        MenuOptionsData.CursorColor = 4;
                        break;                       
                    case 5:                          
                        MenuOptionsData.CursorColor = 5;
                        break;                      
                    case 6:                         
                        MenuOptionsData.CursorColor = 6;
                        break;                      
                    case 7:                         
                        MenuOptionsData.CursorColor = 7;
                        break;                      
                    case 8:                         
                        MenuOptionsData.CursorColor = 8;
                        break;                      
                    case 9:                         
                        MenuOptionsData.CursorColor = 9;
                        break;                     
                    case 10:                       
                        MenuOptionsData.CursorColor = 10;
                        break;
                }
                Console.Clear();
                Head();
            }
            static void ChangeWords()
            {
                string[] welcome ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █ █ █ █▀█ █▀█ █▀▄   █▀▀ █▀█ █   █▀█ █▀█",
                                   "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   ▀▄▀▄▀ █▄█ █▀▄ █▄▀   █▄▄ █▄█ █▄▄ █▄█ █▀▄"};
                Console.ForegroundColor = ConsoleColor.Green;
                Drawer.WriteMenu(welcome, 15);
                Console.WriteLine();
                int i = ChangeColor();
                switch (i)
                {
                    case 1:
                        MenuOptionsData.WordColor = 1;
                        break;
                    case 2:
                        MenuOptionsData.WordColor = 2;
                        break;                     
                    case 3:                       
                        MenuOptionsData.WordColor = 3;
                        break;                    
                    case 4:                       
                        MenuOptionsData.WordColor = 4;
                        break;                     
                    case 5:                        
                        MenuOptionsData.WordColor = 5;
                        break;                     
                    case 6:                        
                        MenuOptionsData.WordColor = 6;
                        break;                    
                    case 7:                       
                        MenuOptionsData.WordColor = 7;
                        break;                    
                    case 8:                        
                        MenuOptionsData.WordColor = 8;
                        break;                     
                    case 9:                        
                        MenuOptionsData.WordColor = 9;
                        break;                     
                    case 10:                       
                        MenuOptionsData.WordColor = 10;
                        break;
                }
                Console.Clear();
                Head();
            }
            static void ChangeTrueWords()
            {
                string[] welcome ={"█▀▀ █▄ █ ▀█▀ █▀▀ █▀█   ▀█▀ █ █ █▀▀   █▀▀ █▀█ █   █▀█ █▀█   █▀█ █▀▀   ▀█▀ █ █ █▀▀   █▀▀ █▀█ █▀█ █▀█ █▀▀ █▀▀ ▀█▀  █ █ █ █▀█ █▀█ █▀▄ █▀",
                                   "██▄ █ ▀█  █  ██▄ █▀▄    █  █▀█ ██▄   █▄▄ █▄█ █▄▄ █▄█ █▀▄   █▄█ █▀     █  █▀█ ██▄   █▄▄ █▄█ █▀▄ █▀▄ ██▄ █▄▄  █   ▀▄▀▄▀ █▄█ █▀▄ █▄▀ ▄█"};
                Console.ForegroundColor = ConsoleColor.Green;
                Drawer.WriteMenu(welcome, 15);
                Console.WriteLine();
                int i = MenuSelectOpt.ChangeColor();
                switch (i)
                {
                    case 1:
                        MenuOptionsData.TrueWordColor = 1;
                        break;
                    case 2:
                        MenuOptionsData.TrueWordColor = 2;
                        break;
                    case 3:
                        MenuOptionsData.TrueWordColor = 3;
                        break;
                    case 4:
                        MenuOptionsData.TrueWordColor=4;
                        break;
                    case 5:
                        MenuOptionsData.TrueWordColor=5;
                        break;
                    case 6:
                        MenuOptionsData.TrueWordColor=6;
                        break;
                    case 7:
                        MenuOptionsData.TrueWordColor=7;
                        break;
                    case 8:
                        MenuOptionsData.TrueWordColor = 8;
                        break;
                    case 9:
                        MenuOptionsData.TrueWordColor = 9;
                        break;
                    case 10:
                        MenuOptionsData.TrueWordColor = 10;
                        break;
                }
                Console.Clear();
                Head();
            }
            public static int ChangeColor()
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
                string[] Color10 ={"             █▀▀ █▀█ █▀▀ █▀▀ █▄ █             ",
                               "             █▄█ █▀▄ ██▄ ██▄ █ ▀█             "};
                Console.ForegroundColor = ConsoleColor.Green;
                Drawer.WriteMenu(Color1, 19);
                int i = 1;
                ConsoleKeyInfo Key = Console.ReadKey();
                while (Key.Key != ConsoleKey.Enter)
                {
                    if (Key.Key == ConsoleKey.A || Key.Key == ConsoleKey.LeftArrow)
                    {
                        if (i == 1)
                        {
                            Console.ForegroundColor = (ConsoleColor)(10);
                            Drawer.WriteMenu(Color10, 19);
                            i = 10;
                        }
                        else if (i == 2)
                        {
                            Console.ForegroundColor = (ConsoleColor)(1);
                            Drawer.WriteMenu(Color1, 19);
                            i--;
                        }
                        else if (i == 3)
                        {
                            Console.ForegroundColor = (ConsoleColor)(2);
                            Drawer.WriteMenu(Color2, 19);
                            i--;
                        }
                        else if (i == 4)
                        {
                            Console.ForegroundColor = (ConsoleColor)(3);
                            Drawer.WriteMenu(Color3, 19);
                            i--;
                        }
                        else if (i == 5)
                        {
                            Console.ForegroundColor = (ConsoleColor)(4);
                            Drawer.WriteMenu(Color4, 19);
                            i--;
                        }
                        else if (i == 6)
                        {
                            Console.ForegroundColor = (ConsoleColor)(5);
                            Drawer.WriteMenu(Color5, 19);
                            i--;
                        }
                        else if (i == 7)
                        {
                            Console.ForegroundColor = (ConsoleColor)(6);
                            Drawer.WriteMenu(Color6, 19);
                            i--;
                        }
                        else if (i == 8)
                        {
                            Console.ForegroundColor = (ConsoleColor)(7);
                            Drawer.WriteMenu(Color7, 19);
                            i--;
                        }
                        else if (i == 9)
                        {
                            Console.ForegroundColor = (ConsoleColor)(8);
                            Drawer.WriteMenu(Color8, 19);
                            i--;
                        }
                        else if (i == 10)
                        {
                            Console.ForegroundColor = (ConsoleColor)(9);
                            Drawer.WriteMenu(Color9, 19);
                            i--;
                        }
                    }
                    else if (Key.Key == ConsoleKey.D || Key.Key == ConsoleKey.RightArrow)
                    {
                        if (i == 1)
                        {
                            Console.ForegroundColor = (ConsoleColor)(2);
                            Drawer.WriteMenu(Color2, 19);
                            i = 2;
                        }
                        else if (i == 2)
                        {
                            Console.ForegroundColor = (ConsoleColor)(3);
                            Drawer.WriteMenu(Color3, 19);
                            i = 3;
                        }
                        else if (i == 3)
                        {
                            Console.ForegroundColor = (ConsoleColor)(4);
                            Drawer.WriteMenu(Color4, 19);
                            i++;
                        }
                        else if (i == 4)
                        {
                            Console.ForegroundColor = (ConsoleColor)(5);
                            Drawer.WriteMenu(Color5, 19);
                            i++;
                        }
                        else if (i == 5)
                        {
                            Console.ForegroundColor = (ConsoleColor)(6);
                            Drawer.WriteMenu(Color6, 19);
                            i++;
                        }
                        else if (i == 6)
                        {
                            Console.ForegroundColor = (ConsoleColor)(7);
                            Drawer.WriteMenu(Color7, 19);
                            i++;
                        }
                        else if (i == 7)
                        {
                            Console.ForegroundColor = (ConsoleColor)(8);
                            Drawer.WriteMenu(Color8, 19);
                            i++;
                        }
                        else if (i == 8)
                        {
                            Console.ForegroundColor = (ConsoleColor)(9);
                            Drawer.WriteMenu(Color9, 19);
                            i++;
                        }
                        else if (i == 9)
                        {
                            Console.ForegroundColor = (ConsoleColor)(10);
                            Drawer.WriteMenu(Color10, 19);
                            i++;
                        }
                        else if (i == 10)
                        {
                            Console.ForegroundColor = (ConsoleColor)(1);
                            Drawer.WriteMenu(Color1, 19);
                            i = 1;
                        }
                    }
                    Key = Console.ReadKey();
                }
                return i;
            }
        }
}
