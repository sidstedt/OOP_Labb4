namespace OOP_Labb4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurant danielsHak = new Restaurant();
            MenuItem carbonara = new MenuItem(1, "Carbonara", 159m);
            MenuItem schnitzel = new MenuItem(2, "Schnitzel", 169m);
            MenuItem fläskOchLöksås = new MenuItem(3, "Fläsk med löksås", 169m);
            MenuItem danielsSpecial = new MenuItem(4, "Daniels Special", 199m);

            danielsHak.AddtoMenu(carbonara);
            danielsHak.AddtoMenu(schnitzel);
            danielsHak.AddtoMenu(fläskOchLöksås);
            danielsHak.AddtoMenu(danielsSpecial);
            Console.WriteLine("-----------------------------");
            danielsHak.ShowMenu();
            Console.WriteLine("-----------------------------");

            List<MenuItem> orderOne = new List<MenuItem> { carbonara, fläskOchLöksås, danielsSpecial };
            List<MenuItem> orderTwo = new List<MenuItem> { schnitzel, carbonara, carbonara, fläskOchLöksås, danielsSpecial };
            List<MenuItem> orderThree = new List<MenuItem> { danielsSpecial, schnitzel };
            List<MenuItem> orderFour = new List<MenuItem> { schnitzel, schnitzel };
            List<MenuItem> orderFive = new List<MenuItem> { schnitzel, fläskOchLöksås };
            List<MenuItem> orderSix = new List<MenuItem> { danielsSpecial, danielsSpecial };
            List<MenuItem> orderSeven = new List<MenuItem> { schnitzel, danielsSpecial };
            List<MenuItem> orderEight = new List<MenuItem> { fläskOchLöksås, carbonara };
            List<MenuItem> orderNine = new List<MenuItem> { carbonara, schnitzel, carbonara };
            List<MenuItem> orderTen = new List<MenuItem> { danielsSpecial, danielsSpecial, schnitzel, carbonara };
            Order one = new Order(orderOne, 30);
            Order two = new Order(orderTwo, 7);
            Order three = new Order(orderThree, 20);
            Order four = new Order(orderFour, 15);
            Order five = new Order(orderFive, 20);
            Order six = new Order(orderSix, 1);
            Order seven = new Order(orderSeven, 3);
            Order eight = new Order(orderEight, 9);
            Order nine = new Order(orderNine, 30);
            Order ten = new Order(orderTen, 1);

            danielsHak.CreateOrder(one);
            Console.WriteLine();
            danielsHak.CreateOrder(two);
            Console.WriteLine();
            danielsHak.CreateOrder(three);

            Console.WriteLine("-----------------------------");

            danielsHak.ShowOrders();
            Console.WriteLine("-----------------------------");
            danielsHak.ShowOrderCount();
            Console.WriteLine();
            danielsHak.ShowNextOrder();
            danielsHak.HandleOrder();
            Console.WriteLine();
            danielsHak.ShowOrderCount();
            Console.WriteLine("-----------------------------");
            danielsHak.CreateOrder(four);
            Console.WriteLine();
            danielsHak.CreateOrder(five);
            Console.WriteLine();
            danielsHak.CreateOrder(six);
            Console.WriteLine();
            danielsHak.MoveToFront(six, true);
            Console.WriteLine();
            danielsHak.CreateOrder(seven);
            Console.WriteLine();
            danielsHak.CreateOrder(eight);
            Console.WriteLine();
            danielsHak.CreateOrder(nine);
            Console.WriteLine();
            danielsHak.CreateOrder(ten);
            Console.WriteLine();
            danielsHak.ShowOrderCount();
            Console.WriteLine();
            danielsHak.HandleOrder();
            danielsHak.HandleOrder();
            Console.WriteLine();
            danielsHak.ShowOrderCount();
            Console.WriteLine("-----------------------------");
            danielsHak.ShowNextOrder();
            Console.WriteLine();
            danielsHak.HandleOrder();
            Console.ReadKey();
        }
    }
}
