using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.PostSharp.CarsDemo
{
    public class LoyalRedemptionService : ILoyaltyRedemptionService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;

        public LoyalRedemptionService(ILoyaltyDataService loyaltyDataService)
        {
            _loyaltyDataService = loyaltyDataService;
        }

        public void Redeem(Invoice invoice, int numberOfDays)
        {

            Console.WriteLine("Redeem:{0}", DateTime.Now);
            Console.WriteLine("Invoice:{0}", invoice.Id);
            var pointsPerDay = 10;
            if (invoice.Vehicle.Size >= Size.Luxury)
            {
                pointsPerDay = 15;
            }
            var totalPoints = pointsPerDay * numberOfDays;
            invoice.Discount = numberOfDays * invoice.CostPerDay;
            _loyaltyDataService.SubstractPoints(invoice.Customer.Id, totalPoints);
            Console.WriteLine("Redeem Complete:{0}", DateTime.Now);
        }
    }
}
