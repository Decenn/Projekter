using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringExtension;

namespace H2CaseBank
{
    class Program
    {
        public static List<Bruger> userList = new List<Bruger>();
        public static List<Konto> kontoList = new List<Konto>();
        public static List<Transaktioner> transactionList = new List<Transaktioner>();
        static void Main()
        {
            Console.Title = "Hvidvask banken";
            Bruger.BrugerListCreator();
            Bruger.KontoListCreator();
            Bruger.TransaktionsListCreator();
            string test = "hej";
            Console.WriteLine(test.Capitalize());
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            ConsoleKey menuOptions = new ConsoleKey();
            #region MenuText
            Console.SetCursorPosition(Console.WindowWidth / 2-20, 0);
            Console.WriteLine("Velkommen til Hvidvaskbank");
            Console.WriteLine("\n\tDu kan vælge nedenunder hvad du gerne vil...\n");
            Console.WriteLine("1) Oprette en bruger:");
            Console.WriteLine("2) Slette en bruger:");
            Console.WriteLine("3) Redigere en bruger:");
            Console.WriteLine("4) Oprette en ny konto på en bruger:");
            Console.WriteLine("5) Vis alt information i databasen:");
            Console.WriteLine("6) Vis alt information om en enkelt bruger:");
            Console.WriteLine("7) Vis saldo på en specific konto:");
            Console.WriteLine("8) Hæve eller indsætte penge på en konto:");
            Console.WriteLine("9) Udskriv transaktioner forbundet med en specific konto:");
            Console.WriteLine("A) Sorter brugere baseret på fornavn:");
            Console.WriteLine("B) Sorter brugere baseret på efternavn:");
            Console.WriteLine("C) Sorter brugere baseret på bruger ID:");
            Console.WriteLine("0) Luk programmet:");
            Console.Write("\nVælg en funktion: ");
            #endregion
            menuOptions = Console.ReadKey().Key;
            switch (menuOptions)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Bruger.NewUserInputMethod();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.Write("Indtast dit bruger ID: ");
                    int choice = 0;
                    choice = GenericTryCatch<int>.TryCatcher(choice);
                    Bruger.DeleteUser(choice);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    Bruger.ChangeUserInfo(userList);
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    Bruger.ObjectOrientedGetUser(userList);
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Bruger.ShowAllUserData();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    Bruger.ObjectOrientedSearchUserWithID(userList, kontoList);
                    break;
                case ConsoleKey.D7:
                    Console.Clear();
                    Bruger.CreditInfo(kontoList);
                    break;
                case ConsoleKey.D8:
                    Console.Clear();
                    Bruger.ChangeCredit(kontoList);
                    break;
                case ConsoleKey.D9:
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2);
                    Console.WriteLine("Funktionen er ikke lavet endnu...");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                    Menu();
                    break;
                case ConsoleKey.D0:
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2);
                    Console.WriteLine("Programmet lukker nu...");
                    System.Threading.Thread.Sleep(5000);
                    Environment.Exit(0);
                    break;
                case ConsoleKey.A:
                    Console.Clear();
                    Bruger.FirstNameSorting(userList);
                    break;
                case ConsoleKey.B:
                    Console.Clear();
                    Bruger.LastNameSorting(userList);
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    Bruger.BrugerIDSorting(userList);
                    break;
                       
                default:
                    Console.WriteLine("\nDu valgte ikke noget..");
                    break;
            }
            Console.Write("\n\nVil du kører programmet igen? Y/N: ");
            ConsoleKey restartOption = new ConsoleKey();
            restartOption = Console.ReadKey().Key;
            switch (restartOption)
            {
                case ConsoleKey.Y:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2);
                    Console.WriteLine("Programmet lukker nu...");
                    System.Threading.Thread.Sleep(5000);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
