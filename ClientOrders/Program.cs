using System;
using ClientOrders.Entities;
using ClientOrders.Entities.Enums;
using System.Globalization;

namespace ClientOrders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Welcome to Client x Order System...");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("");

            // Client Data
            Console.WriteLine("Let's fill Client Data Records:");

            Console.Write("\tClient's Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("\tClient's E-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("\tClient's Birthdate (dd/MM/yyyy): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("");

            Client client1 = new Client(name, email, birthDate);

            //Order Data
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Let's fill Order Data Records:");

            Console.WriteLine("Enter Order Status:");
            Console.WriteLine("\t0. Pending Payment");
            Console.WriteLine("\t1. Processing");
            Console.WriteLine("\t2. Shipped");
            Console.WriteLine("\t3. Delivered");
            Console.Write("\t");
            OrderStatus orderStatus = (OrderStatus)int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Order order1 = new Order(DateTime.Now, orderStatus, client1);

            //Product Data
            Console.WriteLine("---------------------------------");
            Console.WriteLine("How many items would you like to put in this order? ");
            int numberOfOrders = int.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");

            for (int i = 1; i <= numberOfOrders; i++)
            {
                Console.WriteLine($"Enter #{i} item record: ");
                Console.Write("\tProduct Name: ");
                string productName = Console.ReadLine();
                Console.WriteLine("");
                Console.Write("\tProduct Price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("");

                Product product = new Product(productName, productPrice);

                Console.Write("\tProduct Quantity: ");
                int productQty = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                OrderItem orderItem = new OrderItem(productQty, product);
                order1.AddItem(orderItem);
                
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Would you like to see Order's Resume:");
            Console.WriteLine("1. Yes");
            Console.WriteLine("9. No");
            int showOrdersResumeYesNo = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            switch(showOrdersResumeYesNo)
            {
                case 1:
                    Console.WriteLine(order1);
                    break;
                case 9:
                    Console.WriteLine("Ok. Bye!!!");
                    Console.WriteLine("---------------------------------");
                    break;
                default:
                    Console.WriteLine("Err... Wrong selection! Try again.");
                    break;
            }
        }
    }
}
