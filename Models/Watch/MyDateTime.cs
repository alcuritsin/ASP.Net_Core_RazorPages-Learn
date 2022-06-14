using System.Globalization;
using System.Text;

namespace ASP.Net_Core_RazorPages_Learn.Models.Watch;

public class MyDateTime
{
    private WatchTime _watchTime;
    
    public MyDateTime()
    {
        _watchTime = new WatchTime
        {
            Year = 1, 
            Month = 1,
            Day = 1,

            Hour = 0,
            Minute = 0,
            Second = 0
        };
    }

    public MyDateTime(int _year, int _month, int _day, int _hour, int _minute, int _second)
    {
        _watchTime = new WatchTime
        {
            Year = _year, 
            Month = _month,
            Day = _day,

            Hour = _hour,
            Minute = _minute,
            Second = _second
        };
    }

    public void Change(int _year, int _month, int _day, int _hour, int _minute, int _second)
    {
        Change(new WatchTime
        {
            Year = _year, 
            Month = _month,
            Day = _day,

            Hour = _hour,
            Minute = _minute,
            Second = _second 
        });
    }

    public void Change(WatchTime watchTime)
    {
        _watchTime = watchTime;
    }
    
    public DateTime GetDateTime()
    {
        return new DateTime(
            year: _watchTime.Year, month: _watchTime.Month, day: _watchTime.Day,
            hour: _watchTime.Hour, minute: _watchTime.Minute, second: _watchTime.Second);
    }
    
    public DateTime GetDateTimeUTC()
    {
        return GetDateTime().ToUniversalTime();
    }
}