using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.PostSharp.CarsDemo
{

    public class RentalAgreement
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DriversLicense { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Size Size { get; set; }
        public string Vin { get; set; }
    }

    public enum Size
    {
        Compact = 0,
        Midsize,
        FullSize,
        Luxury,
        Truck,
        SUV
    }

}
