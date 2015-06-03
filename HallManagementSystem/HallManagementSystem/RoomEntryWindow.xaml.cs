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
    /// Interaction logic for RoomEntryWindow.xaml
    /// </summary>
    public partial class RoomEntryWindow : Window
    {
        public RoomEntryWindow()
        {
            InitializeComponent();
            BindFloorComboBox();
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        int divId;
        private void BindNewRoomDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdatagridrooms", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                mydataGrid2.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void mydataGrid2_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewRoomDatagrid();
        }
         
        
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Rooms", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                var b = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        b = Convert.ToInt32(reader["RoomId"].ToString());
                        b = b + 1;
                        roomIdTextBox.Text = Convert.ToString(b);
                    }
                }

                conn.Close();

                if (roomIdTextBox.IsEnabled == true)
                {
                    roomIdTextBox.IsEnabled = false;
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
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewRooms", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FloorId", floorNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@BlockId", blockNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@RoomId", roomIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@RoomName",roomNoTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewRoomDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspupdateroom", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoomId", roomIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@RoomName", roomNoTextBox.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewRoomDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspdeletefromnewroomdatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomId",roomIdTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewRoomDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindFloorComboBox()
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand(("SELECT * FROM Floors "),conn);
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
        private void floorNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           try
            {
                if (floorNameComboBox.SelectedItem == null)
                return;
                divId = int.Parse(floorNameComboBox.SelectedValue.ToString());
                BlockComboBox(divId);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void BlockComboBox(int divsonID)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("uspblocks", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FloorId",divsonID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                blockNameComboBox.SelectedValuePath = "BlockId";
                blockNameComboBox.DisplayMemberPath = "BlockName";
                blockNameComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void mydataGrid2_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView DataView = mydataGrid2.CurrentCell.Item as DataRowView;

                if (DataView != null)
                {
                  
                    var blockId = DataView.Row[1].ToString();
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
       
                    SqlCommand cmd1 = new SqlCommand(("SELECT BlockName FROM dbo.Blocks WHERE BlockId = " + blockId + ""), dataConnection);//AND BlockId = "+ val1 +"
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    string name1 = "";

                    while (dr1.Read())
                    {

                        name1 = dr1["BlockName"].ToString();
                    }
                    dr1.Close();
                    // change by sami
                    blockNameComboBox.Text = name1;

                    roomIdTextBox.Text = DataView.Row[1].ToString();
                    roomNoTextBox.Text = DataView.Row[2].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nextwindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewSeatWindow main = new NewSeatWindow();
            main.Show();
            this.Close();
        }

        //private void backButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main = new MainWindow1();
        //    main.Show();
        //    this.Close();
        //}

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            floorNameComboBox.SelectedValue = -1;
            blockNameComboBox.SelectedValue = -1;
            roomIdTextBox.Clear();
            roomNoTextBox.Clear();
        }

        private void previousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            BlockWindow main = new BlockWindow();
            main.Show();
            this.Close();
        }
        }

      
    }
