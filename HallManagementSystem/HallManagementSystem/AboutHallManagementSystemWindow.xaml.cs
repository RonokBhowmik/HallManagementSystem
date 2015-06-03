using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace HallManagementSystem
{
    /// <summary>
    /// Interaction logic for AboutHallManagementSystemWindow.xaml
    /// </summary>
    public partial class AboutHallManagementSystemWindow : Window
    {
        public AboutHallManagementSystemWindow()
        {
            InitializeComponent();
            CurrentHallInfo();
            ShowTheAvailableSeats();
            
        }
        //Make a connection with the database
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;

        private void CurrentHallInfo()
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand("uspcurrenthallinfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds,"CurrentHallInfo");

                totalBlocksTextBlock.Text = ds.Tables[0].Rows[0]["TotalBlocks"].ToString();
                totalRoomsTextBlock.Text = ds.Tables[0].Rows[0]["TotalRooms"].ToString();
                totalFloorsTextBlock.Text = ds.Tables[0].Rows[0]["TotalFloors"].ToString();
                TotalSeatTextBlock.Text = ds.Tables[0].Rows[0]["TotalSeats"].ToString();
                conn.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }



        public List<string> AllSeatCodes()
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("uspSeatCodeList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> seatCodeLists = new List<string>();
                while (reader.Read())
                {
                    string singleSeatCode = reader[0].ToString();
                    seatCodeLists.Add(singleSeatCode);
                }
                conn.Close();
                return seatCodeLists;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
                return null;
            }

        }
        private void ShowTheAvailableSeats()
        {
            int all = AllSeatCodes().Count();
            string temp = TotalSeatTextBlock.Text;
            int RemainingSeats = int.Parse(TotalSeatTextBlock.Text) - all;
            int Answer = RemainingSeats;
            TotalAvailableSeatTextBlock.Text = Answer.ToString();
        }

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main = new MainWindow1();
        //    main.Show();
        //    Close();
        //}


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
      
    }
}
