using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2CaseBank
{
    class UnusedMethods
    {
        #region OldAddKonto
        //Done. Henter bruger info til AddKonto(Bruger e)
        //public static void GetUserForNewKonto()
        //{
        //    Bruger userTest = new Bruger();
        //    Console.Write("Indtast et brugerid: ");
        //    int x = Convert.ToInt32(Console.ReadLine());
        //    SqlConnection connection = new SqlConnection(@"Data Source=SKAB6-PC-02;Initial Catalog=Netbank;Integrated Security=True");
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("SELECT * FROM Bruger where brugerid=@x", connection))
        //        {
        //            command.Parameters.Add("@x", System.Data.SqlDbType.Int);
        //            command.Parameters["@x"].Value = x;
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Bruger user = new Bruger
        //                    {
        //                        FirstName = reader.GetValue(0).ToString(),
        //                        LastName = reader.GetValue(1).ToString(),
        //                        Job = reader.GetValue(2).ToString(),
        //                        BrugerID = Convert.ToInt32(reader.GetValue(3))
        //                    };
        //                    AddKonto(user);
        //                }

        //            }

        //        }

        //        connection.Close();

        //    }
        //}
        #endregion

        #region OldMenu
        //ConsoleKeyInfo choice = Console.ReadKey();
        //if (GenericInputTest(choice))
        //{
        //    userChoice = Convert.ToInt32(choice);
        //}
        //else
        //{
        //    Console.SetCursorPosition(15, 25);
        //    Console.Write("Du valgte ikke en funktion\nVil du prøve igen?\t Y/N: ");
        //    choice = Console.ReadKey();
        //    if (choice.Key == ConsoleKey.Y)
        //    {
        //        Console.Clear();
        //        Menu();
        //    }
        //    else
        //    {
        //        Environment.Exit(0);
        //    }
        //}
        //try
        //{
        //    userChoice = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
        //}
        //catch (FormatException)
        //{
        //    Console.SetCursorPosition(15, 25);
        //    Console.Write("Du valgte ikke en funktion\nVil du prøve igen?\t Y/N: ");
        //    ConsoleKeyInfo choice = Console.ReadKey();
        //    if (choice.Key == ConsoleKey.Y)
        //    {
        //        Console.Clear();
        //        Menu();
        //    }
        //    else
        //    {
        //        Environment.Exit(0);
        //    }
        //}
        #endregion

        #region SearchUserDelegate
        //public delegate void ShowAllSpecificInfo(int x);
        //Done. Viser information om en bruger.
        //public static void SearchUserWithID(int x)
        //{
        //    SqlConnection connection = new SqlConnection(ConnectionString);

        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("SELECT * FROM Bruger where brugerid=@x", connection))
        //        {
        //            command.Parameters.Add("@x", System.Data.SqlDbType.Int);
        //            command.Parameters["@x"].Value = x;
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {

        //                while (reader.Read())
        //                {
        //                    Console.WriteLine("Fornavn: " + reader.GetValue(0));
        //                    Console.WriteLine("Efternavn: " + reader.GetValue(1));
        //                    Console.WriteLine("Job: " + reader.GetValue(2));
        //                    Console.WriteLine("Bruger ID: " + reader.GetValue(3));
        //                    Console.WriteLine("Oprettelses dato: " + reader.GetValue(4) + "\n");
        //                }

        //            }
        //        }
        //        connection.Close();
        //    }
        //}



        ////Done. Viser information om en brugers konti.
        //public static void SearchKontoWithID(int x)
        //{
        //    SqlConnection connection = new SqlConnection(ConnectionString);

        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("SELECT * FROM Konto where brugerid=@x", connection))
        //        {
        //            command.Parameters.Add("@x", System.Data.SqlDbType.Int);
        //            command.Parameters["@x"].Value = x;
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Console.WriteLine("Konto ID: " + reader.GetValue(0));
        //                    Console.WriteLine("Bruger ID: " + reader.GetValue(1));
        //                    Console.WriteLine("Oprettelses dato: " + reader.GetValue(2));
        //                    Console.WriteLine("Saldo: " + reader.GetValue(3) + "\n");
        //                }
        //            }
        //        }
        //        connection.Close();
        //    }
        //}
        #endregion

    }
}
