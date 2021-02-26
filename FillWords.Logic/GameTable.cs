using System;
using System.Collections.Generic;
using System.IO;

namespace FillWords.Logic
{
    public static class GameTable
    {
        static List<string> TrueWords { get; set; } = new List<string>();
        public static List<string> UsedWords { get; private set; } = new List<string>();
        static Stack<int> Coords { get; set; } = new Stack<int>();
        public static List<Word> Words { get; private set; } = new List<Word>();
        static readonly string[] dictionary = File.ReadAllLines(Environment.CurrentDirectory + "\\Dictionary.txt");
        static bool CleanAr(char[,] table, int positionX, int positionY) //Проверка на пустой элемент массива
        {
            return table[positionY, positionX] == '\0';
        }
        static bool TruePos(int tableWidth, int tableHeight, int positionX, int positionY) //Проверка на доступность элемента массива
        {
            return positionX < tableWidth && positionY < tableHeight && positionX >= 0 && positionY >= 0;
        }
        static bool CheckAr(char[,] table, int tableHeight, int tableWidth) //Проверка массива на пустые элементы
        {
            for (int i = 0; i < tableHeight; i++)
            {
                for (int j = 0; j < tableWidth; j++)
                {
                    if (table[i, j] == '\0')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void AddWords()
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                TrueWords.Add(dictionary[i]);
            }
        }
        public static char[,] CreateTable()
        {
            Words.Clear();
            int tableHeight = MenuOptionsData.TableHeight;
            int tableWidth = MenuOptionsData.TableWidth;
            char[,] table = new char[tableHeight, tableWidth];
            Random random = new Random();
            AddWords();
            while (CheckAr(table, tableHeight, tableWidth))
            {
                if (TrueWords.Count == 0)
                {
                    UsedWords.Clear();
                    Words.Clear();
                    table = CreateTable();
                    break;
                }
                Word word1 = new Word();
                char[,] timeTable = (char[,])table.Clone();
                string word = TrueWords[random.Next(0, TrueWords.Count)];
                TrueWords.Remove(word);
                int positionX = random.Next(0, tableWidth);
                int positionY = random.Next(0, tableHeight);
                while (!CleanAr(table, positionX, positionY))
                {
                    positionX = random.Next(0, tableWidth);
                    positionY = random.Next(0, tableHeight);
                }
                table[positionY, positionX] = word[0];
                Coords.Push(positionY);
                Coords.Push(positionX);

                for (int i = 1; i < word.Length; i++)
                {
                    if (TruePos(tableWidth, tableHeight, positionX + 1, positionY) && CleanAr(table, positionX + 1, positionY))
                    {
                        positionX++;
                        table[positionY, positionX] = word[i];
                        Coords.Push(positionY);
                        Coords.Push(positionX);
                    }
                    else if (TruePos(tableWidth, tableHeight, positionX, positionY - 1) && CleanAr(table, positionX, positionY - 1))
                    {
                        positionY--;
                        table[positionY, positionX] = word[i];
                        Coords.Push(positionY);
                        Coords.Push(positionX);
                    }
                    else if (TruePos(tableWidth, tableHeight, positionX - 1, positionY) && CleanAr(table, positionX - 1, positionY))
                    {
                        positionX--;
                        table[positionY, positionX] = word[i];
                        Coords.Push(positionY);
                        Coords.Push(positionX);
                    }
                    else if (TruePos(tableWidth, tableHeight, positionX, positionY + 1) && CleanAr(table, positionX, positionY + 1))
                    {
                        positionY++;
                        table[positionY, positionX] = word[i];
                        Coords.Push(positionY);
                        Coords.Push(positionX);
                    }
                    else
                    {
                        table = timeTable;
                        Coords.Clear();
                        break;
                    }
                }
                if (Coords.Count == 0)
                    continue;
                UsedWords.Add(word);
                word1.Name = word;
                bool c = true;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    positionX = Coords.Pop();
                    positionY = Coords.Pop();
                    word1.CoordsX.Add(positionX);
                    word1.CoordsY.Add(positionY);
                    if (CheckFullElem(table, positionX, positionY, tableWidth, tableHeight) || CheckVariants(table, tableWidth, tableHeight, positionX, positionY))
                    {
                        continue;
                    }
                    else
                    {
                        table = timeTable;
                        Coords.Clear();
                        UsedWords.Remove(word);
                        c = false;
                        break;
                    }
                }
                if (c)
                {
                    word1.CoordsX.Reverse();
                    word1.CoordsY.Reverse();
                    Words.Add(word1);
                }
            }
            return table;
        }
        static bool CheckFullElem(char[,] table, int positionX, int positionY, int tableWidth, int tableHeight)
        {
            if ((!TruePos(tableWidth - 1, tableHeight - 1, positionX, positionY + 1) || table[positionY + 1, positionX] != '\0') && 
                (!TruePos(tableWidth - 1, tableHeight - 1, positionX, positionY - 1) || table[positionY - 1, positionX] != '\0') && 
                (!TruePos(tableWidth - 1, tableHeight - 1, positionX + 1, positionY) || table[positionY, positionX + 1] != '\0') && 
                (!TruePos(tableWidth - 1, tableHeight - 1, positionX - 1, positionY) || table[positionY, positionX - 1] != '\0'))
                return true;
            else return false;
        }
        static bool NormalAr(char[,] table, int tableWidth, int tableHeight, int positionY, int positionX) 
        {
            return (TruePos(tableWidth, tableHeight, positionX, positionY) && CleanAr(table, positionX, positionY));
        }
        static bool CheckVariants(char[,] table, int tableWidth, int tableHeight, int positionX, int positionY)
        {
            if (NormalAr(table, tableWidth, tableHeight, positionY, positionX + 1))
            {
                if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX + 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 2, positionX + 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX + 2))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY, positionX + 2))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX + 2))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY, positionX + 3))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX + 2))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX + 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX + 2))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 2, positionX + 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX))
                        return true;
                }
            }
            else if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX))
            {
                if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX + 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX + 2))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 2, positionX + 1))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY - 2, positionX))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY - 2, positionX + 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 3, positionX))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 2, positionX - 1))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX - 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY - 2, positionX - 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX - 2))
                        return true;
                }
            }
            else if (NormalAr(table, tableWidth, tableHeight, positionY, positionX - 1))
            {
                if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX - 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 2, positionX - 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX - 2))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY, positionX - 2))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY - 1, positionX - 2))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY, positionX - 3))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY, positionX - 2))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX - 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY, positionX - 2))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 2, positionX - 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX))
                        return true;
                }
            }
            else if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX))
            {
                if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX - 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX - 2))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 2, positionX - 1))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY + 2, positionX))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY + 2, positionX - 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 3, positionX))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 2, positionX + 1))
                        return true;
                }
                else if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX + 1))
                {
                    if (NormalAr(table, tableWidth, tableHeight, positionY + 2, positionX + 1))
                        return true;
                    else if (NormalAr(table, tableWidth, tableHeight, positionY + 1, positionX + 2))
                        return true;
                }
            }
            return false;
        }
    }
}
































