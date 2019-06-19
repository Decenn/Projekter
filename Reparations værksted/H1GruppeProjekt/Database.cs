using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace H1GruppeProjekt
{
    class Database
    {
        readonly static SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=AutoShopDB;Integrated Security=True");

        public int GetNextAvailableID(List<Customers> customers)
        {
            int id = 0;
            foreach (Customers customer in customers)
            {
                if (customer.CustomerID > id)
                    id = customer.CustomerID;
            }
            return ++id;
        }

        #region CreateNewEntryInDatabase

        /// <summary>
        /// Creates a new vehicle in the SQL database
        /// </summary>
        /// <param name="vehicle"></param>
        public static void CreateNewEntry(VehicleBuilder vehicle)
        {
            SqlCommand cmd;

            cmd = new SqlCommand("INSERT INTO Vehicles(regNr,brand,model,productionYear,distance,fuelType,color,doors,wheels,customerID,[date])", con);
            con.Open();

            cmd.Parameters.AddWithValue("@regNr", vehicle.RegNr);
            cmd.Parameters.AddWithValue("@brand", vehicle.Brand);
            cmd.Parameters.AddWithValue("@model", vehicle.Model);
            cmd.Parameters.AddWithValue("@productionYear", vehicle.ProductionYear);
            cmd.Parameters.AddWithValue("@distance", vehicle.DistanceDriven);
            cmd.Parameters.AddWithValue("@fuelType", vehicle.Type);
            cmd.Parameters.AddWithValue("@color", vehicle.Color);
            cmd.Parameters.AddWithValue("@doors", vehicle.Doors);
            cmd.Parameters.AddWithValue("@wheels", vehicle.Wheels);
            cmd.Parameters.AddWithValue("@customerID", vehicle.Customer.CustomerID);
            cmd.Parameters.AddWithValue("@[date]", vehicle.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        /// <summary>
        /// Creates a new customer in the SQL database
        /// </summary>
        /// <param name="customer"></param>
        public static void CreateNewEntry(Customers customer)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("INSERT INTO Customer(customerID,firstName,lastName,[date]", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@firstName", customer.Firstname);
            cmd.Parameters.AddWithValue("@lastName", customer.Lastname);
            cmd.Parameters.AddWithValue("@[date]", customer.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Creates a new service check in the SQL database
        /// </summary>
        /// <param name="serviceCheck"></param>
        public static void CreateNewEntry(ServiceCheck serviceCheck)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("INSERT INTO Visits(visitID,customerID,regNr,reason,[date]", con);
            con.Open();
            cmd.Parameters.AddWithValue("@visitID", serviceCheck.VisitID);
            cmd.Parameters.AddWithValue("@customerID", serviceCheck.Customer.CustomerID);
            cmd.Parameters.AddWithValue("@regNr", serviceCheck.Vehicle.RegNr);
            cmd.Parameters.AddWithValue("@reason", serviceCheck.Reason);
            cmd.Parameters.AddWithValue("@[date]", serviceCheck.VisitDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        #region UpdateInfo

        /// <summary>
        /// Updates SQL database info for a vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        public static void UpdateInfo(VehicleBuilder vehicle)
        {
            int i = vehicle.Customer.CustomerID;
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE Vehicles SET regNr = @regNr, brand = @brand, model = @model, productionYear = @productionYear, " +
                "distance = @distance, fuelType = @fuelType, color = @color, doors = @doors, wheels = @wheels, customerID = @customerID, [date] = @[date]" +
                " where regNr=@i", con);
            con.Open();
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;

            cmd.Parameters.AddWithValue("@regNr", vehicle.RegNr);
            cmd.Parameters.AddWithValue("@brand", vehicle.Brand);
            cmd.Parameters.AddWithValue("@model", vehicle.Model);
            cmd.Parameters.AddWithValue("@productionYear", vehicle.ProductionYear);
            cmd.Parameters.AddWithValue("@distance", vehicle.DistanceDriven);
            cmd.Parameters.AddWithValue("@fuelType", vehicle.Type);
            cmd.Parameters.AddWithValue("@color", vehicle.Color);
            cmd.Parameters.AddWithValue("@doors", vehicle.Doors);
            cmd.Parameters.AddWithValue("@wheels", vehicle.Wheels);
            cmd.Parameters.AddWithValue("@customerID", vehicle.Customer.CustomerID);
            cmd.Parameters.AddWithValue("@[date]", vehicle.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();
        } 

        /// <summary>
        /// Updates SQL database info for a customer
        /// </summary>
        /// <param name="customer"></param>
        public static void UpdateInfo(Customers customer)
        {
            int i = customer.CustomerID;
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE Customer SET customerID = @customerID, firstName = @firstName, lastName = @lastName, [date] = @[date]" +
                " where customerID=@i", con);
            con.Open();
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;
            cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@firstName", customer.Firstname);
            cmd.Parameters.AddWithValue("@lastName", customer.Lastname);
            cmd.Parameters.AddWithValue("@[date]", customer.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Updates SQL database info for a Service check
        /// </summary>
        /// <param name="serviceCheck"></param>
        public static void UpdateInfo(ServiceCheck serviceCheck)
        {
            int i = serviceCheck.VisitID;
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE Visits SET visitID = @visitID, customerID = @customerID, regNr = @regNr, reason = @reason, [date] = @[date]" +
                " where visitID=@i", con);
            con.Open();
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;
            cmd.Parameters.AddWithValue("@visitID", serviceCheck.VisitID);
            cmd.Parameters.AddWithValue("@customerID", serviceCheck.Customer.CustomerID);
            cmd.Parameters.AddWithValue("@regNr", serviceCheck.Vehicle.RegNr);
            cmd.Parameters.AddWithValue("@reason", serviceCheck.Reason);
            cmd.Parameters.AddWithValue("@[date]", serviceCheck.VisitDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion

        #region DeleteInfo
        public static void DeleteInfo(ServiceCheck serviceCheck)
        {
            int i = serviceCheck.VisitID;
            SqlCommand cmd;
            
            con.Close();
            cmd = new SqlCommand("DELETE FROM Visits Where visitID=@i", con);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;
            
            con.Open();

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

            con.Close();
        }
        public static void DeleteInfo(VehicleBuilder vehicle)
        {
            int i = vehicle.RegNr;
            SqlCommand cmd;

            con.Close();
            cmd = new SqlCommand("DELETE FROM Vehicles Where regNr=@i", con);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;

            con.Open();

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

            con.Close();
        }
        public static void DeleteInfo(Customers customer)
        {
            int i = customer.CustomerID;
            SqlCommand cmd;

            con.Close();
            cmd = new SqlCommand("DELETE FROM Customer Where customerID=@i", con);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;

            con.Open();

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

            con.Close();
        }
        #endregion

        #region ListCreation

        /// <summary>
        /// Creates the CustomersList by reading from the SQL database
        /// </summary>
        public static void CreateCustomersList()
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListCreator.CustomersList.Add(new Customers
                        {
                            CustomerID = Convert.ToInt32(reader.GetValue(0).ToString()),
                            Firstname = reader.GetValue(1).ToString(),
                            Lastname = reader.GetValue(2).ToString(),
                            CreationDate = Convert.ToDateTime(reader.GetValue(3))

                        });
                    }
                }
            }
            con.Close();
        }
        /// <summary>
        /// Creates the VehiclesList by reading from the SQL database
        /// </summary>
        public static void CreateVehiclesList()
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Vehicles", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListCreator.VehiclesList.Add(new Cars
                        {
                            RegNr = Convert.ToInt32(reader.GetValue(0)),
                            Brand = reader.GetValue(1).ToString(),
                            Model = reader.GetValue(2).ToString(),
                            ProductionYear = Convert.ToInt32(reader.GetValue(3)),
                            DistanceDriven = Convert.ToDecimal(reader.GetValue(4)),
                            Type = FuelTypeEnumConverter(reader.GetValue(5)),
                            Color = reader.GetValue(6).ToString(),
                            Doors = Convert.ToInt32(reader.GetValue(7)),
                            Wheels = Convert.ToInt32(reader.GetValue(8)),
                            Customer = ListCreator.CustomersList.Find(f => f.CustomerID == Convert.ToInt32(reader.GetValue(9))),
                            CreationDate = Convert.ToDateTime(reader.GetValue(10))
                        });

                    }
                }
            }
            con.Close();
            foreach(Customers customer in ListCreator.CustomersList)
            {
                int i = ListCreator.VehiclesList.FindAll(f => f.Customer.CustomerID == customer.CustomerID).Count();
                if (i > 0)
                {
                    for (int x = 0; x < i; x++)
                    {
                        customer.Vehicles.Add(ListCreator.VehiclesList.Find(f => f.Customer.CustomerID == customer.CustomerID));
                    }
                }
                
                
            }

        }
        /// <summary>
        /// Creates the ServiceVisitsList by reading from the SQL database
        /// </summary>
        public static void CreateServiceVisitsList()
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Visits", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListCreator.ServiceCheckList.Add(new ServiceCheck
                        {
                            VisitID = Convert.ToInt32(reader.GetValue(0)),
                            Customer = ListCreator.CustomersList.Find(f => f.CustomerID == Convert.ToInt32(reader.GetValue(1))),
                            Vehicle = ListCreator.VehiclesList.Find(f => f.RegNr == Convert.ToInt32(reader.GetValue(2))),
                            Reason = reader.GetValue(3).ToString(),
                            VisitDate = Convert.ToDateTime(reader.GetValue(4))
                        });
                    }
                }
            }
            con.Close();
        }
        #endregion

        /// <summary>
        /// Used for object to FuelType enum convertion
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static VehicleBuilder.FuelType FuelTypeEnumConverter(object sender)
        {
            string input = sender.ToString();
            if (input.Contains(VehicleBuilder.FuelType.Benzin.ToString()))
                return VehicleBuilder.FuelType.Benzin;
            if (input.Contains(VehicleBuilder.FuelType.Diesel.ToString()))
                return VehicleBuilder.FuelType.Diesel;
            else
                return VehicleBuilder.FuelType.El;
        }
    }


}
