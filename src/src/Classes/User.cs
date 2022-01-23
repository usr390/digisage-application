using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Classes
{
    public class User
    {
        // acts as the databse that holds the user
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }  // optional

        public User() // constructor
        {
            Password = "";
            Email = "";
        }
    }
}