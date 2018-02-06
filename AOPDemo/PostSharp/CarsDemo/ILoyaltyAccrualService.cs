using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.PostSharp.CarsDemo
{
    public interface ILoyaltyAccrualService
    {
        void Accrue(RentalAgreement agreement);
    }
}
