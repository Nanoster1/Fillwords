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
            SetSliders();
            SetCells();
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
        
        private void SetSliders()
        {
            slCursorColor.Value = MenuOptionsData.CursorColor;
            slTableColor.Value = MenuOptionsData.TableColor;
            slWordColor.Value = MenuOptionsData.WordColor;
            slTrueWordColor.Value = MenuOptionsData.TrueWordColor;
        }

        private void SetCells()
        {
            enableCell.Background = Field.Colors[MenuOptionsData.CursorColor];
            enableCell.Foreground = Field.Colors[MenuOptionsData.TrueWordColor];
            standartCell.Background = Field.Colors[MenuOptionsData.TableColor];
            standartCell.Foreground = Field.Colors[MenuOptionsData.WordColor];
        }

        private void SliderCursorColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.CursorColor = (int)e.NewValue;
            enableCell.Background = Field.Colors[MenuOptionsData.CursorColor];
        }
        private void SliderTrueWordColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.TrueWordColor = (int)e.NewValue;
            enableCell.Foreground = Field.Colors[MenuOptionsData.TrueWordColor];
        }
        private void SliderTableColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.TableColor = (int)e.NewValue;
            standartCell.Background = Field.Colors[MenuOptionsData.TableColor];
        }
        private void SliderWordColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MenuOptionsData.WordColor = (int)e.NewValue;
            standartCell.Foreground = Field.Colors[MenuOptionsData.WordColor];
        }
    }
}
