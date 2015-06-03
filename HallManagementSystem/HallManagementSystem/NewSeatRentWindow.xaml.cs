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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HallManagementSystem
{
    /// <summary>
    /// Interaction logic for NewSeatRentWindow.xaml
    /// </summary>
    public partial class NewSeatRentWindow : Window
    {
        public NewSeatRentWindow()
        {
            InitializeComponent();
        }

        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;

      

        private void saveNewBlockButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewseatrents", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SeatRentId",seatRentIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@SeatRent", seatRentTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewSeatRentDatagrid();
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void updateNewBlockButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspupdateseatrent", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SeatRentId", seatRentIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@SeatRent", seatRentTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewSeatRentDatagrid(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            seatRentIdTextBox.Clear();
            seatRentTextBox.Clear();
        }

        
        private void BindNewSeatRentDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdatagridseatrents", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                seatRentdataGrid.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void seatRentdataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewSeatRentDatagrid();
        }

        private void seatRentdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = seatRentdataGrid.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    seatRentIdTextBox.Text = _DataView.Row[0].ToString();
                    seatRentTextBox.Text = _DataView.Row[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
    }
}
