using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class MaxDotProducts
    {
        public int MaxDotProduct(int[] nums1, int[] nums2)
        {
            int[,] result = new int[nums1.Length,nums2.Length]; 

            for(int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    result[i, j] = nums1[i] * nums2[j];
                    if(i > 0 && j > 0)
                    {
                        result[i, j] += Math.Max(result[i - 1, j - 1],0);
                    }
                    if(i > 0)
                    {
                        result[i, j] = Math.Max(result[i, j], result[i - 1, j]);
                    }
                    if (j > 0)
                    {
                        result[i, j] = Math.Max(result[i, j], result[i, j-1]);
                    }
                }
            }

            return result[nums1.Length - 1, nums2.Length - 1];
        }
    }
}
