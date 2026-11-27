
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ONLINE ORDERING SYSTEM");
        Console.WriteLine("==============================");

        // First customer and address
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "New York",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        // First order and products
        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Laptop",
            "P101",
            800,
            1
        );

        Product product2 = new Product(
            "Mouse",
            "P102",
            25,
            2
        );

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Second customer and address
        Address address2 = new Address(
            "15 Independence Avenue",
            "Enugu",
            "Enugu State",
            "Nigeria"
        );

        Customer customer2 = new Customer(
            "Mary Johnson",
            address2
        );

        // Second order and products
        Order order2 = new Order(customer2);

        Product product3 = new Product(
            "Phone",
            "P103",
            500,
            1
        );

        Product product4 = new Product(
            "Headphones",
            "P104",
            50,
            2
        );

        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display first order
        Console.WriteLine("\nORDER 1");
        Console.WriteLine("------------------------------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        // Display second order
        Console.WriteLine("\nORDER 2");
        Console.WriteLine("------------------------------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
