using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Fillwords
{		

	class MenuRecords
    {
		private const string alphabet = "🅰🅱🅲🅳🅴🅵🅶🅷🅸🅹🅺🅻🅼🅽🅾🅿🆀🆁🆂🆃🆄🆅🆆🆇🆈🆉";
                                 
		private static int spaceCount = 10;
		private static char endOfDictionary = 'a';
		public static Dictionary<char, Dictionary<string, string>> recordsSpace = new Dictionary<char, Dictionary<string, string>>()
		{
				{ Convert.ToChar(65), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▀█▀ █▀█ █▀█ ▄▄ ▄█ █▀█" }, { "3", "█ █" } } },
				{ Convert.ToChar(66), new Dictionary<string, string> { { "1", "█ █" }, { "2", " █  █▄█ █▀▀     █ █▄█" }, { "3", "█ █" } } },
				{ Convert.ToChar(67), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▄█    " }, { "3", "█ █" } } },
				{ Convert.ToChar(68), new Dictionary<string, string> { { "1", "█ █" }, { "2", " █    " }, { "3", "█ █" } } },
				{ Convert.ToChar(69), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(70), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▀█    " }, { "3", "█ █" } } },
				{ Convert.ToChar(71), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▄    " }, { "3", "█ █" } } },
				{ Convert.ToChar(72), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(73), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▀█    " }, { "3", "█ █" } } },
				{ Convert.ToChar(74), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▀█    " }, { "3", "█ █" } } },
				{ Convert.ToChar(75), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▄█    " }, { "3", "█ █" } } },
				{ Convert.ToChar(76), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(77), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█ █   " }, { "3", "█ █" } } },
				{ Convert.ToChar(78), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▀▀█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(79), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(80), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▀    " }, { "3", "█ █" } } },
				{ Convert.ToChar(81), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▄█    " }, { "3", "█ █" } } },
				{ Convert.ToChar(82), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(83), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▄▄   " }, { "3", "█ █" } } },
				{ Convert.ToChar(84), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▄█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(85), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(86), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▀▀█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(87), new Dictionary<string, string> { { "1", "█ █" }, { "2", "  █   " }, { "3", "█ █" } } },
				{ Convert.ToChar(88), new Dictionary<string, string> { { "1", "█ █" }, { "2", "	   "   }, { "3", "█ █" } } },
				{ Convert.ToChar(89), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▀█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(90), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▀█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(91), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▄█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(92), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(93), new Dictionary<string, string> { { "1", "█ █" }, { "2", "█▀█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(94), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▀▀█   " }, { "3", "█ █" } } },
				{ Convert.ToChar(95), new Dictionary<string, string> { { "1", "█ █" }, { "2", "      " }, { "3", "█ █" } } },
				{ Convert.ToChar(96), new Dictionary<string, string> { { "1", "█ █" }, { "2", "▄█ █▀█" }, { "3", "█ █" } } },
				{ Convert.ToChar(97), new Dictionary<string, string> { { "1", "█ █" }, { "2", " █ █▄█" }, { "3", "█ █" } } }

		};
		static string textRecords = "\\records.txt";
		public static void Head()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			PrintSpace();
			string[] a = ConvertAllUsers();
            for (int i = 0; i < a.Length; i += 2)
            {
				Console.SetCursorPosition(Console.WindowWidth / 2 - 15, i);
				Console.WriteLine(a[i]);
            }
		}
		private static void PrintSpace()
		{
			for (char i = Convert.ToChar(65); i <= endOfDictionary; i++)
			{
				for (char j = '1'; j <= '3'; j++)
				{
					Console.Write(recordsSpace[i][j.ToString()]);

					if (j == '1')
						WriteSpace(spaceCount);
					if (j == '2')
						WriteSpace(spaceCount);
				}
				Console.WriteLine();

			}
		}
		private static void WriteSpace(int num)
		{
			for (int i = 0; i < num; i++)
			{
				Console.Write(" ");
			}
		}
		private static string ConvertWordInFront(string nameUser)
		{
			
			string NewName="";
			for (int i = 0; i < nameUser.Length; i++)
			{
				NewName += ConvertLetter(nameUser[i]);
			}
			return NewName;
		}
		private static string ConvertLetter(char letter)
		{
			return alphabet[letter - 65].ToString();
		}
		private static string[]  ConvertAllUsers()
		{
			string[] scoreSpace = File.ReadAllLines(textRecords);
			int[] numOfUsers;
			int[] scoreAllUsers = SortScore(scoreSpace, out numOfUsers);
			for (int count = 0; count < numOfUsers.Length; count++)
			{
				int b = numOfUsers[count];
				string nameUser = scoreSpace[numOfUsers[count]-1];
				scoreSpace[numOfUsers[count]-1] = ConvertWordInFront(nameUser);
			}
			return scoreSpace;
		}
		private static int[] SortScore(string[] scoreSpace, out int[] numOfUsers)
		{
			numOfUsers = new int[scoreSpace.Length / 2 + 1];
			int[] scoreAllUsers=new int[scoreSpace.Length/2+1];
			int g = 0;

			for (int i = 1; i <= scoreSpace.Length-1; i+=2)
			{
				if (scoreSpace[i] == "")
					break;
				scoreAllUsers[g] = Convert.ToInt32(scoreSpace[i]);
				numOfUsers[g] = i;
				g++;
			}
			
			for (int i = 0; i < scoreAllUsers.Length; i++)
			{
				for (int j = 0; j < scoreAllUsers.Length-i - 1; j++)
				{
					if(scoreAllUsers[j]> scoreAllUsers[j+1])
					{
						int x = scoreAllUsers[j];
						int num = numOfUsers[j];
						scoreAllUsers[j] = scoreAllUsers[j + 1];
						numOfUsers[j] = numOfUsers[j + 1];
						scoreAllUsers[j + 1] = x;
						numOfUsers[j + 1] = num;
					}
				}
			}
			return scoreAllUsers;
		}
    }
}
