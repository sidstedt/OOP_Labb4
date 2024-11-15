using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labb4
{
    internal class Restaurant
    {
        int maxQueueSize = 5;
        List<MenuItem> TheMenu = new List<MenuItem>();
        Queue<Order> Orders = new Queue<Order>();
        List<Order> WaitingList = new List<Order>();

        public void AddtoMenu(MenuItem menuItem)
        {
            TheMenu.Add(menuItem);
            Console.WriteLine($"Maträtten {menuItem.Name} lades till på menyn");
        }
        public void ShowMenu()
        {
            Console.WriteLine("Meny:");
            foreach (var menu in TheMenu)
            {
                Console.WriteLine(menu.ToString());
            }
        }
        public void CreateOrder(Order order)
        {
            if (Orders.Count < maxQueueSize)
            {
                // Checking if an order from a table already exist
                var tableExist = Orders.FirstOrDefault(newOrder => newOrder.GetTableNumber() == order.GetTableNumber());
                if (tableExist != null)
                {
                    AddToTable(tableExist, order);
                }
                else
                {
                    Orders.Enqueue(order);
                    Console.WriteLine($"Beställning nr {order.GetOrderId()} har lagts till i kön.");
                }
            }
            else
            {
                WaitingList.Add(order);
                Console.WriteLine($"Beställning nr {order.GetOrderId()} har lagts till i väntelistan.");
            }
        }
        public void HandleOrder()
        {
            if (Orders.Count > 0)
            {
                Order handleOrder = Orders.Dequeue();
                Console.WriteLine($"Order {handleOrder.GetOrderId()} är färdig.\n" +
                    $"Det tog {handleOrder.TimeCompleted()} minuter för ordern att bli färdig.");
                if (WaitingList.Any())
                {
                    var nextOrder = WaitingList[0];
                    WaitingList.RemoveAt(0);
                    Orders.Enqueue(nextOrder);
                    Console.WriteLine($"Order {nextOrder.GetOrderId()} har lagts till i kön från väntelistan");
                }
            }
            else
            {
                Console.WriteLine("Finns ingen order att hantera.");
            }
        }
        public void ShowOrders()
        {

            Console.WriteLine("Aktuella beställningar:");
            if (Orders.Count > 0)
            {
                foreach (var order in Orders)
                {
                    order.PrintOrder();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Finns inga aktuella beställningar.");
            }
        }
        public void ShowNextOrder()
        {
            Console.WriteLine("Nästa order i kön:");
            if (Orders.TryPeek(out Order result))
            {
                result.PrintOrder();
            }
            else
            {
                Console.WriteLine("Finns inga ordrar just nu.");
            }
        }
        public void ShowOrderCount()
        {
            Console.WriteLine($"Det är {Orders.Count} ordrar i kön.");
        }
        public void AddToTable(Order exist, Order order)
        {
            foreach (var item in order.GetOrderItems())
            {
                exist.AddMenuItem(item);
            }
            Console.WriteLine($"Order från bord {order.GetTableNumber()} har uppdaterats.");
        }
        public void MoveToFront(Order order, bool urgent = false)
        {
            if (Orders.Contains(order))
            {
                var tempList = Orders.ToList();
                tempList.Remove(order);
                Orders.Clear();
                Orders.Enqueue(order);
                foreach (var orders in tempList)
                {
                    Orders.Enqueue(orders);
                }
                if (urgent == true)
                {
                    Console.WriteLine($"Order {order.GetOrderId()} har markerats som bårdskande och placerats först i kön!");
                }
                else
                {
                    Console.WriteLine($"Order {order.GetOrderId()} har flyttats längst fram i kön.");
                }
            }
            else
            {
                Console.WriteLine("Ordern finns inte i kön");
            }
        }
    }
}
