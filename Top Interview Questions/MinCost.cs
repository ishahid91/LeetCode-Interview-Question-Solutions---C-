using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public static class MinCost
    {
        public static int minCost(String s, int[] cost)
        {
            int res = 0, max_cost = 0, sum_cost = 0, n = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && s[i] != s[i - 1])
                {
                    res += sum_cost - max_cost;
                    sum_cost = max_cost = 0;
                }
                sum_cost += cost[i];
                max_cost = Math.Max(max_cost, cost[i]);
            }
            res += sum_cost - max_cost;
            return res;
        }



        public static int minCost2(String s, int[] cost)
        {
            int n = s.Length;
            int result = 0;
            int prevCost = cost[0];

            for (int i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1])
                {
                    result += Math.Min(cost[i], prevCost);
                    prevCost = Math.Max(cost[i], prevCost);
                }
                else
                    prevCost = cost[i];
            }

            return result;
        }
    }
}
