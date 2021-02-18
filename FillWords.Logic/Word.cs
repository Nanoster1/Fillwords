using System;
using System.Collections.Generic;

namespace FillWords.Logic
{
    public class Word
    {
        public List<int> CoordsX { get; private set; } = new List<int>();
        public List<int> CoordsY { get; private set; } = new List<int>();
        public string Name { get; set; }
    }
}
