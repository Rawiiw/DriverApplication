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
using System.Configuration;

namespace DriverApplication
{
    /// <summary>
    /// Логика взаимодействия для DriverWin.xaml
    /// </summary>
    public partial class DriverWin : Window
    {
        string ConnectionString;
        SqlDataAdapter adapter;
        DataTable Driver;
        public DriverWin()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateDB(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("server = WIN-LJGUDIN31Q3; Trusted_Connection = Yes; DataBase = DriveApp;"))
            {
                connection.Open();
                string cmd = "SELECT * FROM Driver"; // Из какой таблицы нужен вывод 
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Driver"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                DriverGrid.ItemsSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriverGrid.SelectedItems != null)
            {
                for (int i = 0; i < DriverGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = DriverGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
        }

        private void DriverGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
