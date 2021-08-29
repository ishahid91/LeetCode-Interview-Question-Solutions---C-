using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
   public static  class Calculator
    {
        public static int Calculate(string s)
        {
            int len = s.Length;
            int sign = 1;
            int result = 0;

            Stack<int> stack = new Stack<int>();

            for(int i = 0 ; i < len; i++)
            {
                if (Char.IsDigit(s[i])) // multiple digit
                {
                    int sum = s[i] - '0';
                    while (i + 1 < len && char.IsDigit(s[i + 1]))
                    {
                        sum = sum * 10 + s[i + 1] - '0';
                        i++;
                    }

                    result += sum * sign;
                }
                else if (s[i] == '+')
                {
                    sign = 1;
                }
                else if(s[i] == '-')
                {
                    sign = -1;
                }
                else if(s[i] == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if (s[i] == ')')
                {
                    result = result * stack.Pop() + stack.Pop();
                }
            }

            return result;

        }


        public static int Calculate2(string s)
        {
            int len = s.Length;
            int operation = '+';
            int result = 0;

            Stack<int> stack = new Stack<int>();

            int currentNumber = 0;
            for (int i = 0; i < len; i++)
            {
                var currentChar = s[i];
                if (Char.IsDigit(s[i])) // multiple digit
                {
                    currentNumber= s[i] - '0';
                    while (i + 1 < len && char.IsDigit(s[i + 1]))
                    {
                        currentNumber = currentNumber * 10 + s[i + 1] - '0';
                        i++;
                    }

                }
                if (!char.IsDigit(currentChar) && currentChar != ' ' || i ==len - 1)
                {
                    if (operation == '+')
                    {
                        stack.Push(currentNumber);
                    }
                    else if (operation == '-')
                    {
                        stack.Push(-currentNumber);
                    }
                    else if (operation == '*')
                    {
                        stack.Push(stack.Pop() * currentNumber);
                    }
                    else if (operation == '/')
                    {
                        stack.Push(stack.Pop() / currentNumber);
                    }

                    operation = currentChar;
                    currentNumber = 0;
                }
            }

            while(stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;

        }



        public static int Calculate2New(string s)
        {
            int len = s.Length;
            int operation = '+';
            int result = 0;


            int currentNumber = 0;
            int lastNumber = 0;
            for (int i = 0; i < len; i++)
            {
                var currentChar = s[i];
                if (Char.IsDigit(s[i])) // multiple digit
                {
                    currentNumber = s[i] - '0';
                    while (i + 1 < len && char.IsDigit(s[i + 1]))
                    {
                        currentNumber = currentNumber * 10 + s[i + 1] - '0';
                        i++;
                    }

                }
                if (!char.IsDigit(currentChar) && currentChar != ' ' || i == len - 1)
                {
                    if(operation == '+' || operation == '-')
                    {
                        result += currentNumber;
                        lastNumber = operation == '+' ? currentNumber : -currentNumber;
                    }
                    else if(operation == '*')
                    {
                        lastNumber = lastNumber * currentNumber;
                    }
                    else if (operation == '/')
                    {
                        lastNumber  = lastNumber / currentNumber;
                    }
                    operation = currentChar;
                    currentNumber = 0;
                }
            }

            result += lastNumber;
            return result;

        }
    }
}
