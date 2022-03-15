using System;
using System.Globalization;

namespace Nasfaq.API
{
    public static class TimeUtils
    {
        

        public static long Get(int year, int month, int day, int minutes = 0, int seconds = 0, int milliseconds = 0)
        {
            return new DateTimeOffset(new DateTime(year, month, day, minutes, seconds, milliseconds)).ToUnixTimeMilliseconds();
        }

        public static string GetAuctionString(int hours, int minutes)
        {
            if(minutes < 0) minutes = 0;
            else if(minutes > 59) minutes = 59;
            int hourInMinutes = (hours * 60) + minutes;
            if(hourInMinutes < 120 || hourInMinutes > 4320)
            {
                throw new Exception($"Auction must be between 2 and 72 hours, wanted {hours}:{minutes}.");
            }

            return DateTime.UtcNow.Add(new TimeSpan(hours, minutes, 0)).ToString("yyyy-MM-ddThh:mm:ss.fffZ", CultureInfo.InvariantCulture);
        }

        public static long GetCurrent()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public static int CyclesUntilDividends(long timestamp)
        {
            DateTime nasfaqTimeNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, NasfaqAPI.SERVER_TIMEZONE);
            DateTime nasfaqCycleTime = nasfaqTimeNow.Date.AddDays(-(int)nasfaqTimeNow.Date.DayOfWeek + (int)DayOfWeek.Saturday);
            if (nasfaqTimeNow.CompareTo(nasfaqCycleTime) > 0)
                nasfaqCycleTime = nasfaqCycleTime.AddDays(7);
            return (int)((nasfaqCycleTime - nasfaqTimeNow).TotalSeconds / NasfaqAPI.CYCLE_LENGTH_IN_SECONDS);
        }

        public static int CyclesUntilAdjustement(long timestamp)
        {

            DateTime nasfaqTimeNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, NasfaqAPI.SERVER_TIMEZONE);
            DateTime nasfaqCycleTime = nasfaqTimeNow.Date.AddHours(9).AddMinutes(5);
            if (nasfaqTimeNow.CompareTo(nasfaqCycleTime) > 0)
                nasfaqCycleTime = nasfaqCycleTime.AddDays(1);
            return (int)((nasfaqCycleTime - nasfaqTimeNow).TotalSeconds / NasfaqAPI.CYCLE_LENGTH_IN_SECONDS);
        }
    }
}