using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class FindJudg
    {
        public int FindJudge(int n, int[][] trust)
        {
            if (trust.Length < n - 1)
            {
                return -1;
            }

            int[] trustScore = new int[n + 1];

            foreach (var relation in trust)
            {
                trustScore[relation[0]]--;
                trustScore[relation[1]]++;
            }
            for (var i = 1; i <= n; i++)
            {
                if (trustScore[i] == n - 1)
                {
                    return i;
                }
            }

            return -1;



        }
    }
}
