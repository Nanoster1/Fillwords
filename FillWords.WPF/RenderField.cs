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
        public static void CreateField(NewGame game, Canvas Field, double winWidth, double winHeight)
        {
            Field.Children.Clear();
            Field.Width = winWidth;
            Field.Height = (winHeight - 200);
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
                    label.Width = winWidth / MenuOptionsData.TableWidth;
                    label.Height = (winHeight - 200) / MenuOptionsData.TableHeight;
                    Canvas.SetLeft(label, i * winWidth / MenuOptionsData.TableWidth);
                    Canvas.SetTop(label, j * (winHeight - 200) / MenuOptionsData.TableHeight);
                    Field.Children.Add(label);
                }
            }
        }
        public static void ReRenderField(Canvas Field, double winWidth, double winHeight)
        {
            for (int i = 0; i < Field.Children.Count; i++)
            {
                (Field.Children[i] as Label).Width = winWidth / MenuOptionsData.TableWidth;
                (Field.Children[i] as Label).Height = (winHeight - 200) / MenuOptionsData.TableHeight;
                Canvas.SetLeft((Field.Children[i] as Label), i % MenuOptionsData.TableWidth * winWidth / MenuOptionsData.TableWidth);
                Canvas.SetTop((Field.Children[i] as Label), i / MenuOptionsData.TableWidth * (winHeight - 200) / MenuOptionsData.TableHeight);
            }
            Field.Width = winWidth;
            Field.Height = (winHeight - 200);
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
