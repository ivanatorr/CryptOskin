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

namespace CryptOskin
{
    /// <summary>
    /// Логика взаимодействия для Cesar.xaml
    /// </summary>
    public partial class Cesar : Window
    {
        private string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
        public Cesar()
        {
            InitializeComponent();
        }
        private void encryptCesar(object sender, RoutedEventArgs e)
        {
            try
            {
                string inp = enterdText.Text.ToLower();
                string outp = string.Empty;
                int key = Int32.Parse(keyCesar.Text.ToString());
                for (int i = 0; i < inp.Length; i++)
                {
                    int offset = (alphabet.IndexOf(inp[i]) + key) % alphabet.Length;
                    if (offset > alphabet.Length)
                        offset = offset - alphabet.Length;
                    else if (offset < 0)
                        offset = alphabet.Length + offset;
                    outp += alphabet[offset];
                }
                resultCesar.Text = outp;
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неправильное сообщение или ключ");
            }
        }

        private void decryptCesar(object sender, RoutedEventArgs e)
        {
            try
            {
                string inp = enterdText.Text.ToLower();
                string outp = string.Empty;
                int key = Int32.Parse(keyCesar.Text.ToString());
                for (int i = 0; i < inp.Length; i++)
                {
                    int offset = (alphabet.IndexOf(inp[i]) - key) % alphabet.Length;
                    if (offset > alphabet.Length)
                        offset = offset - alphabet.Length;
                    else if (offset < 0)
                        offset = alphabet.Length + offset;
                    outp += alphabet[offset];
                }
                resultCesar.Text = outp;
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неправильное сообщение или ключ");
            }
        }


    }
}

