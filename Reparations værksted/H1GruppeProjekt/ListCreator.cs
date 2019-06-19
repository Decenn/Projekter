using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GruppeProjekt
{
    static class ListCreator
    {
        private static List<VehicleBuilder> vehiclesList = new List<VehicleBuilder>();
        private static List<Customers> customersList = new List<Customers>();
        private static List<ServiceCheck> serviceCheckList = new List<ServiceCheck>();
        public static List<VehicleBuilder> VehiclesList => vehiclesList;
        public static List<Customers> CustomersList => customersList;
        public static List<ServiceCheck> ServiceCheckList => serviceCheckList;
        
    }
}
