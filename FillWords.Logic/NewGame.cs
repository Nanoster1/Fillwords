using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FillWords.Logic
{
    public class NewGame
    {
        public GamerInfo Gamer { get; private set; }
        public List<Word> Words { get; private set; } = new List<Word>(); //Угаданные слова
        public int ScoresForLvl { get; set; }
        public NewGame(GamerInfo gamer)
        {
            Gamer = gamer;
            ScoresForLvl = GameTable.Words.Count;
        }
        public bool CheckWord(Word word)
        {
            for (int i = 0; i < GameTable.Words.Count; i++)
            {
                if (GameTable.Words[i].CoordsX.SequenceEqual(word.CoordsX) && GameTable.Words[i].CoordsY.SequenceEqual(word.CoordsY))
                {
                    Words.Add(GetWord(word));
                    GameTable.Words.Remove(GameTable.Words[i]);
                    return true;
                }
            }
            return false;
        }
        public static bool CheckInWords(int x, int y, NewGame game)
        {
            for (int i = 0; i < game.Words.Count; i++)
            {
                for (int k = 0; k < game.Words[i].CoordsX.Count; k++)
                {
                    if (game.Words[i].CoordsX[k] == x && game.Words[i].CoordsY[k] == y)
                        return true;
                }
            }
            return false;
        }
        public static bool CheckLetter(int x, int y, Word SelectedWord)
        {
            for (int i = 0; i < SelectedWord.CoordsX.Count; i++)
            {
                if (SelectedWord.CoordsX[i] == x && SelectedWord.CoordsY[i] == y)
                    return true;
            }
            return false;
        }
        Word GetWord(Word word)
        {
            Word word1 = new Word();
            int[] coordsX = word.CoordsX.ToArray();
            int[] coordsY = word.CoordsY.ToArray();
            for (int k = 0; k < coordsX.Length; k++)
            {
                word1.CoordsX.Add(coordsX[k]);
                word1.CoordsY.Add(coordsY[k]);
            }
            return word1;
        }
        public bool GetNextLvl()
        {
            if (GameTable.Words.Count == 0)
            {
                Gamer.SetTable(GameTable.CreateTable());
                Gamer.SetScores(ScoresForLvl);
                ScoresForLvl = GameTable.Words.Count;
                Words.Clear();
                return true;
            }
            return false;
        }
    }
}
