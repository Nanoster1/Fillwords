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
    /// Логика взаимодействия для Records.xaml
    /// </summary>
    public partial class Records : Window
    {
        public Records()
        {
            InitializeComponent();
            tbRecords.Text = GetRecords();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string GetRecords()
        {
            FileWorker fileWorker = new FileWorker();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < fileWorker.Records.Length; i++)
            {
                stringBuilder.Append(fileWorker.Records[i] + "\n\n");
            }
            return stringBuilder.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
