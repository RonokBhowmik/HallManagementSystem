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
using System.Windows.Shapes;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace HallManagementSystem
{
    /// <summary>
    /// Interaction logic for UpadateHallInfoWindow.xaml
    /// </summary>
    public partial class UpadateHallInfoWindow : Window
    {
        public UpadateHallInfoWindow()
        {
            InitializeComponent();
       
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
      
        private void BindupdateHallInfoDatagrid()
        {
            try
            {

                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspcurrenthallinfo", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                updateHallInfodatagrid.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            


        }
        private void updateHallInfodatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            BindupdateHallInfoDatagrid();
        }



        private void updateHallInfodatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = updateHallInfodatagrid.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                   
                    totalBlocksTextBox.Text = _DataView.Row[0].ToString();
                    totalRoomsTextBox.Text = _DataView.Row[1].ToString();
                    totalFloorsTextBox.Text = _DataView.Row[2].ToString();
                    totalSeatsTextBox.Text = _DataView.Row[3].ToString();
                    IdTextBox.Text = _DataView.Row[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspupdateHallinfo", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", IdTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalBlocks", totalBlocksTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalRooms", totalRoomsTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalFloors", totalFloorsTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalSeats", totalSeatsTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindupdateHallInfoDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspinsertionIntoHallinfo", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", IdTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalBlocks", totalBlocksTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalRooms", totalRoomsTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalFloors", totalFloorsTextBox.Text);
                    cmd.Parameters.AddWithValue("@TotalSeats", totalSeatsTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindupdateHallInfoDatagrid();
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //private void backButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main = new MainWindow1();
        //    main.Show();
        //    this.Close();
        //}

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            IdTextBox.Clear();
            totalBlocksTextBox.Clear();
            totalFloorsTextBox.Clear();
            totalRoomsTextBox.Clear();
            totalSeatsTextBox.Clear();
        }
    }
}
