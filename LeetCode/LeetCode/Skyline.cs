using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Skyline
    {
        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            var rows = new int[grid.Length];
            var cols = new int[grid[0].Length];

            int sum = 0;

            for(int i=0; i < grid.Length; i++)
            {
                for(int j=0; j < grid[i].Length; j++)
                {
                    rows[i] = Math.Max(rows[i], grid[i][j]);
                    cols[j] = Math.Max(cols[j], grid[i][j]);
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    sum += (Math.Min(rows[i], cols[j]) - grid[i][j]);
                }
            }

            return sum;
        }
    }
}
