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
using System.Text.RegularExpressions;

namespace HallManagementSystem
{
    /// <summary>
    /// Interaction logic for NewAllotmentWindow.xaml
    /// </summary>
    public partial class NewAllotmentWindow : Window
    {
        public NewAllotmentWindow()
        {
            InitializeComponent();
            BindFloorComboBox();
            BindDepartmentComboBox();
            SeatRentPerMonth();
        }
        //Make a connection with the database
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        int divId;
        List<string> allocatedSeatOfARoom = new List<string>();
        //Binding the FloorComboBox
        public void BindFloorComboBox()
        {
            
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand("uspfloors", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds,"Floors");
                FloorIDComboBox.SelectedValuePath = ds.Tables[0].Columns["FloorId"].ToString();
                FloorIDComboBox.DisplayMemberPath = ds.Tables[0].Columns["FloorName"].ToString();
                FloorIDComboBox.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
                //AllSeatCodes();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        //Selection Change Event Based on Floor
        private void FloorIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (FloorIDComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(FloorIDComboBox.SelectedValue.ToString());
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
                BlockIDComboBox.SelectedValuePath = "BlockId";
                BlockIDComboBox.DisplayMemberPath = "BlockName";
                BlockIDComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
        }



        //Selection change Event
        private void BlockIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (BlockIDComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(BlockIDComboBox.SelectedValue.ToString());
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
                RoomIDComboBox.SelectedValuePath = "RoomId";
                RoomIDComboBox.DisplayMemberPath = "RoomName";
                RoomIDComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
            
        }
        private void RoomIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (RoomIDComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(RoomIDComboBox.SelectedValue.ToString());                
                allocatedSeatOfARoom = CheckingAllocatedSitOfARoom(RoomIDComboBox.SelectedValue.ToString());
                SeatComboBox();
                //ShowTheAvailableSeats();
                //int all = AllSeatCodes().Count();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        //public void SeatComboBox(int divsonID)
        //{
        //    SqlConnection conn = new SqlConnection(dataconnection);
        //    SqlCommand cmd = new SqlCommand("uspseats", conn);
        //    cmd.Connection = conn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("RoomId", divsonID);
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.SelectCommand = cmd;
        //    conn.Open();
        //    da.Fill(ds);
        //    conn.Close();

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        SeatIDComboBox.SelectedValuePath = "SeatName";
        //        SeatIDComboBox.DisplayMemberPath = "SeatName";
        //        SeatIDComboBox.ItemsSource = ds.Tables[0].DefaultView;
        //    }
        //}



        public void SeatComboBox()
        {
            List<string> allSeadCodes = new List<string>() { "S1","S2","S3","S4"};
            //List<string> list1 = allSeadCodes.Intersect(allocatedSeatOfARoom).ToList();
            var list1 = allSeadCodes.Except(allocatedSeatOfARoom);
            SeatIDComboBox.ItemsSource = list1;
            //SeatIDComboBox.ItemsSource = allSeadCodes.Intersect(allocatedSeatOfARoom).ToList();
            //SeatIDComboBox.ItemsSource = allocatedSeatOfARoom;
        }
        private void SeatIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            string Floor = FloorIDComboBox.Text;
            string Block = BlockIDComboBox.Text;
            string Room = RoomIDComboBox.Text;
            string seat = SeatIDComboBox.SelectedValue.ToString();
            GeneratedSeatCodeTextBox.Text = ("ASH" + Floor + Block + Room + seat);            
        }
        //All seatcodelist from database
        public List<string> AllSeatCodes()
        {
            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("uspSeatCodeList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> seatCodeLists = new List<string>();
                while (reader.Read())
                {
                    string singleSeatCode = reader[0].ToString();
                    seatCodeLists.Add(singleSeatCode);
                }
                conn.Close();
                return seatCodeLists;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }

        }

        //Checking the allocated sit of a room
        public List<string> CheckingAllocatedSitOfARoom(string roomIdCombo) 
        {
            try            
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                conn.Open();
                string query = string.Format("SELECT * FROM Rooms WHERE RoomId='{0}'",roomIdCombo);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                string roomName = null;
                //cmd.CommandType = CommandType.StoredProcedure;
                if (reader.Read())
                 roomName = reader[2].ToString(); 
                List<string> allSeatCodes = AllSeatCodes();
                List<string> allocatedSeatIdOfARoomLocal = new List<string>();
                foreach (string aSeatCode in allSeatCodes) 
                {
                    //string roomNameFromSeatCode = string.Format(aSeatCode.Remove(0,6));
                    if (aSeatCode.Contains(roomName)) 
                    {
                        string allocatedSeatId = aSeatCode.Remove(0,9);
                        allocatedSeatIdOfARoomLocal.Add(allocatedSeatId);
                    }
                }
                return allocatedSeatIdOfARoomLocal;
            }
            catch(Exception ex) 
            {
            throw new Exception(ex.ToString());
            }
        }

