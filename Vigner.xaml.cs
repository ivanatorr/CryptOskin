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
    /// Логика взаимодействия для Vigner.xaml
    /// </summary>
    public partial class Vigner : Window
    {
        private string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";

        public Vigner()
        {
            InitializeComponent();
        }

        private string GetRepeatKey(string key, int n)
        {
            var p = key;
            while (p.Length < n)
            {
                p += p;
            }

            return p.Substring(0, n);
        }
        private void Vigenere(string text, string password, bool encrypting = true)
        {
            var key = GetRepeatKey(password, text.Length);
            var retValue = "";
            var alphLength = alphabet.Length;

            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = alphabet.IndexOf(text[i]);
                var codeIndex = alphabet.IndexOf(key[i]);
                if (letterIndex < 0)
                {
                    retValue += text[i].ToString();
                }
                else
                {
                    retValue += alphabet[(alphLength + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % alphLength].ToString();
                }
            }
            resultVig.Text = retValue;


        }
        private void encryptVigBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                string plainMessage = enterdText.Text.ToLower();
                string password = keyVig.Text.ToLower();
                Vigenere(plainMessage, password);
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неправильное сообщение или ключ");
            }

        }
        private void decryptVigBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                string encryptedMessage = enterdText.Text.ToLower();
                string password = keyVig.Text.ToLower();
                Vigenere(encryptedMessage, password, false);
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неправильное сообщение или ключ");
            }

        }

    }
}

