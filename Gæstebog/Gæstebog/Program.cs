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

        static string PathFinder() //Beslutter hvor filen gemmes
        {
            string path = @"D:\Programmerings projekter\Projekter\test.txt";
            return path;
        }
        static void Menu() //Udskriver menuen
        {
            Console.Clear();
            Console.SetWindowSize(100, 35);
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("Velkommen til Gæste-Registrerings programmet");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Telefon nr.: ");
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Navn       : ");
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("Adresse    : ");
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Post nr.   : ");
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("By         : ");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Email      : ");
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("[O]: Opret    [F] Find    [V] Vis Alle    [Q] Afslut");
            Console.SetCursorPosition(0, 28);
            Console.Write("Vælg en funktion: ");
        }
        static void Main()
        {
            
            FileCreator();
            bool Continue = true;
            while (Continue)
            {
                ConsoleKeyInfo ChosenFunction;
                Menu();
                ChosenFunction = Console.ReadKey();
                if (ChosenFunction.Key == ConsoleKey.O)
                {
                    string UserInput = UserRegistration();
                    TextImplementation(UserInput);
                }
                
                else if (ChosenFunction.Key == ConsoleKey.V)
                {
                    FileReader();
                }
                else if (ChosenFunction.Key == ConsoleKey.F)
                {
                    FileSearcher();
                }
                else
                {
                    Continue = false;
                }
                
            }
            

        }
        private static void FileCreator() //Laver text filen hvis den ikke allerede eksistere, ellers opretter den filen
        {
            string path = PathFinder();
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Velkommen til gæstebogen:\n");
                }
            }
        }
        private static string UserRegistration() //Alt information som brugeren skal taste ind gøres her
        {
            bool InputChecker = false; //Bruges til de forskellige while loops
            string StrUserInput = ""; //Bruges til sidst for at konvertere UserInput array til et string i stedet
            string[] UserInput = new string[6]; //Et array til at indsamle alt input brugeren giver
            int CursorPosition = 5; //Bruges til at bestemme hvilken linje brugeren skriver på
            //Telefon nr.
            {
                
                while (InputChecker == false)
                {
                    var ErrorCharacters = "abcdefghijklmnopqrstuvwxyzæøå!?'=)(&%¤#`´^¨'*-_:;,@£${[]}+\\|\"½§ ./"; //Tegn og bogstaver som ikke kan bruges i telefon nummere
                    Console.SetCursorPosition(0, CursorPosition);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r"); //Rydder det der står. Bliver brugt i tilfælde af at brugeren indtaster noget forkert
                    Console.WriteLine("Telefon nr.: ");
                    Console.SetCursorPosition(13, CursorPosition);
                    var TestUserInput = Console.ReadLine();
                    TestUserInput = TestUserInput.ToLower();
                    TestUserInput = new string(TestUserInput.Where(c => !ErrorCharacters.Contains(c)).ToArray()); //Checker hvad brugeren har skrevet, og fjerner brug af forkerte tegn eller bogstaver, som findes i linje 97 string
                    bool DuplicateInput = DuplicateChecker(TestUserInput); //Tester om brugerens input allerede findes i databasen
                    if (DuplicateInput) //Hvis inputten allerede findes
                    {
                        Console.SetCursorPosition(20, 20);
                        Console.Write(TestUserInput + " er allerede registreret!");
                    }
                    else //Hvis det ikke gør
                    {
                        UserInput[0] = TestUserInput;
                        Console.SetCursorPosition(20, 20);
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r"); //Bliver brugt til at rydde tidligere fejl meddelelser
                        if (UserInput[0].Length == 8) //Checker om det nummer brugeren har skrevet ind består af 8 tal
                        {
                            Console.SetCursorPosition(13, CursorPosition);
                            InputChecker = true; //Bryder while loopet
                            Console.Write(UserInput[0] + " : Nummeret er registeret!"); //Giver brugerens besked om at de indtastede et brugbart telefon nummer
                        }
                        else
                        {
                            Console.SetCursorPosition(20, 20);
                            Console.Write(UserInput[0] + " er ikke et gyldigt telefon nr."); //Fortæller brugeren at de ikke har indtastet et brugbart telefon nummer og loopet starter forfra
                        }
                    }
                    
                }
                CursorPosition += 1; //Rykker linjen brugeren skriver på 1 linje ned

            }
            InputChecker = false;
            //Navn
            {
                var ErrorCharacters = "0123456789!?'=)(&%¤#`´^¨'*_:;,@£${[]}+\\|\"½§./"; //Samme som linje 97, men med andre fejl symboler da navne indholder bogstaver, men ikke tal
                Console.SetCursorPosition(13, CursorPosition);
                var TestUserInput = Console.ReadLine();
                TestUserInput = TestUserInput.ToLower();
                UserInput[1] = new string(TestUserInput.Where(c => !ErrorCharacters.Contains(c)).ToArray());
                UserInput[1] = UserInput[1].TrimStart(' ');
                UserInput[1] = UserInput[1].TrimEnd(' ');
                if (UserInput[1].Contains(' '))
                {
                    string[] UserName = UserInput[1].Split(' ');
                    UserInput[1] = "";
                    string temp = "";
                    for (int i = 0; i < UserName.Length; i++)
                    {
                        temp = UserName[i].Substring(0, 1);
                        UserName[i] = UserName[i].Remove(0, 1);
                        UserName[i] = temp.ToUpper() + UserName[i];
                        UserInput[1] = UserInput[1] + UserName[i];
                        UserInput[1] += " ";
                    }
                }
                else
                {
                    string temp = "";
                    string UserName = UserInput[1];
                    temp = UserName.Substring(0, 1);
                    UserName = UserName.Remove(0, 1);
                    UserName = temp.ToUpper() + UserName;
                    UserInput[1] = UserName;
                }
                UserInput[1] = UserInput[1].TrimEnd(' ');
                Console.SetCursorPosition(13, CursorPosition);
                Console.Write(UserInput[1] + " : Navnet er registreret!");
                CursorPosition += 1;
            }

            //Adresse
            {
                string UserInputError = "123456789";
                bool UserInputTester = false;
                while (InputChecker == false)
                {
                    int AddressNumber = 0;
                    var ErrorCharacters = "!?'=)(&%¤#`´^¨'*-_:;,@£${[]}+\\|\"½§./";
                    Console.SetCursorPosition(0, CursorPosition);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.WriteLine("Adresse    : ");
                    Console.SetCursorPosition(13, CursorPosition);
                    var TestUserInput = Console.ReadLine();
                    TestUserInput = TestUserInput.ToLower();
                    UserInput[2] = new string(TestUserInput.Where(c => !ErrorCharacters.Contains(c)).ToArray());
                    UserInput[2] = UserInput[2].TrimStart(' ');
                    UserInput[2] = UserInput[2].TrimEnd(' ');
                    for (int i = 0; i < UserInput[2].Length; i++)
                    {
                        if (UserInput[2].Contains(UserInputError.Substring(i,1)))
                        {
                            UserInputTester = true;
                            break;
                        }
                    }
                    if (UserInputTester)
                    {
                        
                        Console.SetCursorPosition(20, 20);
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                        if (UserInput[2].Contains(' '))
                        {

                            string[] UserTestInput = UserInput[2].Split(' ');
                            UserInput[2] = "";
                            for (int i = 0; i < UserTestInput.Length; i++)
                            {
                                string temp = "";
                                try
                                {
                                    AddressNumber = Convert.ToInt32(UserTestInput[i]);
                                    UserInput[2] = UserInput[2] + AddressNumber;
                                    UserInput[2] += " ";
                                }
                                catch (Exception)
                                {
                                    temp = UserTestInput[i].Substring(0, 1);
                                    UserTestInput[i] = UserTestInput[i].Remove(0, 1);
                                    UserTestInput[i] = temp.ToUpper() + UserTestInput[i];
                                    UserInput[2] = UserInput[2] + UserTestInput[i];
                                    UserInput[2] += " ";
                                }
                                
                                //TestUserInput = UserInput[2];
                                
                            }
                            bool DuplicateInput = DuplicateChecker(UserInput[2]);
                            if (DuplicateInput == true)
                            {
                                Console.SetCursorPosition(20, 20);
                                Console.Write(TestUserInput + " er allerede registreret!");
                                InputChecker = false;

                            }
                            else
                            {
                                InputChecker = true;
                                UserInput[2] = UserInput[2].TrimEnd(' ');
                                Console.SetCursorPosition(13, CursorPosition);
                                Console.Write(UserInput[2] + " : Adressen er registreret!");
                                CursorPosition += 1;
                            }
                        }

                    }
                    else
                    {
                        Console.SetCursorPosition(20, 20);
                        Console.WriteLine(UserInput[2] + " er ikke en gyldig adresse!");
                        //string temp = "";
                        //temp = UserInput[2].Substring(0, 1);
                        //UserInput[2] = UserInput[2].Remove(0, 1);
                        //UserInput[2] = temp.ToUpper() + UserInput[2];
                    }
                   
                }
                
                
            }
            InputChecker = false;
            //Post nr.
            {
                while (InputChecker == false)
                {
                    var ErrorCharacters = "abcdefghijklmnopqrstuvwxyzæøå!?'=)(&%¤#`´^¨'*-_:;,@£${[]}+\\|\"½§ ./";
                    Console.SetCursorPosition(0, CursorPosition);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.WriteLine("Post nr.   : ");
                    Console.SetCursorPosition(13, CursorPosition);
                    var TestUserInput = Console.ReadLine();
                    TestUserInput = TestUserInput.ToLower();
                    UserInput[3] = new string(TestUserInput.Where(c => !ErrorCharacters.Contains(c)).ToArray());
                    Console.SetCursorPosition(20, 20);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    if (UserInput[3].Length == 4)
                    {
                        Console.SetCursorPosition(13, CursorPosition);
                        InputChecker = true;
                        Console.Write(UserInput[3] + " : Post nummeret er registeret");
                    }
                    else
                    {
                        Console.SetCursorPosition(20, 20);
                        Console.Write(UserInput[3] + " er ikke et gyldigt post nr.");
                    }
                }
                CursorPosition += 1;
            }
            InputChecker = false;
            //By
            {
                var ErrorCharacters = "0123456789!?'=)(&%¤#`´^¨'*-_:;,@£${[]}+\\|\"½§./ ";
                Console.SetCursorPosition(13, CursorPosition);
                var TestUserInput = Console.ReadLine();
                TestUserInput = TestUserInput.ToLower();
                UserInput[4] = new string(TestUserInput.Where(c => !ErrorCharacters.Contains(c)).ToArray());
                string temp = "";
                string CityName = UserInput[4];
                temp = CityName.Substring(0, 1);
                CityName = CityName.Remove(0, 1);
                CityName = temp.ToUpper() + CityName;
                UserInput[4] = CityName;
                Console.SetCursorPosition(13, CursorPosition);
                Console.Write(UserInput[4] + " : By navnet er registreret!");
                CursorPosition += 1;
            }

            //Email Addresse
            {
                int EmailInputChecker = 0;
                while (InputChecker == false)
                {
                    var ErrorCharacters = "!?'=)(&%¤#`´^¨'*:;,£${[]}+\\|\"½§ /";
                    Console.SetCursorPosition(0, CursorPosition);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.WriteLine("Email      : ");
                    Console.SetCursorPosition(13, CursorPosition);
                    var TestUserInput = Console.ReadLine();
                    string UserInputError = TestUserInput;
                    UserInput[5] = new string(TestUserInput.Where(c => !ErrorCharacters.Contains(c)).ToArray());
                    Console.SetCursorPosition(20, 20);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    if (UserInput[5].Contains('@') && UserInput[5].Length>7&& (UserInput[5].Contains(".com") || UserInput[5].Contains(".dk")))
                    {
                        for (int i = 0; i < UserInput[5].Length - 1; i++)
                        {
                            
                            if (UserInput[5].Substring(i, 2) == "@@")
                            {
                                UserInput[5] = UserInput[5].Remove(i, 1);
                                i -= 1;
                                
                                
                            }
                            else if (UserInput[5].Substring(i,1) == "@")
                            {
                                if (EmailInputChecker > 0)
                                {
                                    UserInput[5] = UserInput[5].Remove(i, 1);
                                }
                                else
                                {
                                    EmailInputChecker += 1;
                                }
                               
                            }
                            
                        }
                        if (EmailInputChecker == 1)
                        {
                            string[] EmailChecker = UserInput[5].Split('@');
                            if (EmailChecker[1].Contains(".com") || EmailChecker[1].Contains(".dk"))
                            {
                                bool DuplicateInput = DuplicateChecker(UserInput[5]);
                                if (DuplicateInput == true)
                                {
                                    Console.SetCursorPosition(20, 20);
                                    Console.Write(UserInput[5] + " er allerede registreret!");
                                }
                                else
                                {
                                    Console.SetCursorPosition(20, 20);
                                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                                    Console.SetCursorPosition(13, CursorPosition);
                                    InputChecker = true;
                                    Console.Write(UserInput[5] + " : Email adressen er registeret!");
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(20, 20);
                                Console.Write(UserInputError + " er ikke en gyldigt email adresse");
                            }

                        }
                        else
                        {
                            Console.SetCursorPosition(20, 20);
                            Console.Write(UserInputError + " er ikke en gyldigt email adresse");
                        }

                    }
                    else
                    {
                        Console.SetCursorPosition(20, 20);
                        Console.Write(UserInput[5] + " er ikke en gyldigt email adresse");
                    }
                }
            }
            
            for (int i = 0; i < UserInput.Length; i++)
            {
                StrUserInput = StrUserInput + " , " + UserInput[i];
            }
            StrUserInput = StrUserInput.TrimStart(' ', ',');
            return StrUserInput;
        } 
        private static void TextImplementation(string UserInput) //Tager brugerens input og taster det ind i filen
        {
            string path = PathFinder();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(UserInput);
            }
            return;
        } 
        private static bool DuplicateChecker(string UserInput) //Checker om den information som brugeren har skrevet allerede eksistere i databasen
        {
            string path = PathFinder();
            string text = File.ReadAllText(path);
            return text.Contains(UserInput);
        } 
        private static void FileReader() //Læser informationen fundet i databasen op til brugeren
        {
            string path = PathFinder();
            string[] FileLines = File.ReadAllLines(path);
            int LineCounter = 2;
            bool ShowMore = true;
            while (ShowMore)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til gæstebogen:");
                Console.SetCursorPosition(0, 3);
                if (FileLines.Length <= 2)
                {
                    Console.WriteLine("Der er ingen registreringer i gæstebogen");
                }
                else
                {
                    Console.WriteLine("Der er i alt " + (FileLines.Length - 2) + " registreringer i gæstebogen\n");
                }
               
                for (int i = 0; i < 15; i++)
                {
                    if (FileLines.Length == LineCounter)
                    {
                        Console.SetCursorPosition(0, 25);
                        Console.Write("Der er ikke mere at vise - tryk en tast for at komme tilbage til menuen: ");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine(FileLines[LineCounter]);
                        LineCounter += 1;
                    }
                }
                Console.SetCursorPosition(0, 25);
                Console.Write("Hvis du gerne vil se mere tast Y, ellers tast en vilkårlig tast: ");
                ConsoleKeyInfo LoopOptions = Console.ReadKey();
                if (LoopOptions.Key != ConsoleKey.Y)
                {
                    ShowMore = false;

                }
            }
            return;
            
        } 
        private static void FileSearcher() //Søger efter information i databasen
        {
            bool Continue = true;
            string path = PathFinder();
            while (Continue)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("Indtast et telefon nr. eller email, som du gerne vil søge efter: ");
                string UserInput = Console.ReadLine();
                
                string[] FileLines = File.ReadAllLines(path);
                bool WrongInput = false;
                for (int i = 0; i < FileLines.Length; i++)
                {
                    if (FileLines[i].Contains(UserInput))
                    {
                        string[] UserInfo = FileLines[i].Split(',');
                        Console.WriteLine("\nTelefon nr.:  " + UserInfo[0]);
                        Console.WriteLine("Navn       : " + UserInfo[1]);
                        Console.WriteLine("Adresse    : " + UserInfo[2]);
                        Console.WriteLine("Post nr.   : " + UserInfo[3]);
                        Console.WriteLine("By         : " + UserInfo[4]);
                        Console.WriteLine("Email      : " + UserInfo[5]);
                        WrongInput = true;
                        break;
                    }
                    
                }
                if (WrongInput == false)
                {
                    Console.SetCursorPosition(5, 13);

                    Console.WriteLine("Informationen kunne ikke blive fundet i databasen");
                }
                Console.SetCursorPosition(0, 15);
                Console.Write("Hvis du gerne vil søge efter et andet telefon nr. eller email adresse tast Y: ");
                ConsoleKeyInfo ChosenFunction;
                ChosenFunction = Console.ReadKey();
                if (ChosenFunction.Key == ConsoleKey.Y)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.SetCursorPosition(0, 16);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.SetCursorPosition(0, 17);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.SetCursorPosition(0, 18);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.SetCursorPosition(0, 19);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.SetCursorPosition(0, 20);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.SetCursorPosition(0, 21);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                    Console.SetCursorPosition(0, 22);
                    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                }
                else
                {
                    Continue = false;
                }
                

            }
            
            return;
        } 
    }
}
