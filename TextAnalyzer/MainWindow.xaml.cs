using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.IO;

namespace TextAnalyzer
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

        // Open file
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "(.txt)|*.txt";
            
            dlg.ShowDialog();
            if (dlg.FileName != string.Empty)
            {
                StreamReader fin = new StreamReader(dlg.FileName);
                Field.Text = fin.ReadToEnd();
            }
        }

        // Save file
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Field.Text
        }

        // Print information
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string text = Field.Text;
            string[] words = text.Split(" ,./?-_+=<>;'".ToCharArray());
            new PrintInformation().Show();
        }
    }
}
