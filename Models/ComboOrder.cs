using System;
using System.Collections.Generic;

namespace CafeOrdersTP1.Models
{
    public class ComboOrder : OrderComponent
    {
        private readonly List<OrderComponent> items;

        public ComboOrder(string comboName)
            : base(comboName)
        {
            items = new List<OrderComponent>();
        }

        public void AddItem(OrderComponent item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        protected override decimal GetBasePrice()
        {
            decimal total = 0m;

            foreach (OrderComponent item in items)
            {
                total += item.GetPrice();
            }

            return total;
        }

        public override void Display(int level = 0)
        {
            string indentation = new string(' ', level * 2);
            decimal subtotalValue = GetBasePriceValue();
            decimal finalPrice = GetPrice();

            Console.WriteLine($"{indentation}+ {GetName()} | Subtotal: ${subtotalValue} | Final Price: ${finalPrice} | Status: {Status}");

            foreach (OrderComponent item in items)
            {
                item.Display(level + 1);
            }
        }
    }
}