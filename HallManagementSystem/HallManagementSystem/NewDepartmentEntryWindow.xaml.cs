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
    /// Interaction logic for NewDepartmentEntryWindow.xaml
    /// </summary>
    public partial class NewDepartmentEntryWindow : Window
    {
        public NewDepartmentEntryWindow()
        {
            InitializeComponent();
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        //private void backButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main = new MainWindow1();
        //    main.Show();
        //    this.Close();
        //}

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            NewSessionEntryWindow main = new NewSessionEntryWindow();
            main.Show();
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("uspdepartments", conn);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                var b = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        b = Convert.ToInt32(reader["DepartmentId"].ToString());
                        b = b + 1;
                        newDepartmentIdTextBox.Text = Convert.ToString(b);
                    }
                }

                conn.Close();

                if (newDepartmentIdTextBox.IsEnabled != true)
                {
                    newDepartmentIdTextBox.IsEnabled = true;
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
                    SqlCommand cmd = new SqlCommand("uspupdatedepartment", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", newDepartmentIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@DepartmentName", newDepartmentNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewdepartmentDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewdepartments", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", newDepartmentIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@DepartmentName", newDepartmentNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewdepartmentDatagrid();
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                    conn.Close();
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
                    SqlCommand cmd = new SqlCommand("uspdeletefromnewdepartmentdatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", newDepartmentIdTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewdepartmentDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindNewdepartmentDatagrid()
        {
            try
            {

                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdepartments", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                departmentdataGrid.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void departmentdataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewdepartmentDatagrid();
        }
    

        private void departmentdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = departmentdataGrid.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    newDepartmentIdTextBox.Text = _DataView.Row[0].ToString();
                    newDepartmentNameTextBox.Text = _DataView.Row[1].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 

        }
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            newDepartmentIdTextBox.Clear();
            newDepartmentNameTextBox.Clear();
        }

        private void nextwindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewSessionEntryWindow main = new NewSessionEntryWindow();
            main.Show();
            this.Close();
        }
        }
    }

