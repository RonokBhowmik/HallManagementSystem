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
    /// Interaction logic for NewNameEntryWindow.xaml
    /// </summary>
    public partial class NewNameEntryWindow : Window
    {
        public NewNameEntryWindow()
        {
            InitializeComponent();
            BindDepartmentComboBox();
        }

        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        int divId;
        int sessionid;

        public void BindDepartmentComboBox()
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
            //try
            //{
            //    SqlConnection conn = new SqlConnection(dataconnection);
            //    SqlCommand cmd = new SqlCommand("uspdepartments", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    conn.Open();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds, "Departments");
            //    departmentNameComboBox.SelectedValuePath = ds.Tables[0].Columns["DepartmentId"].ToString();
            //    departmentNameComboBox.DisplayMemberPath = ds.Tables[0].Columns["DepartmentName"].ToString();
            //    departmentNameComboBox.ItemsSource = ds.Tables[0].DefaultView;
            //    conn.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());

            //}

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
        private void sessionNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sessionNameComboBox.SelectedItem == null)
                    return;
                sessionid = int.Parse(sessionNameComboBox.SelectedValue.ToString());
                RollNoComboBox(sessionid);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void RollNoComboBox(int sessionid)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("usprollnos", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("StudentSessionId", sessionid);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                rollNoCombobox.SelectedValuePath = "StudentRollNoId";
                rollNoCombobox.DisplayMemberPath = "StudentRollNo";
                rollNoCombobox.ItemsSource = ds.Tables[0].DefaultView;
            }

        }
        private void BindNewRollNoDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdatagridnames", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                namedatagrid.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void namedatagrid_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewRollNoDatagrid();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            NewDistrictEntryWindow main = new NewDistrictEntryWindow();
            main.Show();
            this.Close();
        }

        //private void backButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main = new MainWindow1();
        //    main.Show();
        //    this.Close();

        //}

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("uspstudentnamesintodatagrid", conn);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                var b = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        b = Convert.ToInt32(reader["StudentNameId"].ToString());
                        b = b + 1;
                        nameIdTextBox.Text = Convert.ToString(b);
                    }
                }

                conn.Close();

                if (nameIdTextBox.IsEnabled != true)
                {
                    nameIdTextBox.IsEnabled = true;
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
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewnames", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@StudentSessionId", sessionNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@StudentRollNoId", rollNoCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@StudentNameId", nameIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@StudentName", NameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewRollNoDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspupdatename", conn);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@StudentNameId", nameIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@StudentName", NameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewRollNoDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspdeletefromnewnamedatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentNameId", nameIdTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewRollNoDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void namedatagrid_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView DataView = namedatagrid.CurrentCell.Item as DataRowView;

                if (DataView != null)
                {
                    var sessionId = DataView.Row[3].ToString();
                    var rollId = DataView.Row[2].ToString();
                    var departmentId = DataView.Row[0].ToString();


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

                    //roll no
                    SqlCommand cmd2 = new SqlCommand(("SELECT StudentRollNo FROM dbo.StudentRollNos WHERE StudentRollNoId = " + rollId + ""), dataConnection);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    string name2 = "";

                    while (dr2.Read())
                    {
                        name2 = dr2["StudentRollNo"].ToString();
                    }
                    dr2.Close();

                    rollNoCombobox.Text = name2;
                    sessionNameComboBox.Text = name1;
                    nameIdTextBox.Text = DataView.Row[3].ToString();
                    NameTextBox.Text = DataView.Row[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            departmentNameComboBox.SelectedValue = -1;
            sessionNameComboBox.SelectedValue = -1;
            rollNoCombobox.SelectedValue = -1;
            nameIdTextBox.Clear();
            NameTextBox.Clear();
        }

        private void previousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewRollNoEntryWindow main = new NewRollNoEntryWindow();
            main.Show();
            this.Close();
        }

        private void nextWindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewDistrictEntryWindow main = new NewDistrictEntryWindow();
            main.Show();
            this.Close();
        }

    }
}
