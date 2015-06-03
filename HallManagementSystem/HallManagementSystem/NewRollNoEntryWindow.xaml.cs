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
using System.Data.SqlClient;
using System.Configuration;
namespace HallManagementSystem
{
    /// <summary>
    /// Interaction logic for NewRollNoEntryWindow.xaml
    /// </summary>
    public partial class NewRollNoEntryWindow : Window
    {
        public NewRollNoEntryWindow()
        {
            InitializeComponent();
            BindDepartmentComboBox();
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        int divId;
        public void BindDepartmentComboBox()
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand(("SELECT * from Departments"),conn);
                //SqlCommand cmd = new SqlCommand("SELECT DISTINCT dbo.Departments.DepartmentId, dbo.Departments.DepartmentName, dbo.StudentSessions.DepartmentId AS Expr1 FROM dbo.Departments INNER JOIN dbo.StudentSessions ON dbo.Departments.DepartmentId = dbo.StudentSessions.DepartmentId ", conn);
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
        private void departmentNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (departmentNameComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(departmentNameComboBox.SelectedValue.ToString());
                StudentSessionComboBox(divId);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void StudentSessionComboBox(int divsonID)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("uspstudentsessions", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DepartmentId", divsonID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                sessionNameComboBox.SelectedValuePath = "StudentSessionId";
                sessionNameComboBox.DisplayMemberPath = "StudentSessionName";
                sessionNameComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void BindNewRollnoDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdatagridrolls", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                rollnodataGrid.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void rollnodataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewRollnoDatagrid();
        }


        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from StudentRollNos", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                var b = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        b = Convert.ToInt32(reader["StudentRollNoId"].ToString());
                        b = b + 1;
                        rollIdTextBox.Text = Convert.ToString(b);
                    }
                }

                conn.Close();

                if (rollIdTextBox.IsEnabled == true)
                {
                    rollIdTextBox.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewRollnos", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@StudentSessionId", sessionNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@StudentRollNoId", rollIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@StudentRollNo", rollNoTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewRollnoDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspupdaterollno", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentRollNoId", rollIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@StudentRollNo", rollNoTextBox.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewRollnoDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspdeletefromnewrollnodatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentRollNoId", rollIdTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewRollnoDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }



        private void rollnodataGrid_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            
            try
            {
                DataRowView DataView = rollnodataGrid.CurrentCell.Item as DataRowView;

                if (DataView != null)
                {
                   
                    var departmentId = DataView.Row[0].ToString();
                    var sessionId = DataView.Row[1].ToString();

                    SqlConnection dataConnection = new SqlConnection(dataconnection);
                    dataConnection.Open();
                    SqlCommand cmd = new SqlCommand(("SELECT DepartmentName FROM dbo.Departments WHERE DepartmentId = " + departmentId + ""), dataConnection);//AND BlockId = "+ val1 +"
                    SqlDataReader dr = cmd.ExecuteReader();
                    string name = "";

                    while (dr.Read())
                    {
                        name = dr["DepartmentName"].ToString();

                    }
                    dr.Close();
                    // change by sami
                    departmentNameComboBox.Text = name;

                    SqlCommand cmd1 = new SqlCommand(("SELECT StudentSessionName FROM dbo.StudentSessions WHERE StudentSessionId = " + sessionId + ""), dataConnection);//AND BlockId = "+ val1 +"
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    string name1 = "";

                    while (dr1.Read())
                    {

                        name1 = dr1["StudentSessionName"].ToString();
                    }
                    dr1.Close();
                    // change by sami
                    sessionNameComboBox.Text = name1;
                    rollIdTextBox.Text = DataView.Row[2].ToString();
                    rollNoTextBox.Text = DataView.Row[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow1 main = new MainWindow1();
            main.Show();
            this.Close();
        }

        private void nextwindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewNameEntryWindow main = new NewNameEntryWindow();
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
            sessionNameComboBox.SelectedValue = -1;
            rollIdTextBox.Clear();
            rollNoTextBox.Clear();
        }

        private void previouswindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewSessionEntryWindow main = new NewSessionEntryWindow();
            main.Show();
            this.Close();
        }
    }
}
