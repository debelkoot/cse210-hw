using System;

class Program
{
    static void Main(string[] args)
    {
        // First customer and order
        Address address1 = new Address(
            "123 Main Street",
            "Rexburg",
            "Idaho",
            "USA");
        Customer customer1 = new Customer(
            "Alice Johnson",
            address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(
            new Product("Laptop Mouse", "M101", 25.99, 2));
        order1.AddProduct(
            new Product("Keyboard", "K102", 75.50, 1));
        // Second customer and order
        Address address2 = new Address(
            "456 Queen Street",
            "Toronto",
            "Ontario",
            "Canada");
        Customer customer2 = new Customer(
            "Bob Smith",
            address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(
            new Product("Monitor", "MN201", 299.99, 1));
        order2.AddProduct(
            new Product("Desk Mat", "DM202", 19.99, 2));
        Console.WriteLine("====== ORDER 1 ======");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(
            $"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();
        Console.WriteLine("====== ORDER 2 ======");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(
            $"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}
