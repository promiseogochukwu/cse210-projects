
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost;

        if (_customer.LivesInUSA())
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }

        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL\n";

        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()}\n";
            label += $"Product ID: {product.GetProductId()}\n";
            label += "-------------------------\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return "SHIPPING LABEL\n" +
               _customer.GetName() + "\n" +
               _customer.GetAddress().GetAddress();
    }
}
