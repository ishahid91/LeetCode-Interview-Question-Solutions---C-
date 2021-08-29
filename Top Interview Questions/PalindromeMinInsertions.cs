using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class PalindromeMinInsertions
    {
        int[,] memo;
        public int MinInsertions(string s)
        {
            memo = new int[s.Length,s.Length];
            if(s.Length == 0)
            {
                return 0;
            }
            return FindMinInsertions(s, 0, s.Length - 1);
        }

        int FindMinInsertions(string s, int start, int end)
        {
            if(start >= end)
            {
                return 0;
            }

            if(memo[start,end] != 0)
            {
                return memo[start, end];
            }

            int count = 0;

            if(s[start] == s[end])
            {
                count = FindMinInsertions(s, start + 1, end - 1);
            }
            else
            {
                count = 1 + Math.Min(FindMinInsertions(s, start + 1, end), FindMinInsertions(s, start, end - 1));
            }

            memo[start, end] = count;


            return count;
        }
    }
}
