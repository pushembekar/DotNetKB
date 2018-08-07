using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class Numbers
    {
        public static int pickingNumbers(int[] a)
        {
            int count = 0;
            int final = 0;

            for(int i=0; i< a.Length-1; i++)
            {
                for (int j= i+1; j < a.Length; j++)
                {
                    if(a[i] == a[j] || Math.Abs(a[i] - a[j]) == 1)
                    {
                        count++;
                        if (!(j+1 < a.Length && (a[j] == a[j+1] || Math.Abs(a[j] - a[j+1]) == 1)))
                        {
                            if (count > final) final = count;
                            count = 0;
                        }
                    }
                }
                if (count > final) final = count;
                count = 0;
            }

            return final + 1;
        }
    }
}
