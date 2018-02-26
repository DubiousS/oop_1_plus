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
    /// Логика взаимодействия для four.xaml
    /// </summary>
    public partial class four : Window
    {
        int year_now;
        int month_now;
        int day_now;
        int amount_years;
        int amount_month;
        int amount_day;

        public four()
        {
            InitializeComponent();
            DateTime date = DateTime.Now;
            this.year_now = int.Parse(date.ToString("yyyy"));
            this.month_now = int.Parse(date.ToString("MM"));
            this.day_now = int.Parse(date.ToString("dd"));
            for (int i = year_now; i > 1812; i--)
            { 
                years.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 12; i++)
            {
                month.Items.Add(i.ToString());
            }
            result.Text = string.Concat("Years: -",
                                        "\nMonth: -",
                                        "\nDays: -");
        }
        public void AddInDay(int day)
        {
            for (int i = 1; i <= day; i++)
            {
                days.Items.Add(i.ToString());
            }
        }
        public int dayInMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return 31;
                case 2:
                    if ((int.Parse(years.Items[years.SelectedIndex].ToString()) % 4 == 0 &&
                        int.Parse(years.Items[years.SelectedIndex].ToString()) % 100 != 0) ||
                        int.Parse(years.Items[years.SelectedIndex].ToString()) % 400 == 0)
                    {
                        return 29;
                    }
                    else {
                        return 28;
                    }
                case 3:
                    return 31;
                case 4:
                    return 30;
                case 5:
                    return 31;
                case 6:
                    return 30;
                case 7:
                    return 31;
                case 8:
                    return 31;
                case 9:
                    return 30;
                case 10:
                    return 31;
                case 11:
                    return 30;
                case 12:
                    return 31;
                default:
                    break;
            }
            return -1;
        }
        private void month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = days.SelectedIndex;
            days.Items.Clear();
            if (years.SelectedIndex != -1 && month.SelectedIndex != -1) {
                if (int.Parse(month.Items[month.SelectedIndex].ToString()) == this.month_now &&
                        int.Parse(years.Items[years.SelectedIndex].ToString()) == this.year_now) {
                    for (int i = 1; i <= this.day_now; i++)
                    {
                        days.Items.Add(i.ToString());
                    }
                } else this.AddInDay(dayInMonth(int.Parse(month.Items[month.SelectedIndex].ToString())));
                if (selected > dayInMonth(int.Parse(month.Items[month.SelectedIndex].ToString())))
                {
                    if (int.Parse(month.Items[month.SelectedIndex].ToString()) == this.month_now &&
                        int.Parse(years.Items[years.SelectedIndex].ToString()) == this.year_now)
                    {
                        days.SelectedIndex = this.day_now - 1;
                    } else days.SelectedIndex = dayInMonth(int.Parse(month.Items[month.SelectedIndex].ToString())) - 1;
                } else days.SelectedIndex = selected;
            }
            if (month.SelectedIndex != -1 && years.SelectedIndex != -1 && days.SelectedIndex != -1)
            {
                Amount();
            }   
        }

        private void years_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = month.SelectedIndex;
            month.Items.Clear();
            if (int.Parse(years.Items[years.SelectedIndex].ToString()) == this.year_now)
            {  
                
                for (int i = 1; i <= this.month_now; i++)
                {
                    month.Items.Add(i.ToString());
                }
            } else
            {
                for (int i = 1; i <= 12; i++)
                {
                    month.Items.Add(i.ToString());
                }
            }

            if (selected > month.Items.Count - 1)
            {
                month.SelectedIndex = int.Parse(month.Items.GetItemAt(month.Items.Count - 1).ToString()) - 1;
            }
            else month.SelectedIndex = selected;
            Amount();
        }
        public void Amount()
        {

            if (month.SelectedIndex != -1 && years.SelectedIndex != -1 && days.SelectedIndex != -1) {

                int y = int.Parse(years.Items[years.SelectedIndex].ToString());
                int m = int.Parse(month.Items[month.SelectedIndex].ToString());
                int d = int.Parse(days.Items[days.SelectedIndex].ToString());

                string DateParse = string.Concat(y);
                if (m / 10 == 0) {
                    DateParse = string.Concat(DateParse, "0", m);
                } else DateParse = string.Concat(DateParse, m);
                if (d / 10 == 0)
                {
                    DateParse = string.Concat(DateParse, "0", d);
                }
                else DateParse = string.Concat(DateParse, d);

                DateTime Input = DateTime.ParseExact(DateParse, "yyyyMMdd", null);
                TimeSpan temp = DateTime.Today - Input;

                this.amount_years = temp.Days / 365;
                this.amount_month = this.amount_years * 12;
                this.amount_day = temp.Days;


                result.Text = string.Concat("Years: ", this.amount_years, 
                                            "\nMonth: ", this.amount_month, 
                                            "\nDays: ", this.amount_day);
            } else
            {
                result.Text = string.Concat("Years: -",
                                            "\nMonth: -",
                                            "\nDays: -");
            }
        }

        private void days_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Amount();
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
            else if (button1.IsFocused)
            {
                window = new MainWindow();
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
