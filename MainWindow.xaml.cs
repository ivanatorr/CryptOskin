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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptOskin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnCesar(object sender, RoutedEventArgs e)
        {

            Cesar cesar = new Cesar();
            cesar.Owner = this;
            cesar.Show();
        }
        private void btnVig(object sender, RoutedEventArgs e)
        {

            Vigner vigner = new Vigner();
            vigner.Owner = this;
            vigner.Show();
        }
        private void btnTable(object sender, RoutedEventArgs e)
        {

            TableSP table = new TableSP();
            table.Owner = this;
            table.Show();
        }
    }
}
