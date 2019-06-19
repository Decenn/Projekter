using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GruppeProjekt
{
    class Cars : VehicleBuilder
    {
        public Cars()
        {
            Database.CreateNewEntry(this);
        }
        public override string ToString(VehicleBuilder car)
        {
            throw new NotImplementedException();
        }
        public override void UpdateInfo(VehicleBuilder car)
        {
            
            throw new NotImplementedException();
        }
        public override void ShowInfo(VehicleBuilder car)
        {
            throw new NotImplementedException();
        }
        public override void DeleteInfo(VehicleBuilder car)
        {
            throw new NotImplementedException();
        }
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
            Database.CreateNewEntry(this);
        }
    }
}
