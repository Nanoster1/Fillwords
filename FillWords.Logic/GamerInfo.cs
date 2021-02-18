using System;
using System.Collections.Generic;

namespace FillWords.Logic
{
    public class GamerInfo
    {
        public string Name { get; private set; }
        public char[,] Table { get; private set; }
        public int Scores { get; private set; }
        public GamerInfo(string name, int scores, char[,] table)
        {
            Name = name;
            Table = table;
            Scores = scores;
        }
        public void SetTable(char[,] table)
        {
            Table = table;
        }
        public void SetScores(int scores)
        {
            Scores += scores;
        }
    }
}
