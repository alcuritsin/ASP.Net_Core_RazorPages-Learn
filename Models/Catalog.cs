using System.Collections.Concurrent;

namespace ASP.Net_Core_RazorPages_Learn.Models;

public class Catalog
{
    private ConcurrentBag<Product> _products;

    public Catalog()
    {
        _products = new ConcurrentBag<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    
    
}