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
    /// Interaction logic for NewProvostEntryWindow.xaml
    /// </summary>
    public partial class NewProvostEntryWindow : Window
    {
        public NewProvostEntryWindow()
        {
            InitializeComponent();
     
            BindProvostComboBox();
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        public void BindProvostComboBox()
        {
            
            try
            {
                SqlConnection dataConnection = new SqlConnection(dataconnection);
                dataConnection.Open();

                SqlCommand cmd = new SqlCommand(("SELECT Distinct UserType from Users"), dataConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserTypeComboBox.Items.Add(dr["UserType"].ToString());
                }
                dr.Close();

            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }


        }
        private void BindNewProvostDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspprovostdatagrid", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                mydataGrid1.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void mydataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewProvostDatagrid();
        }
        private void mydataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspinsertionIntoProvosts", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", userNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@UserType", UserTypeComboBox.Text);
                    cmd.Parameters.AddWithValue("@password", userPasswordTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this. BindNewProvostDatagrid();
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspupdateprovost", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", userNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@password", userPasswordTextBox.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewProvostDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspdeletefromprovostdatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", userNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewProvostDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void backButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main = new MainWindow1();
        //    main.Show();
        //    this.Close();
        //}

        private void mydataGrid1_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = mydataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    userNameTextBox.Text = _DataView.Row[0].ToString();
                    UserTypeComboBox.Text = _DataView.Row[1].ToString();
                    userPasswordTextBox.Text = _DataView.Row[2].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            userNameTextBox.Clear();
            UserTypeComboBox.SelectedValue = -1;
            userPasswordTextBox.Clear();

        }
      
        } 
    }

