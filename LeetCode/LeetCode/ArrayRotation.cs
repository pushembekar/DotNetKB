using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class ArrayRotation
    {
        public static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            int n = a.Length;
            int actual = k % n;
            int[] b = new int[n];

            for(int i = 0; i < queries.Length; i++)
            {
                if (queries[i] - actual >= 0)
                    b[i] = a[queries[i] - actual];
                else
                    b[i] = a[queries[i] - actual + n];

            }

            return b;
        }
    }
}
