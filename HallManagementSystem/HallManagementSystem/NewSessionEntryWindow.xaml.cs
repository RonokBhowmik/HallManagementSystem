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
    /// Interaction logic for NewSessionEntryWindow.xaml
    /// </summary>
    public partial class NewSessionEntryWindow : Window
    {
        public NewSessionEntryWindow()
        {
            InitializeComponent();
            BindDepartmentNameComboBox();
        }

        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
     
        public void BindDepartmentNameComboBox()
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand(("SELECT * from Departments "), conn);
                //SqlCommand cmd = new SqlCommand("SELECT DISTINCT dbo.Floors.FloorId, dbo.Floors.FloorName, dbo.Blocks.FloorId AS Expr1 FROM dbo.Floors INNER JOIN dbo.Blocks ON dbo.Floors.FloorId = dbo.Blocks.FloorId ", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Departments");
                departmentNameComboBox.SelectedValuePath = ds.Tables[0].Columns["DepartmentId"].ToString();
                departmentNameComboBox.DisplayMemberPath = ds.Tables[0].Columns["DepartmentName"].ToString();
                departmentNameComboBox.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            
        }
        private void BindNewSessionDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdatagridsessions", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding,"DataBind");
                SessiondataGrid.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void SessiondataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewSessionDatagrid();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from StudentSessions", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                var b = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        b = Convert.ToInt32(reader["StudentSessionId"].ToString());
                        b = b + 1;
                        sessionIdTextBox.Text = Convert.ToString(b);
                    }
                }

                conn.Close();

                if (sessionIdTextBox.IsEnabled == true)
                {
                    sessionIdTextBox.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveNewBlockButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewsessions", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId",departmentNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@StudentSessionId",sessionIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@StudentSessionName",sessionNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewSessionDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspupdatesession", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentSessionId", sessionIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@StudentSessionName", sessionNameTextBox.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewSessionDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void deleteNewBlockButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspdeletefromnewsessiondatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentSessionId", sessionIdTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewSessionDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void SessiondataGrid_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView DataView = SessiondataGrid.CurrentCell.Item as DataRowView;
                if (DataView != null)
                {


                    var departmentId = DataView.Row[0].ToString();
                    SqlConnection dataConnection = new SqlConnection(dataconnection);
                    dataConnection.Open();
                    SqlCommand cmd = new SqlCommand(("SELECT DepartmentName FROM dbo.Departments WHERE DepartmentId= " + departmentId + ""), dataConnection);//AND BlockId = "+ val1 +"
                    SqlDataReader dr = cmd.ExecuteReader();
                    string name = "";
                    while (dr.Read())
                    {
                        name = dr["DepartmentName"].ToString();

                    }
                    dr.Close();
                    // change by sami
                    departmentNameComboBox.Text = name;
                    sessionIdTextBox.Text = DataView.Row[1].ToString();
                    sessionNameTextBox.Text = DataView.Row[2].ToString();
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

        private void nextwindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewRollNoEntryWindow main = new NewRollNoEntryWindow();
            main.Show();
            this.Close();

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            departmentNameComboBox.SelectedValue = -1;
            sessionIdTextBox.Clear();
            sessionNameTextBox.Clear();
        }

        private void previouswindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewDepartmentEntryWindow main = new NewDepartmentEntryWindow();
            main.Show();
            this.Close();

        }
    }
}
