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
using System.Windows.Shapes;

namespace lab_
{
    /// <summary>
    /// Логика взаимодействия для second.xaml
    /// </summary>
    public partial class second : Window
    {
        public second()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string result = add_form.GetLineText(0);
            if (string.IsNullOrEmpty(result))
            {
                add_form.Clear();
            }
            else
            {
                list.Items.Add(result);
                add_form.Clear();
            }


        }
        private void Button(object sender, RoutedEventArgs e)
        {

            Window window;
            if (button1.IsFocused)
            {
                window = new MainWindow();
            }
            else if (button3.IsFocused)
            {
                window = new three();
            }
            else if (button4.IsFocused)
            {
                window = new four();
            }
            else if (button5.IsFocused)
            {
                window = new five();
            }
            else if (button6.IsFocused)
            {
                window = new six();
            }
            else window = null;
            window.Show();

        }
    }
}
