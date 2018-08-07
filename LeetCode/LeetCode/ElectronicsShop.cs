using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    public static class ElectronicsShop
    {
        public static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            keyboards = keyboards.OrderByDescending(item => item).ToArray();
            drives = drives.OrderByDescending(item => item).ToArray();
            int threshold = -1;

            for(int i = 0; i < keyboards.Length; i++)
            {
                for(int j = 0; j < drives.Length; j++)
                {
                    if (keyboards[i] + drives[j] == b) return keyboards[i] + drives[j];
                    else if (keyboards[i] + drives[j] > b) continue;
                    else
                    {
                        threshold = Math.Max(threshold, keyboards[i] + drives[j]);
                    }
                }
            }

            return threshold;
        }
    }
}
