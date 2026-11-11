namespace Delivery
{
    class Bike : Transport
    {
        public Bike()
        {
            Name = "Велосипед";
            MaxWeight = 10;
        }

        public override double CalculateCost(Order order)
        {
            return 20 + 5 * order.Distance;
        }
        public override bool CanTake(Order order)
        {
            if (order.Weight <= MaxWeight && order.Distance <= 10)
            {
                return true;
            }
            return false;
        }
    }
}