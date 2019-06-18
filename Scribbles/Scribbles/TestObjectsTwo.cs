using System;
using System.Collections.Generic;

namespace Scribbles
{
    class TestObjectsTwo : TestObjectsBase, ITestObjects
    {
        
        int Count => this.Count;
        public override void PerformLogicHere()
        {
            Console.WriteLine("Object two");
        }
        void ITestObjects.WriteToConsole() => Console.WriteLine("Type two object");
        
    }
    public interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
    }
}
