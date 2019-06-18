using System;
using CSharpNutshell.Constructors.Multiple_Constructors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNutshell
{
    class Program
    {
        static void Main()
        {
            Foo(10);
            Foo(10, 20);
            Foo(10, 5, 30);
            Creation Product1 = new Creation(10, 30, "Name");
        }
        static void Foo(int x) => Console.WriteLine(x);
        static void Foo(int x, int y) => Console.WriteLine(x + y);
        static void Foo(int x, int y, int z) => Console.WriteLine(x * z - y);
    }
}

