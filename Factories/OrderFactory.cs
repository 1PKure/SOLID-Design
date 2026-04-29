using CafeOrdersTP1.Models;

namespace CafeOrdersTP1.Factories
{
    public abstract class OrderFactory
    {
        public abstract OrderComponent CreateOrder();
    }
}