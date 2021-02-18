using System;
using System.IO;
using System.Text;

namespace FillWords.Logic
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
                    string[] records = { "1) Admin - 0",
                                         "2) Admin - 0",
                                         "3) Admin - 0",
                                         "4) Admin - 0",
                                         "5) Admin - 0",
                                         "6) Admin - 0",
                                         "7) Admin - 0",
                                         "8) Admin - 0",
                                         "9) Admin - 0",
                                         "10) Admin - 0"};
                    FileStream fs = File.Create(path);
                    fs.Close();
                    File.WriteAllLines(path, records);
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
            MenuOptionsData.EnterColorTable((ConsoleColor)(int.Parse(save[2])));
            MenuOptionsData.EnterCursorColor((ConsoleColor)(int.Parse(save[3])));
            MenuOptionsData.EnterWordColor((ConsoleColor)(int.Parse(save[4])));
            MenuOptionsData.EnterTrueWordColor((ConsoleColor)(int.Parse(save[5])));
            MenuOptionsData.EnterTableHeight(int.Parse(save[6]));
            MenuOptionsData.EnterTableWidth(int.Parse(save[7]));
            GamerInfo gamer = new GamerInfo(save[0], int.Parse(save[1]), new char[0,0]);
            return gamer;
        }
        public static void CreateSave(GamerInfo gamer)
        {
            string path = Environment.CurrentDirectory + "\\Saves" + $"\\{gamer.Name}.txt";
            FileStream fs = File.Create(path);
            fs.Close();
            File.AppendAllText(path, $"{gamer.Name} {gamer.Scores} {(int)MenuOptionsData.TableColor} {(int)MenuOptionsData.CursorColor} {(int)MenuOptionsData.WordColor} {(int)MenuOptionsData.TrueWordColor} {(int)MenuOptionsData.TableHeight} {(int)MenuOptionsData.TableWidth}");

        }
        public static void WriteRecord(GamerInfo gamer)
        {
            int k = 0;
            string[] records = Records;
            if (CheckInRecords(gamer.Name, gamer.Scores, records, ref k))
            {
                records[k] = $"{records[k].Split(" ")[0]} {gamer.Name} - {gamer.Scores} ";
                BubbleSort(ref records);
            }
            else if (gamer.Scores > int.Parse(records[9].Split(" ")[3]))
            {
                records[9] = $"{records[9].Split(" ")[0]} {gamer.Name} - {gamer.Scores} ";
                BubbleSort(ref records);
            }
            File.WriteAllLines(Environment.CurrentDirectory + "\\Records.txt", records);
        }
        static bool CheckInRecords(string name, int scores, string[] records, ref int k)
        {
            for (int i = 0; i < records.Length; i++)
            {
                if (name == records[i].Split(" ")[1] && scores > int.Parse(records[i].Split(" ")[3]))
                {
                    k = i;
                    return true;
                }
            }
            return false;
        }
        static void BubbleSort(ref string[] records)
        {
            for (int i = 0; i < records.Length; i++)
                for (int j = 0; j < records.Length - 1; j++)
                    if (int.Parse(records[j].Split(" ")[3]) < int.Parse(records[j + 1].Split(" ")[3]))
                    {
                        string t = records[j + 1];
                        records[j + 1] = records[j].Replace(records[j].Split(" ")[0], records[j + 1].Split(" ")[0]);
                        records[j] = t.Replace(t.Split(" ")[0], records[j].Split(" ")[0]);
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
