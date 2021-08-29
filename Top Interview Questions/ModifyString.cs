using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class ModifyStringReplace
    {
        public static string ModifyString(string s)
        {
            var arr = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '?')
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i > 0 && s[i - 1] - 'a' == j) continue;
                        if (i + 1 < s.Length && s[i + 1] - 'a' == j) continue;
                        arr[i] = (char)('a' + j);
                    }
                }

            }

            return new string(arr);
        }
    }
}
