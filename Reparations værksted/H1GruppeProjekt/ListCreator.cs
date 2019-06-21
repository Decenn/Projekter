using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GruppeProjekt
{
    static class ListCreator
    {
        readonly private static List<Customers> customersList = new List<Customers>();
        readonly private static List<ServiceCheck> serviceCheckList = new List<ServiceCheck>();
        readonly private static List<VehicleBuilder> vehiclesList = new List<VehicleBuilder>();
        public static List<VehicleBuilder> VehiclesList => vehiclesList;
        public static List<Customers> CustomersList => customersList;
        public static List<ServiceCheck> ServiceCheckList => serviceCheckList;
        public static List<string> ToStringCustomerList()
        {
            List<string> CustomerStringList = new List<string>();
            foreach(Customers customer in CustomersList)
            {
                CustomerStringList.Add(customer.ToString());
            }
            return CustomerStringList;
        }
    }
}
