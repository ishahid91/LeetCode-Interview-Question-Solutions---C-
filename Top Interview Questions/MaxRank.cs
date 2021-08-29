using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public static class MaxRank
    {
        public static int MaximalNetworkRank(int n, int[][] roads)
        {
            int[] indegree = new int[n];

            HashSet<string> directed = new HashSet<string>();
            for(int i = 0; i < roads.Length; i++)
            {
                indegree[roads[i][0]] += 1;
                indegree[roads[i][1]] += 1;

                directed.Add(roads[i][0] + "," + roads[i][1]);
                directed.Add(roads[i][1] + "," + roads[i][0]);
            }

           int MaxRank = 0;
            for(int i = 0; i < n; i ++)
            {
                for(int j = i; j < n; j++)
                {
                    var offset = 0;
                    if(directed.Contains(i +"," + j))
                    {
                        offset = 1;
                    }
                    MaxRank = Math.Max(MaxRank, indegree[i] + indegree[j] - offset);
                }
            }

            return MaxRank;
        }
    }
}
