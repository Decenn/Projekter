using System;
using System.Collections.Generic;
using System.Linq;

namespace H1GruppeProjekt
{
    class Customers : IEquatable<Customers>, IComparable<Customers>
    {
        readonly private Database database;
        private int customerID;
        private string firstname;
        private string lastname;
        private DateTime creationDate;
        private List<VehicleBuilder> vehicles = new List<VehicleBuilder>();

        public string Firstname { get { return firstname; } set { firstname = value; } }
        public int CustomerID { get { return customerID; } set { customerID = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public DateTime CreationDate { get { return creationDate; } set { creationDate = value; } }
        public List<VehicleBuilder> Vehicles { get { return vehicles; } set { vehicles = value; } }
        public Customers()
        {
            
        }
        public Customers(List<Customers> customers)
        {
            customers.Add(new Customers()
            {
                CustomerID = GetNextAvailableID(customers),
                Firstname = Console.ReadLine(),
                Lastname = Console.ReadLine(),
                Vehicles = CustomerListCreator(ListCreator.VehiclesList, this),
                CreationDate = DateTime.Now
            }) ;
            
        }
        public List<VehicleBuilder> CustomerListCreator(List<VehicleBuilder> vehicles, Customers customer)
        {
            
            foreach(VehicleBuilder vehicle in vehicles)
            {
                if (vehicle.Customer.CustomerID == this.CustomerID)
                    Vehicles.Add(vehicle);
            }
            return Vehicles;
        }
        #region Database functions
        public void ShowInfo(Customers customer) => database.ShowInfo(customer);
        public void UpdateInfo(Customers customer) => database.UpdateInfo(customer);
        public void DeleteInfo(Customers customer) => database.DeleteInfo(customer);
        #endregion

        public int GetNextAvailableID(List<Customers> customers)
        {
            int id = 0;
            foreach (Customers customer in customers)
            {
                if (customer.customerID > id)
                {
                    id = customer.CustomerID;
                }
            }
            return ++id;
        }
        
        /// <summary>
        /// Sorts CustomersList with CustomerID
        /// </summary>
        public void CustomerIDSorting()
        {
            ListCreator.CustomersList.Sort();
            foreach (Customers customer in ListCreator.CustomersList)
            {
                Console.WriteLine("Kunde ID: {0}", customer.CustomerID);
                Console.WriteLine("Fornavn: {0}", customer.Firstname);
                Console.WriteLine("Efternavn: {0}", customer.Lastname);
                Console.WriteLine("Oprettelses dato: {0}", customer.CreationDate.ToString());
            }
        }

        #region CompareTo and Equals methods for CustomerID sorting
        public int CompareTo(Customers compareCustomer)
        {
            if (compareCustomer == null)
                return 1;
            else
                return this.CustomerID.CompareTo(compareCustomer.CustomerID);
        }
        public bool Equals(Customers other)
        {
            if (other == null)
                return false;
            return this.CustomerID.Equals(other.CustomerID);

        }
        #endregion

        /// <summary>
        /// Sorts CustomersList with lastnames
        /// </summary>
        public static void LastNameSorting()
        {
            ListCreator.CustomersList.Sort(delegate (Customers x, Customers y)
            {
                if (x.Lastname == null && y.Lastname == null) return 0;
                else if (x.Lastname == null) return -1;
                else if (y.Lastname == null) return 1;
                else return x.Lastname.CompareTo(y.Lastname);
            });

        }
        public override string ToString()
        {
            try
            {
                Vehicles.Count();
                return $"{Firstname}      \t {Lastname}            \t - {CustomerID} \t - Biler: {Vehicles.Count()} \t\t";
            }
            catch (Exception)
            {
                return $"{Firstname}      \t {Lastname}            \t - {CustomerID} \t - Biler: 0 \t\t";
                throw;
            }
                
            
        }
    }
}
