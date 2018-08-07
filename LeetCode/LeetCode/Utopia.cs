using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Utopia
    {
        public static int utopianTree(int n)
        {
            if (n == 0)
                return 1;
            else if (n % 2 == 0)
                return 1 + utopianTree(n - 1);
            else
                return 2 * utopianTree(n - 1);
        }
    }
}
