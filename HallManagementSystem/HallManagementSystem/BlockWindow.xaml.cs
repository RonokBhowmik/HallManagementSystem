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
    /// Interaction logic for BlockWindow.xaml
    /// </summary>
    public partial class BlockWindow : Window
    {
        public BlockWindow()
        {
            InitializeComponent();
            BindFloorComboBox();  
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        public void BindFloorComboBox()
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand(("SELECT * FROM Floors "), conn);
                //SqlCommand cmd = new SqlCommand("SELECT DISTINCT dbo.Floors.FloorId, dbo.Floors.FloorName, dbo.Blocks.FloorId AS Expr1 FROM dbo.Floors INNER JOIN dbo.Blocks ON dbo.Floors.FloorId = dbo.Blocks.FloorId ", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Floors");
                floorNameComboBox.SelectedValuePath = ds.Tables[0].Columns["FloorId"].ToString();
                floorNameComboBox.DisplayMemberPath = ds.Tables[0].Columns["FloorName"].ToString();
                floorNameComboBox.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }  
            
        }
        private void BindNewBlockDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdatagridblocks", Conn);
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
            BindNewBlockDatagrid();
        }
      
        private void deleteNewBlockButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspdeletefromnewblockdatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlockId", newblockidTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewBlockDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString());
             
            }
        }

        private void saveNewBlockButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewBlocks", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FloorId",floorNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@BlockId", newblockidTextBox.Text);
                    cmd.Parameters.AddWithValue("@BlockName",newBlockNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewBlockDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspupdateblock", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlockId", newblockidTextBox.Text);
                    cmd.Parameters.AddWithValue("@BlockName",newBlockNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewBlockDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        

        private void new_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Blocks", conn);
                SqlDataReader reader = cmd.ExecuteReader();
             
                var b = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        b = Convert.ToInt32(reader["BlockId"].ToString());
                        b = b + 1;
                        newblockidTextBox.Text = Convert.ToString(b);
                    }
                }

                conn.Close();

                if (newblockidTextBox.IsEnabled == true)
                {
                    newblockidTextBox.IsEnabled = false;
                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void mydataGrid1_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView DataView = mydataGrid1.CurrentCell.Item as DataRowView;

                
                if (DataView != null)
                {

                  
                    var floorId = DataView.Row[0].ToString();
                    SqlConnection dataConnection = new SqlConnection(dataconnection);
                    dataConnection.Open();
                    SqlCommand cmd = new SqlCommand(("SELECT FloorName FROM dbo.Floors WHERE FloorId = " + floorId + ""), dataConnection);//AND BlockId = "+ val1 +"
                    SqlDataReader dr = cmd.ExecuteReader();
                    string name = "";
                    while (dr.Read())
                    {
                        name = dr["FloorName"].ToString();

                    }
                    dr.Close();
                    // change by sami
                    floorNameComboBox.Text = name;
                    newblockidTextBox.Text = DataView.Row[1].ToString();
                    newBlockNameTextBox.Text = DataView.Row[2].ToString();
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
            main.ShowDialog();
            //this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            floorNameComboBox.SelectedValue = -1;
            newblockidTextBox.Clear();
            newBlockNameTextBox.Clear();
        }

        private void nextwindowButton_Click(object sender, RoutedEventArgs e)
        {
            RoomEntryWindow main = new RoomEntryWindow();
            main.Show();
            this.Close();
        }

        private void previouswindowButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_Window main = new Admin_Window();
            main.Show();
            this.Close();
        }
    }
}
