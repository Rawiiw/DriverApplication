using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace DriverApplication
{
    /// <summary>
    /// Логика взаимодействия для AddressWin.xaml
    /// </summary>
    public partial class AddressWin : Window
    {
        string ConnectionString;
        SqlDataAdapter adapter;
        DataTable Address;
        public AddressWin()
        {
            InitializeComponent();
        }

    

        private void AddressGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateDB(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("server = WIN-LJGUDIN31Q3; Trusted_Connection = Yes; DataBase = DriveApp;"))
            {
                connection.Open();
                string cmd = "SELECT * FROM Address"; // Из какой таблицы нужен вывод 
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Address"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                AddressGrid.ItemsSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
        }
    

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
