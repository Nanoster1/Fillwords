using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using FillWords.Logic;

namespace FillWords.WPF
{
    public static class RenderField
    {
        public static void CreateField(NewGame game, WrapPanel Field)
        {
            Field.Orientation = Orientation.Horizontal;
            Field.Width = 80 * MenuOptionsData.TableWidth;
            char[,] table = game.Gamer.Table;
            for (int j = 0; j < MenuOptionsData.TableHeight; j++)
            {
                for (int i = 0; i < MenuOptionsData.TableWidth; i++)
                {
                    Label label = new Label();
                    label.Content = table[j, i];
                    label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    label.VerticalContentAlignment = VerticalAlignment.Center;
                    label.Background = Brushes.Black;
                    label.Foreground = Brushes.White;
                    Field.Children.Add(label);
                }
            }
        }
        public static void WriteWords(TextBlock tbWords)
        {
            for (int i = 0; i < GameTable.Words.Count; i++)  //В отдельный метод
            {
                tbWords.Text += GameTable.Words[i].Name + "\n";
            }
        }
    }
}
