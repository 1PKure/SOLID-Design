namespace CafeOrdersTP1.Strategies
{
    public class MembershipDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal percentage;

        public MembershipDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return total - (total * percentage / 100m);
        }
    }
}