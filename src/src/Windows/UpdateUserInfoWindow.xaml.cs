using src.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace src.Windows
{
    /// <summary>
    /// Interaction logic for UpdateUserInfoWindow.xaml
    /// </summary>
    public partial class UpdateUserInfoWindow : Window
    {
        // this class contains the userDatabaseManager in order to funnel updated information to the database.
        private userDatabaseManager userDatabaseManager;
        public UpdateUserInfoWindow(userDatabaseManager uDM)
        {

            userDatabaseManager = uDM;
            InitializeComponent();
        }
        private async void confirmUpdate_Click(object sender, RoutedEventArgs e) { 

            // grabs information from the window and passes it to the manager for processing, closes window after.
            userDatabaseManager.fetchInfoFromUpdateUserInfoWindow(newPasswordTextBox.Text, newEmailTextBox.Text, newConfirmPasswordTextBox.Text);

            if (newPasswordTextBox.Text == newConfirmPasswordTextBox.Text && newPasswordTextBox.Text.Length >= 12)
            {
                Close();
            }
            else if (newPasswordTextBox.Text != newConfirmPasswordTextBox.Text)
            {
                popup.Visibility = Visibility.Visible;
                await Task.Delay(3000);
                popup.Visibility = Visibility.Hidden;
            }
            else if (newPasswordTextBox.Text.Length < 12)
            {
                popup1.Visibility = Visibility.Visible;
                await Task.Delay(3000);
                popup1.Visibility = Visibility.Hidden;
            }
        }
    }
}