       //Binding the Departments
        

        public void BindDepartmentComboBox()
        {

            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand("uspdepartments", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds,"Departments");
                DepartmentIDComboBox.SelectedValuePath = ds.Tables[0].Columns["DepartmentId"].ToString();
                DepartmentIDComboBox.DisplayMemberPath = ds.Tables[0].Columns["DepartmentName"].ToString();
                DepartmentIDComboBox.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        //Selection Change Event Based on Department
        private void DepartmentIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DepartmentIDComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(DepartmentIDComboBox.SelectedValue.ToString());
                AllSessionComboBox(divId);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AllSessionComboBox(int divsonID)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("uspstudentsessions", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentId", divsonID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                SessionComboBox.SelectedValuePath = "StudentSessionId";
                SessionComboBox.DisplayMemberPath = "StudentSessionName";
                SessionComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        //Selection Change Event Based on session
        private void SessionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (SessionComboBox.SelectedItem == null)
                   return;
                divId = int.Parse(SessionComboBox.SelectedValue.ToString());
                AllRollComboBox(divId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void AllRollComboBox(int divsonID)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("uspstudentrollnos", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentSessionId", divsonID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                RollComboBox.SelectedValuePath = "StudentRollNoId";
                RollComboBox.DisplayMemberPath = "StudentRollNo";
                RollComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void RollComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (RollComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(RollComboBox.SelectedValue.ToString());
                AllNameComboBox(divId);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AllNameComboBox(int divsonID)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("uspstudentnames", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentRollNoId", divsonID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                NameComboBox.SelectedValuePath = "StudentNameId";
                NameComboBox.DisplayMemberPath = "StudentName";
                NameComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void NameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             try
            {
                if (NameComboBox.SelectedItem == null)
                    return;
                divId = int.Parse(NameComboBox.SelectedValue.ToString());
                AllDistrictComboBox(divId);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AllDistrictComboBox(int divsonID)
        {
            SqlConnection conn = new SqlConnection(dataconnection);
            SqlCommand cmd = new SqlCommand("uspstudentdistricts", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentNameId", divsonID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DistrictComboBox.SelectedValuePath = "StudentDistrictId";
                DistrictComboBox.DisplayMemberPath = "StudentDistrict";
                DistrictComboBox.ItemsSource = ds.Tables[0].DefaultView;
            }
        }
        //Reseting the valuses of the comboBoxes and the textboxes

       private void RefreshAllButton_Click(object sender, RoutedEventArgs e)
        {
            FloorIDComboBox.SelectedValue = -1;
            BlockIDComboBox.SelectedValue = -1;
            RoomIDComboBox.SelectedValue = -1;
            SeatIDComboBox.SelectedValue = -1;
            GeneratedSeatCodeTextBox.Clear();
           //SeatAvailabilityComboBox.SelectedValue = -1;
           // AllotmentDatetimepicker.ClearValue();
            DepartmentIDComboBox.SelectedValue = -1;
            SessionComboBox.SelectedValue = -1;
            RollComboBox.SelectedValue = -1;
            NameComboBox.SelectedValue = -1;
            DistrictComboBox.SelectedValue = -1;
            SeatRentTextBox.Clear();
            StudentPhoneNoTextBox.Clear();
            ParentPhoneNoTextBox.Clear();

        }

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow1 main=new MainWindow1();
        //    main.Show();
        //    Close();
        //}

        private void AlloteButton_Click(object sender, RoutedEventArgs e)
        {

            if (StudentPhoneNoTextBox.Text.Length == 0 )
            {
                MessageBox.Show("Please Enter Student's Phone No", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else  if ( ParentPhoneNoTextBox.Text.Length == 0 )
            {
                MessageBox.Show("Please Enter Parent's Phone No", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Regex.IsMatch(StudentPhoneNoTextBox.Text , @"^\+88\d{11}$"))
            {
                MessageBox.Show("Data entry Successful", "Messsage", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Regex.IsMatch(ParentPhoneNoTextBox.Text, @"^\+88\d{11}$"))
            {
                MessageBox.Show("Data entry Successful", "Messsage", MessageBoxButton.OK, MessageBoxImage.Information);

            }
           
            try
            {
                {
                    SqlConnection conn = new SqlConnection(dataconnection);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("uspinsertionIntoStudents", conn);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GeneratedSeatCode", GeneratedSeatCodeTextBox.Text);
                    cmd.Parameters.AddWithValue("@DepartmentId", Convert.ToInt32(DepartmentIDComboBox.SelectedValue));
                    cmd.Parameters.AddWithValue("@StudentSessionId", Convert.ToInt32(SessionComboBox.SelectedValue));
                    cmd.Parameters.AddWithValue("@StudentRollNo",RollComboBox.Text);
                    cmd.Parameters.AddWithValue("@StudentRollNoId", Convert.ToInt32(RollComboBox.SelectedValue));
                    cmd.Parameters.AddWithValue("@StudentNameId", Convert.ToInt32(NameComboBox.SelectedValue));
                    cmd.Parameters.AddWithValue("@StudentDistrictId", Convert.ToInt32(DistrictComboBox.SelectedValue));
                    cmd.Parameters.AddWithValue("@StudentPhoneNo",StudentPhoneNoTextBox.Text);
                    cmd.Parameters.AddWithValue("@ParentPhoneNo",ParentPhoneNoTextBox.Text);
                    cmd.Parameters.AddWithValue("@AllotmentDate", AllotmentDatetimepicker.Text);
                    cmd.Parameters.AddWithValue("@ExpieryDate", ValidationDatetimepicker.Text);
                    cmd.Parameters.AddWithValue("@SeatRent",SeatRentTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SeatRentPerMonth()
        {

            try
            {
                SqlConnection conn = new SqlConnection(dataconnection);
                SqlCommand cmd = new SqlCommand("uspcurrentseatrents", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds,"seatrents");
                seatRentPerMonthTextBox.Text = ds.Tables[0].Rows[0]["SeatRent"].ToString();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime start =AllotmentDatetimepicker.SelectedDate.Value.Date;
            DateTime finish =ValidationDatetimepicker.SelectedDate.Value.Date;
            int compMonth = (finish.Month + start.Year * 12) - (start.Month + start.Year * 12);
            double daysInEndMonth = (finish - finish.AddMonths(1)).Days;
            double months = compMonth + (start.Day - finish.Day) / daysInEndMonth;
            int PerMOnthSeatRent =int.Parse(seatRentPerMonthTextBox.Text.ToString());
            SeatRentTextBox.Text = Convert.ToString(Math.Ceiling(months * PerMOnthSeatRent));           
        }

        private void AllotmentDatetimepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidationDatetimepicker.SelectedDate = AllotmentDatetimepicker.SelectedDate.Value.AddMonths(6);
        }
        }
}
