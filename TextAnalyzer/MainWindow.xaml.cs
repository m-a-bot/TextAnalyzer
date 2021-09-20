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
            PrintInformation info = new PrintInformation();
            string text = Field.Text.ToLower();
            string[] words = text.Split(" ,./?-_+=<>\\;:\n\t{}()[]»«'".ToCharArray());
            Sort(words, true);

            for (int i = 0; i < words.Length; i++)
                info.field5.Text += words[i]+"; ";

            //SortedList<string, int> data = new SortedList<string, int>();

            
            
            //info.field1.Text = NumberWords(words).ToString();
            //info.field5.Text = LetterRatio(text);
            info.Show();

        }
        
        private Boolean CompareStrings(string s1, string s2, Boolean tS) // s1 < s2
        {
            int strlen1 = s1.Length, strlen2 = s2.Length;
            if (!tS)
            {
                for (int i = 0; i < Math.Min(strlen1, strlen2); i++)
                {
                    if (s1[i] < s2[i])
                        return true;
                    if (s1[i] > s2[i])
                        return false;
                }
            }
            if (strlen1 < strlen2)
                return true;
            return false;
        }

        // if the typeSorting equals false the array of strings is sorted by lexical type
        // if the typeSorting equals true the array of strings is sorted by their length
        private void Sort(string[] array, Boolean typeSorting = false)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                {
                   if (!CompareStrings(array[i], array[j], typeSorting))
                    {
                        string c = array[j];
                        array[j] = array[i];
                        array[i] = c;
                    }
                }
        }
        
        private int CountVariousWords(string[] symbs)
        {
            int count = 0;
            int n = symbs.Length;
            return 0;
        }
                    

        private string LongWords(string[] symbs)
        {
            return "";
        }
        private string FrequentWords(string[] symbs)
        {
            return "";
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
