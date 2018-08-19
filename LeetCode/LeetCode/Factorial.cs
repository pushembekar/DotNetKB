using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCode
{
    public static class Factorial
    {
        public static void extraLongFactorials(int n)
        {
            var factorial = BigFactorial(n);
            Console.WriteLine(factorial.ToString());

        }

        private static BigInteger BigFactorial(BigInteger n)
        {
            if (n == 1)
                return 1;
            return n * BigFactorial(n - 1);
        }
    }
}
