using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FillWords.Logic;

namespace FillWords.WPF
{
    class Field
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
        private Word ActualWord { get; set; } = new Word();
        private Canvas Canvas { get; set; }
        private NewGame Game { get; set; }
        private Label Info { get; set; }
        public Field(Canvas canvas, NewGame game, TextBlock tbWords, Label info)
        {
            this.Canvas = canvas;
            this.Game = game;
            CreateField(game, canvas);
            AddLabelHandlers();
            this.Info = info;
            WriteWords(tbWords);
            SetLNameContent();
        }
        public void CreateField(NewGame game, Canvas canvas)
        {
            canvas.Children.Clear();
            char[,] table = game.Gamer.Table;
            for (int j = 0; j < MenuOptionsData.TableHeight; j++)
            {
                for (int i = 0; i < MenuOptionsData.TableWidth; i++)
                {
                    canvas.Children.Add(CreateCell(table, j, i));
                }
            }
        }
        private Label CreateCell(char[,] table, int j, int i)
        {
            Label cell = new Label
            {
                Content = table[j, i],
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Background = Colors[FillWords.Logic.MenuOptionsData.TableColor],
                Foreground = Colors[FillWords.Logic.MenuOptionsData.WordColor],
                Width = Canvas.Width / MenuOptionsData.TableWidth - 10,
                Height = Canvas.Height / MenuOptionsData.TableHeight - 10,
            };
            if (!double.IsNaN(cell.Width) || !double.IsNaN(cell.Height))
                SetFontSize(cell);
            Canvas.SetLeft(cell, i * Canvas.Width / MenuOptionsData.TableWidth);
            Canvas.SetTop(cell, j * Canvas.Height / MenuOptionsData.TableHeight);
            return cell;
        }
        public void ReRenderField()
        {
            for (int i = 0; i < Canvas.Children.Count; i++)
            {
                Label cell = Canvas.Children[i] as Label;
                cell.Width = Canvas.Width / MenuOptionsData.TableWidth - 10;
                cell.Height = Canvas.Height / MenuOptionsData.TableHeight - 10;
                cell.VerticalContentAlignment = VerticalAlignment.Stretch;
                SetFontSize(cell);
                Canvas.SetLeft(cell, i % MenuOptionsData.TableWidth * Canvas.Width / MenuOptionsData.TableWidth);
                Canvas.SetTop(cell, i / MenuOptionsData.TableWidth * Canvas.Height / MenuOptionsData.TableHeight);
            }
        }
        private void SetFontSize(Label cell)
        {
            if (cell.Width < cell.Height)
                cell.FontSize = cell.Width * 0.60;
            else
                cell.FontSize = cell.Height * 0.60;
        }
        public static void WriteWords(TextBlock tbWords)
        {
            tbWords.Text = "";
            for (int i = 0; i < GameTable.Words.Count; i++)
            {
                tbWords.Text += GameTable.Words[i].Name + "\n";
            }
        }
        private void Letter_Click(object sender, MouseEventArgs e)
        {
            ActualWord.CoordsX.Add(Canvas.Children.IndexOf(sender as Label) % MenuOptionsData.TableWidth);
            ActualWord.CoordsY.Add(Canvas.Children.IndexOf(sender as Label) / MenuOptionsData.TableWidth);
            (sender as Label).Background = Colors[MenuOptionsData.CursorColor];
            (sender as Label).Foreground = Colors[MenuOptionsData.TrueWordColor];
            (sender as Label).RemoveHandler(Label.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Letter_Click));
            if (Game.CheckWord(ActualWord))
            {
                for (int i = 0; i < ActualWord.CoordsX.Count; i++)
                {
                    int index = ActualWord.CoordsY[i] * MenuOptionsData.TableWidth + ActualWord.CoordsX[i];
                    Label cell = Canvas.Children[index] as Label;
                    cell.Background = Brushes.DarkViolet;
                }
                ActualWord.CoordsX.Clear();
                ActualWord.CoordsY.Clear();
            }
            if (Game.GetNextLvl())
            {
                Canvas.Children.Clear();
                CreateField(Game, Canvas);
                AddLabelHandlers();
                SetLNameContent();
            }
        }
        private void ResetLabelHandlers()
        {
            for (int i = 0; i < Canvas.Children.Count; i++)
            {
                if ((Canvas.Children[i] as Label).Background == Brushes.DarkSalmon)
                {
                    Canvas.Children[i].AddHandler(Label.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Letter_Click));
                    (Canvas.Children[i] as Label).Background = Colors[MenuOptionsData.TableColor];
                    (Canvas.Children[i] as Label).Foreground = Colors[MenuOptionsData.WordColor];
                }
            }
        }
        private void AddLabelHandlers()
        {
            for (int i = 0; i < Canvas.Children.Count; i++)
            {
                Canvas.Children[i].AddHandler(Label.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Letter_Click));
            }
        }
        public void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ActualWord.CoordsX.Count; i++)
            {
                int index = ActualWord.CoordsY[i] * MenuOptionsData.TableWidth + ActualWord.CoordsX[i];
                (Canvas.Children[index] as Label).Background = Brushes.DarkSalmon; //Colors[MenuOptionsData.TableColor]
                                                                                   //Colors[MenuOptionsData.WordColor];
            }
            ActualWord.CoordsX.Clear();
            ActualWord.CoordsY.Clear();
            ResetLabelHandlers();
        }
        private void SetLNameContent()
        {
            Info.Content = $"{Game.Gamer.Name}\n{Game.Gamer.Scores}";
        }
    }
}