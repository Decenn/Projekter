using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribbles
{
    class Program
    {
        static void Main()
        {
            TestObjectsBase.DelegateTest testDelegate = TestObjectsBase.DelegateTestOne;
            testDelegate += TestObjectsBase.DelegateTestTwo;
            testDelegate();
            int x = 0;
            List<TestObjectsBase> testListTwo = new List<TestObjectsBase>
            {
                new TestObjectsBase { Size = 25, Name = "Object 1", Weight = 302 },
                new TestObjectsBase { Size = 12, Name = "Object 2", Weight = 25 },
                new TestObjectsOne { Size = 35, Name = "Object 3", Weight = 321 },
                new TestObjectsTwo { Size = 12, Name = "Object 4", Weight = 3920 }
            };
            
            ITestObjects e = new TestObjectsBase();
            foreach (var i in testListTwo)
            {
                e = testListTwo.ElementAt(x++);
                e.WriteToConsole();
            }
            testListTwo.Add(new TestObjectThree { Size = 25, Name = "Object 5", Weight = 392 });
            ITestObjectsTwo z = new TestObjectThree();
            z.DetailedWriteToConsole(testListTwo.Single(f => f.Name == "Object 5"));
            z.DetailedWriteToConsole(testListTwo.Single(f => f.Name == "Object 1"));
                
        }
    }
}