//          Stack<string> words = ChooseWords(tableWidth, tableHeight, dictionary);
//          while (words.Count != 0)
//          {
//              string word = words.Pop();
//          for (int i = 0; i < word.Length; i++)
//          {
//              if (i == 0)
//              {
//                  table[positionX, positionY] = word[i];
//                  continue;
//              }
//              int step = random.Next(1, 4);
//              switch (step)
//              {
//                  case (1):
//                      table[positionX + 1, positionY] = word[i];
//                      positionX++;
//                      break;
//                  case (2):
//                      table[positionX - 1, positionY] = word[i];
//                      positionX--;
//                      break;
//                  case (3):
//                      table[positionX, positionY + 1] = word[i];
//                      positionY++;
//                      break;
//                  case (4):
//                      table[positionX, positionY - 1] = word[i];
//                      positionY--;
//                      break;
//              }
//          }
//      }
//  }
//  private static Stack<string> ChooseWords(int tableWidth, int tableHeight, string[] dictionary)
//  {
//      int elInAr = tableHeight * tableWidth;
//      Stack<string> words = new Stack<string>();
//      Random random = new Random();
//      while (!CheckElInWords(words, elInAr))
//      {
//          int i = random.Next();                  //Составить словарь
//          words.Push(dictionary[i]);
//      }
//      return words;
//  }
//  private static bool CheckElInWords(Stack<string> words, int elInAr)
//  {
//      int elInWords = 0;
//      for (int i = 0; i < words.Count; i++)
//      {
//          elInWords += words.Pop().Length;
//      }
//      if (elInWords == elInAr)
//          return true;
//      else
//          return false;
//  }
