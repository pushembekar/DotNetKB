using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class TextJustification
    {
        //https://leetcode.com/problems/text-justification/description/
        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            var retstring = new List<string>();
            int width = maxWidth;
            var sb = new List<string>();

            foreach(var word in words)
            {
                if (word.Length <= width)
                {
                    sb.Add(word);
                    width = width - word.Length - 1;
                }
                else
                {
                    if (sb.Count == 1)
                        retstring.Add(new StringBuilder().Append(sb[0]).Append(' ', maxWidth - sb[0].Length).ToString());
                    else
                    {
                        int spaces = width + sb.Count;
                        retstring.Add(FormSentence(sb, spaces));
                    }
                    sb = new List<string> { word };
                    width = maxWidth - word.Length - 1;
                }
            }

            if (sb.Count > 0)
            {
                var last = new StringBuilder();
                foreach(var s in sb)
                {
                    last.Append(s).Append(" ");
                }
                if (last.Length < maxWidth)
                    last.Append(' ', maxWidth - last.Length);

                retstring.Add(last.ToString());
            }

            return retstring;
        }

        private static string FormSentence(List<string> sb, int spaces)
        {
            int minspaces = spaces / (sb.Count- 1); // 8/2 = 4
            int extraspaces = spaces % (sb.Count - 1); // 8 % 2 = 0
            var retstring = new StringBuilder();

            foreach(var s in sb)
            {
                retstring.Append(s).Append(' ' , minspaces + (extraspaces > 0 ? 1 : 0));
                extraspaces = (extraspaces - 1) < 0 ? 0 : extraspaces - 1;
            }

            return retstring.ToString().Trim();
        }
    }
}
