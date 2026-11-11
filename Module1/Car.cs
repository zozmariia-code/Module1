namespace Delivery
{
    class Car : Transport
    {
        public Car()
        {
            Name = "Автомобіль";
            MaxWeight = 150;
        }

        public override double CalculateCost(Order order)
        {
            return 50 + 8 * order.Distance + 1 * order.Weight;
        }
    }
}