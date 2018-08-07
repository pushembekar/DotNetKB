using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class ToLowerCase
    {
        public static string toLowerCase(string str)
        {
            string res = String.Empty;
            var s = str.ToCharArray();

            foreach(var c in s)
            {
                res = res + ((c >= 'A' && c <= 'Z') ? ((char)(c + 32)).ToString() : c.ToString());
            }

            return res;
        }
    }
}
