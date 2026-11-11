using System;

namespace Delivery
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeliveryService service = new DeliveryService();
            Bike bike = new Bike();
            Car car = new Car();
            Truck truck = new Truck();
            service.AddTransport(bike);
            service.AddTransport(car);
            service.AddTransport(truck);

            Order small = new Order(1, "Документи", 2, 5);
            Order far = new Order(2, "Квіти", 3, 25);
            Order heavy = new Order(3, "Меблі", 500, 12);
            Order laptop = new Order(4, "Ноутбук", 2, 30);

            CardPayment card = new CardPayment();
            CashPayment cash = new CashPayment();

            Console.WriteLine("        Порожні списки        ");
            service.ShowActive();
            service.ShowHistory();

            Console.WriteLine("\n         Вартість доставки      ");
            service.ShowCosts(small);
            service.ShowCosts(far);
            service.ShowCosts(heavy);

            Console.WriteLine("\n          Призначення      ");
            service.Assign(far, bike);
            service.Assign(heavy, car);
            service.Assign(small, bike);
            service.Assign(far, bike);
            service.Assign(far, car);
            service.Assign(heavy, truck);
            service.Assign(small, truck);
            service.ShowActive();

            Console.WriteLine("\n      Доставка      ");
            service.Deliver(small, card);
            service.Deliver(far, cash);
            service.Deliver(small, card);
            service.Deliver(laptop, card);
            service.Deliver(heavy, card);

            Console.WriteLine("\n      Призначення доставленого       ");
            service.Assign(small, bike);

            Console.WriteLine("\n    Результат      ");
            service.ShowActive();
            service.ShowHistory();
        }
    }
}