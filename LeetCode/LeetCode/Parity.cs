using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Parity
    {
        public static List<IList<int>> alternatingParityPermutations(int n)
        {
            List<IList<int>> output = new List<IList<int>>();
            int[] input = new int[n];
            for (int i = 1; i <= n; i++)
            {
                input[i - 1] = i;
            }

            for (int i = 0; i < input.Length; i++)
            {
                //FormParity(input, output, i, new List<int>());
                Backtrack(input, i, new List<int>(), output);
            }

            return output;
        }

        private static void Backtrack(int[] nums, int currentIndex, List<int> currentCombination, List<IList<int>> result)
        {
            List<int> tempList = new List<int>(currentCombination);

            tempList.Add(nums[currentIndex]);

            if (tempList.Count == nums.Length)
            {
                if (CheckParity(tempList.ToArray()))
                    result.Add(tempList);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
                if (!tempList.Contains(nums[i]))
                    Backtrack(nums, i, tempList, result);
        }

        private static bool CheckParity(int[] nums)
        {
            bool state = isOdd(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (isOdd(nums[i]) == state)
                {
                    return false;
                }

                state = isOdd(nums[i]);
            }
            return true;
        }

        private static bool isOdd(int n)
        {
            return n % 2 == 1;
        }

        private static bool isEven(int n)
        {
            return !isOdd(n);
        }

        //private static void FormParity(int[] input, List<IList<int>> output, int currentIndex, List<int> currentcombo)
        //{
        //    List<int> list = new List<int>(currentcombo);
        //    list.Add(input[currentIndex]);

        //    if (list.Count == input.Length)
        //    {
        //        output.Add(list);
        //        return;
        //    }

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (!list.Contains(input[i]))
        //            FormParity(input, output, currentIndex, list);
        //    }
        //}
    }
}
