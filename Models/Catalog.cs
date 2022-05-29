using System.Collections.Concurrent;

namespace ASP.Net_Core_RazorPages_Learn.Models;

public class Catalog
{
    private ConcurrentBag<Product> _products;

    public Catalog()
    {
        _products = new();
        LoadData();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    
    public void AddArray(Product[] products)
    {
        foreach (Product product in products)
        {
            AddProduct(product);
        }
    }

    public IEnumerable<Product> GetCatalog()
    {
        return _products.ToList();
    }
    
    private void LoadData()
    {
        //  Init catalog
        string testImg =
            "https://avatars.mds.yandex.net/get-zen_doc/1841592/pub_5dedfb8292414d00afe52dc6_5dedfffcc49f2900abb2105b/scale_1200";
        AddArray(new Product[]
        {
            new() {Id = 1,Name = "Продукт_01", Price = new decimal(11.11), Img = testImg},
            new() {Id = 2,Name = "Продукт_02", Price = new decimal(22.22), Img = testImg},
            new() {Id = 3,Name = "Продукт_03", Price = new decimal(33.33), Img = testImg},
            new() {Id = 4,Name = "Продукт_04", Price = new decimal(44.44), Img = testImg},
        });
    }
}