using System;

namespace AOPDemo.PostSharp.CarsDemo
{
    public interface ILoyaltyDataService
    {
        void AddPoints(Guid customerId, int points);
        void SubstractPoints(Guid customerId, int points);
    }
}