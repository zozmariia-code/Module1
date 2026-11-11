using System;

namespace Delivery
{
    class CashPayment : IPayment
    {
        public string Name
        {
            get { return "готівка"; }
        }

        public void Pay(double amount)
        {
            Console.WriteLine("Оплачено готівкою: " + amount + " грн");
        }
    }
}