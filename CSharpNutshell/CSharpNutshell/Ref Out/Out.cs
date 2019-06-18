using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNutshell.Ref_Out
{
    class Out
    {
        class Test
        {
            static void Split(string name, out string firstNames,
            out string lastName)
            {
                int i = name.LastIndexOf(' ');
                firstNames = name.Substring(0, i);
                lastName = name.Substring(i + 1);
            }
            static void Temp()
            {
                string a, b;
                Split("Stevie Ray Vaughan", out a, out b);
                Console.WriteLine(a); // Stevie Ray
                Console.WriteLine(b); // Vaughan
            }
        }
    }
}
