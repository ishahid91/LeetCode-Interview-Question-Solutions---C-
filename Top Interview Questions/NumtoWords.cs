using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public static class NumtoWords
    {
        private static string[] ONETOTWENTY = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static string[] TENS = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static string[] THOUSANDS = { "", "Thousand", "Million", "Billion" };

        public static string numberToWords(int num)
        {
            if (num == 0) return "Zero";

            int i = 0;
            string words = "";

            while (num > 0)
            {
                if (num % 1000 != 0)
                {
                    words = helper(num % 1000) + THOUSANDS[i] + " " + words;
                }

                num /= 1000;
                i++;
            }


            return words.Trim();

        }


        private static string helper(int num)
        {
            if (num == 0)
            {
                return "";
            }
            else if (num < 20)
                return ONETOTWENTY[num] + " ";
            else if (num < 100)
                return TENS[num / 10] + " " + helper(num % 10);
            else
                return ONETOTWENTY[num / 100] + " Hundred " + helper(num % 100);
        }
    }
}
