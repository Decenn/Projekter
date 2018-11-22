using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangmand
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool TryAgain = true;
            bool iLive = true;
            string strTryAgain = "";
            while (TryAgain == true)
            {
                Console.Clear();
                string[] randomOrd = { "øre", "tegning", "computer", "ræv", "mus", "gummi", "kat", "hund ", "bokser", "skærm", "bil", "cykel", "cola", "kaffe", "headset", "juice", "nørd", "papir",
                "ordbog", "opgave", "gave", "sprog", "kost", "skat", "ægteskab", "pirater",
                "pik", "liste", "vej", "fisk", "pool", "gas", "kapsel", "fodbold", "fisse",
                "violin", "jøde", "sten", "aske", "strand", "telefon", "våben", "hals", "te",
                "kappe", "lære", "underviser", "vogn", "isbjørn", "bjørn", "barn", "have",
                "børnehave", "selvmord", "sofa", "lov", "skov", "pistol", "jackpot", "bundkort",
                "klan", "vindue", "næse", "atom", "drage", "perle", "økse", "briller", "sodavand", "sukkersyge" };
                string valgtOrd = randomOrd[rnd.Next(1, randomOrd.Length)];
                string[] arrValgtOrd = OrdSplitter(valgtOrd);
                string[] arrRigtigeBogstaver = new string[arrValgtOrd.Length];
                string[] arrForkerteBogstaver = new string[6];
                string[] arrRigtigtSvar = new string[arrValgtOrd.Length];
                string strRigtigeBogstaver = "";
                string strValgtOrd = "";
                bool RigtigtSvar = false;
                //Console.WriteLine(valgtOrd);
                Console.WriteLine("Velkommen til spillet. Spillet du skal spille er galge");
                Console.WriteLine("Du har 6 liv i alt, hvis du gætter forkert med et bogstav mister du 1 liv\nHvis du gætter forkert med et ord mister du alle dine liv");
                Console.Write("Ordet du skal gætte er: ");
                for (int i = 0; i < arrValgtOrd.Length; i++)
                {
                    strValgtOrd = strValgtOrd + arrValgtOrd[i];
                    arrRigtigeBogstaver[i] = "_ ";
                    Console.Write("_ ");
                }
                for (int i = 0; i < arrForkerteBogstaver.Length; i++)
                {
                    arrForkerteBogstaver[i] = "_ ";
                }
                Console.WriteLine("\n");
                Console.Write("Indtast et bogstav eller et helt ord: ");
                int liv = 6;
                while (iLive == true)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        strRigtigeBogstaver = "";
                        bool livchecker = false;
                        string brugerSvar = Console.ReadLine();
                        string[] arrBrugerSvar = new string[brugerSvar.Length];
                        for (int z = 0; z < arrBrugerSvar.Length; z++)
                        {
                            arrBrugerSvar[z] = brugerSvar.Substring(z, 1);
                        }
                        int intBrugerSvar = arrBrugerSvar.Length;
                        if (intBrugerSvar <= 1)
                        {
                            for (int x = 0; x < arrValgtOrd.Length; x++)
                            {
                                if (arrValgtOrd[x] == arrBrugerSvar[0])
                                {
                                    arrRigtigeBogstaver[x] = arrBrugerSvar[0];
                                    i--;
                                    livchecker = true;
                                    arrRigtigtSvar[x] = arrRigtigeBogstaver[x];
                                }
                            }
                            if (livchecker == false)
                            {
                                liv = liv - 1;
                                for (int y = 0; y < arrValgtOrd.Length; y++)
                                {
                                    if (arrForkerteBogstaver[y] == "_ ")
                                    {
                                        arrForkerteBogstaver[y] = arrBrugerSvar[0];
                                        break;
                                    }
                                }
                            }
                        }
                        else if (intBrugerSvar >= 2)
                        {
                            for (int l = 0; l < arrBrugerSvar.Length; l++)
                            {
                                if (arrValgtOrd[l] == arrBrugerSvar[l])
                                {
                                    arrRigtigtSvar[l] = arrBrugerSvar[l];
                                    RigtigtSvar = true;
                                }
                                else
                                {
                                    RigtigtSvar = false;
                                    iLive = false;
                                    break;
                                }
                            }
                        }

                        for (int g = 0; g < arrValgtOrd.Length; g++)
                        {
                            strRigtigeBogstaver += arrRigtigtSvar[g];
                        }
                        if (liv==0)
                        {
                            iLive = false;
                        }
                        if (iLive == false)
                        {
                            break;
                        }


                        else if (valgtOrd == strRigtigeBogstaver)
                        {
                            for (int r = 0; r < arrValgtOrd.Length; r++)
                            {
                                strRigtigeBogstaver += arrRigtigtSvar[r];
                            }
                            RigtigtSvar = true;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Du har " + liv + " liv tilbage");
                            Console.WriteLine("");
                            Console.Write("Ordet du skal gætte: ");
                            for (int c = 0; c < arrValgtOrd.Length; c++)
                            {
                                Console.Write(arrRigtigeBogstaver[c]);
                            }
                            Console.WriteLine("\n");
                            Console.Write("Du har brugt de her bogstaver som var forkerte: ");
                            for (int f = 0; f < arrForkerteBogstaver.Length; f++)
                            {
                                Console.Write(arrForkerteBogstaver[f]);
                            }
                            Console.WriteLine("");
                            Console.Write("\nIndtast et bogstav: ");
                        }
                        
                    }
                }
                Console.Clear();
                if (RigtigtSvar == true)
                {
                    Console.WriteLine("Tillykke du har vundet, det rigtige ord var " + valgtOrd);
                    Console.WriteLine("");
                    Console.WriteLine("Vil du prøve igen? y/n");
                }
                else
                {
                    Console.WriteLine("Du tabte");
                    Console.WriteLine("");
                    Console.WriteLine("Det rigtige ord var " + valgtOrd);
                    Console.WriteLine("");
                    Console.WriteLine("Vil du prøve igen? y/n");
                }
                strTryAgain = Console.ReadLine();
                if (strTryAgain == "n")
                {
                    TryAgain = false;
                }
            }
        }
        static string[] OrdSplitter(string Ord)
        {
            string[] randomOrd = new string[Ord.Length];
            for (int i = 0; i < Ord.Length; i++)
            {
                randomOrd[i] = Ord.Substring(i, 1);
            }
            return randomOrd;
        }
        
    }
}
