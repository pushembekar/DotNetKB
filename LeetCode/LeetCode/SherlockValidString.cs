using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class SherlockValidString
    {
        public static string isValid(string s)
        {
            Dictionary<char, int> charset = new Dictionary<char, int>();

            foreach(char c in s)
            {
                if (charset.ContainsKey(c)) charset[c]++;
                else charset.Add(c, 1);
            }

            if (charset.Values.ToList().Distinct().Count() == 1)
                return "YES";

            return "NO";
        }
    }
}
