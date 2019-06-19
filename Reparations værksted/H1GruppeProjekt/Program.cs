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
            UI.UI.UIMain();
            Database.CreateCustomersList();
            Database.CreateVehiclesList();
            Database.CreateServiceVisitsList();
        }
    }
}
