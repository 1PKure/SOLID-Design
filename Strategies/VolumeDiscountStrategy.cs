namespace CafeOrdersTP1.Strategies
{
    public class VolumeDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal percentage;
        private readonly decimal minimumAmount;

        public VolumeDiscountStrategy(decimal percentage, decimal minimumAmount)
        {
            this.percentage = percentage;
            this.minimumAmount = minimumAmount;
        }

        public decimal ApplyDiscount(decimal total)
        {
            if (total >= minimumAmount)
            {
                return total - (total * percentage / 100m);
            }

            return total;
        }
    }
}