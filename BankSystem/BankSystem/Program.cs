using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Program
    {
        static void Main()
        {
            
            Database UserDatabase = new Database();
            Database SpecificData = new Database();
            DatabaseTest<Bank.BankUser> Test = new DatabaseTest<Bank.BankUser>();
            DatabaseTest<Bank.BankUser.NewBankAccount> Test2 = new DatabaseTest<Bank.BankUser.NewBankAccount>();
            int searchFunction;
            var User1 = new Bank.BankUser.NewBankAccount("Bob", "22. April", 302);
            var User2 = new Bank.BankUser.NewBankAccount("Tom", "23. April", 305);
            UserDatabase.SimpleDatabase.Add(User1);
            UserDatabase.SimpleDatabase.Add(User2);
            SpecificData.SpecificDatabase.Add(User1);
            Test.Database.Add(User1);
            Console.WriteLine();
            PrintInfo(UserDatabase);
            Console.WriteLine(User1.userName);
            DetailedInfo(SpecificData);
            searchFunction = UserDatabase.SimpleDatabase.FindIndex(c => c.userName == "Tom");
            Console.WriteLine(UserDatabase.SimpleDatabase.ElementAt(searchFunction).userName);
            
        }
        static void PrintInfo(Database data)
        {
            foreach(var c in data.SimpleDatabase)
            {
                Console.WriteLine(c.userName);
                
            }
                
                
        }
        static void DetailedInfo(Database data)
        {
            foreach(var c in data.SpecificDatabase)
            {
                Console.WriteLine(c.creationDate);
                Console.WriteLine(c.creditTotal);
                Console.WriteLine(c.userName);
            }
        }
    }
    class Bank
    {
        public class BankUser
        {
            public string userName;
            public class NewBankAccount : BankUser
            {
                public string creationDate;
                public int creditTotal;
                public NewBankAccount(string UserName, string CreationDate,int CreditTotal)
                {
                    userName = UserName; creationDate = CreationDate; creditTotal = CreditTotal;
                }
            }
        }
    }
    class Database
    {
        
        public List<Bank.BankUser> SimpleDatabase = new List<Bank.BankUser>();
        public List<Bank.BankUser.NewBankAccount> SpecificDatabase = new List<Bank.BankUser.NewBankAccount>();
    }
    public class DatabaseTest<T>
    {
        public List<T> Database = new List<T>();
    }
}
