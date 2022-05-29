namespace ASP.Net_Core_RazorPages_Learn.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string Img { get; set; } = "";
}