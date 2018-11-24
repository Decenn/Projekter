using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gæstebog
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path = @"C:\Users\Sebber\Desktop";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    Console.WriteLine("Hej");
                }
            }
        }
        
    }
}
