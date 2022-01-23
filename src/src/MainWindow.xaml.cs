 using SQLite;
using src.Classes;
using src.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace src
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            userDatabaseManager userDatabaseManager = new userDatabaseManager();
        }

        private async void passwordButton_Click(object sender, RoutedEventArgs e)
        {
            string pass = passwordTextBox.Password;
            if (Guard.passwordIsValidated(EncryptionTool.encryptText(pass)))
            {
                MenuWindow menuWindow = new MenuWindow();
                Close();
                menuWindow.ShowDialog();
            }
            else
            {
                popup.Visibility = Visibility.Visible;
                await Task.Delay(3000);
                popup.Visibility = Visibility.Hidden;
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
