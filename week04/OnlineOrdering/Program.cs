using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main St",
            "Seattle",
            "WA",
            "USA"
        );

        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);

        Product product1 = new Product("KeyBoard", "K100", 50.00, 2);
        Product product2 = new Product("Mouse", "M200", 25.00, 1);
        Product product3 = new Product("USB Cable", "U300", 10.00, 3);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Address address2 = new Address(
            "88 Zhongxiao East Road",
            "Taipei",
            "Taipei",
            "Taiwan"
        );

        Customer customer2 = new Customer("Amy Chen", address2);

        Order order2 = new Order(customer2);

        Product product4 = new Product("Monitor", "MON400", 200.00, 1);
        Product product5 = new Product("Webcam", "CAM500", 60.00, 2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("ORDER 1");
        Console.WriteLine();

        Console.WriteLine("Packing Label: ");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label: ");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}");

        Console.WriteLine();
        Console.WriteLine("----------------------------");
        Console.WriteLine();

        Console.WriteLine("ORDER 2");
        Console.WriteLine();

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}");
        }
}