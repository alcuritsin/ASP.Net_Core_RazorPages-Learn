using ASP.Net_Core_RazorPages_Learn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_RazorPages_Learn.Controllers;

public class CatalogController : Controller
{
    private static Catalog _catalog = new Catalog();

    public IActionResult Products()
    {
        return View(_catalog);
    }

    [HttpGet]
    public IActionResult ProductAdding()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ProductAdding([FromForm] Product product)
    {
        _catalog.AddProduct(product);
        return View();
    }
}