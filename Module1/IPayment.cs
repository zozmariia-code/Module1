namespace Delivery
{
    interface IPayment
    {
        string Name { get; }
        void Pay(double amount);
    }
}