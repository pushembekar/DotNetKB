using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class SavePrisoner
    {
        public static int saveThePrisoner(int n, int m, int s)
        {
            int prisoner = (((m % n) + (s - 1)) % n);
            return prisoner == 0 ? n : prisoner; 

        }
    }
}
