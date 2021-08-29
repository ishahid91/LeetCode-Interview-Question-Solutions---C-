using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public static class RandomProblems
    {
        public static int MyAtoi(string s)
        {
            var sign = 1;
            int num = 0;
            for(var i = 0; i < s.Length; i++)
            {
                while(i < s.Length && !char.IsWhiteSpace(s[i]))
                {
                    i++;
                }

                sign = s[i] == '+' ? 1 : -1;

                if(Char.IsDigit(s[i]))
                {
                    num = num * 10 + s[i];
                }

            }
            return num * sign;
        }

        public static String longestPalindrome(String s)
        {
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int s1 = extend(s, i, i);
                int s2 = extend(s, i, i + 1);
                var len = Math.Max(s1, s2);
              if(len > end - start)
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }
            return s.Substring(start, end-start);
        }

        public  static int extend(String s, int i, int j)
        {
            for (; i >= 0 && j < s.Length; i--, j++)
            {
                if (s[i] != s[j]) break;
            }
            return i - j - 1;
        }
    }
    }
