using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    public static class BillSplit
    {
        public static string SplitBill(int k, int[] ar, int charged)
        {
            string result = String.Empty;
            var split = (ar.Where((x, i) => i != k).Sum()) / 2.0;
            

            if (split == Convert.ToDouble(charged))
                result = "Bon Appetit";
            else
                result = (charged - split/2).ToString();

            return result;
        }
    }
}
