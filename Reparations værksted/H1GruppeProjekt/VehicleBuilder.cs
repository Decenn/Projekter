using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GruppeProjekt
{
    abstract class VehicleBuilder
    {
        private Customers customer;
        public enum FuelType { Diesel, El, Benzin };
        private FuelType fuelType;
        private string color;
        private int doors;
        private int wheels;
        private int regNr;
        private string brand;
        private string model;
        private int productionYear;
        private decimal distanceDriven;
        private DateTime creationDate;
        public DateTime CreationDate { get { return creationDate; } set { creationDate = value; } }
        public Customers Customer { get { return customer; } set { customer = value; } }
        public string Color { get { return color; } set { color = value; } }
        public FuelType Type { get { return fuelType; } set { fuelType = value; } }
        public int Doors { get { return doors; } set { doors = value; } }
        public int Wheels { get { return wheels; } set { wheels = value; } }
        public int RegNr{ get { return regNr; } set { regNr = value; } }
        public string Brand { get { return brand; } set { brand = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int ProductionYear { get { return productionYear; } set { productionYear = value; } }
        public decimal DistanceDriven { get { return distanceDriven; } set { distanceDriven = value; } }

        public abstract string ToString(VehicleBuilder vehicle);

        public abstract void UpdateInfo(VehicleBuilder vehicle);

        public abstract void DeleteInfo(VehicleBuilder vehicle);

        public abstract void ShowInfo(VehicleBuilder vehicle);

        public abstract int GetNextAvailableRegNr(List<VehicleBuilder> vehicles);
        
    }
}
