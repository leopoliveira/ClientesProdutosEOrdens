using System;
using System.Text;
using System.Collections.Generic;
using ClientOrders.Entities.Enums;

namespace ClientOrders.Entities
{
    internal class Order
    {
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime orderDate, OrderStatus status, Client client)
        {
            OrderDate = orderDate;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
        }

        public double Total()
        {
            double total = 0;
            foreach(OrderItem orderItem in OrderItems)
            {
                total += orderItem.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------");
            sb.AppendLine("ORDER RESUME: ");
            sb.Append("\tOrder Date: ");
            sb.AppendLine(OrderDate.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("\tOrder Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("\tClient: ");
            sb.Append(Client.Name);
            sb.Append(" - ");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(" - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("");
            sb.AppendLine("");

            sb.AppendLine("Order Items: ");
            
            foreach(OrderItem orderItem in OrderItems)
            {
                sb.Append("\tItem Name: ");
                sb.AppendLine(orderItem.Product.Name);
                sb.Append("\tItem Price: $");
                sb.AppendLine(orderItem.Product.Price.ToString("F2"));
                sb.Append("\tQuantity of Items: ");
                sb.AppendLine(orderItem.Quantity.ToString());
                sb.Append("\tItem Total Value: $");
                sb.AppendLine(orderItem.SubTotal().ToString("F2"));
                sb.AppendLine("---------------");
            }
            sb.AppendLine("");
            sb.Append("\tOrder Total Value: $");
            sb.AppendLine(Total().ToString("F2"));

            return sb.ToString();
        }
    }
}
