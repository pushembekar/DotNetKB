using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Advertizing
    {
        public static int viralAdvertising(int n)
        {
            int sum = 0;
            int shared = 5;
            int liked = 0;

            for(int i=0; i<n; i++)
            {
                liked = shared / 2;
                sum += liked;
                shared = liked * 3;
            }

            return sum;
        }
    }
}
