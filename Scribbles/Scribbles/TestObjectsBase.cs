using System;
using System.Linq;

namespace Scribbles
{
    class TestObjectsBase : ITestObjects
    {
        
        public delegate void DelegateTest();
        public static void DelegateTestOne() => Console.WriteLine("Delegate one");
        public static void DelegateTestTwo() => Console.WriteLine("Delegate two");
        public int Size;
        public int Weight;
        public string Name;
        void ITestObjects.WriteToConsole() => Console.WriteLine("Base object");
        public virtual void PerformLogicHere() { }
    }

    class TestObjectsOne : TestObjectsBase, ITestObjects
    {
        public override void PerformLogicHere()
        {
            Console.WriteLine("Object type one");
        }
        void ITestObjects.WriteToConsole() => Console.WriteLine("Type one object");
    }
    interface ITestObjects
    {
        void WriteToConsole();
        //void DetailedConsole(TestObjectsBase e);
    }
    interface ITestObjectsTwo
    {
        void DetailedWriteToConsole(TestObjectsBase e);
    }
}
