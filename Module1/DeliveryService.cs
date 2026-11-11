using System;
using System.Collections.Generic;

namespace Delivery
{
    class DeliveryService
    {
        List<Transport> transports = new List<Transport>();
        List<Order> activeOrders = new List<Order>();
        List<string> history = new List<string>();

        public void AddTransport(Transport transport)
        {
            transports.Add(transport);
        }

        bool IsValid(Order order)
        {
            if (order.Weight <= 0 || order.Distance <= 0)
            {
                return false;
            }
            return true;
        }

        public void ShowCosts(Order order)
        {
            Console.WriteLine("Замовлення №" + order.Number + " (" + order.Description + "):");

            if (!IsValid(order))
            {
                Console.WriteLine("  Некоректне замовлення: вага і відстань мають бути більшими за 0");
                return;
            }

            bool found = false;
            foreach (Transport t in transports)
            {
                if (t.CanTake(order))
                {
                    Console.WriteLine("  " + t.Name + ": " + t.CalculateCost(order) + " грн");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("  Жоден транспорт не може взяти це замовлення");
            }
        }

        public void Assign(Order order, Transport transport)
        {
            if (!IsValid(order))
            {
                Console.WriteLine("Не вийшло: замовлення №" + order.Number + " некоректне");
            }
            else if (order.IsDelivered)
            {
                Console.WriteLine("Не вийшло: замовлення №" + order.Number + " вже доставлене");
            }
            else if (order.AssignedTransport != null)
            {
                Console.WriteLine("Не вийшло: замовлення №" + order.Number + " вже призначене на " + order.AssignedTransport.Name);
            }
            else if (transport.IsBusy)
            {
                Console.WriteLine("Не вийшло: " + transport.Name + " зайнятий");
            }
            else if (!transport.CanTake(order))
            {
                Console.WriteLine("Не вийшло: " + transport.Name + " не може взяти замовлення №" + order.Number);
            }
            else
            {
                transport.IsBusy = true;
                order.AssignedTransport = transport;
                activeOrders.Add(order);
                Console.WriteLine("Замовлення №" + order.Number + " призначено: " + transport.Name);
            }
        }

        public void Deliver(Order order, IPayment payment)
        {
            if (order.AssignedTransport == null)
            {
                Console.WriteLine("Замовлення №" + order.Number + " не призначене на транспорт (або вже доставлене)");
                return;
            }

            Transport transport = order.AssignedTransport;
            double cost = transport.CalculateCost(order);

            payment.Pay(cost);
            transport.IsBusy = false;
            order.AssignedTransport = null;
            order.IsDelivered = true;
            activeOrders.Remove(order);
            history.Add("Замовлення №" + order.Number + " " + order.Description + ", " + transport.Name + ", " + cost + " грн, " + payment.Name);
            Console.WriteLine("Замовлення №" + order.Number + " доставлено");
        }

        public void ShowActive()
        {
            Console.WriteLine("    Активні замовлення    ");
            if (activeOrders.Count == 0)
            {
                Console.WriteLine("Активних замовлень немає");
                return;
            }

            foreach (Order o in activeOrders)
            {
                Console.WriteLine("№" + o.Number + " " + o.Description + " (" + o.AssignedTransport.Name + ")");
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("     Історія доставок    ");
            if (history.Count == 0)
            {
                Console.WriteLine("Історія доставок порожня");
                return;
            }

            foreach (string record in history)
            {
                Console.WriteLine(record);
            }
        }
    }
}