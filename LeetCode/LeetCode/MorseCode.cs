using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class MorseCode
    {
        public static int UniqueMorseCodeRepresentations(string[] words)
        {
            string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            List<string> strMorse = new List<string>();
            foreach (var word in words)
            {
                string str = String.Empty;
                for (int i = 0; i < word.Length; i++)
                {
                    int ascii = (int)word[i];
                    str += morse[ascii - 97];
                }
                strMorse.Add(str);
            }

            return strMorse.GroupBy(a => a).Count();
        }
    }
}
