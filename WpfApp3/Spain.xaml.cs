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
    /// Логика взаимодействия для Spain.xaml
    /// </summary>
    public partial class Spain : Page
    {
        MySqlDataAdapter adapter;
        DataTable antitable;
        string connectionString;
        public Spain()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Spain";
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
            Process.Start("https://yandex.ru/search/?text=Реал+Мадрид&lr=8&clid=2456107&ento=0zH4sIAAAAAAAAAx3PMW_qMBQFYKldqje-qWP3SsWJG6iHDsSA0-Bazw6EOBtxWiCNAZHEafkr_a1P6qXbla50znf-3Jy63hv5KPj7fV037UNTW1p9zMNI1W-RTF4z8V5gFRi2HC5wvOee6Asco5Sl22IZumI3tvEuPGe4PK79-l37M5SvzNDsUywWy0BA1qw_zIxNmzzTycTmzljPK9iUaJ-0xYp0tDLzMFPHkn3W091IHgWbIM1lU9J7xJ2qBCVIO9kmE9m1dIT0P_gx_iKoRjqSjtAecSw7QR-pfZxTLFyZxVWekma9Ck7TmhzKSPXmfHAcxx7f_1r7fKWOOgnAY1zp16d1MpC2hSzobkt6RnykNpCJ9NMQzRdqQxhFHPp-DWfpwID4coP4SXYEzDxSu6-JtIKFiA9kc3HzSnbjQ0c33pcGC3j2GQ63xs7a6RZf7PewYwBdcF8yYC9h48se10IOWLrx8_Pt1dP_O-8HEixpBa4BAAA&noreask=1&es_context=0zH4sIAAAAAAAAA0VUu44UQQwMSGBOSMQEiBhphJ9tdwgxEkLwA3toRXIcaA_EJxAi8V18FDXT7p3M6622y1X23P5elseXn784hHyPXNNyeYIowrfksv3t7tL7nrbk3mQPOZplXJ-1PaktwwZUg1xsDxtJc666kVZ1g7lz7GnxbOEFbupSiPBIGjFpi3bQjD0rkh7eZj0y0hFbJ9KKe7fGVrFGRk6MSVYdgBTEx7xEwQNjCkTUW2dCs-rl1GgwE1KOPhgLiuTEC3hOfAsBvxGnhmRxbgTMEDQEFUdJ1XRtA6KcwsRTkBZaJbts_Pc4OxpP-kFw6aCsTlOGZB94iY2m19sQE5tvqdPEwAi1GpGTSJab3QgIC1jNQmau88G1GWTAKkyt1KQNvLo37Tx1tugj32DA9JS75xx-WxD4Pt4Ss1HFsqtbGPOpv0GtsMEnsqPbVYjI8tThLuesiWF8Dp-Aj76CLbcm0wAwGjG2Cu75cnO-x6ImubIcw-RcWzEvxyRxUTwIKZjxERvVIYAEiffZLFWqMeAhVzzNmoYb8u5FyFvOQ8VpYeRZE5pXHXCzGHHrKRhhCNTIZHMYw7j2Y8saVkXmLGpcBwMDxEsgZLFaecxVIqIXDK68Zzed_JEtIy3hJA08pGqMXpugLtgzomrg-CYEPXvx_AOOJ5uaG2pgqXRlfCEiOo5UUcfSlPr6cHrQlbL39TbO26_1Ltbb093p_vP5sibMWt--ebfiovnlo1dP31--vP74_dvlx6fz6evf878__wG3nxULDgUAAA");
        }
    }
}
