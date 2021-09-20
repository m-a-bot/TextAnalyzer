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
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.DefaultExt = ".txt";
            sdlg.Filter = "(.txt)|*.txt";

            sdlg.ShowDialog();
        }

        // Print information
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string text = Field.Text;
            string[] words = text.Split(" ,./?-_+=<>;'\n\t".ToCharArray());
            PrintInformation info = new PrintInformation();
            info.field1.Text = NumberWords(words).ToString();
            info.field5.Text = LetterRatio(text);
            info.Show();

        }
        private int CountVariousWords(string[] symbs)
        {
            ;
        }
        private string LongWords(string[] symbs)
        {

        }
        private string FrequentWords(string[] symbs)
        {

        }
        private int NumberWords(string[] symbs)
        {
            return symbs.Length;
        }
        private string LetterRatio(string words)
        {
            string res = "";
            string Symbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя" + "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < Symbols.Length; i++)
                letters.Add(Symbols[i], 0);
            int count = 0;
            foreach (char ch in words)
            {
                try
                {
                    letters[ch]++;
                    count++;
                } catch
                {
                }
            }
            foreach (KeyValuePair<char, int> keyValue in letters)
            {
                if (keyValue.Value != 0)
                {
                    res += keyValue.Key + "-" + Math.Round(keyValue.Value * 100.0 / count, 1) + "%; ";
                }
            }
            return res;
        }

    }
}
