using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Loop = true;
            while (Loop == true)
            {
                string ErrorCharacters = "abcdefghijklmnopqrstuvwxyzæøå!?'=)(&%¤#`´^¨'*-_:;,@£${[]}+| \"½§";
                string CorrectCharacters = "1234567890./";
                bool CharacterTester = false;
                bool Error = false;
                bool IPError = true;
                bool SubnetError = false;
                string[] SubnetIdentifier = new string[2];
                string strIP = "";
                string strSubnet = "";

                Console.WriteLine("Velkommen til netværkskalkulatoren!\n");
                Console.WriteLine("Indtast adressen som DD eller CIDR. f.eks.:");
                Console.WriteLine("192.12.13.14/255.255.255.0 eller 192.12.13.14/24\n");
                Console.Write("Indtast her: ");
                while (Error == false)
                {
                    CharacterTester = false;
                    string UserInput = Console.ReadLine();
                    UserInput = UserInput.ToLower();
                    if (UserInput.Length < 32 && UserInput.Length > 2)
                    {
                        for (int i = 0; i < ErrorCharacters.Length; i++)
                        {
                            if (UserInput.Contains(ErrorCharacters.Substring(i, 1)) == true)
                            {
                                CharacterTester = true;
                                break;
                            }

                        }
                        //for (int i = 0; i < CorrectCharacters.Length; i++)
                        //{
                        //    if (UserInput.Contains(CorrectCharacters.Substring(i, 1)) == true)
                        //    {
                        //        CharacterTester = true;
                        //        break;
                        //    }

                        //}
                        if (CharacterTester == false && UserInput.Contains("/") == true)
                        {
                            SubnetIdentifier = UserInput.Split('/');
                            strIP = SubnetIdentifier[0];
                            strSubnet = SubnetIdentifier[1];
                            if (SubnetIdentifier[0].Length < 7)
                            {
                                IPError = false;
                                Console.WriteLine("\nDu indtastede en forkert IP");
                                Console.Write("Indtast en ny adresse her: ");
                            }
                            else if (IPError == true)
                            {
                                if (IPError == true)
                                {
                                    IPError = ErrorTester(strIP);
                                }
                                if (IPError == false)
                                {
                                    Console.WriteLine("\nDu indtastede en forkert IP");
                                    Console.Write("Indtast en ny adresse her: ");
                                }

                            }
                            if (IPError == true)
                            {
                                if (strSubnet.Length > 15 || strSubnet.Length < 7)
                                {
                                    SubnetError = false;
                                }
                                if (strSubnet.Length < 3)
                                {
                                    SubnetError = SlashSubnetTester(strSubnet);
                                    if (SubnetError == false)
                                    {
                                        Console.WriteLine("\nDu indtastede en forkert Subnetmaske");
                                        Console.Write("Indtast en ny addresse her: ");
                                    }
                                    else
                                    {
                                        SubnetError = ErrorTester(strSubnet);
                                        if (SubnetError == false)
                                        {
                                            Console.WriteLine("\nDu indtastede en forkert Subnetmaske");
                                            Console.Write("Indtast en ny addresse her: ");
                                        }

                                    }
                                }
                                else
                                {
                                    SubnetError = ErrorTester(strSubnet);
                                    if (SubnetError == false)
                                    {
                                        Console.WriteLine("\nDu indtastede en forkert Subnetmaske");
                                        Console.Write("Indtast en ny addresse her: ");
                                    }

                                }
                            }
                            if (IPError == true && SubnetError == true)
                            {
                                Error = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDu har givet et forkert input");
                            Console.Write("Indtast en ny adresse her: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nDu har givet et forkert input");
                        Console.Write("Indtast en ny adresse her: ");
                    }

                }


                int[] SubnetMask = new int[4];
                int[] IPAdress = StringSplitter(strIP);
                int[] NetworkAddress = new int[4];

                if (strSubnet.Length < 3)
                {
                    SubnetMask = SubnetConverter(strSubnet);
                }
                else
                {
                    SubnetMask = StringSplitter(strSubnet);
                }
                for (int i = 0; i < SubnetMask.Length; i++)
                {
                    NetworkAddress[i] = IPAdress[i] & SubnetMask[i];
                }
                Console.Write("\nDin netværksadresse er: ");
                for (int i = 0; i < NetworkAddress.Length; i++)
                {
                    if (i == 3)
                    {
                        Console.Write(NetworkAddress[i]);
                    }
                    else
                    {
                        Console.Write(NetworkAddress[i] + ".");
                    }
                }
                int UseableHosts = UseableHostsChecker(SubnetMask);
                Console.WriteLine("\nAntal usable hosts: " + UseableHosts);
                Console.Write("\nHvis du vil prøve en anden adresse tast Y, hvis ikke tast N: ");
                ConsoleKeyInfo LoopOptions = Console.ReadKey();

                if (LoopOptions.Key == ConsoleKey.Y)
                {
                    Loop = true;
                    Console.Clear();
                }
                else
                {
                    Loop = false;
                }



            }

        }
        private static int[] StringSplitter(string strUserInput)
        {
            string[] strSplit = strUserInput.Split('.');
            int[] intSplit = new int[strSplit.Length];
            for (int i = 0; i < strSplit.Length; ++i)
            {
                intSplit[i] = Convert.ToInt32(strSplit[i]);
            }
            return intSplit;
        }
        private static int UseableHostsChecker(int[] Hosts)
        {
            int[] temp = { 256, 256, 256, 256 };
            int UseableHosts = 1;
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = temp[i] - Hosts[i];
                if (temp[i] > 1)
                {
                    UseableHosts *= temp[i];
                }
            }
            UseableHosts -= 2;
            return UseableHosts;
        }
        private static int[] SubnetConverter(string SlashSubnet)
        {
            string EmptyBits = "";
            int RemainingBits = Convert.ToInt32(SlashSubnet) + 1;
            string SubnetConverter = "";
            int[] SubnetArray = new int[4];
            int SubnetArrayLength = 0;
            for (int i = 0; i <= 32; i++)
            {
                if (RemainingBits > 0)
                {
                    RemainingBits -= 1;
                    if (RemainingBits > 0)
                    {
                        SubnetConverter += 1;
                    }

                    if (SubnetConverter.Length == 8)
                    {
                        SubnetArray[SubnetArrayLength] = Convert.ToInt32(SubnetConverter);
                        SubnetArrayLength += 1;
                        SubnetConverter = "";
                    }
                }
                else
                {
                    if (SubnetConverter.Length > 0)
                    {
                        EmptyBits = SubnetConverter;
                        SubnetConverter = "";
                    }
                    EmptyBits += "0";
                    if (EmptyBits.Length == 8)
                    {
                        SubnetArray[SubnetArrayLength] = Convert.ToInt32(EmptyBits);
                        SubnetArrayLength += 1;
                        EmptyBits = "";
                    }


                }



            }
            for (int i = 0; i < SubnetArray.Length; i++)
            {
                string temp1 = Convert.ToString(SubnetArray[i]);
                int temp = Convert.ToInt32(temp1, 2);
                SubnetArray[i] = temp;

            }
            Console.WriteLine();
            return SubnetArray;
        }
        private static bool ErrorTester(string TestArray)
        {
            int[] Test = new int[4];
            if (TestArray.Length < 3)
            {
                Test = SubnetConverter(TestArray);
            }
            else
            {
                Test = StringSplitter(TestArray);
            }

            bool Tester = true;
            for (int i = 0; i < Test.Length; i++)
            {
                if (Test[i] > 255 || Test[i] < 0)
                {
                    Tester = false;
                    break;
                }
                else
                {
                    Tester = true;
                }
            }
            return Tester;

        }
        private static bool SlashSubnetTester(string Tester)
        {
            bool SubnetTest = true;
            int Test = Convert.ToInt32(Tester);
            if (Test > 31 || Test < 0)
            {
                SubnetTest = false;
            }
            else
            {
                SubnetTest = true;
            }
            return SubnetTest;
        }
    }
}
