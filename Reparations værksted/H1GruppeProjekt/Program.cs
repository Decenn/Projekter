using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions;
using UI;

namespace H1GruppeProjekt
{
    class Program
    {
        static void Main()
        {
            Database database = new Database();
            database.CreateCustomersList();
            database.CreateVehiclesList();
            Customers.LastNameSorting();
            //ListCreator.CustomersList.Sort();
            UI.UI.UIMain();
            
            
            database.CreateServiceVisitsList();
        }
    }
}
