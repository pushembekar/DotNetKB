using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter string");
            //string input = Console.ReadLine();

            //int result = ReverseInt.Reverse(Convert.ToInt32(input));
            //bool isPalindrome = Palindrome.IsPalindrome(Convert.ToInt32(input));
            //int result = Divisible.divisibleSumPairs(6, 3, new int[] { 1, 3, 2, 6, 1, 2 });
            //int result = StonesAndJewels.NumJewelsInStones("zxEc", "ztzzzIEEkslcc");
            //int result = MigratoryBirds.migratoryBirds(new int[] { 5, 2, 2, 2, 4, 1, 1, 2, 4, 2, 2, 2, 4, 1, 2, 4, 1,
            //                                                        2, 4, 4, 3, 2, 3, 1, 3, 3, 4, 3, 5, 2, 5, 3, 4, 1,
            //                                                        3, 2, 3, 3, 3, 5, 2, 4, 1, 5, 4, 5, 4 });
            //string result = DayOfTheProgrammer.Solve(1918);

            //string result = ToLowerCase.toLowerCase("AkalckD");
            //string result = BillSplit.SplitBill(92747, new int[] { 9044, 3135, 7604, 4793, 8, 4704, 3565, 8545, 9328, 4186, 3940, 7003, 3531, 1093, 7494, 8593, 3779, 3062, 3 }, 0);
            //int result = SockMerchant.SocksSold(2, new int[] { 2,4 });
            //int result = Skyline.MaxIncreaseKeepingSkyline(new int[4][] { new int[] { 3, 0, 8, 4}, new int[] { 2, 4, 5, 7}, new int[] { 9, 2, 6, 3 }, new int[] { 0, 3, 1, 0} });
            //int result = MorseCode.UniqueMorseCodeRepresentations(new string[] { "gin", "zen", "gig", "msg"});
            //int result = Valleys.countingValleys(12, "DDUUUUDDDUDU");
            //int result = ElectronicsShop.getMoneySpent(new int[] { 30, 26, 24, 16, 8, 6 }, new int[] { 14, 13, 8, 5, 4 }, 15);
            //string result = CatsAndMouse.catAndMouse(1, 3, 2);
            //int result = Numbers.pickingNumbers(new[] { 1,2,2,3,1,2 });
            //var result = Leaderboard.climbingLeaderboard(new[] { 125, 100, 100, 50, 40, 40, 20, 10 }, new[] { 5,8,25,50,120 });
            //var result = PDFViewer.designerPdfViewer(new[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 }, "zaba");
            //var result = Utopia.utopianTree(59);
            //var result = Professor.angryProfessor(2, new[] { 0, -1, 2, 1 });
            //var result = BeautifulDays.beautifulDays(20, 23, 6);
            //var result = Advertizing.viralAdvertising(60);
            var result = SavePrisoner.saveThePrisoner(5, 2, 2);

            Console.WriteLine(result);
            //Console.WriteLine(int.MaxValue);
            Console.ReadKey();
        }

        public static int LengthOfLongestSubstring(string s)
        {
            // initialize return variable (optional)
            int count = 0;

            // if the string is null or empty return zero
            if (string.IsNullOrEmpty(s)) return 0;
            // if the string has exactly one character, return 1
            if (s.Length == 1) return 1;

            for (int i = 0; i < s.Length; i++)
            {
                // find the next occurrence of the character at hand
                int index = s.IndexOf(s[i], i + 1);
                // if we don't find the character this means that part of the substring
                // is distinct. For now, set the index to length of the string
                if (index == -1) index = s.Length;
                // if the difference between the index of the next char
                // and the current iterator is more than the value of count
                // replace count with the difference; otherwise keep it
                count = (index - i) > count ? (index - i) : count;
            }

            // return statement
            return count;
        }

        public bool IsValid(string s)
        {
            int count = 0, count2 = 0, count3 = 0;
            foreach (char c in s)
            {
                if (c == '(') count++;
                if (c == ')') count--;
                if (c == '[') count2++;
                if (c == ']') count2--;
                if (c == '{') count3++;
                if (c == '}') count3--;
            }
            return count == 0 && count2 == 0 && count3 == 0 && s != "([)]" && s != "{[}]" && s != "[([]])" ? true : false;
        }
    }
}
