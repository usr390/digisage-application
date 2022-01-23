using src.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Classes
{
    // prevents unauthorized users from accessing the main menu (where sensitive files are stored)
    public class Guard
    {
        public static bool passwordIsValidated(string loginPassword)
        {
            if (userDatabaseManager.dispenseCipheredPassword() == loginPassword)
                return true;

            return false;
        }
    }
}
