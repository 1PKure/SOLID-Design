using System.Collections.Generic;
using CafeOrdersTP1.Observers;
using CafeOrdersTP1.Strategies;

namespace CafeOrdersTP1.Models
{
    public abstract class OrderComponent
    {
        private readonly string name;
        private readonly List<IObserver> observers;
        private IDiscountStrategy discountStrategy;

        public OrderStatus Status { get; private set; }

        protected OrderComponent(string name)
        {
            this.name = name;
            observers = new List<IObserver>();
            discountStrategy = new NoDiscountStrategy();
            Status = OrderStatus.Pending;
        }

        public string GetName()
        {
            return name;
        }

        public decimal GetBasePriceValue()
        {
            return GetBasePrice();
        }

        public decimal GetPrice()
        {
            return discountStrategy.ApplyDiscount(GetBasePrice());
        }

        public void SetDiscountStrategy(IDiscountStrategy strategy)
        {
            if (strategy != null)
            {
                discountStrategy = strategy;
            }
        }

        public void AddObserver(IObserver observer)
        {
            if (observer != null && !observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public bool MarkAsReady()
        {
            if (Status == OrderStatus.Ready)
            {
                return false;
            }

            Status = OrderStatus.Ready;
            NotifyObservers();
            return true;
        }

        protected void NotifyObservers()
        {
            string message = $"The order '{name}' is ready.";

            foreach (IObserver observer in observers)
            {
                observer.Update(message);
            }
        }

        protected abstract decimal GetBasePrice();
        public abstract void Display(int level = 0);
    }
}