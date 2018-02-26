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
    /// Логика взаимодействия для five.xaml
    /// </summary>
    public partial class five : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;
        byte sec = 0;
        bool pause = false;

        public five()
        {
            InitializeComponent();
            this.Timer = new System.Windows.Threading.DispatcherTimer();
            this.Timer.Interval = new TimeSpan(0, 0, 1);
            this.Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            time1.Text = "- : - : -";
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.pause = false;
            this.Timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.sec++;
            if (!this.pause) {
                if (second.IsChecked == true && minuts.IsChecked == true && hours.IsChecked == true)
                    time1.Text = (this.sec / 3600 + " : " + this.sec / 60 + " : " + this.sec % 60).ToString();
                else if (second.IsChecked == true && minuts.IsChecked == true)
                    time1.Text = ("- : " + this.sec / 60 + " : " + this.sec % 60).ToString();
                else if (second.IsChecked == true && hours.IsChecked == true)
                    time1.Text = (this.sec / 3600 + " : - : " + this.sec % 60).ToString();
                else if (hours.IsChecked == true && minuts.IsChecked == true)
                    time1.Text = (this.sec / 3600 + " : " + this.sec % 60 + ": -").ToString();
                else if (second.IsChecked == true) time1.Text = ("- : - : " + this.sec).ToString();
                else if (minuts.IsChecked == true) time1.Text = ("- : " + this.sec / 60 + " : -").ToString();
                else if (hours.IsChecked == true) time1.Text = (this.sec / 3600 + " : - : -").ToString();
                else time1.Text = "- : - : -";
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            this.pause = true;
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            this.Timer.Stop();
            this.pause = true;
            this.sec = 0;
            time1.Text = "- : - : -";
        }

        private void Button(object sender, RoutedEventArgs e)
        {

            Window window;
            this.Timer.Stop();
            this.sec = 0;
            time1.Text = "- : - : -";
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
            else if (button1.IsFocused)
            {
                window = new MainWindow();
                window.Show();
            }
            else if (button4.IsFocused)
            {
                window = new four();
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
