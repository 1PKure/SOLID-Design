using CafeOrdersTP1.Models;

namespace CafeOrdersTP1.Factories
{
    public class ComboOrderFactory : OrderFactory
    {
        public override OrderComponent CreateOrder()
        {
            ComboOrder combo = new ComboOrder("Coffee + Cake Combo");
            combo.AddItem(new SimpleOrder("Coffee", 2500m));
            combo.AddItem(new SimpleOrder("Cake", 3200m));

            return combo;
        }
    }
}