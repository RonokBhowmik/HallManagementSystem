using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace HallManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //BindProvostRankComboBox();
        }
        string dataconnection = ConfigurationManager.ConnectionStrings["HallManagementSystem.Properties.Settings.MydatabaseConnectionString"].ConnectionString;
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

            if (ProvostNametextbox.Text.Length == 0)
            {
                MessageBox.Show("Enter User Name", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
   
            }

            if (ProvostPasswordtextbox.Password.Length == 0)
            {
                MessageBox.Show("Enter Password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }

            if (string.IsNullOrEmpty(ProvostRankComboBox.Text))
            {
                MessageBox.Show("Select Designation", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }

            else
            {
                string user = ProvostNametextbox.Text;
                string password = ProvostPasswordtextbox.Password;
                string Utype =ProvostRankComboBox.SelectedItem.ToString();

                SqlConnection dataConnection = new SqlConnection(dataconnection);
                dataConnection.Open();
                SqlCommand cmd = new SqlCommand("Select * from Users where UserName='" + user + "' And Password='" + password + "'", dataConnection);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {

                    string level = dataSet.Tables[0].Rows[0]["UserType"].ToString();
                    string nm = dataSet.Tables[0].Rows[0]["UserName"].ToString();

                    if (Utype == level)
                    {
                        if (level == "Provost")
                        {
                            MainWindow1 mainwindow = new MainWindow1();
                            mainwindow.Welcometextblock.Text = nm;
                            mainwindow.Entertextblock.Text = level;
                            mainwindow.ShowDialog();
                            Close();

                        }
                        else if (level == "Assistant Provost")
                        {
                            AssistantProvostWindow mainwindow = new AssistantProvostWindow();
                            mainwindow.Welcometextblock.Text = nm;
                            mainwindow.Entertextblock.Text = level;
                            mainwindow.ShowDialog();
                            Close();

                        }
                        
                        else
                        {
                            MessageBox.Show("Select a User", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect User Type", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                else
                {
                    MessageBox.Show("Sorry! Please enter existing User Name/ Password.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                dataConnection.Close();
            }

    }
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection dataConnection = new SqlConnection(dataconnection);
            dataConnection.Open();
            SqlCommand cmd = new SqlCommand(("Select Distinct UserType from Users"), dataConnection);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProvostRankComboBox.Items.Add(dr["UserType"].ToString());
                }
                dr.Close();
                dataConnection.Close();
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
       

        //Reset the textboxes and ComboBox
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ProvostNametextbox.Text=string.Empty;
            ProvostRankComboBox.SelectedValue = -1;
            ProvostPasswordtextbox.Clear();
        }

        //Exiting the Application
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
          
        }
    }
}
