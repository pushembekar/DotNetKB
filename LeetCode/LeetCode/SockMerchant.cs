using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    public static class SockMerchant
    {
        public static int SocksSold(int n, int[] ar)
        {
            return ar.GroupBy(a => a)
                    .Select(c => c.Count() / 2)
                    .Sum();
        }
    }
}
