using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Entities.Enums;

namespace Orders.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();

        public Order() 
        { 
        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }
        public void RemoveItem(OrderItem item) 
        {  
            items.Remove(item); 
        }
        public double Total()
        { 
            double total = 0;
            foreach (OrderItem item in items)
            {
                total += item.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString());
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" ");
            sb.Append(Client.BirthDate.ToString());
            sb.Append(" - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order Items:");
            foreach (OrderItem item in items)
            {
                sb.Append(item.Product.Name);
                sb.Append(", ");
                sb.Append(item.Price.ToString());
                sb.Append(", quantity:  ");
                sb.Append(item.Quantity);
                sb.Append(", subtotal: ");
                sb.AppendLine(item.SubTotal().ToString("F2"));
            }
            sb.Append("Total Price: ");
            sb.AppendLine(Total().ToString("F2"));

            return sb.ToString();
        }
    }
}
