using System;

namespace CafeOrdersTP1.Observers
{
    public class CustomerObserver : IObserver
    {
        private readonly string customerName;

        public CustomerObserver(string customerName)
        {
            this.customerName = customerName;
        }

        public void Update(string message)
        {
            Console.WriteLine($"[Customer: {customerName}] Your order is ready for pickup. Details: {message}");
        }
    }
}