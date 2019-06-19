using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GruppeProjekt
{
    class ServiceCheck
    {
        private int visitID;
        private Customers customer;
        private VehicleBuilder vehicle;
        private string reason;
        private DateTime visitDate;
        public int VisitID { get { return visitID; } set { visitID = value; } }
        public Customers Customer { get { return customer; } set { customer = value; } }
        public VehicleBuilder Vehicle { get { return vehicle; } set { vehicle = value; } }
        public string Reason { get { return reason; } set { reason = value; } }
        public DateTime VisitDate { get { return visitDate; } set { visitDate = value; } }
        public ServiceCheck() { }
        public ServiceCheck(VehicleBuilder vehicle, Customers customer) { }
        public void UpdateInfo(ServiceCheck serviceCheck) { }
        public void DeleteInfo(ServiceCheck serviceCheck) { }
    }
}
