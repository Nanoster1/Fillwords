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
        public static readonly SolidColorBrush[] Colors = 
        { 
            Brushes.Red, 
            Brushes.Blue, 
            Brushes.White, 
            Brushes.Black, 
            Brushes.GreenYellow, 
            Brushes.Chocolate, 
            Brushes.Green, 
            Brushes.Gold, 
            Brushes.Pink, 
            Brushes.YellowGreen 
        };

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
                    Field.Children.Add(CreateCell(winWidth, winHeight, table, j, i));
                }
            }
        }
        static Label CreateCell(double winWidth, double winHeight, char[,] table, int j, int i)
        {
            Label label = new Label
            {
                Content = table[j, i],
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Background = Colors[FillWords.Logic.MenuOptionsData.TableColor],
                Foreground = Colors[FillWords.Logic.MenuOptionsData.WordColor],
                Width = winWidth / MenuOptionsData.TableWidth,
                Height = (winHeight - 200) / MenuOptionsData.TableHeight
            };
            Canvas.SetLeft(label, i * winWidth / MenuOptionsData.TableWidth);
            Canvas.SetTop(label, j * (winHeight - 200) / MenuOptionsData.TableHeight);
            return label;
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
            for (int i = 0; i < GameTable.Words.Count; i++)
            {
                tbWords.Text += GameTable.Words[i].Name + "\n";
            }
        }
    }
}
