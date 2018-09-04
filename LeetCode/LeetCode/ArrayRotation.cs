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
            k = k % n;
            int[] b = new int[n];

            for(int i=0; i<n; i++)
            {
                if (i + k < n)
                    b[i + k] = a[i];
                else
                    b[i - (n - k)] = a[i];
            }
            for(int i=0; i < queries.Length; i++)
            {
                queries[i] = b[queries[i]];
            }

            return queries;
        }
    }
}
