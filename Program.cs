using System;
using CafeOrdersTP1.Factories;
using CafeOrdersTP1.Services;

namespace CafeOrdersTP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                ShowMenu();

                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                Console.Clear();
                string message = string.Empty;

                switch (input)
                {
                    case "1":
                        message = orderManager.CreateOrder(new CoffeeOrderFactory());
                        break;

                    case "2":
                        message = orderManager.CreateOrder(new CakeOrderFactory());
                        break;

                    case "3":
                        message = orderManager.CreateOrder(new ComboOrderFactory());
                        break;

                    case "4":
                        message = orderManager.ShowOrders();
                        break;

                    case "5":
                        message = HandleMembershipDiscount(orderManager);
                        break;

                    case "6":
                        message = HandleVolumeDiscount(orderManager);
                        break;

                    case "7":
                        message = HandleMarkAsReady(orderManager);
                        break;

                    case "0":
                        isRunning = false;
                        message = "Closing application...";
                        break;

                    default:
                        message = "Invalid option.";
                        break;
                }

                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine(message);
                }

                if (isRunning)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("=== CAFE ORDER SYSTEM ===");
            Console.WriteLine("1 - Create Coffee Order");
            Console.WriteLine("2 - Create Cake Order");
            Console.WriteLine("3 - Create Combo Order");
            Console.WriteLine("4 - Show Orders");
            Console.WriteLine("5 - Apply Membership Discount");
            Console.WriteLine("6 - Apply Volume Discount");
            Console.WriteLine("7 - Mark Order As Ready");
            Console.WriteLine("0 - Exit");
            Console.WriteLine();
        }

        private static string HandleMembershipDiscount(OrderManager orderManager)
        {
            Console.Write("Enter order number: ");
            if (!int.TryParse(Console.ReadLine(), out int orderIndex))
            {
                return "Invalid order number.";
            }

            Console.Write("Enter membership discount percentage: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal percentage))
            {
                return "Invalid percentage.";
            }

            return orderManager.ApplyMembershipDiscount(orderIndex - 1, percentage);
        }

        private static string HandleVolumeDiscount(OrderManager orderManager)
        {
            Console.Write("Enter order number: ");
            if (!int.TryParse(Console.ReadLine(), out int orderIndex))
            {
                return "Invalid order number.";
            }

            Console.Write("Enter volume discount percentage: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal percentage))
            {
                return "Invalid percentage.";
            }

            Console.Write("Enter minimum amount required: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal minimumAmount))
            {
                return "Invalid minimum amount.";
            }

            return orderManager.ApplyVolumeDiscount(orderIndex - 1, percentage, minimumAmount);
        }

        private static string HandleMarkAsReady(OrderManager orderManager)
        {
            Console.Write("Enter order number: ");
            if (!int.TryParse(Console.ReadLine(), out int orderIndex))
            {
                return "Invalid order number.";
            }

            return orderManager.MarkOrderAsReady(orderIndex - 1);
        }
    }
}