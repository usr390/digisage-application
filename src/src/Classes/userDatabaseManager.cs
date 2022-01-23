using SQLite;
using src.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace src.Classes
{
    public class userDatabaseManager
    {
        passwordChecker pc = new passwordChecker();

        // userDatabaseManager manages the single user in the userDatabase. This application will always
        // have one user and one user only.
        public userDatabaseManager()
        {
            // creates database and asks user to create credentials
            createDatabase();
            initializeUser();
        }
        public void fetchInfoFromUpdateUserInfoWindow(string windowPassword, string windowEmail, string cWP)
        {
            // this method is called from a window, specifically 'UpdateUserInfoWindow'. It fetches information provdied
            // by the text fields and passes it to 'userDatabaseManager' class members 'password' and 'email'.

            Password = EncryptionTool.encryptText(windowPassword);
            Email = EncryptionTool.encryptText(windowEmail);
            cPassword = EncryptionTool.encryptText(cWP);
        }
        public static string dispenseCipheredPassword()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.userDatabasePath))
            {
                return connection.Table<User>().ToList()[0].Password;
            }
        }
        private void createDatabase()
        {

            if (databaseIsCreated())
            {
                // do nothing
            } 
            else
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.userDatabasePath))
                {
                    connection.CreateTable<User>();
                    connection.Insert(createUser());                                                                // creates a null user and inserts into the database
                }
            }
        }
        private void initializeUser()
        {
            // prompts user to set password when running application for the first time
                if (fetchUser().Password == "")
                {
                    UpdateUserInfoWindow UpdateUserInfoWindow = new UpdateUserInfoWindow(this);                         // creates new window where user is to update their information. the manager is passed to this window.
                    UpdateUserInfoWindow.ShowDialog();                                                                  // displays window

                    var p = Password.ToCharArray();
                    if (Password != cPassword)
                    {
                        // gotta match until then we aint moving
                    }

                    if (pc.illChecker(p))
                    {
                        // ey u got sumthin illegal in dere
                    }

                    if (p.Length < 12 && !pc.capChecker(p) && !pc.numChecker(p) && !pc.spChecker(p))
                    {
                        // ey man u missing shii
                    }
                
                using (SQLiteConnection connection = new SQLiteConnection(App.userDatabasePath))
                {
                    connection.CreateTable<User>();
                    User user = fetchUser();
                    user.Email = Email;
                    user.Password = Password;
                    connection.Update(user);
                }
            }
        }
        private void updateUser()
        {
            // to be implemented when we develop more of the UI. allows user to update their credentials.
        }
        private bool databaseIsCreated()
        {
            // bool method that tells the manager if user database has been created. Prevents duplicate databases.
            using (SQLiteConnection connection = new SQLiteConnection(App.userDatabasePath))
            {
                connection.CreateTable<User>();
                var tableMembers = connection.Table<User>().ToList();

                if (tableMembers.Count == 0)
                    return false;
            }

            return true;
        }
        private User createUser()
        {
            return new User();
        }
        private User fetchUser()
        {
            // returns the single user in the user database
            using (SQLiteConnection connection = new SQLiteConnection(App.userDatabasePath))
            {
                return connection.Table<User>().ToList()[0];
            }
        }
        private string Password { get; set; }
        private string Email { get; set; }
        private string cPassword { get; set; }
    }
}
