using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;

namespace H1GruppeProjekt
{
    class UIConstructors
    {
        Customers CustomerClass = new Customers();
        Cars CarsClass = new Cars();
        ServiceCheck ServiceCheckClass = new ServiceCheck();
        public void CustomerConstructor(Customers customer, int X, int Y)
        {
            int i = 0;
            Console.SetCursorPosition(X + 1, Y + i * 2 + 1);
            customer.Firstname = InputChecker.NameChecker(X + 1, Y + i * 2 + 1);
            i++;
            customer.Lastname = InputChecker.NameChecker(X+ 1, Y + i * 2 + 1);
            customer.CreationDate = DateTime.Now;
            customer.CustomerID = CustomerClass.GetNextAvailableID(ListCreator.CustomersList);
            ListCreator.CustomersList.Add(customer);
        }
        public void CustomerConstructor(VehicleBuilder vehicle, int X, int Y)
        {
            int i = 0;
            Console.SetCursorPosition(X + 1, Y + i * 2 + 1);
            vehicle.RegNr = CarsClass.GetNextAvailableRegNr(ListCreator.VehiclesList);
            i++;
            vehicle.Brand = InputChecker.NameChecker(X + 1, Y + i * 2 + 1);
            i++;
            vehicle.Color = InputChecker.NameChecker(X + 1, Y + i * 2 + 1);
            i++;
            vehicle.Model = InputChecker.NameChecker(X + 1, Y + i * 2 + 1);
            i++;
            vehicle.ProductionYear = InputChecker.IntInputChecker(X + 1, Y + i * 2 + 1);
            i++;
            vehicle.DistanceDriven = InputChecker.IntInputChecker(X + 1, Y + i * 2 + 1);
            i++;
            vehicle.Doors = InputChecker.IntInputChecker(X + 1, Y + i * 2 + 1);
            i++;
            vehicle.Wheels = InputChecker.IntInputChecker(X + 1, Y + i * 2 + 1);
            i++;
            vehicle.CreationDate = DateTime.Now;

            ListCreator.VehiclesList.Add(vehicle);
        }
    }
}
