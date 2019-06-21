using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GruppeProjekt
{
    class Cars : VehicleBuilder
    {
        readonly private Database database;
        public Cars()
        {
            
        }
        public override string ToString(VehicleBuilder car)
        {
            return $"{car.RegNr} {car.Brand} {car.Model} {car.Color} {car.Type}";
        }
        public override void UpdateInfo(VehicleBuilder car) => database.UpdateInfo(car);
        public override void ShowInfo(VehicleBuilder car) => database.ShowInfo(car);
        public override void DeleteInfo(VehicleBuilder car) => database.DeleteInfo(car);

        /// <summary>
        /// Returns the next available RegNr
        /// </summary>
        /// <param name="vehicles"></param>
        /// <returns></returns>
        public override int GetNextAvailableRegNr(List<VehicleBuilder> vehicles)
        {
            int nextRegNr = 0;
            foreach(VehicleBuilder vehicle in vehicles)
            {
                if (vehicle.RegNr > nextRegNr)
                    nextRegNr = vehicle.RegNr;
            }
            return ++nextRegNr;
        }

        public Cars(Customers user)
        {
            
            Customer = user;
            RegNr = GetNextAvailableRegNr(ListCreator.VehiclesList);
            
            ListCreator.VehiclesList.Add(this);
            database.CreateNewEntry(this);
        }

    }
}
