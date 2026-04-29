using CafeOrdersTP1.Models;

namespace CafeOrdersTP1.Factories
{
    public class CakeOrderFactory : OrderFactory
    {
        public override OrderComponent CreateOrder()
        {
            return new SimpleOrder("Cake", 3200m);
        }
    }
}