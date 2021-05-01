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
        static Canvas Field { get; set; }
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
        public static void SetField(Canvas canvas)
        {
            if (Field == null)
                Field = canvas;
            else
                throw new Exception("Поле уже задано");
        }

        public static void CreateField(NewGame game, Canvas Field)
        {
            Field.Children.Clear();
            char[,] table = game.Gamer.Table;
            for (int j = 0; j < MenuOptionsData.TableHeight; j++)
            {
                for (int i = 0; i < MenuOptionsData.TableWidth; i++)
                {
                    Field.Children.Add(CreateCell( table, j, i));
                }
            }
            
        }
        private static Label CreateCell(char[,] table, int j, int i)
        {
            Label cell = new Label
            {
                Content = table[j, i],
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Background = Colors[FillWords.Logic.MenuOptionsData.TableColor],
                Foreground = Colors[FillWords.Logic.MenuOptionsData.WordColor],
                Width = Field.Width / MenuOptionsData.TableWidth - 10,
                Height = Field.Height / MenuOptionsData.TableHeight - 10,
                BorderBrush = Brushes.White
            };
            if (!double.IsNaN(cell.Width) || !double.IsNaN(cell.Height)) 
                SetFontSize(cell);
            Canvas.SetLeft(cell, i * Field.Width / MenuOptionsData.TableWidth);
            Canvas.SetTop(cell, j * Field.Height / MenuOptionsData.TableHeight);
            return cell;
        }
        public static void ReRenderField()
        {
            for (int i = 0; i < Field.Children.Count; i++)
            {
                Label cell = Field.Children[i] as Label;
                cell.Width = Field.Width / MenuOptionsData.TableWidth - 10;
                cell.Height = Field.Height / MenuOptionsData.TableHeight - 10;
                cell.VerticalContentAlignment = VerticalAlignment.Stretch;
                SetFontSize(cell);
                Canvas.SetLeft(cell, i % MenuOptionsData.TableWidth * Field.Width / MenuOptionsData.TableWidth);
                Canvas.SetTop(cell, i / MenuOptionsData.TableWidth * Field.Height / MenuOptionsData.TableHeight);
            }
        }
        private static void SetFontSize(Label cell)
        {
            if (cell.Width < cell.Height)
                cell.FontSize = cell.Width * 0.60;
            else
                cell.FontSize = cell.Height * 0.60;
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
