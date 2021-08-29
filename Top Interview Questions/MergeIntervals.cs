using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codetest
{
    static class MergeIntervals
    {
        public static int[][] Merge(int[][] intervals)
        {
            intervals = intervals.OrderBy(s => s[0]).ToArray();

            var result = new List<int[]>();
            var current_start = intervals[0][0];
            var current_end = intervals[0][1];

            for(int i = 1; i < intervals.Length; i++)
            {
                if(intervals[i][0] < current_end)
                {
                    current_end = Math.Max(current_end, intervals[i][1]);
                }
                else
                {
                    result.Add(new int[] { current_start, current_end});
                    current_start = intervals[i][0];
                    current_end = intervals[i][1];
                }

            }
            result.Add(new int[] { current_start, current_end });

            return result.ToArray();
         }
    }
}
