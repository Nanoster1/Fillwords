using System;
using System.IO;
using System.Text;

namespace FillWords.Logic
{
    public class FileWorker
    {
        public string[] Records { get; private set; } 
        public string[] Saves { get; private set; }
        string[] SetRecords()
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
        string[] SetSaves()
        {
            string path = Environment.CurrentDirectory + "\\Saves";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (Directory.GetFiles(path).Length == 0)
                return new string[1] { "Saves not found" };
            return Directory.GetFiles(path);
        }
        public FileWorker()
        {
            Records = SetRecords();
            Saves = SetSaves();
        }
        public GamerInfo GetOneSave(string path)
        {
            string file = File.ReadAllText(path);
            string[] save = file.Split(' ');
            MenuOptionsData.TableColor = (ConsoleColor)(int.Parse(save[2]));
            MenuOptionsData.CursorColor = (ConsoleColor)(int.Parse(save[3]));
            MenuOptionsData.WordColor= (ConsoleColor)(int.Parse(save[4]));
            MenuOptionsData.TrueWordColor = (ConsoleColor)(int.Parse(save[5]));
            MenuOptionsData.TableHeight = int.Parse(save[6]);
            MenuOptionsData.TableWidth =int.Parse(save[7]);
            GamerInfo gamer = new GamerInfo(save[0], int.Parse(save[1]), new char[0,0]);
            return gamer;
        }
        public void CreateSave(GamerInfo gamer)
        {
            string path = Environment.CurrentDirectory + "\\Saves" + $"\\{gamer.Name}.txt";
            FileStream fs = File.Create(path);
            fs.Close();
            File.AppendAllText(path, $"{gamer.Name} {gamer.Scores} {(int)MenuOptionsData.TableColor} {(int)MenuOptionsData.CursorColor} {(int)MenuOptionsData.WordColor} {(int)MenuOptionsData.TrueWordColor} {(int)MenuOptionsData.TableHeight} {(int)MenuOptionsData.TableWidth}");

        }
        public void WriteRecord(GamerInfo gamer)
        {
            int k = 0;
            if (CheckInRecords(gamer.Name, gamer.Scores, Records, ref k))
            {
                Records[k] = $"{Records[k].Split(" ")[0]} {gamer.Name} - {gamer.Scores} ";
                BubbleSort(Records);
            }
            else if (gamer.Scores > int.Parse(Records[9].Split(" ")[3]))
            {
                Records[9] = $"{Records[9].Split(" ")[0]} {gamer.Name} - {gamer.Scores} ";
                BubbleSort(Records);
            }
            File.WriteAllLines(Environment.CurrentDirectory + "\\Records.txt", Records);
        }
        bool CheckInRecords(string name, int scores, string[] records, ref int k)
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
        void BubbleSort(string[] records)
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
        public bool CheckNameInSaves(string name)
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
