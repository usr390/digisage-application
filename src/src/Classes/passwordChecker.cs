using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Classes
{
    public class passwordChecker
    {
        public bool capChecker(Char[] p) // checks for the first capital letter it comes across
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (Char.IsUpper(p[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool numChecker(Char[] p) // checks for the first number it comes across
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (Char.IsDigit(p[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool illChecker(Char[] p) // checks for any illegal symbols
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (Char.IsSymbol(p[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool spChecker(Char[] p) // checks for the first special character it comes across
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].Equals("!") || p[i].Equals("#") || p[i].Equals("$") || p[i].Equals("&") || p[i].Equals("@") || p[i].Equals("%"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
