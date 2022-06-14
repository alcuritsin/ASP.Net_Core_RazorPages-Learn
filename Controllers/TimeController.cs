using ASP.Net_Core_RazorPages_Learn.Models;
using ASP.Net_Core_RazorPages_Learn.Models.Watch;
using Microsoft.AspNetCore.Mvc;
using static System.DateTime;

namespace ASP.Net_Core_RazorPages_Learn.Controllers;

public class TimeController:Controller
{
    private static MyDateTime _dateTime = new MyDateTime();

    public IActionResult NowUTC()
    {
        return View(_dateTime);
    }
    
    [HttpGet]
    public IActionResult SetTime()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SetTime([FromForm] WatchTime watchTime)
    {
        _dateTime.Change(watchTime);
        return View();
    }

}