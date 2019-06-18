using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribbles
{
    class DelegateTests
    {
        public static void NotMain()
        {
            NewDelegateTest test = Plus;
            TestArea(test);
            Action<int, int> action = new Action<int, int>(Minus);
            action(1, 2);
            action += Plus;
            action(1, 2);
        }
        public delegate void NewDelegateTest (int x, int y);
        public static void Plus(int x, int y)
        {
            Console.WriteLine(x+y);
        }

        public static void Minus(int x, int y)
        {
            Console.WriteLine(x-y);
        }

        public static void TestArea(NewDelegateTest delegateTest)
        {
            delegateTest.Invoke(1, 2);
        }
    }
}
