using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Classes
{
    // tool used for the encryption of user passwords and user files.
    public class EncryptionTool
    {
        public static string encryptText(string message)
        {
            char[] charArray = message.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string decryptText(string message)
        {
            char[] charArray = message.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
