using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FillWords.Logic;
using System.Text;

namespace Fillwords.Desktop
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

       private void WriteRecords()
       {
           FileWorker file = new FileWorker();
           var tbRecords = this.FindControl<TextBlock>("tbRecords");
           StringBuilder stringBuilder = new StringBuilder();
           for (int i = 0; i < file.Records.Length; i++)
           {
               stringBuilder.Append(file.Records[i] + "\n\n");
           }
           tbRecords.Text = stringBuilder.ToString();
       }
        private void Click_Rec(object sender, RoutedEventArgs e)
        {
            WriteRecords();
            this.FindControl<Grid>("MainMenu").IsVisible = false;
            this.FindControl<Grid>("Records").IsVisible = true;
        }
        private void Click_RecBack(object sender, RoutedEventArgs e)
        {
            this.FindControl<Grid>("MainMenu").IsVisible = true;
            this.FindControl<Grid>("Records").IsVisible = false;
            this.FindControl<Grid>("Options").IsVisible = false;
        }
        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Click_Opt(object sender, RoutedEventArgs e)
        {
            this.FindControl<Grid>("Options").IsVisible = true;
            this.FindControl<Grid>("MainMenu").IsVisible = false;
        }
        private void Click_FieldSize(object sender, RoutedEventArgs e)
        {
            this.FindControl<Button>("btnSizeField").IsVisible = false;
            this.FindControl<StackPanel>("SizeField").IsVisible = true;
        }
        private void Click_SaveOpt(object sender, RoutedEventArgs e)
        {
            var tableColor = this.FindControl<TextBox>("TableColor");
            var cursorColor = this.FindControl<TextBox>("CursorColor");
            var wordColor = this.FindControl<TextBox>("WordColor");
            var trueWordColor = this.FindControl<TextBox>("TrueWordColor");
            var tableHeight = this.FindControl<TextBox>("TableHeight");
            var tableWidth = this.FindControl<TextBox>("TableWidth");
            //Доделать цвет
            if (tableWidth.Text == null && tableHeight.Text == null)
            {
                this.FindControl<Grid>("MainMenu").IsVisible = true;
                this.FindControl<Grid>("Options").IsVisible = false;
            }
            else if (int.Parse(tableHeight.Text) + int.Parse(tableWidth.Text) > 225 || int.Parse(tableHeight.Text) + int.Parse(tableWidth.Text) < 4)
            {
                tableHeight.Text = "Недопустимое значение, максимум - 15, минимум - 4";
                tableWidth.Text = "Недопустимое значение, максимум - 15, минимум - 4";
            }
            else
            {
                MenuOptionsData.TableHeight = int.Parse(tableHeight.Text);
                MenuOptionsData.TableWidth = int.Parse(tableWidth.Text);
                this.FindControl<Grid>("MainMenu").IsVisible = true;
                this.FindControl<Grid>("Options").IsVisible = false;
            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
