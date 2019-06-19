using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2CaseBank
{
    class GenericTryCatch<T>
    {
        public static int TryCatcher()
        {
            do
            {
                try
                {
                    int i = Convert.ToInt32(Console.ReadLine());
                    return i;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nDu indtastede ikke et hel tal, prøv igen\n");
                    Console.Write("Indtast igen: ");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("\nDu indtastede ikke et hel tal, prøv igen\n");
                    Console.Write("Indtast igen: ");
                }
            } while (true);
        }
        public static T TryCatcher(T testInput)
        {
            if(testInput.GetType() == typeof(string))
            {
                string wrongChars = "1234567890";
                bool wrongInput = false;
                for (int i = 0; i < testInput.ToString().Length; i++)
                {
                    for (int x = 0; x < wrongChars.Length; x++)
                    {
                        if (testInput.ToString().Substring(i, 1) == wrongChars.Substring(x, 1))
                        {
                            wrongInput = true;
                            break;
                        }
                            
                    }
                }
                do
                {
                    if (wrongInput)
                    {
                        Console.WriteLine("Du kan kun bruge bogstaver\n");
                        Console.Write("Indtast igen: ");
                        var newTestInput = Console.ReadLine();
                        testInput = (T)Convert.ChangeType(newTestInput, typeof(T));
                    }
                    else
                    {
                        return testInput;
                    }

                } while (true);
            }
            if(testInput.GetType() == typeof(ConsoleKeyInfo))
            {
                do
                {
                    try
                    {
                        int i = Convert.ToInt32(testInput);
                        return testInput;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Du valgte ikke en funktion\nPrøv igen: ");
                        var newTestInput = Console.ReadLine();
                        testInput = (T)Convert.ChangeType(newTestInput, typeof(T));
                    }
                    catch(InvalidCastException)
                    {
                        Console.Write("Du valgte ikke en funktion\nPrøv igen: ");
                        var newTestInput = Console.ReadLine();
                        testInput = (T)Convert.ChangeType(newTestInput, typeof(T));
                    }
                    catch (OverflowException)
                    {
                        Console.Write("Du valgte ikke en funktion\nPrøv igen: ");
                        var newTestInput = Console.ReadLine();
                        testInput = (T)Convert.ChangeType(newTestInput, typeof(T));
                    }
                } while (true);
            }
            return testInput;
        }
    }
}
