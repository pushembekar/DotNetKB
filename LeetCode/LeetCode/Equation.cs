using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Equation
    {
        public static int[] permutationEquation(int[] p)
        {
            int[] order = new int[p.Length];

            for (int i=1; i <= p.Length; i++)
            {
                int index1 = Array.IndexOf(p, i) + 1;
                int index2 = Array.IndexOf(p, index1) + 1;
                order[i - 1] = index2;
            }

            return order;
        }
    }
}
