using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class Leaderboard
    {
        public static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int rank = 1;
            List<int> alicerank = new List<int>();

            for(int i=scores.Length-1; i > 0; i--)
            {
                if (scores[i] < scores[i - 1])
                    rank++;
            }
            rank++;
            int j = scores.Length - 1;
            for(int i=0; i < alice.Length; i++)
            {
                while(j>=0 && alice[i] >= scores[j])
                {
                    if (rank == 1)
                        break;
                    if(j>0 && scores[j] == scores[j-1])
                    {
                        j--;
                    }
                    else
                    {
                        rank--;
                        j--;
                    }
                }
                alicerank.Add(rank);
            }

            return alicerank.ToArray();
        }
    }
}
