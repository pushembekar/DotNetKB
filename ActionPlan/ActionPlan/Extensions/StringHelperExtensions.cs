using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionPlan.Extensions
{
    public static class StringHelperExtensions
    {
        public static string Truncate(this string value, int words)
        {
            // return input if it is either null or empty
            if (String.IsNullOrEmpty(value)) return value;
            // split the string into words
            var wordlist = value.Split(' ');
            // if words is greater that or equal to words in the string, return the string
            if (words >= wordlist.Length) return value;
            // return the trucated substring
            return string.Join(' ', wordlist.Take(words));
        }
    }
}
