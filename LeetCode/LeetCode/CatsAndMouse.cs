using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class CatsAndMouse
    {
        public static string catAndMouse(int x, int y, int z)
        {
            if (Math.Abs(z - x) == Math.Abs(z - y)) return @"Mouse C";
            else if (Math.Abs(z - x) > Math.Abs(z - y)) return @"Cat B";
            else return @"Cat A";

        }
    }
}
