using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labb4
{
    internal class Order
    {
        // I denna klass använder vi i stället private fields
        static int orderIdCounter = 1;
        private int _orderId;
        private List<MenuItem> _orderItems;
        private int _tableNumber;
        private DateTime _timeCreated;
        private DateTime _timeCompleted;

        public Order(List<MenuItem> orderItems, int tableNumber)
        {
            // Automatiskt skapande av id
            _orderId = orderIdCounter;
            orderIdCounter++;
            _orderItems = orderItems;
            _tableNumber = tableNumber;
            _timeCreated = DateTime.Now;
        }
        // Method to Print out the order.
        // Using GroupBy to combine identical menu items if they appear
        // Using key values to Name & Price.
        // It calculates the total cost and number of menu items ordered.
        public void PrintOrder()
        {
            Console.WriteLine($"Order {_orderId}:\n" +
                $"Created at {_timeCreated}");
            var theOrder = _orderItems.GroupBy(item => new { item.Name, item.Price });
            decimal totalSum = 0;
            foreach (var order in theOrder)
            {
                string name = order.Key.Name;
                decimal price = order.Key.Price;
                int quantity = order.Count();
                decimal itemTotal = price * quantity;

                Console.WriteLine($"{quantity} st {name} á {price:C}");
                totalSum += itemTotal;
            }
            Console.WriteLine($"Summa: {totalSum:C}");
            Console.WriteLine($"Till bord nummer {_tableNumber}");
        }
        public int GetOrderId()
        {
            return _orderId;
        }
        public int GetTableNumber()
        {
            return _tableNumber;
        }
        public void AddMenuItem(MenuItem item)
        {
            _orderItems.Add(item);
        }
        public List<MenuItem> GetOrderItems()
        {
            return _orderItems;
        }
        public DateTime TimeCreated()
        {
            return _timeCreated;
        }
        public int TimeCompleted()
        {
            _timeCompleted = DateTime.Now;
            var completed = _timeCompleted.Minute - _timeCreated.Minute;
            return completed;
        }
    }
}
