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
    /// Логика взаимодействия для Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Options()
        {
            InitializeComponent();
        }

        private void btnSizeField_Click(object sender, RoutedEventArgs e)
        {
            btnSizeField.Visibility = Visibility.Hidden;
            spSizeField.Visibility = Visibility.Visible;
        }
        private void Click_SaveOpt(object sender, RoutedEventArgs e)
        {
            //Доделать цвет
            if (tbxFieldWidth.Text == "" || tbxFieldHeight.Text == "")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (int.Parse(tbxFieldHeight.Text) * int.Parse(tbxFieldWidth.Text) > 100 || int.Parse(tbxFieldHeight.Text) * int.Parse(tbxFieldWidth.Text) < 4)
            {
                tbxFieldHeight.Text = "Недопустимое значение, максимум символов - 100, минимум - 4";
                tbxFieldWidth.Text = "Недопустимое значение, максимум символов - 100, минимум - 4";
            }
            else
            {
                MenuOptionsData.TableHeight = int.Parse(tbxFieldHeight.Text);
                MenuOptionsData.TableWidth = int.Parse(tbxFieldWidth.Text);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
