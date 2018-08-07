using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class HurdleRace
    {
        public static int hurdleRace(int k, int[] height)
        {
            int max = height.ToList().Max();
            if (max > k)
                return max - k;

            return 0;

        }
    }
}
