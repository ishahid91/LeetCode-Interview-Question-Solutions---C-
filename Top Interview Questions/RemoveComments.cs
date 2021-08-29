using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    static class RemoveComments
    {
        public static List<String> removeComments(String[] source)
        {
            StringBuilder sb = new StringBuilder();
            var result = new List<string>();

            bool comment = false;
            foreach (var line in source)
            {

                for (var i = 0; i < line.Length; i++)
                {
                    var currentChar = line[i];
                    if (comment)
                    {
                        if (currentChar == '*' && i < source.Length - 1 && line[i + 1] == '/')
                        {
                            comment = false;
                            i++;
                        }
                    }
                    else
                    {
                        if (currentChar == '/' && i < source.Length - 1 && line[i + 1] == '/')
                        {

                            break;
                        }
                        else if (currentChar == '/' && i < source.Length - 1 && line[i + 1] == '*')
                        {
                            comment = true;
                            i++;
                        }
                        else
                        {
                            sb.Append(currentChar);
                        }
                    }

                }

                if (!comment && sb.Length > 0)
                {
                    result.Add(sb.ToString());
                }
                sb = new StringBuilder();
            }
            return result;
        }
    }
}
