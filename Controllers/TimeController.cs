using ASP.Net_Core_RazorPages_Learn.Models;
using Microsoft.AspNetCore.Mvc;
using static System.DateTime;

namespace ASP.Net_Core_RazorPages_Learn.Controllers;

public class TimeController:Controller
{
    private MyDateTime _dateTime = new MyDateTime();

    public IActionResult NowUTC()
    {
        return View(_dateTime);
    }
}