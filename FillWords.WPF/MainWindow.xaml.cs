using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FillWords.Logic;

namespace FillWords.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly FileWorker fileWorker;
        public MainWindow()
        {
            fileWorker = new FileWorker();
            InitializeComponent();
        }
        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            spContinue.Visibility = Visibility.Collapsed;
            btnContinue.Visibility = Visibility.Visible;
            btnNewGame.Visibility = Visibility.Collapsed;
            spNewGame.Visibility = Visibility.Visible;
        }
        private void BtnCountinue_Click(object sender, RoutedEventArgs e)
        {
            spNewGame.Visibility = Visibility.Collapsed;
            btnNewGame.Visibility = Visibility.Visible;
            btnContinue.Visibility = Visibility.Collapsed;
            spContinue.Visibility = Visibility.Visible;
        }
        private void BtnStartNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (fileWorker.CheckNameInSaves(tbxName1.Text))
            {
                tbxName1.Text = "Имя уже используется";
            }
            else if (tbxName1.Text == "")
            {
                tbxName1.Text = "Введите имя";
            }
            else
            {
                NewGame game = new NewGame(new GamerInfo(tbxName1.Text, 0, GameTable.CreateTable()));
                WGame winWGame = new WGame(game);
                winWGame.Show();
                this.Close();
            }
        }
        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (fileWorker.CheckNameInSaves(tbxName2.Text))
            {
                NewGame game = new NewGame(fileWorker.GetOneSave("Saves\\" + tbxName2.Text + ".txt"));
                game.GetNextLvl();
                WGame winWGame = new WGame(game);
                winWGame.Show();
                this.Close();
            }
            else
                tbxName2.Text = "Игрока с таким именем не существует"; 
        }
        private void BtnCheckSaves_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < fileWorker.Saves.Length; i++)
            {
                if (i % 3 == 0)
                    text.Append(fileWorker.Saves[i].Split("\\")[^1].Replace(".txt", "") + "\n");
                else
                    text.Append(fileWorker.Saves[i].Split("\\")[^1].Replace(".txt", ""));
            }
            MessageBox.Show(text.ToString(), "Сохранения");
        }
        private void BtnRecords_Click(object sender, RoutedEventArgs e)
        {
            Records recordsWindow = new Records();
            recordsWindow.Show();
            this.Close();
        }
        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            Options optionsWindow = new Options();
            optionsWindow.Show();
            this.Close();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           for (int i = 0; i < spMenu.Children.Count; i++)
           {
                if (spMenu.Children[i] is Button)
                {
                    Button button = spMenu.Children[i] as Button;
                    button.Height = ActualHeight / 12;
                    button.Width = ActualWidth / 3;
                    button.FontSize = button.Width * button.Height / 800;
                }
                else
                {
                    StackPanel panel = spMenu.Children[i] as StackPanel;
                    for (int k = 0; k < panel.Children.Count; k++)
                    {
                        (panel.Children[k] as Control).Height = ActualHeight / 12;
                        (panel.Children[k] as Control).Width = ActualWidth / 5;
                        (panel.Children[k] as Control).FontSize = (panel.Children[k] as Control).Width * (panel.Children[k] as Control).Height / 800;
                    }
                }
           }
        }
    }
}
