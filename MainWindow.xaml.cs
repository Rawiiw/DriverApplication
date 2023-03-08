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

namespace DriverApplication
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

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderWin order = new OrderWin();
            order.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            ClientWin client = new ClientWin();
            client.Show();
        }

        private void Driver_Click(object sender, RoutedEventArgs e)
        {
            DriverWin driver = new DriverWin();     
            driver.Show();
        }

        private void Address_Click(object sender, RoutedEventArgs e)
        {
            AddressWin address = new AddressWin();  
                address.Show();
        }
    }
}
