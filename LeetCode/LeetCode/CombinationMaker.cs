using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class CombinationMaker
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
        {
            yield return item;

            foreach (var element in source)
            {
                yield return element;
            }
        }
    }
}
