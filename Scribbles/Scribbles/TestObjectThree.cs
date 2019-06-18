using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribbles
{
    class TestObjectThree : TestObjectsBase, ITestObjectsTwo
    {
        void ITestObjectsTwo.DetailedWriteToConsole(TestObjectsBase e)
        {
            Console.WriteLine("Name of object: " + e.Name);
            Console.WriteLine("Size of object: " + e.Size);
            Console.WriteLine("Weight of object: " + e.Weight);
            Console.WriteLine("Type of object: " + e.GetType());
        }
    }
}
