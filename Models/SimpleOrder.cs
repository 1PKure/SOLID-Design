using System;

namespace CafeOrdersTP1.Models
{
    public class SimpleOrder : OrderComponent
    {
        private readonly decimal basePrice;

        public SimpleOrder(string name, decimal basePrice)
            : base(name)
        {
            this.basePrice = basePrice;
        }

        protected override decimal GetBasePrice()
        {
            return basePrice;
        }

        public override void Display(int level = 0)
        {
            string indentation = new string(' ', level * 2);
            decimal basePriceValue = GetBasePriceValue();
            decimal finalPrice = GetPrice();

            Console.WriteLine($"{indentation}- {GetName()} | Base Price: ${basePriceValue} | Final Price: ${finalPrice} | Status: {Status}");
        }
    }
}