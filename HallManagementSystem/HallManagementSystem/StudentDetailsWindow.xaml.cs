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
    /// Interaction logic for StudentDetailsWindow.xaml
    /// </summary>
    public partial class StudentDetailsWindow : Window
    {
        public StudentDetailsWindow()
        {
            InitializeComponent();
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main = new MainWindow1();
        //    main.Show();
        //    Close();
        //}
        private void Bindgrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand("uspdatagrid", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds,"datagrid");
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["GeneratedSeatCode"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["DepartmentId"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["StudentSessionId"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["StudentRollNo"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["StudentNameId"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["StudentDistrictId"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["StudentPhoneNo"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["AllotmentDate"].ToString();
                mydataGrid.SelectedValuePath = ds.Tables[0].Columns["ExpieryDate"].ToString();
             
                mydataGrid.ItemsSource = ds.Tables[0].DefaultView;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void mydataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Bindgrid();
        }
        private void mydataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspDeleteFromStudentsDetails", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataRowView DataView = (DataRowView)mydataGrid.SelectedItem;
                    string GeneratedSeatCode = DataView.Row[0].ToString();
                    cmd.Parameters.AddWithValue("@GeneratedSeatCode", GeneratedSeatCode);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Bindgrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

       if (e.Key == Key.Return)
           try
            {
               
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspSearchFromStudentsDataGrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GeneratedSeatCode",searchTextBox.Text);
                    cmd.Parameters.AddWithValue("@StudentPhoneNo", searchTextBox.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    mydataGrid.ItemsSource = ds.Tables[0].DefaultView;
                    conn.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } 
        }
    }

