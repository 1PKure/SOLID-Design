using System;

namespace CafeOrdersTP1.Observers
{
    public class EmployeeObserver : IObserver
    {
        private readonly string employeeName;

        public EmployeeObserver(string employeeName)
        {
            this.employeeName = employeeName;
        }

        public void Update(string message)
        {
            Console.WriteLine($"[Employee: {employeeName}] Please prepare to deliver the order. Details: {message}");
        }
    }
}