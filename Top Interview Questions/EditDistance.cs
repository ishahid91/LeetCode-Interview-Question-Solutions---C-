using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            var word1Len = word1.Length;
            var word2Len = word2.Length;

            if(word1Len * word2Len == 0)
            {
                return word1Len + word2Len ;
            }

            var tmp = new int[word1Len + 1,word2Len + 1];

            for(int i = 0; i < word1Len; i++)
            {
                tmp[0, i] = i;
            }

            for (int i = 0; i < word1Len; i++)
            {
                tmp[i, 0] = i;
            }

            for(var i = 1; i <= word1Len; i++)
            {
                for(var j = 1; j <= word2Len; j++)
                {
                    if(word1.ToCharArray()[i] == word2.ToCharArray()[j])
                    {
                        tmp[i, j] = tmp[i - 1, j - 1];
                    }
                    else
                    {
                        tmp[i, j] = min(tmp[i, j - 1], tmp[i - 1, j - 1], tmp[i - 1, j]) + 1;
                    }
                }
            }

            return tmp[word1Len, word2Len];

        }

        private int min(int a, int b, int c)
        {
            int l = Math.Min(a, b);
            return Math.Min(l, c);
        }

    }
}
