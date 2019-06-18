using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNutshell.Ref_Out
{
    class Ref
    {
        class Test
        {
            static void Foo(ref int p)
            {
                p = p + 1; // Increment p by 1
                Console.WriteLine(p); // Write p to screen
            }
            static void Temp()
            {
                int x = 8;
                Foo(ref x); // Ask Foo to deal directly with x
                Console.WriteLine(x); // x is now 9
            }
            public int x { get; set; }
            
        }

    }
}
