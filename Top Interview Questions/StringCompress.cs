using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class StringCompress
    {
        public int compress(char[] chars)
        {
            var index = 0;
            var ResultIndex = 0;
            while(index < chars.Length)
            {
                var currentChar = chars[index];
                int count = 0;
                while(index < chars.Length && chars[index] == currentChar)
                {
                    index++;
                    count++;
                }

                chars[ResultIndex++] = currentChar;
                if(count > 1)
                {
                    foreach (var c in count.ToString())
                    {
                        chars[ResultIndex++] = c;
                    }
                }

            }

            return ResultIndex;
        }
    }
}
