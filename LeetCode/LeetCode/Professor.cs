using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class Professor
    {
        public static string angryProfessor(int k, int[] a)
        {

            return (a.Where(item => item <= 0).Count() < k) ? "YES" : "NO";

        }
    }
}
