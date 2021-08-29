using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class ReverseWords
    {
       



        public StringBuilder trimSpaces(String s)
        {
            int left = 0, right = s.Length - 1;
            // remove leading spaces
            while (left <= right && s[left] == ' ') ++left;

            // remove trailing spaces
            while (left <= right && s[right] == ' ') --right;

            // reduce multiple spaces to single one
            StringBuilder sb = new StringBuilder();
            while (left <= right)
            {
                char c = s[left];

                if (c != ' ') sb.Append(c);
                else if (sb[sb.Length - 1] != ' ') sb.Append(c);

                ++left;
            }
            return sb;
        }

        public void reverse(StringBuilder result, int left, int right)
        {

            while (left < right)
            {
                var tmp = result[left];
                result[left] = result[right];
                result[right] = tmp;

                left++;
                right--;
            }

        }

        public void reverseEachWord(StringBuilder sb)
        {
            int n = sb.Length;
            int start = 0, end = 0;

            while (start < n)
            {
                // go to the end of the word
                while (end < n && sb[end] != ' ') ++end;
                // reverse the word
                reverse(sb, start, end - 1);
                // move to the next word
                start = end + 1;
                ++end;
            }
        }

        public String reverseWords(String s)
        {
            // converst string to string builder 
            // and trim spaces at the same time
            StringBuilder sb = trimSpaces(s);

            // reverse the whole string
            reverse(sb, 0, sb.Length - 1);

            // reverse each word
            reverseEachWord(sb);

            return sb.ToString();
        }
    }
}
