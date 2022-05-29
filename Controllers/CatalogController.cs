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
}