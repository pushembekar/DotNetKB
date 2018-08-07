using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class PDFViewer
    {
        public static int designerPdfViewer(int[] h, string word)
        {
            char[] words = word.ToCharArray();
            int sum = 0;

            for(int i = 0; i < words.Length; i++)
            {
                sum = Math.Max(sum, h[words[i] - 97]);
            }

            return sum* words.Length;
        }
    }
}
