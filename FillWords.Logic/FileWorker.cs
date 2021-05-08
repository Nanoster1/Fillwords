using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace FillWords.Logic
{
    public class FileWorker
    {
        public static readonly string ExecutedPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string RecordsPath = Path.Combine(ExecutedPath, "Records.txt");
        public static readonly string SavesPath = Path.Combine(ExecutedPath, "Saves");
        public static readonly string DictionaryPath = Path.Combine(ExecutedPath, "Dictionary.txt");

        public string[] Records { get; private set; }
        public string[] Saves { get; private set; }
        string[] SetRecords()
        {
            if (!File.Exists(RecordsPath))
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
                FileStream fs = File.Create(RecordsPath);
                fs.Close();
                File.WriteAllLines(RecordsPath, records);
            }
            return File.ReadAllLines(RecordsPath);
        }
        string[] SetSaves()
        {
            if (!Directory.Exists(SavesPath))
                Directory.CreateDirectory(SavesPath);
            if (Directory.GetFiles(SavesPath).Length == 0)
                return ["Saves not found"];
            return Directory.GetFiles(SavesPath);
        }
        public FileWorker()
        {
            Records = SetRecords();
            Saves = SetSaves();
        }
        public GamerInfo GetOneSave(string username)
        {
            string path = Path.Combine(SavesPath, $"{username}.txt");
            string file = File.ReadAllText(path);
            string[] save = file.Split(' ');
            MenuOptionsData.TableColor = int.Parse(save[2]);
            MenuOptionsData.CursorColor = int.Parse(save[3]);
            MenuOptionsData.WordColor = int.Parse(save[4]);
            MenuOptionsData.TrueWordColor = int.Parse(save[5]);
            MenuOptionsData.TableHeight = int.Parse(save[6]);
            MenuOptionsData.TableWidth = int.Parse(save[7]);
            GamerInfo gamer = new GamerInfo(save[0], int.Parse(save[1]), new char[0, 0]);
            return gamer;
        }
        public void CreateSave(GamerInfo gamer)
        {
            string path = Path.Combine(SavesPath, $"{gamer.Name}.txt");
            FileStream fs = File.Create(path);
            fs.Close();
            File.AppendAllText(path, $"{gamer.Name} {gamer.Scores} {(int)MenuOptionsData.TableColor} {(int)MenuOptionsData.CursorColor} {(int)MenuOptionsData.WordColor} {(int)MenuOptionsData.TrueWordColor} {(int)MenuOptionsData.TableHeight} {(int)MenuOptionsData.TableWidth}");
        }
        public void WriteRecord(GamerInfo gamer)
        {
            int k = 0;
            if (CheckInRecords(gamer.Name, gamer.Scores, Records, ref k) == 1)
            {
                Records[k] = $"{Records[k].Split(" ")[0]} {gamer.Name} - {gamer.Scores} ";
                BubbleSort(Records);
            }
            else if (CheckInRecords(gamer.Name, gamer.Scores, Records, ref k) == 0)
            {
                BubbleSort(Records);
            }
            else if (gamer.Scores > int.Parse(Records[9].Split(" ")[3]))
            {
                Records[9] = $"{Records[9].Split(" ")[0]} {gamer.Name} - {gamer.Scores} ";
                BubbleSort(Records);
            }
            File.WriteAllLines(RecordsPath, Records);
        }
        int CheckInRecords(string name, int scores, string[] records, ref int k)
        {
            for (int i = 0; i < records.Length; i++)
            {
                if (name == records[i].Split(" ")[1] && scores > int.Parse(records[i].Split(" ")[3]))
                {
                    k = i;
                    return 1;
                }
                else if (name == records[i].Split(" ")[1])
                {
                    return 0;
                }
            }
            return -1;
        }
        void BubbleSort(string[] records)
        {
            for (int i = 0; i < records.Length; i++)
            {
                for (int j = 0; j < records.Length - 1; j++)
                {
                    if (int.Parse(records[j].Split(" ")[3]) < int.Parse(records[j + 1].Split(" ")[3]))
                    {
                        string t = records[j + 1];
                        records[j + 1] = records[j].Replace(records[j].Split(" ")[0], records[j + 1].Split(" ")[0]);
                        records[j] = t.Replace(t.Split(" ")[0], records[j].Split(" ")[0]);
                    }
                }
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