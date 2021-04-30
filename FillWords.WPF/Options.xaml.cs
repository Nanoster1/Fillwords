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
        SolidColorBrush[] Colors { get; set; } = { Brushes.Red, Brushes.Blue, Brushes.White, Brushes.Black, Brushes.GreenYellow, Brushes.Chocolate,
                                                   Brushes.Green, Brushes.Gold, Brushes.Pink, Brushes.YellowGreen};

        public Options()
        {
            InitializeComponent();
        }
        private void Click_SaveOpt(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbxFieldWidth.Text, out _) || !int.TryParse(tbxFieldHeight.Text, out _))
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

        private void SliderCursorColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.CursorColor = (int)e.NewValue;
            EnableCell.Background = Colors[MenuOptionsData.CursorColor];
        }
        private void SliderTrueWordColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.TrueWordColor = (int)e.NewValue;
            EnableCell.Foreground = Colors[MenuOptionsData.TrueWordColor];
        }
        private void SliderTableColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.TableColor = (int)e.NewValue;
            StandartCell.Background = Colors[MenuOptionsData.TableColor];
        }
        private void SliderWordColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.WordColor = (int)e.NewValue;
            StandartCell.Foreground = Colors[MenuOptionsData.WordColor];
        }
    }
}
