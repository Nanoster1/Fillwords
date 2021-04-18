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
        SolidColorBrush[] Colors { get; set; } = { Brushes.Red, Brushes.Blue, Brushes.White, Brushes.Black, Brushes.GreenYellow, Brushes.Chocolate, Brushes.Green, Brushes.Gold, Brushes.Pink, Brushes.YellowGreen};
        public Options()
        {
            InitializeComponent();
            AddLabels(spCursorColor);
            AddLabels(spTableColor);
            AddLabels(spWordColor);
            AddLabels(spTrueWordColor);
        }

        private void btnSizeField_Click(object sender, RoutedEventArgs e)
        {
            btnSizeField.Visibility = Visibility.Collapsed;
            spSizeField.Visibility = Visibility.Visible;
        }
        private void Click_SaveOpt(object sender, RoutedEventArgs e)
        {
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
        private void AddLabels(StackPanel panel)
        {
            for (int i = 0; i < Colors.Length; i++)
            {
                Label label = new Label();
                label.Content = $"Color{i}";
                label.Width = Width/10;
                label.Background = Colors[i];
                label.MouseLeftButtonDown += Label_MouseLeftButtonDown;
                label.Foreground = Brushes.Aqua;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                panel.Children.Add(label);
            }
        }
        private void SetColorLabel(StackPanel panel)
        {
            for (int i = 0; i < panel.Children.Count; i++)
            {
                (panel.Children[i] as Label).Foreground = Brushes.Aqua;
            }
        }
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int index = Array.IndexOf(Colors, (sender as Label).Background);
            SetColorLabel(((sender as Label).Parent as StackPanel));
            (sender as Label).Foreground = Brushes.Gray;
            if ((sender as Label).Parent == spCursorColor)
            {
                MenuOptionsData.CursorColor = index;
            }
            else if ((sender as Label).Parent == spTableColor)
            {
                MenuOptionsData.TableColor = index;
            }
            else if ((sender as Label).Parent == spTrueWordColor)
            {
                MenuOptionsData.TrueWordColor = index;
            }
            else
            {
                MenuOptionsData.WordColor = index;
            }
        }

        private void Win_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            for (int i = 0; i < spCursorColor.Children.Count; i++)
            {
                (spCursorColor.Children[i] as Label).Width = ActualWidth / 10;
                (spTableColor.Children[i] as Label).Width = ActualWidth / 10;
                (spTrueWordColor.Children[i] as Label).Width = ActualWidth / 10;
                (spWordColor.Children[i] as Label).Width = ActualWidth / 10;
                (spCursorColor.Children[i] as Label).FontSize = ActualWidth / 60;
                (spTableColor.Children[i] as Label).FontSize = ActualWidth / 60;
                (spTrueWordColor.Children[i] as Label).FontSize = ActualWidth / 60;
                (spWordColor.Children[i] as Label).FontSize = ActualWidth / 60;
            }
            ChangeSizeAllButtons();
        }
        void ChangeSizeButton(Button button)
        {
            if (button.ActualHeight < button.ActualWidth)
            {
                button.FontSize = button.ActualHeight;
                if (button.ActualWidth < button.Content.ToString().Length * button.FontSize)
                    button.FontSize = button.Content.ToString().Length * button.ActualHeight - button.ActualWidth;
            }
            else
                button.FontSize = ActualWidth / button.Content.ToString().Length;
        }
        void ChangeSizeAllButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                ChangeSizeButton(Grid.Children[i] as Button);
            }
        }

        private void btnCursorColor_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility();
            (sender as Button).Visibility = Visibility.Collapsed;
            int index = Grid.GetRow(sender as Button);
            spCursorColor.Visibility = Visibility.Visible;
        }
        private void btnCellColor_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility();
            btnCellColor.Visibility = Visibility.Collapsed;
            spTableColor.Visibility = Visibility.Visible;
        }
        private void btnWordColor_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility();
            btnWordColor.Visibility = Visibility.Collapsed;
            spWordColor.Visibility = Visibility.Visible; 
        }
        private void btnTrueWordColor_Click(object sender, RoutedEventArgs e)
        {
            SetVisibility();
            btnTrueWordColor.Visibility = Visibility.Collapsed;
            spTrueWordColor.Visibility = Visibility.Visible;
        }
        private void SetVisibility()
        {
            for (int i = 0; i < Grid.Children.Count; i++)
            {
                if (Grid.Children[i] is Button)
                    (Grid.Children[i] as Button).Visibility = Visibility.Visible;
                else if (Grid.Children[i] is StackPanel)
                    (Grid.Children[i] as StackPanel).Visibility = Visibility.Collapsed;
            }
        }
    }
}
