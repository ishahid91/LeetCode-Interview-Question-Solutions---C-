using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public class testclass
    {
        public virtual int A { get; set; }

        public virtual int GetA()
        {
            return A;
        }
    }

    public class testclass2
    {
        public int a { get; set; }

        testclass aa = new testclass();
    }

    public class testclass3 : testclass
    {

        public override int GetA()
        {
            return base.GetA();
        }
    }


}
