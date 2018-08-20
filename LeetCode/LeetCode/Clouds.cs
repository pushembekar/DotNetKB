using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Clouds
    {
        public static int jumpingOnClouds(int[] c, int k)
        {
            int e = 100;
            for(int i= 0; i < c.Length; i +=k)
            {
                if (k > c.Length) break;

                e -= (c[i] == 1) ? 3 : 1;
                
            }
            return e;
        }
    }
}
