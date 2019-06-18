using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace H2CaseBank
{

    class Bruger : IEquatable<Bruger>, IComparable<Bruger>
    {
        #region BrugerVariabler

        public string FirstName;
        public string LastName;
        public string Job;
        public int BrugerID;
        public static string ConnectionString = @"Data Source=SKAB6-PC-02;Initial Catalog=Netbank;Integrated Security=True"; //Connectionstring til database.

        #endregion

        #region SorteringsMetoder

        //Done. Sortere baseret på brugerID.
        public static void BrugerIDSorting(List<Bruger> userList)
        {
            userList.Sort();
            foreach (Bruger bruger in userList)
            {
                Console.WriteLine("BrugerID: " + bruger.BrugerID);
                Console.WriteLine("Fornavn: " + bruger.FirstName);
                Console.WriteLine("Efternavn: " + bruger.LastName);
                Console.WriteLine("Job: " + bruger.Job + "\n");
            }
        }

        //Done. Sortere baseret på efternavn.
        public static void LastNameSorting(List<Bruger> userList)
        {
            userList.Sort(delegate (Bruger x, Bruger y)
            {
                if (x.LastName == null && y.LastName == null) return 0;
                else if (x.LastName == null) return -1;
                else if (y.LastName == null) return 1;
                else return x.LastName.CompareTo(y.LastName);
            });
            foreach (Bruger bruger in userList)
            {
                Console.WriteLine("BrugerID: " + bruger.BrugerID);
                Console.WriteLine("Fornavn: " + bruger.FirstName);
                Console.WriteLine("Efternavn: " + bruger.LastName);
                Console.WriteLine("Job: " + bruger.Job + "\n");
            }
        }

        //Done. Sortere baseret på fornavn.
        public static void FirstNameSorting(List<Bruger> userList)
        {
            userList.Sort(delegate (Bruger x, Bruger y)
            {
                if (x.FirstName == null && y.FirstName == null) return 0;
                else if (x.FirstName == null) return -1;
                else if (y.FirstName == null) return 1;
                else return x.FirstName.CompareTo(y.FirstName);
            });
            foreach (Bruger bruger in userList)
            {
                Console.WriteLine("BrugerID: " + bruger.BrugerID);
                Console.WriteLine("Fornavn: " + bruger.FirstName);
                Console.WriteLine("Efternavn: " + bruger.LastName);
                Console.WriteLine("Job: " + bruger.Job + "\n");
            }
        }

        //Done. Bruges til sorting af brugerid
        public int CompareTo(Bruger compareBruger)
        {
            if (compareBruger == null)
                return 1;
            else
                return this.BrugerID.CompareTo(compareBruger.BrugerID);
        }

        //Done. Bruges til sorting af brugerid
        public bool Equals(Bruger other)
        {
            if (other == null) return false;
            return this.BrugerID.Equals(other.BrugerID);
        }

        #endregion

        #region InputTilDatabase

        
        //Done. Henter information til AddKonto.
        public static void ObjectOrientedGetUser(List<Bruger> userList)
        {

            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            object[] userInfo = new object[5];
            Console.Write("Indtast et bruger ID: ");
            Bruger foundUser = userList.Find(f => f.BrugerID == GenericTryCatch<int>.TryCatcher());
            userInfo[0] = foundUser.BrugerID;
            userInfo[1] = time.ToString(format);
            Console.Write("Indtast en start saldo: ");
            userInfo[2] = GenericTryCatch<int>.TryCatcher();
            if (userInfo[2] == null)
                userInfo[2] = 0;
            Console.Write("Du kan vælge forskellige kontotyper. De typer er Kviklån, Opsparing eller Almindelig lån.\n Vælg et lån type: ");
            userInfo[3] = Console.ReadLine();
            Console.Write("Skriv en rentesats: ");
            userInfo[4] = Convert.ToInt32(Console.ReadLine());
            Konto newKonto = new Konto
            {
                BrugerID = Convert.ToInt32(userInfo[0]),
                OprettelsesDato = Convert.ToDateTime(userInfo[1]).ToString(),
                Saldo = Convert.ToInt32(userInfo[2]),
                Kontotype = userInfo[3].ToString(),
                Rentesats = Convert.ToInt32(userInfo[4])
            };
            AddKonto(newKonto);
        }

        /// <summary>
        /// Sender en bruger hen til AddUser
        /// </summary>
        //Done. Sender en Bruger hen til AddUser.
        public static void NewUserInputMethod()
        {
            var Bruger = new Bruger();
            Console.Write("Indtast fornavn: ");
            Bruger.FirstName = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            Console.Write("Indtast efternavn: ");
            Bruger.LastName = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            Console.Write("Indtast din job: ");
            Bruger.Job = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            AddUser(Bruger);
        }

        //Done. Laver en ny bruger i databasen.
        public static void AddUser(Bruger e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;

            cmd = new SqlCommand("select * from Bruger", connection);
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Bruger(fname, lname, job,oprettet) values('" + e.FirstName + "', '" + e.LastName + "', '" + e.Job + "" +
                    "','" + time.ToString(format) + "');";
                cmd.ExecuteNonQuery();


                Console.WriteLine("Tilføjede " + e.FirstName + " " + e.LastName + " til ansatte database.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        //Done. Laver en ny konto i databasen.
        public static void AddKonto(Konto k)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("select * from Konto", connection);
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Konto(brugerid,oprettet,saldo,kontotype,rentesats) " +
                    "values('" + k.BrugerID + "', '" + time.ToString(format) + "','"+ k.Saldo +"','" + k.Kontotype + "','" + k.Rentesats + "');";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tilføjede kontoen til database.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        //Done. Laver en ny transaktion i databasen.
        public static void AddTransaktion(Transaktioner t)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("select * from Trans", connection);
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Trans(kontonr,beløb,saldo,tid)" +
                    "values('" + t.KontoNr + "','" + t.Beløb + "','" + t.Saldo + "','" + t.TransaktionsTid + "')";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tilføjede transaktionen til databasen.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region DeleteFraDatabase
        //Done. Fjerner en specific bruger.
        public static void DeleteUser(int i)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            SqlCommand cmdTwo;
            connection.Close();
            cmd = new SqlCommand("DELETE FROM Bruger Where brugerid=@i", connection);
            cmdTwo = new SqlCommand("Delete from Konto where brugerid=@i", connection);

            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;
            cmdTwo.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmdTwo.Parameters["@i"].Value = i;

            connection.Open();

            int slettet = cmd.ExecuteNonQuery();
            int slettetTo = cmdTwo.ExecuteNonQuery();
            if (slettet > 0)
            {
                Console.WriteLine("Slettet - TRYK enter.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ikke fundet - TRYK enter");
                Console.ReadKey();
            }

            connection.Close();
        }

        //Done. Fjerner en specific konto
        public static void DeleteKonto(int i)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            connection.Close();
            cmd = new SqlCommand("DELETE FROM Konto Where kontonr=@i", connection);

            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;
            connection.Open();

            int slettet = cmd.ExecuteNonQuery();
            if (slettet > 0)
            {
                Console.WriteLine("Slettet - TRYK enter.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ikke fundet - TRYK enter");
                Console.ReadKey();
            }

            connection.Close();
        }

        #endregion

        #region UdskriverDataFraDatabase
        //Done. Viser alt info i databasen.
        public static void ShowAllUserData()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Bruger", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Fornavn: " + reader.GetValue(0));
                            Console.WriteLine("Efternavn: " + reader.GetValue(1));
                            Console.WriteLine("Job: " + reader.GetValue(2));
                            Console.WriteLine("Bruger ID: " + reader.GetValue(3));
                            Console.WriteLine("Oprettelses dato: " + reader.GetValue(4) + "\n");

                        }
                    }
                }
                using (SqlCommand kontiCommand = new SqlCommand("Select * from Konto", connection))
                {
                    using (SqlDataReader kontiReader = kontiCommand.ExecuteReader())
                    {
                        while (kontiReader.Read())
                        {
                            Console.WriteLine("Konto nr: " + kontiReader.GetValue(0));
                            Console.WriteLine("BrugerID: " + kontiReader.GetValue(1));
                            Console.WriteLine("Oprettelses dato: " + kontiReader.GetValue(2));
                            Console.WriteLine("Saldo: " + kontiReader.GetValue(3) + "\n");
                        }
                    }
                }
                connection.Close();
            }
        }
        
        //Done. Bedre version af SearchUserWithID.
        public static void ObjectOrientedSearchUserWithID(List<Bruger> userList, List<Konto> kontoList)
        {
            Console.Write("Indtast bruger ID: ");
            int userID = GenericTryCatch<int>.TryCatcher();
            Bruger foundUser = userList.Find(f => f.BrugerID == userID);
            Console.WriteLine("Bruger ID: " + foundUser.BrugerID);
            Console.WriteLine("Fornavn: " + foundUser.FirstName);
            Console.WriteLine("Efternavn: " + foundUser.LastName);
            Console.WriteLine("Job: " + foundUser.Job + "\n");
            List<Konto> foundKonti = kontoList.FindAll(f => f.BrugerID == userID);
            foreach (Konto konti in foundKonti)
            {
                Console.WriteLine("Bruger ID: " + konti.BrugerID);
                Console.WriteLine("Konto Nr: " + konti.KontoNr);
                Console.WriteLine("Saldo: " + konti.Saldo);
                Console.WriteLine("Oprettelses dato: " + konti.OprettelsesDato + "\n");


            }
        }

        //Viser saldo for en specific konto.
        public static void CreditInfo(List<Konto> kontiList)
        {
            Console.Write("Indtast et konto nr.: ");
            int kontoNr = GenericTryCatch<int>.TryCatcher();
            try
            {
                Console.WriteLine("Du har : " + kontiList.Find(f => f.KontoNr == kontoNr).Saldo + "kr. på din konto");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Konto nummeret kunne ikke blive fundet.");
            }
        }

        #endregion

        #region ListOprettelse

        //Done. Laver en lister over de brugere der er i databasen.
        public static List<Bruger> BrugerListCreator()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Bruger", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Program.userList.Add(new Bruger
                            {
                                FirstName = reader.GetValue(0).ToString(),
                                LastName = reader.GetValue(1).ToString(),
                                Job = reader.GetValue(2).ToString(),
                                BrugerID = Convert.ToInt32(reader.GetValue(3))
                            });

                        }
                    }
                }
                connection.Close();
                return Program.userList;
            }
        }

        //Done. Laver en liste over de konti der er i databasen.
        public static List<Konto> KontoListCreator()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            {
                connection.Open();
                using (SqlCommand kontiCommand = new SqlCommand("Select * from Konto", connection))
                {
                    using (SqlDataReader kontiReader = kontiCommand.ExecuteReader())
                    {
                        while (kontiReader.Read())
                        {
                            Program.kontoList.Add(new Konto
                            {
                                KontoNr = Convert.ToInt32(kontiReader.GetValue(0)),
                                BrugerID = Convert.ToInt32(kontiReader.GetValue(1)),
                                OprettelsesDato = kontiReader.GetValue(2).ToString(),
                                Saldo = Convert.ToInt32(kontiReader.GetValue(3))
                            });
                        }
                    }
                }
                connection.Close();
                return Program.kontoList;
            }
        }

        public static List<Transaktioner> TransaktionsListCreator()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            {
                connection.Open();
                using (SqlCommand transCommand = new SqlCommand("Select * from Trans", connection))
                {
                    using (SqlDataReader transReader = transCommand.ExecuteReader())
                    {
                        while (transReader.Read())
                        {
                            Program.transactionList.Add(new Transaktioner
                            {
                                KontoNr = Convert.ToInt32(transReader.GetValue(0)),
                                TransNr = Convert.ToInt32(transReader.GetValue(1)),
                                Beløb = Convert.ToInt32(transReader.GetValue(2)),
                                Saldo = Convert.ToInt32(transReader.GetValue(3)),
                                TransaktionsTid = transReader.GetValue(4).ToString()
                            });
                        }
                    }
                }
                connection.Close();
                return Program.transactionList;
            }
        }

        #endregion
        
        #region OpdateringAfData

        //Done. Opdatere en specific konto's saldo i databasen.
        public static void ChangeCredit(List<Konto> kontiList)
        {
            ConsoleKey options = new ConsoleKey();
            int kontoSaldo;
            int beløb = 0;
            bool wrongInput = true;
            Console.Write("Indtast et konto nr.: ");
            Konto kontiFound = kontiList.Find(f => f.KontoNr == GenericTryCatch<int>.TryCatcher());
            int kontiNr = kontiFound.KontoNr;
            kontoSaldo = kontiFound.Saldo;
            do
            {
                Console.WriteLine("\n\nDin konto har " + kontoSaldo + "kr. lige nu\n");
                Console.Write("\nVil du hæve eller indsætte penge?: H / I : ");
                options = Console.ReadKey().Key;
                switch (options)
                {
                    case ConsoleKey.H:
                        Console.Write("\nIndtast et beløb du vil hæve: ");
                        if(kontoSaldo - GenericTryCatch<int>.TryCatcher() < 0)
                        {
                            Console.WriteLine("Du kan ikke hæve flere penge en du har..");
                            break;
                        }

                        beløb = kontoSaldo - GenericTryCatch<int>.TryCatcher();
                        wrongInput = false;
                        break;
                    case ConsoleKey.I:
                        Console.Write("\nIndtast et beløb du vil indsætte: ");
                        beløb = kontoSaldo + GenericTryCatch<int>.TryCatcher();
                        wrongInput = false;
                        break;
                    default:
                        Console.WriteLine("Du valgte ikke en funktion...\n");
                        break;
                }
            } while (wrongInput);
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("update Konto set saldo = " + beløb + " where kontonr=@kontiNr", connection);
            connection.Open();
            cmd.Parameters.Add("@kontiNr", System.Data.SqlDbType.Int);
            cmd.Parameters["@kontiNr"].Value = kontiNr;
            cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("\nDer står nu " + beløb + "kr. på din konto\n");
            kontiList.Find(f => f.KontoNr == kontiNr).Saldo = beløb;
        }
        
        //Sender brugeren vidre til InformationChangingMethods class baseret på hvad han vil ændre.
        public static void ChangeUserInfo(List<Bruger> userList)
        {
            Bruger userFound = new Bruger();
            ConsoleKey options = new ConsoleKey();
            do
            {
                Console.Write("Indtast et bruger ID: ");
                int userChoice = GenericTryCatch<int>.TryCatcher();
                if (userList.Exists(f => f.BrugerID == userChoice))
                {
                    userFound = userList.Find(f => f.BrugerID == userChoice);
                    break;
                }
                else
                {
                    Console.WriteLine("\nDet bruger ID du indtastede eksisterer ikke\n");
                }
            } while (true);
            Console.Clear();
            Console.WriteLine("Bruger info:");
            Console.WriteLine("Fornavn: " + userFound.FirstName);
            Console.WriteLine("Efternavn: " + userFound.LastName);
            Console.WriteLine("Job: " + userFound.Job);
            Console.Write("\nHvilken information vil du gerne ændre?:\n1) Alt\n2) Fornavn\n3) Efternavn\n4) Job\n5) Tilbage til menu\n\n\nValg: ");
            options = Console.ReadKey().Key;
            switch (options)
            {
               
                case ConsoleKey.D1:
                    InformationChangingMethods.ChangeAllInfo(userFound);
                    break;
                case ConsoleKey.D2:
                    InformationChangingMethods.ChangeFirstname(userFound);
                    break;
                case ConsoleKey.D3:
                    InformationChangingMethods.ChangeLastname(userFound);
                    break;
                case ConsoleKey.D4:
                    InformationChangingMethods.ChangeJob(userFound);
                    break;
                case ConsoleKey.D5:
                    Program.Menu();
                    break;
                default:
                    Console.WriteLine("\n\nDu valgte ikke nogen funktion...\n");
                    break;
            }
        }
        #endregion
    }
}
