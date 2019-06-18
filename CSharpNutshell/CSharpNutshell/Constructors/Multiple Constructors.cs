using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNutshell.Constructors
{
    namespace Multiple_Constructors
    {
        public class Product
        {
            public static void Temp()
            {
                Creation Product1 = new Creation(10);
                Creation Product2 = new Creation(30, 10);
                Creation Product3 = new Creation(10, 35, "Chair");
                
                Console.WriteLine(Product1.height);
                Console.WriteLine(Product2.length);
            }
            
            
	    }
        public class Creation
        {
            public string name;
            public int height, length;
            public static int UserID;
            public static Creation Create()
            {
                return new Creation(10,"Test");
            }
            public Creation(int x)
            {
                height = x;
                UserID += 1;
            }
            public Creation(int x, int y)
            {
                height = x;
                length = y;
            }
            public Creation(int x, int y, string n)
            {
                name = n;
                height = x;
                length = y;
            }
            Creation(int x, string n)
            {

            }
            
        }
    }
}
