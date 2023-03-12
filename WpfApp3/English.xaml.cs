using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для English.xaml
    /// </summary>
    public partial class English : Page
    {
        MySqlDataAdapter adapter;
        DataTable antitable;
        string connectionString;
        public English()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Eng";
            antitable = new DataTable();
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand(sql, connection);
                adapter = new MySqlDataAdapter(command);


                adapter.InsertCommand = new MySqlCommand("gg", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new MySqlParameter("@Name", MySqlDbType.VarChar, 20, "Name"));
                adapter.InsertCommand.Parameters.Add(new MySqlParameter("@Games", MySqlDbType.Int64, 5, "Games"));
                adapter.InsertCommand.Parameters.Add(new MySqlParameter("@Win", MySqlDbType.Int64, 5, "Win"));
                adapter.InsertCommand.Parameters.Add(new MySqlParameter("@Draw", MySqlDbType.Int64, 5, "Draw"));
                adapter.InsertCommand.Parameters.Add(new MySqlParameter("@Lose", MySqlDbType.Int64, 5, "Lose"));
                MySqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", MySqlDbType.Int64, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(antitable);
                dg.ItemsSource = antitable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://yandex.ru/search/?text=манчестер+юнайтед&lr=8&clid=2456107");
        }
    }
}
