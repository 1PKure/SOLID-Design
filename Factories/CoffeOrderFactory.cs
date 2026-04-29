using CafeOrdersTP1.Models;

namespace CafeOrdersTP1.Factories
{
    public class CoffeeOrderFactory : OrderFactory
    {
        public override OrderComponent CreateOrder()
        {
            return new SimpleOrder("Coffee", 2500m);
        }
    }
}