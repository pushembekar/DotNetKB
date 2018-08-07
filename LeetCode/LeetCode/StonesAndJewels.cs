using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class StonesAndJewels
    {
        public static int NumJewelsInStones(string J, string S)
        {
            int jewels = 0;

            char[] stones = S.ToCharArray();
            foreach(var stone in stones)
            {
                if (J.Contains(stone.ToString())) jewels++;
            }

            return jewels;
        }
    }
}
