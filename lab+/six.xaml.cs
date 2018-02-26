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
    /// Логика взаимодействия для six.xaml
    /// </summary>
    public partial class six : Window
    {
        public six()
        {
            InitializeComponent();

            NameF.Text = "Имя файла.";
            pathF.Text = "Путь к файлу.";
            TextFile.IsEnabled = false;
            save.IsEnabled = false;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();
            this.Read(dlg.FileName);

            pathF.Text = dlg.FileName;

            string[] split = dlg.FileName.Split('\\');
            NameF.Text = split[split.Length - 1];

            NameF.IsEnabled = true;
            pathF.IsEnabled = true;
            TextFile.IsEnabled = true;
            save.IsEnabled = true;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();

            this.Save(dlg.FileName);
        }

        private void Read(string FilePath)
        {
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(FilePath, Encoding.GetEncoding(1251));
            TextFile.Text = "";
            while ((line = file.ReadLine()) != null)
            {
                TextFile.Text += line;
                TextFile.Text += "\n";
            }
            file.Close();
        }
        private void Save(string FilePath)
        {
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(FilePath, true, Encoding.GetEncoding(1251)))
            {
                string line = TextFile.Text;
                outputFile.WriteLine(line);
                outputFile.Close();
            }
            NameF.Text = "Имя файла.";
            pathF.Text = "Путь к файлу.";
            TextFile.Text = "Файл не выбран.";
            TextFile.IsEnabled = false;
            save.IsEnabled = false;
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
            else if (button4.IsFocused)
            {
                window = new four();
                window.Show();
            }

        }
    }
}
