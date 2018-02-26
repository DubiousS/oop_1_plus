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

namespace lab_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Convert(char method, string val_1, string val_2)
        {
            
            if (!string.IsNullOrEmpty(val_1) || !string.IsNullOrEmpty(val_2))
            {
                int result = 0;
                if (method == '+') result = int.Parse(val_1) + int.Parse(val_2);
                else if (method == '-') result = int.Parse(val_1) - int.Parse(val_2);
                else if (method == '*') result = int.Parse(val_1) * int.Parse(val_2);
                else if (method == '/') result = int.Parse(val_1) / int.Parse(val_2);
                input.Content = result;
            }

        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            this.Convert('+', textbox1.GetLineText(0), textbox2.GetLineText(0));
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            this.Convert('-', textbox1.GetLineText(0), textbox2.GetLineText(0));
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            this.Convert('*', textbox1.GetLineText(0), textbox2.GetLineText(0));
        }

        private void devine_Click(object sender, RoutedEventArgs e)
        {
            this.Convert('/', textbox1.GetLineText(0), textbox2.GetLineText(0));
        }

       

        private void Button(object sender, RoutedEventArgs e)
        {

            Window window;
            if (button2.IsFocused)
            {
                window = new second();
                window.Show();
            }
            else if (button3.IsFocused)
            {
                window = new three();
                window.Show();
            }
            else if (button4.IsFocused)
            {
                window = new four();
                window.Show();
            }
            else if (button5.IsFocused)
            {
                window = new five();
                window.Show();
            }
            else if (button6.IsFocused)
            {
                window = new six();
                window.Show();
            }

        }
    }
}
