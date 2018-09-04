using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class FindDigits
    {
        public static int findDigits(int n)
        {
            int p = n;
            int count = 0;

            while(p > 0)
            {
                int d = p % 10;
                p /= 10;
                if (d == 0) continue;

                if (n % d == 0) count++;
            }

            return count;
        }
    }
}
