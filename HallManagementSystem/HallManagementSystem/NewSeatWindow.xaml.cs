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
    /// Interaction logic for NewSeatWindow.xaml
    /// </summary>
    public partial class NewSeatWindow : Window
    {
        public NewSeatWindow()
        {
            InitializeComponent();
            BindFloorComboBox();
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        int divId;
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
            cmd.Parameters.AddWithValue("FloorId", divsonID);
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
        //private void floorNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (floorNameComboBox.SelectedItem == null)
        //            return;
        //        divId = int.Parse(floorNameComboBox.SelectedValue.ToString());
        //        BlockComboBox(divId);
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //public void BlockComboBox(int divsonID)
        //{
        //    SqlConnection conn = new SqlConnection(dataconnection);
        //    SqlCommand cmd = new SqlCommand("uspblocks", conn);
        //    cmd.Connection = conn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("FloorId", divsonID);
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.SelectCommand = cmd;
        //    conn.Open();
        //    da.Fill(ds);
        //    conn.Close();

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        blockNameComboBox.SelectedValuePath = "BlockId";
        //        blockNameComboBox.DisplayMemberPath = "BlockName";
        //        blockNameComboBox.ItemsSource = ds.Tables[0].DefaultView;
        //    }
        //}
        private void blockNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (blockNameComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(blockNameComboBox.SelectedValue.ToString());
                RoomComboBox(divId);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void RoomComboBox(int divsonID)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("usprooms", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("BlockId", divsonID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                roomNoCombobox.SelectedValuePath = "RoomId";
                roomNoCombobox.DisplayMemberPath = "RoomName";
                roomNoCombobox.ItemsSource = ds.Tables[0].DefaultView;
            }

        }
        private void BindNewSeatDatagrid()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(dataconnection);
                SqlDataAdapter adapt = new SqlDataAdapter("uspdatagridseats", Conn);
                Conn.Open();
                DataSet binding = new DataSet();
                adapt.Fill(binding, "DataBind");
                mydataGrid3.DataContext = binding;
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void mydataGrid3_Loaded(object sender, RoutedEventArgs e)
        {
            BindNewSeatDatagrid();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Seats", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                var b = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        b = Convert.ToInt32(reader["SeatId"].ToString());
                        b = b + 1;
                        seatIdTextBox.Text = Convert.ToString(b);
                    }
                }

                conn.Close();

                if (seatIdTextBox.IsEnabled == true)
                {
                    seatIdTextBox.IsEnabled = false;
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
                    SqlCommand cmd = new SqlCommand("uspinsertionIntonewseats", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FloorId", floorNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@BlockId", blockNameComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@RoomId", roomNoCombobox.SelectedValue);
                    cmd.Parameters.AddWithValue("@SeatId", seatIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@SeatNo", seatNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    this.BindNewSeatDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspupdateseat", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SeatId", seatIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@SeatName", seatNameTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Updated Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewSeatDatagrid();
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
                    SqlCommand cmd = new SqlCommand("uspdeletefromnewseatdatagrid", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SeatId", seatIdTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("One Record Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.BindNewSeatDatagrid();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void mydataGrid3_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {

            try
            {
                DataRowView DataView = mydataGrid3.CurrentCell.Item as DataRowView;

                if (DataView != null)
                {
                    var roomId = DataView.Row[0].ToString();
                    var blockId = DataView.Row[3].ToString();
                    var floorId = DataView.Row[4].ToString();

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
                   
                    // for room
                    SqlCommand cmd2 = new SqlCommand(("SELECT RoomName FROM dbo.Rooms WHERE RoomId = " + roomId + ""), dataConnection);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    string name3 = "";

                    while (dr2.Read())
                    {
                        name3 = dr2["RoomName"].ToString();
                    }
                    dr2.Close();
                    // change by sami
                    roomNoCombobox.Text = name3;
                    
                    seatIdTextBox.Text = DataView.Row[1].ToString();
                    seatNameTextBox.Text = DataView.Row[2].ToString();
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

        private void previousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            RoomEntryWindow main = new RoomEntryWindow();
            main.Show();
            this.Close();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            floorNameComboBox.SelectedValue = -1;
            blockNameComboBox.SelectedValue = -1;
            roomNoCombobox.SelectedValue = -1;
            seatIdTextBox.Clear();
            seatNameTextBox.Clear();
        }
    }



}
