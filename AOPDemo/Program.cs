using AOPDemo.Business;
using AOPDemo.ConvertHelper;
using AOPDemo.PostSharp;
using AOPDemo.PostSharp.CarsDemo;
using AOPDemo.RedisHelper;
using AOPDemo.RedisWork;
using NewAop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Main1();
            //Main2();
            //Main3();
            Console.Read();
        }

        static void Main1()
        {
            //var epc = new Exameplec("张三");
            //epc.SayHello();
            //epc.SayByeBye();
            var epc = new RedisExameplec();
            var data = epc.Push("001");
            //var data1 = epc.Get();

            //var str = CatchTest.TryCatchTest();
            //Console.WriteLine(str);
            //XMLHelper.ConvertXmlSiteMap();
            //SiteMapRead.GetContent();
            //RedisConfigInfo.GetConfig();
            Console.Read();
        }

        /// <summary>
        /// 上一个AOPDemo太难理解了，使用PostSharp试试
        /// </summary>
        static void Main2()
        {
            var obj = new MyClass();
            obj.MyMehtod();
            Console.Read();
        }
        static void Main3()
        {
            SimulateAddingPoints();//模拟累积
            Console.WriteLine("***************");
            SimulateRemovingPoints();//模拟兑换
            Console.Read();
        }

        /// <summary>
        /// 模拟累积积分
        /// </summary>
        static void SimulateAddingPoints()
        {
            var dataService = new FakeLoyalDataService();//这里使用的数据库服务是伪造的
            var service = new LoyaltyAccrualService(dataService);
            var agreement = new RentalAgreement
            {
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "tkb至简",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    DriversLicense = "123456"
                },
                Vehicle = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Make = "Ford",
                    Model = "金牛座",
                    Size = Size.Compact,
                    Vin = "浙-ABC123"
                },
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now
            };
            service.Accrue(agreement);
        }

        /// <summary>
        /// 模拟兑换积分
        /// </summary>
        static void SimulateRemovingPoints()
        {
            var dataService = new FakeLoyalDataService();
            var service = new LoyalRedemptionService(dataService);
            var invoice = new Invoice
            {
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Farb",
                    DateOfBirth = new DateTime(1999, 1, 1),
                    DriversLicense = "abcdef"
                },
                Vehicle = new Vehicle
                {
                    Id = Guid.NewGuid(),
                    Make = "奥迪",
                    Model = "Q7",
                    Size = Size.Compact,
                    Vin = "浙-DEF123"
                },
                CostPerDay = 100,
                Id = Guid.NewGuid()
            };
            service.Redeem(invoice, 3);//这里兑换3天
        }

    }
}
