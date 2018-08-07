using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    public static class MigratoryBirds
    {
        public static int migratoryBirds(int[] ar)
        {
            return ar.GroupBy(item => item)
                        .Select(a => new { Bird = a.Key, Count = a.Count() })
                        .OrderByDescending(c => c.Count)
                        .ThenBy(c => c.Bird)
                        .First().Bird;

        }
    }
}
