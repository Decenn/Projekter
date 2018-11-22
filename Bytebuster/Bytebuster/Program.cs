using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBuster
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int intSvar = 0;
            string strSvar;
            int intResultat = 0;
            int intRigtigeSvar = 0;
            int intForkertSvar = 3;
            bool talchecker = false;
            Console.WriteLine("Christian Mørk er altid på talentjagt");
            Console.WriteLine("Christian Mørk ønsker dig held og lykke med spillet.");
            Console.WriteLine("Vinder du, får du en lille præmie.");
            Console.WriteLine("De bedste hilsener fra Christian Mørk.");
            Console.WriteLine("Og så er vi i gang...");
            Console.WriteLine("");
            Console.WriteLine("Omregn de binære tal til decimal for at score points.");
            Console.WriteLine("Får du 3 point vinder du.");
            Console.WriteLine("Du har 5 forsøg.");
            Console.WriteLine("");
            for (int i = 0; i < 5; i++)
            {
                int rndtal = rnd.Next(0, 255);
                Console.Write("{0,10}", Convert.ToString(rndtal, 2) + ": ");
                strSvar = Console.ReadLine();
                while (talchecker == false)
                {
                    try
                    {
                        intSvar = Convert.ToInt32(strSvar);
                        talchecker = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Indtast kun tal!");
                        Console.Write("{0,10}", Convert.ToString(rndtal, 2) + ": ");
                        strSvar = Console.ReadLine();
                    }
                    if (intSvar == rndtal)
                    {
                        intResultat = intResultat + 1;
                        intRigtigeSvar = intRigtigeSvar + 1;

                    }
                    if (intResultat == 3)
                    {
                        i = 5;
                    }
                }
            }
            if (intResultat == 3)
            {
                Console.WriteLine("");
                Console.WriteLine("Tillykke, du har vundet!");
                Console.WriteLine("Kontakt mig på telefon 0x24688E8");
                Console.WriteLine("");
                Console.WriteLine("Venlig hilsen Christian");
                Console.WriteLine("");
                Console.WriteLine("Fortsat god festival og husk nu at få din præmie!");
                Console.WriteLine("");
                Console.WriteLine("Tryk enter for at afslutte programmet . . .");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Du ramte rigtigt " + intRigtigeSvar + " gange og mangler derfor " + (intForkertSvar - intRigtigeSvar) + " rigtige svar for at vinde.");
                Console.WriteLine("Tak fordi du spillede med. Fortsat god festival!");
                Console.WriteLine("");
                Console.WriteLine("Tryk enter for at afslutte programmet . . .");
                Console.ReadLine();
            }
        }
    }
}