namespace CafeOrdersTP1.Strategies
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal total)
        {
            return total;
        }
    }
}