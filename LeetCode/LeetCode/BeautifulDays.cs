using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BeautifulDays
    {
        public static int beautifulDays(int i, int j, int k)
        {
            int count = 0;
            for(int n=i; n <= j; n++)
            {
                int rev = 0;
                int partial = n;
                while (partial != 0)
                {
                    rev = rev * 10 + partial % 10;
                    partial /= 10;
                }

                if (Math.Abs(rev - n) % k == 0) count++;
            }
            return count;
        }
    }
}
