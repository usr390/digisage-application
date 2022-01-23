using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace src
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // defines a path to the password database.
        static string userDatabaseName = "User.db";
        static string userDatabaseFolderPath = Directory.GetCurrentDirectory();
        public static string userDatabasePath = System.IO.Path.Combine(userDatabaseFolderPath, userDatabaseName);
    }
}
