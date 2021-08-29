using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class FindCeleb
    {
        public virtual bool Knows(int a, int b)
        {
            return true;
        }
        int number = 0;
        public int FindCelebrity(int n)
        {
            number = n;
            int celebrity = 0;
            for (int i = 0; i < n; i++)
            {
                if (Knows(celebrity, i))
                {
                    celebrity = i;
                }

            }

            if(IsCelebrity(celebrity))
            {
                return celebrity;
            }
            return -1;

        }

        public bool IsCelebrity(int celebrity)
        {
            for(var i = 0; i < number; i++)
            {
                if (i == celebrity) continue;

                if(Knows(celebrity,i) || !Knows(i,celebrity))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
