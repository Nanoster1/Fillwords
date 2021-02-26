using System;
using System.IO;
using System.Text;

namespace Fillwords
{
    public static class Files
    {
        public static string[] Records
        {
            get
            {
                string path = Environment.CurrentDirectory + "\\Records.txt";
                if (!File.Exists(path))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                return File.ReadAllLines(path);
            }
            private set { }
        }
        public static string[] Saves
        {
            get
            {
                string path = Environment.CurrentDirectory + "\\Saves";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.GetFiles(path).Length == 0)
                    return new string[1] { "Saves not found" };
                return Directory.GetFiles(path);
            }
            private set { }
        }
        public readonly static string[] dictionary = File.ReadAllLines(Environment.CurrentDirectory + "\\Dictionary.txt");
        public static GamerInfo GetOneSave(string path)
        {
            string file = File.ReadAllText(path);
            string[] save = file.Split(' ');
            MenuOptionsData.EnterColorTable((ConsoleColor)(int.Parse(save[3])));
            MenuOptionsData.EnterCursorColor((ConsoleColor)(int.Parse(save[4])));
            MenuOptionsData.EnterWordColor((ConsoleColor)(int.Parse(save[5])));
            MenuOptionsData.EnterTrueWordColor((ConsoleColor)(int.Parse(save[6])));
            MenuOptionsData.EnterTableHeight(int.Parse(save[7]));
            MenuOptionsData.EnterTableWidth(int.Parse(save[8]));
            GamerInfo gamer = new GamerInfo(save[0], int.Parse(save[1]), ConvertStringToArray(save[2]));
            return gamer;
        }
        public static void CreateSave(GamerInfo gamer)
        {
            string path = Environment.CurrentDirectory + "\\Saves" + $"\\{gamer.Name}.txt";
            FileStream fs = File.Create(path);
            fs.Close();
            File.AppendAllText(path, $"{gamer.Name} {gamer.Scores} {ConvertArrayToString(gamer.Table)} {(int)MenuOptionsData.TableColor} {(int)MenuOptionsData.CursorColor} {(int)MenuOptionsData.WordColor} {(int)MenuOptionsData.TrueWordColor} {(int)MenuOptionsData.TableHeight} {(int)MenuOptionsData.TableWidth}");

        }
        static string ConvertArrayToString(char[,] table)
        {
            StringBuilder str = new StringBuilder();
            foreach (var ch in table)
            {
                str.Append(ch);
            }
            return str.ToString();
        }
        static char[,] ConvertStringToArray(string text)
        {
            char[,] table = new char[MenuOptionsData.TableWidth, MenuOptionsData.TableHeight];
            int x = 0;
            int y = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (x == MenuOptionsData.TableWidth)
                {
                    y++;
                    x = 0;
                }
                table[y, x] = text[i];
                x++;
            }
            return table;
        }
        public static void WriteRecord(GamerInfo gamer)
        {
            string[] records = Records;
            for (int i = 0; i < records.Length; i++)
            {
                if (gamer.Scores > int.Parse(records[i].Split(" ")[3]))
                {
                    records[i] = $"{records[i].Split(" ")[0]} {gamer.Name} - {gamer.Scores}";
                    break;
                }
            }
        }
        public static bool CheckNameInSaves(string name)
        {
            for (int i = 0; i < Saves.Length; i++)
            {
                string[] ar = Saves[i].Split("\\");
                if (name == ar[^1].Split('.')[0])
                    return true;
            }
            return false;
        }
    }
}
