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
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "(.txt)|*.txt"
            };

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
            SaveFileDialog sdlg = new SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "(.txt)|*.txt"
            };

            sdlg.ShowDialog();
        }

        // Print information
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrintInformation info = new PrintInformation();
            string text = Field.Text.ToLower();

            string comp = " ,./?-_+=<>\\;:\n\t{}()[]»«'";
            string res = "";
            List<string> words = new List<string>();
            for (int i=0; i<text.Length; i++)
            {
                if (comp.IndexOf(text[i]) == -1)
                    res += text[i];
                else
                {
                    if (res != "")
                        words.Add(res);
                    res = "";
                }
            }
            words.Add(res);

            int n = words.Count;
            info.field1.Text = n.ToString();
            Sort(words);

            string sr = words[0];
            
            int count = 1;
            int k = 1;
            
            List<int> CountStr = new List<int>();
            List<string> Strs = new List<string>();
            
            for (int i=1; i < n; i++)
            {
                
                if (sr != words[i])
                {
                    count++;
                    Strs.Add(sr);
                    CountStr.Add(k);
                    k = 1;
                }
                else
                {
                    k++;
                }
                sr = words[i];
            }

            if (!Strs.Contains(sr))
            {
                Strs.Add(sr);
                CountStr.Add(k);
            }

            int m = CountStr.Count;
            for (int i=0; i<m-1; i++)
            {
                 for (int j=i+1; j<m; j++)
                {
                    if (CountStr[i] > CountStr[j])
                    {
                        int cN = CountStr[j];
                        string cS = Strs[j];
                        CountStr[j] = CountStr[i];
                        CountStr[i] = cN;
                        Strs[j] = Strs[i];
                        Strs[i] = cS;
                    }
                }
            }

            try
            {
                for (int i = m - 1; i > m - 11; i--)
                    info.field4.Text += Strs[i]+" - "+ CountStr[i] + "; ";
            } catch
            {

            }

            info.field2.Text = count.ToString();

            


            Sort(words, true);
            try
            {
                for (int i = n - 1; i > n - 11; i--)
                    info.field3.Text += words[i] + "; ";
            } catch (System.ArgumentOutOfRangeException)
            {

            }

            info.field5.Text = LetterRatio(text);
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
        private void Sort(List<string> array, Boolean typeSorting = false)
        {
            int n = array.Count;
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
