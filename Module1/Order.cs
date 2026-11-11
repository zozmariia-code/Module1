namespace Delivery
{
    class Order
    {
        public int Number;
        public string Description;
        public double Weight;
        public double Distance;
        public Transport AssignedTransport;
        public bool IsDelivered;
        public Order(int number, string description, double weight, double distance)
        {
            Number = number;
            Description = description;
            Weight = weight;
            Distance = distance;
            AssignedTransport = null;
            IsDelivered = false;
        }
    }
} 