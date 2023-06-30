using System;
using System.Windows;


namespace CryptOskin
{
    /// <summary>
    /// Логика взаимодействия для TableSP.xaml
    /// </summary>
    public partial class TableSP : Window
    {
        public TableSP()
        {
            InitializeComponent();
        }
        private int[] key = null;

        public void SetKey(int[] _key)
        {
            
                key = new int[_key.Length];

                for (int i = 0; i < _key.Length; i++)
                    key[i] = _key[i];
            
        }

        public void SetKey(string[] _key)
        {
   
        key = new int[_key.Length];

            for (int i = 0; i < _key.Length; i++)
                key[i] = Convert.ToInt32(_key[i]);
            }
          
        

        public void SetKey(string _key)
        {
            SetKey(_key.Split(' '));
        }

        public string Encrypt(string input)
        {
           


                for (int i = 0; i < input.Length % key.Length; i++)
                    input += input[i];

                string result = "";

                for (int i = 0; i < input.Length; i += key.Length)
                {
                    char[] transposition = new char[key.Length];

                    for (int j = 0; j < key.Length; j++)
                        transposition[key[j] - 1] = input[i + j];

                    for (int j = 0; j < key.Length; j++)
                        result += transposition[j];
                }
                resultTable.Text = result;

                
           return result;

        }

        public string Decrypt(string input)
        {
            string result = "";

            for (int i = 0; i < input.Length; i += key.Length)
            {
                char[] transposition = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                    transposition[j] = input[i + key[j] - 1];

                for (int j = 0; j < key.Length; j++)
                    result += transposition[j];
            }
            resultTable.Text = result;
            return result;
        }
        private void encryptTable(object sender, RoutedEventArgs e)
        {
            try
            {
                SetKey(keyTable.Text);
            
               
                Encrypt(enterdText.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неправильное сообщение или ключ");
            }


        }
        private void decryptTable(object sender, RoutedEventArgs e)
        {
           
            try
            {
                SetKey(keyTable.Text);

                Decrypt(enterdText.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неправильное сообщение или ключ");
            }
        }
    }
}

