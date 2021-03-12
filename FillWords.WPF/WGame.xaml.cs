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
    /// <summary>
    /// Логика взаимодействия для WGame.xaml
    /// </summary>
    public partial class WGame : Window
    {
        private NewGame Game { get; set; }
        private Word ActualWord { get; set; } = new Word();
        public WGame(NewGame game)
        {
            InitializeComponent();
            Game = game;
            CreateField();
        }
        public void CreateField()
        {
            Field.Width = 80 * MenuOptionsData.TableWidth;
            char[,] table = Game.Gamer.Table;
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
                    label.AddHandler(Label.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Letter_Click));
                    Field.Children.Add(label);
                }
            }
            for (int i = 0; i < GameTable.Words.Count; i++)
            {
                tbWords.Text += GameTable.Words[i].Name + "\n";
            }
        }
        private void Letter_Click(object sender, MouseButtonEventArgs e)
        {
            ActualWord.CoordsX.Add(Field.Children.IndexOf(sender as Label) % MenuOptionsData.TableWidth);
            ActualWord.CoordsY.Add(Field.Children.IndexOf(sender as Label) / MenuOptionsData.TableWidth);
            (sender as Label).Background = Brushes.Green;
            if (Game.CheckWord(ActualWord))
            {
                for (int i = 0; i < ActualWord.CoordsX.Count; i++)
                {
                    int index = ActualWord.CoordsY[i] * MenuOptionsData.TableWidth + ActualWord.CoordsX[i];
                    (Field.Children[index] as Label).Background = Brushes.Blue;
                }
                ActualWord.CoordsX.Clear();
                ActualWord.CoordsY.Clear();
            }
            if (Game.GetNextLvl())
            {
                Field.Children.Clear();
                tbWords.Text = "";
                CreateField();
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ActualWord.CoordsX.Count; i++)
            {
                int index = ActualWord.CoordsY[i] * MenuOptionsData.TableWidth + ActualWord.CoordsX[i];
                (Field.Children[index] as Label).Background = Brushes.Black;
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
    }
}
