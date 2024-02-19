using Orders.Entities;
using Orders.Entities.Enums;
using System.Globalization;

Console.WriteLine("Enter client data:");
Console.Write("Name: ");
string clientName = Console.ReadLine();
Console.Write("Email: ");
string clientEmail = Console.ReadLine();
Console.Write("Birth Date: ");
DateTime clientBirthDate = DateTime.Parse(Console.ReadLine());

Client client = new Client(clientName, clientEmail, clientBirthDate);

Console.WriteLine("Enter order Data:");
Console.Write("Status: ");
OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

Console.Write("How many items to this order? ");
int numberOfItems  = int.Parse(Console.ReadLine());

DateTime moment = DateTime.Now;

Order order = new Order(moment, status, client);

for (int i = 0; i < numberOfItems; i++) 
{
    Console.WriteLine($"Enter #{i + 1} item data:");
    Console.Write("Product name: ");
    string productName = Console.ReadLine();
    Console.Write("Product price: ");
    double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Quantity: ");
    int quantity = int.Parse(Console.ReadLine());

    Product product = new Product(productName, productPrice);
    OrderItem orderItem = new OrderItem(quantity, productPrice, product);

    order.AddItem(orderItem);
}

Console.WriteLine(order);