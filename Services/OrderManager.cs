using System;
using System.Collections.Generic;
using CafeOrdersTP1.Factories;
using CafeOrdersTP1.Models;
using CafeOrdersTP1.Observers;
using CafeOrdersTP1.Strategies;

namespace CafeOrdersTP1.Services
{
    public class OrderManager
    {
        private readonly List<OrderComponent> orders;
        private readonly IObserver customerObserver;
        private readonly IObserver employeeObserver;

        public OrderManager()
        {
            orders = new List<OrderComponent>();
            customerObserver = new CustomerObserver("Matias");
            employeeObserver = new EmployeeObserver("Barista");
        }

        public string CreateOrder(OrderFactory factory)
        {
            if (factory == null)
            {
                return "Error: invalid factory.";
            }

            OrderComponent order = factory.CreateOrder();

            if (order == null)
            {
                return "Error: order could not be created.";
            }

            order.AddObserver(customerObserver);
            order.AddObserver(employeeObserver);

            orders.Add(order);

            return "Order created successfully.";
        }

        public string ShowOrders()
        {
            if (orders.Count == 0)
            {
                return "There are no orders created.";
            }

            Console.WriteLine("=== ORDER LIST ===");

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"Order #{i + 1}");
                orders[i].Display();
                Console.WriteLine();
            }

            return string.Empty;
        }

        public string ApplyMembershipDiscount(int orderIndex, decimal percentage)
        {
            if (!IsValidOrderIndex(orderIndex))
            {
                return "Invalid order number.";
            }

            if (!IsValidDiscountPercentage(percentage))
            {
                return "Invalid percentage. Enter a value greater than 0 and less than 100.";
            }

            orders[orderIndex].SetDiscountStrategy(new MembershipDiscountStrategy(percentage));
            return $"Membership discount of {percentage}% applied successfully.";
        }

        public string ApplyVolumeDiscount(int orderIndex, decimal percentage, decimal minimumAmount)
        {
            if (!IsValidOrderIndex(orderIndex))
            {
                return "Invalid order number.";
            }

            if (!IsValidDiscountPercentage(percentage))
            {
                return "Invalid percentage. Enter a value greater than 0 and less than 100.";
            }

            if (minimumAmount <= 0)
            {
                return "Invalid minimum amount. It must be greater than 0.";
            }

            orders[orderIndex].SetDiscountStrategy(new VolumeDiscountStrategy(percentage, minimumAmount));
            return $"Volume discount of {percentage}% applied successfully.";
        }

        public string MarkOrderAsReady(int orderIndex)
        {
            if (!IsValidOrderIndex(orderIndex))
            {
                return "Invalid order number.";
            }

            bool changed = orders[orderIndex].MarkAsReady();

            if (!changed)
            {
                return "The selected order is already marked as ready.";
            }

            return "Order marked as ready successfully.";
        }

        private bool IsValidOrderIndex(int orderIndex)
        {
            return orderIndex >= 0 && orderIndex < orders.Count;
        }

        private bool IsValidDiscountPercentage(decimal percentage)
        {
            return percentage > 0m && percentage < 100m;
        }
    }
}