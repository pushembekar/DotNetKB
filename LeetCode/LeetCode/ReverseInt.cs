using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class ReverseInt
    {
        public static int Reverse(int x)
        {
            int num = 0;
            bool neg = (x < 0) ? true : false;
            if (neg) x = -1 * x;

            while (x > 0)
            {
                checked
                {
                    try
                    {
                        num = (num * 10) + (x % 10);
                    }
                    catch(OverflowException ex)
                    {
                        num = 0;
                        break;
                    }
                }
                
                x /= 10;
            }

            if (neg) num = -1 * num;
            return num;
        }

        //public static int Reverse(int x)
        //{
        //    int num = 0;
        //    bool neg = (x < 0) ? true : false;
        //    var lst = String.Empty;

        //    while (x > 0)
        //    {
        //        lst += (x % 10).ToString();
        //        x /= 10;
        //    }

        //    num = Convert.ToInt32(lst);
        //    if (neg) num = -1 * num;
        //    return num;
        //}
    }
}
