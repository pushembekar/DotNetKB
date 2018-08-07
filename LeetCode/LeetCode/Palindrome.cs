using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Palindrome
    {
        public static bool IsPalindrome(int x)
        {
            int num = x;
            int palindrome = 0;
            if (x < 0)
                return false;
            checked
            {
                try
                {
                    while(num > 0)
                    {
                        palindrome = (palindrome * 10) + (num % 10);
                        num /= 10;
                    }

                    if (x == palindrome) return true;
                }
                catch(OverflowException ex)
                {
                    palindrome = 0;
                }
            }

            return false;
        }
    }
}
