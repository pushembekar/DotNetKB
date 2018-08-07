using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Valleys
    {
        public static int countingValleys(int n, string s)
        {
            int sealevel = 0;
            int valleys = 0;

            char[] str = s.ToCharArray();

            foreach(char c in str)
            {
                if (c == 'U')
                {
                    sealevel++;
                    if (sealevel == 0)
                        valleys++;
                }
                else sealevel--;

            }

            return valleys;
        }
    }
}
