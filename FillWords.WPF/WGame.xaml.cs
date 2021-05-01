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
    public partial class WGame : Window
    {
        NewGame Game { get; set; }
        Word ActualWord { get; set; } = new Word();
        public WGame(NewGame game)
        {
            InitializeComponent();
            RenderField.SetField(Field);
            Game = game;
            RenderField.CreateField(Game, Field);
            AddLabelHandlers();
            RenderField.WriteWords(tbWords);
            SetLNameContent();
        }

        private void Letter_Click(object sender, MouseButtonEventArgs e)
        {
            ActualWord.CoordsX.Add(Field.Children.IndexOf(sender as Label) % MenuOptionsData.TableWidth);
            ActualWord.CoordsY.Add(Field.Children.IndexOf(sender as Label) / MenuOptionsData.TableWidth);
            (sender as Label).Background = RenderField.Colors[FillWords.Logic.MenuOptionsData.CursorColor];
            if (Game.CheckWord(ActualWord))
            {
                for (int i = 0; i < ActualWord.CoordsX.Count; i++)
                {
                    int index = ActualWord.CoordsY[i] * MenuOptionsData.TableWidth + ActualWord.CoordsX[i];
                    Label cell = Field.Children[index] as Label;
                    cell.Background = RenderField.Colors[FillWords.Logic.MenuOptionsData.TrueWordColor];
                    cell.RemoveHandler(Label.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Letter_Click));
                }
                ActualWord.CoordsX.Clear();
                ActualWord.CoordsY.Clear();
            }
            if (Game.GetNextLvl())
            {
                Field.Children.Clear();
                tbWords.Text = "";
                RenderField.CreateField(Game, Field);
                AddLabelHandlers();
                SetLNameContent();
            }
        }
        private void AddLabelHandlers()
        {
            for (int i = 0; i < Field.Children.Count; i++)
            {
                Field.Children[i].AddHandler(Label.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Letter_Click));
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ActualWord.CoordsX.Count; i++)
            {
                int index = ActualWord.CoordsY[i] * MenuOptionsData.TableWidth + ActualWord.CoordsX[i];
                (Field.Children[index] as Label).Background = RenderField.Colors[FillWords.Logic.MenuOptionsData.TableColor];
            }
            ActualWord.CoordsX.Clear();
            ActualWord.CoordsY.Clear();
        }
        private void BtnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.fileWorker.CreateSave(Game.Gamer);
            mainWindow.fileWorker.WriteRecord(Game.Gamer);
            mainWindow.Show();
            this.Close();
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Field.Width = e.NewSize.Width / 3 * 2;
            Field.Height = Row.ActualHeight;
            RenderField.ReRenderField();
        }

        private void SetLNameContent()
        {
            LName.Content = $"{Game.Gamer.Name}\nОчки: {Game.Gamer.Scores}";
        }
    }
}
