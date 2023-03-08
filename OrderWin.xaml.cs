using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DriverApplication
{
    /// <summary>
    /// Логика взаимодействия для OrderWin.xaml
    /// </summary>
    public partial class OrderWin : Window
    {

        string ConnectionString;
        SqlDataAdapter adapter;
        DataTable Orders;
        public OrderWin()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
  

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItems != null)
            {
                for (int i = 0; i < OrdersGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = OrdersGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }

        private void OrdersGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        }
      

        private void UpdateDB(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("server = WIN-LJGUDIN31Q3; Trusted_Connection = Yes; DataBase = DriveApp;"))
            {
                connection.Open();
                string cmd = "SELECT * FROM Orders"; // Из какой таблицы нужен вывод 
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Orders"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                OrdersGrid.ItemsSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

    

