using System.Globalization;

namespace ASP.Net_Core_RazorPages_Learn.Models;

public class MyDateTime
{
    private DateTime _dateTime;

    public MyDateTime()
    {
        _dateTime = new DateTime();
    }

    public string NowUTC()
    {
        _dateTime = DateTime.Now;
        return _dateTime.ToUniversalTime().ToString(CultureInfo.InvariantCulture);
    }
}