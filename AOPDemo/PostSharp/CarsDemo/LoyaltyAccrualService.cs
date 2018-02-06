using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.PostSharp.CarsDemo
{
    public class LoyaltyAccrualService : ILoyaltyAccrualService
    {
        private readonly ILoyaltyDataService _loyaltyDataService;

        public LoyaltyAccrualService(ILoyaltyDataService loyaltyDataService)
        {
            _loyaltyDataService = loyaltyDataService;//数据服务必须在该对象初始化时传入该对象
        }
        /// <summary>
        /// 该方法包含了积分系统累积客户积分的逻辑和规则
        /// </summary>
        /// <param name="agreement">租赁协议实体</param>
        public void Accrue(RentalAgreement agreement)
        {
            Console.WriteLine("Accrue:{0}", DateTime.Now);
            Console.WriteLine("Customer:{0}", agreement.Customer.Id);
            Console.WriteLine("Vehicle:{0}", agreement.Vehicle.Id);
            var rentalTimeSpan = agreement.EndDate.Subtract(agreement.StartDate);
            var numberOfDays = (int)rentalTimeSpan.TotalDays;
            var pointsPerDay = 1;
            if (agreement.Vehicle.Size >= Size.Luxury)
            {
                pointsPerDay = 2;
            }
            var points = numberOfDays * pointsPerDay;
            //调用数据服务存储客户获得的积分
            _loyaltyDataService.AddPoints(agreement.Customer.Id, points);

            Console.WriteLine("Accrue Complete：{0}", DateTime.Now);
        }
    }
}
