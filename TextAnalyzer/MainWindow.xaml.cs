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
            if (dlg.FileName == string.Empty) return;
            StreamReader fin = new StreamReader(dlg.FileName);
            Field.Text = fin.ReadToEnd();
            fin.Close();
        }

        // Save file
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "(.txt)|*.txt"
            };

            string[] result = ResultPr(Field.Text.ToLower());
            string str = "Количество слов : " + result[0] + "\n" +
                "Количество уникальных слов : " + result[1] + "\n" +
                "10 самых длинных слов : " + result[2] + "\n" +
                "10 самых часто встречающихся слов : " + result[3] + "\n" +
                "Процентное соотношение букв в тексте : " + result[4] + "\n";
            sdlg.ShowDialog();
            if (sdlg.FileName == string.Empty) return;
            StreamWriter fout = new StreamWriter(sdlg.FileName);
            fout.WriteLine(str);
            fout.Close();
        }

        private string[] ResultPr (string text)
        {
            if (text.Length == 0)
            {
                return new string[] { "0", "0", "", "", "" };
            }
            const string Symbols = " ,./?-_+=<>\\;:\n\t{}()[]»«'";
            string res = "";

            string[] result = new string[5];
            for (int i = 0; i < 5; i++)
                result[i] = "";

            List<string> words = new List<string>();
            List<int> CountStr = new List<int>();
            List<string> Strs = new List<string>();

            /* 
             From this string is removed extra symbols and it is divided by array of strings
             */
            for (int i = 0; i < text.Length; i++)
            {
                if (Symbols.IndexOf(text[i]) == -1)
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
            result[0] = n.ToString();
            
            words.Sort();
            //Sort(words);

            string sr = words[0];
            int count = 1;
            int k = 1;

            for (int i = 1; i < n; i++)
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
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = i + 1; j < m; j++)
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

            for (int i = m - 1; i > m - 11; i--)
            {
                try
                {
                    result[3] += Strs[i] + "; ";
                }
                catch
                {
                    break;
                }
            }
            result[1] = count.ToString();

            StringsCompare sCompare = new StringsCompare();

            words.Sort(sCompare);
            for (int i = n - 1; i > n - 11; i--)
            {
                try
                {
                    result[2] += words[i] + "; ";
                }
                catch
                {
                    break;
                }
            }
            result[4] = LetterRatio(text);
            return result;
        }

        // Print information
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrintInformation info = new PrintInformation();
            info.Show();
            try
            {
                string[] r = ResultPr(Field.Text.ToLower());
                info.field1.Text = r[0];
                info.field2.Text = r[1];
                info.field3.Text = r[2];
                info.field4.Text = r[3];
                info.field5.Text = r[4];
                
            } catch { }
            
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
    class StringsCompare : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            if (x.Length > y.Length)
                return 1;
            else if (x.Length < y.Length)
                return -1;
            return 0;
            throw new NotImplementedException();
        }
    }

}
