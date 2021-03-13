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
        public readonly FileWorker fileWorker = new FileWorker();
        public MainWindow()
        {
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
        private string GetRecords()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < fileWorker.Records.Length; i++)
            {
                stringBuilder.Append(fileWorker.Records[i] + "\n\n");
            }
            return stringBuilder.ToString();
        }
        private void BtnRecords_Click(object sender, RoutedEventArgs e)
        {
            Records recordsWindow = new Records();
            recordsWindow.tbRecords.Text = GetRecords();
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
    }
}
