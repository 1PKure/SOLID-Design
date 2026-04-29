namespace CafeOrdersTP1.Strategies
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal total);
    }
}