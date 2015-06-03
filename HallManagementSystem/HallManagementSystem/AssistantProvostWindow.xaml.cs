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

namespace HallManagementSystem
{
    /// <summary>
    /// Interaction logic for AssistantProvostWindow.xaml
    /// </summary>
    public partial class AssistantProvostWindow : Window
    {
        public AssistantProvostWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StudentDetailsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StudentDetailsWindow main = new StudentDetailsWindow();
            main.Show();
            //this.Close();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow main = new AboutWindow();
            main.Show();
            //this.Close();
        }

        private void NewAllotmentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewAllotmentWindow main = new NewAllotmentWindow();
            main.Show();
            //this.Close();
        }

        private void AdminWindowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Admin_Window main = new Admin_Window();
            main.Show();
            //this.Close();
        }

     
        private void ProvostsButton_Click(object sender, RoutedEventArgs e)
        {
            ProvotsWindow main = new ProvotsWindow();
            main.Show();
            //this.Close();
        }

        private void AboutVSASHButton_Click(object sender, RoutedEventArgs e)
        {
            AboutHallManagementSystemWindow main = new AboutHallManagementSystemWindow();
            main.Show();
            //this.Close();
        }

      

        private void Admin_Window_Click(object sender, RoutedEventArgs e)
        {
            Admin_Window main = new Admin_Window();
            main.Show();
            //this.Close();
        }

        private void NewBlockEntry_Click(object sender, RoutedEventArgs e)
        {
            BlockWindow main = new BlockWindow();
            main.Show();
            //this.Close();
        }

        private void NewRoomEntry_Click(object sender, RoutedEventArgs e)
        {
            RoomEntryWindow main = new RoomEntryWindow();
            main.Show();
            //this.Close();
        }

        private void NewSeatEntry_Click(object sender, RoutedEventArgs e)
        {
            NewSeatWindow main = new NewSeatWindow();
            main.Show();
            //this.Close();
        }

        private void NewProvostEntry_Click(object sender, RoutedEventArgs e)
        {
            NewProvostEntryWindow main = new NewProvostEntryWindow();
            main.Show();
            //this.Close();
        }  
  }
 }

