using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.PostSharp.CarsDemo
{
    public interface ILoyaltyRedemptionService
    {
        void Redeem(Invoice invoice, int numberOfDays);
    }

    /// <summary>
    /// 发票实体
    /// </summary>
    public class Invoice
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public int CostPerDay { get; set; }
        public decimal Discount { get; set; }
    }
}
