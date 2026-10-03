using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    // An order contains products and belongs to a customer
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost;

        if (_customer.LivesInUsa())
        {
            shippingCost = 5.00;
        }
        else
        {
            shippingCost = 35.00;
        }

        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();

        label.AppendLine("=== Packing Label ===");

        foreach (Product product in _products)
        {
            label.AppendLine(
                $"Product: {product.GetName()}");
        }

        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("=== Shipping Label ===");
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddress().GetAddress());
        return label.ToString();
    }
}
