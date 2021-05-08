using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using FillWords.Logic;

namespace FillWords.WPF
{
    public partial class WGame : Window
    {
        private NewGame Game { get; set; }
        private Field Field { get; set; }
        public WGame(NewGame game)
        {
            InitializeComponent();
            Game = game;
            Field = new Field(canvas, game, lInfo);
            btnCancel.Click += Field.BtnCancel_Click;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Width = e.NewSize.Width / 3 * 2;
            canvas.Height = Row.ActualHeight;
            Field.ReRenderField();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.fileWorker.CreateSave(Game.Gamer);
            mainWindow.fileWorker.WriteRecord(Game.Gamer);
            mainWindow.Show();
        }
        private void BtnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}