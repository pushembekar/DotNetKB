using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Divisible
    {
        public static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int count = 0;
            for (int i = 0, j = i + 1; i < n -1;)
            {
                if ((ar[i] + ar[j]) % k == 0)
                    count++;
                if (j == n - 1)
                {
                    i++;
                    j = i + 1;
                }
                else j++;
            }
            return count;
        }
    }
}
