using System;

namespace Delivery
{
    class CardPayment : IPayment
    {
        public string Name
        {
            get { return "картка"; }
        }

        public void Pay(double amount)
        {
            Console.WriteLine("Оплачено карткою: " + amount + " грн");
        }
    }
}