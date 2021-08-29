using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public static class IPAddresses
    {
        public static IList<string> RestoreIpAddresses(string s)
        {
            var result = new List<string>();
            if(s.Length < 4 || s.Length > 12 )
            {
                return result;
            }


            backtrack(result, 0, new List<string>(),s);

            return result;
        }

        static void backtrack(List<string> result, int index, List<string> current, string s)
        {
            if (current.Count == 4)
            {
                if (index == s.Length)
                {
                    result.Add(string.Join(".", current));
                }
                return;
            }

            string num = "";

            for(int i = index;  i < Math.Min(index + 3, s.Length); i++)
            {
                num += s[i];

                if(num[0] == '0' && num.Length > 1)
                {
                    break;
                }

                if(Convert.ToInt16(num) >= 0 && Convert.ToInt16(num) <= 255)
                {
                    current.Add(num);
                    backtrack(result, i + 1, current, s);
                    current.RemoveAt(current.Count - 1);
                }

            }

        }


    }
}
