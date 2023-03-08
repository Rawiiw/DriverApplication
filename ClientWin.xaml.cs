using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace DriverApplication
{
    /// <summary>
    /// Логика взаимодействия для ClientWin.xaml
    /// </summary>
    public partial class ClientWin : Window
    {
        string ConnectionString;
        SqlDataAdapter adapter;
        DataTable Client;
        public ClientWin()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void UpdateDB(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("server = WIN-LJGUDIN31Q3; Trusted_Connection = Yes; DataBase = DriveApp;"))
            {
                connection.Open();
                string cmd = "SELECT * FROM Client"; // Из какой таблицы нужен вывод 
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Client"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                ClientGrid.ItemsSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
        }

        private void OrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientGrid.SelectedItems != null)
            {
                for (int i = 0; i < ClientGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = ClientGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }
    }
}
