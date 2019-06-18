using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2CaseBank
{
    class InformationChangingMethods
    {
        
        public static void ChangeAllInfo(Bruger foundUser)
        {
            int brugerID = foundUser.BrugerID;
            Console.Clear();
            Console.Write("Skriv et nyt fornavn: ");
            foundUser.FirstName = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            Console.Write("Skriv et nyt efternavn: ");
            foundUser.LastName = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            Console.Write("Skriv et nyt job: ");
            foundUser.Job = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            var connection = new SqlConnection(Bruger.ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("update Bruger set fname = " + foundUser.FirstName + ", set lname = " + foundUser.LastName +
                ", set job = " + foundUser.Job + " where brugerid=@brugerID", connection);
            connection.Open();
            cmd.Parameters.Add("@brugerID", System.Data.SqlDbType.Int);
            cmd.Parameters["@brugerID"].Value = brugerID;
            cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Brugeren: " + foundUser.BrugerID + " har nu fået opdateret sin info");
            Console.WriteLine("\nFornavn: " + foundUser.FirstName);
            Console.WriteLine("Efternavn: " + foundUser.LastName);
            Console.WriteLine("Job: " + foundUser.Job);
            Program.userList.Find(f => f.BrugerID == foundUser.BrugerID).FirstName = foundUser.FirstName;
            Program.userList.Find(f => f.BrugerID == foundUser.BrugerID).LastName = foundUser.LastName;
            Program.userList.Find(f => f.BrugerID == foundUser.BrugerID).Job = foundUser.Job;
        }
        public static void ChangeFirstname(Bruger foundUser)
        {
            int brugerID = foundUser.BrugerID;
            Console.Clear();
            Console.Write("Skriv et nyt fornavn: ");
            foundUser.FirstName = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            var connection = new SqlConnection(Bruger.ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("update Bruger set fname = " + foundUser.FirstName + " where brugerid=@brugerID", connection);
            connection.Open();
            cmd.Parameters.Add("@brugerID", System.Data.SqlDbType.Int);
            cmd.Parameters["@brugerID"].Value = brugerID;
            cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Brugeren: " + foundUser.BrugerID + " har nu fået opdateret sin info");
            Console.WriteLine("\nNyt Fornavn: " + foundUser.FirstName);
            Program.userList.Find(f => f.BrugerID == foundUser.BrugerID).FirstName = foundUser.FirstName;
        }
        public static void ChangeLastname(Bruger foundUser)
        {
            int brugerID = foundUser.BrugerID;
            Console.Clear();
            Console.Write("Skriv et nyt efternavn: ");
            foundUser.LastName = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            var connection = new SqlConnection(Bruger.ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("update Bruger set lname = " + foundUser.LastName + " where brugerid=@brugerID", connection);
            connection.Open();
            cmd.Parameters.Add("@brugerID", System.Data.SqlDbType.Int);
            cmd.Parameters["@brugerID"].Value = brugerID;
            cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Brugeren: " + foundUser.BrugerID + " har nu fået opdateret sin info");
            Console.WriteLine("\nNyt Efternavn: " + foundUser.LastName);
            Program.userList.Find(f => f.BrugerID == foundUser.BrugerID).FirstName = foundUser.FirstName;
            Program.userList.Find(f => f.BrugerID == foundUser.BrugerID).LastName = foundUser.LastName;
        }
        public static void ChangeJob(Bruger foundUser)
        {
            int brugerID = foundUser.BrugerID;
            Console.Clear();
            Console.Write("Skriv et nyt job: ");
            foundUser.Job = GenericTryCatch<string>.TryCatcher(Console.ReadLine());
            var connection = new SqlConnection(Bruger.ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("update Bruger set job = " + foundUser.Job + " where brugerid=@brugerID", connection);
            connection.Open();
            cmd.Parameters.Add("@brugerID", System.Data.SqlDbType.Int);
            cmd.Parameters["@brugerID"].Value = brugerID;
            cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Brugeren: " + foundUser.BrugerID + " har nu fået opdateret sin info");
            Console.WriteLine("\nNyt Job: " + foundUser.Job);
            Program.userList.Find(f => f.BrugerID == foundUser.BrugerID).Job = foundUser.Job;
        }
    }
}
