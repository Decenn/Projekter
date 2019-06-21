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
        readonly static SqlConnection con = new SqlConnection(@"Data Source=SKAB6-PC-02;Initial Catalog=AutoshopDB;Integrated Security=True");
        
        #region CreateNewEntryInDatabase

        /// <summary>
        /// Creates a new vehicle in the SQL database
        /// </summary>
        /// <param name="vehicle"></param>
        public void CreateNewEntry(VehicleBuilder vehicle)
        {
            SqlCommand cmd;

            cmd = new SqlCommand("INSERT INTO Vehicles(@regNr,@brand,@model,@productionYear,@distance,@fuelType,@color,@doors,@wheels,@customerID,@creationDate)", con);
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
            cmd.Parameters.AddWithValue("@creationDate", vehicle.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        /// <summary>
        /// Creates a new customer in the SQL database
        /// </summary>
        /// <param name="customer"></param>
        public void CreateNewEntry(Customers customer)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("INSERT INTO Customer VALUES (@customerID,@firstName,@lastName,@creationDate)", con);
            con.Close();
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@firstName", customer.Firstname);
            cmd.Parameters.AddWithValue("@lastName", customer.Lastname);
            cmd.Parameters.AddWithValue("@creationDate", customer.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Creates a new service check in the SQL database
        /// </summary>
        /// <param name="serviceCheck"></param>
        public void CreateNewEntry(ServiceCheck serviceCheck)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("INSERT INTO Visits VALUES (@visitID,@customerID,@regNr,@reason,@creationDate", con);
            con.Open();
            cmd.Parameters.AddWithValue("@visitID", serviceCheck.VisitID);
            cmd.Parameters.AddWithValue("@customerID", serviceCheck.Customer.CustomerID);
            cmd.Parameters.AddWithValue("@regNr", serviceCheck.Vehicle.RegNr);
            cmd.Parameters.AddWithValue("@reason", serviceCheck.Reason);
            cmd.Parameters.AddWithValue("@creationDate", serviceCheck.VisitDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        #region UpdateInfo

        /// <summary>
        /// Updates SQL database info for a vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        public void UpdateInfo(VehicleBuilder vehicle)
        {
            int i = vehicle.Customer.CustomerID;
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE Vehicles SET regNr = @regNr, brand = @brand, model = @model, productionYear = @productionYear, " +
                "distance = @distance, fuelType = @fuelType, color = @color, doors = @doors, wheels = @wheels, customerID = @customerID, creationDate = @creationDate" +
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
            cmd.Parameters.AddWithValue("@creationDate", vehicle.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();
        } 

        /// <summary>
        /// Updates SQL database info for a customer
        /// </summary>
        /// <param name="customer"></param>
        public void UpdateInfo(Customers customer)
        {
            int i = customer.CustomerID;
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE Customer SET customerID = @customerID, firstName = @firstName, lastName = @lastName, creationDate = @creationDate" +
                " where customerID=@i", con);
            con.Open();
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;
            cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@firstName", customer.Firstname);
            cmd.Parameters.AddWithValue("@lastName", customer.Lastname);
            cmd.Parameters.AddWithValue("@creationDate", customer.CreationDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Updates SQL database info for a Service check
        /// </summary>
        /// <param name="serviceCheck"></param>
        public void UpdateInfo(ServiceCheck serviceCheck)
        {
            int i = serviceCheck.VisitID;
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE Visits SET visitID = @visitID, customerID = @customerID, regNr = @regNr, reason = @reason, creationDate = @creationDate" +
                " where visitID=@i", con);
            con.Open();
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int);
            cmd.Parameters["@i"].Value = i;
            cmd.Parameters.AddWithValue("@visitID", serviceCheck.VisitID);
            cmd.Parameters.AddWithValue("@customerID", serviceCheck.Customer.CustomerID);
            cmd.Parameters.AddWithValue("@regNr", serviceCheck.Vehicle.RegNr);
            cmd.Parameters.AddWithValue("@reason", serviceCheck.Reason);
            cmd.Parameters.AddWithValue("@creationDate", serviceCheck.VisitDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion

        #region DeleteInfo
        /// <summary>
        /// Deletes a service check from the database
        /// </summary>
        /// <param name="serviceCheck"></param>
        public void DeleteInfo(ServiceCheck serviceCheck)
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

        /// <summary>
        /// Deletes a vehicle from the database
        /// </summary>
        /// <param name="vehicle"></param>
        public void DeleteInfo(VehicleBuilder vehicle)
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

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="customer"></param>
        public void DeleteInfo(Customers customer)
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

        #region ShowInfo

        public void ShowInfo(List<VehicleBuilder> vehicles)
        {
            foreach(VehicleBuilder vehicle in vehicles)
            {
                Console.WriteLine(vehicle.CreationDate);
                Console.WriteLine(vehicle.RegNr);
                Console.WriteLine(vehicle.Brand);
                Console.WriteLine(vehicle.Model);
                Console.WriteLine(vehicle.Color);
                Console.WriteLine(vehicle.ProductionYear);
                Console.WriteLine(vehicle.Type);
                Console.WriteLine(vehicle.DistanceDriven);
                Console.WriteLine(vehicle.Doors);
                Console.WriteLine(vehicle.Wheels);
                Console.ReadKey();
            }
        }

        public void ShowInfo(VehicleBuilder vehicle)
        {
            Console.WriteLine(vehicle.Customer.CustomerID);
            Console.WriteLine(vehicle.Customer.Firstname);
            Console.WriteLine(vehicle.Customer.Lastname);
            Console.WriteLine(vehicle.Customer.Vehicles.Count());
            Console.WriteLine(vehicle.CreationDate);
            Console.WriteLine(vehicle.RegNr);
            Console.WriteLine(vehicle.Brand);
            Console.WriteLine(vehicle.Model);
            Console.WriteLine(vehicle.Color);
            Console.WriteLine(vehicle.ProductionYear);
            Console.WriteLine(vehicle.Type);
            Console.WriteLine(vehicle.DistanceDriven);
            Console.WriteLine(vehicle.Doors);
            Console.WriteLine(vehicle.Wheels);
            Console.ReadKey();
        }
        public void ShowInfo(Customers customer)
        {
            Console.WriteLine(customer.CustomerID);
            Console.WriteLine(customer.Firstname);
            Console.WriteLine(customer.Lastname);
            Console.WriteLine(customer.Vehicles.Count());
            Console.WriteLine(customer.CreationDate);
            Console.ReadKey();
        }
        public void ShowInfo(ServiceCheck serviceCheck)
        {
            Console.WriteLine(serviceCheck.VisitID);
            Console.WriteLine(serviceCheck.Customer.CustomerID);
            Console.WriteLine(serviceCheck.Customer.Firstname);
            Console.WriteLine(serviceCheck.Customer.Lastname);
            Console.WriteLine(serviceCheck.Vehicle.RegNr);
            Console.WriteLine(serviceCheck.VisitDate);
            Console.WriteLine(serviceCheck.Reason);
            Console.ReadKey();
        }
        public void ShowCustomersVehicleInfo(Customers customer)
        {
            List<VehicleBuilder> customersVehicles = new List<VehicleBuilder>();
            foreach(VehicleBuilder vehicle in ListCreator.VehiclesList)
            {
                if (customer.CustomerID == vehicle.Customer.CustomerID)
                    customersVehicles.Add(vehicle);
            }
            ShowInfo(customersVehicles);
            
        }

        #endregion

        #region ListCreation

        /// <summary>
        /// Creates the CustomersList by reading from the SQL database
        /// </summary>
        /// 
        public void CreateCustomersList()
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
        public void CreateVehiclesList()
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
        public void CreateServiceVisitsList()
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
        public VehicleBuilder.FuelType FuelTypeEnumConverter(object sender)
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
