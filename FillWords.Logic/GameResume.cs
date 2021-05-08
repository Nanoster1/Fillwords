using System;
using System.Collections.Generic;
using System.Text;

namespace FillWords.Logic
{
    public static class GameResume
    {
        public static NewGame GetGame(string name)
        {
            FileWorker files = new FileWorker();
            string[] saves = files.Saves;
            for (int i = 0; i < saves.Length; i++)
            {
                string[] ar = saves[i].Split("\\");
                if (name == ar[^1].Split('.')[0])
                    return new NewGame(files.GetOneSave(saves[i].Replace(".txt", string.Empty)));
            }
            return null;
        }
    }
}