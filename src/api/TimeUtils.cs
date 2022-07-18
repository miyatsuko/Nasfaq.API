using System;
using System.Globalization;

namespace Nasfaq.API
{
    public static class TimeUtils
    {
        public const long WEEK = 7*24*60*60*1000;
        public const long DAY = 24*60*60*1000;
        public const long HOUR = 60*60*1000;
        public const long MINUTE = 60*1000;

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

        public static long ZuluToUnix(string fundTimestamp)
        {
            return ((DateTimeOffset) DateTime.Parse(fundTimestamp, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal)).ToUnixTimeMilliseconds();
        }

        public static long GetCurrent()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public static DateTime GetCurrentServerTime()
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, NasfaqAPI.SERVER_TIMEZONE);
        }

        public static int CyclesUntilDividends(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            DateTime nasfaqTimeNow = TimestampToDateTimeInTimezone(timestamp, NasfaqAPI.SERVER_TIMEZONE);
            DateTime nasfaqCycleTime = nasfaqTimeNow.Date.AddDays(-(int)nasfaqTimeNow.Date.DayOfWeek + (int)DayOfWeek.Saturday);
            if (nasfaqTimeNow.CompareTo(nasfaqCycleTime) > 0)
                nasfaqCycleTime = nasfaqCycleTime.AddDays(7);
            return (int)((nasfaqCycleTime - nasfaqTimeNow).TotalSeconds / NasfaqAPI.CYCLE_LENGTH_IN_SECONDS);
        }

        public static long GetNextDividendsTimestamp(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            DateTime nasfaqTimeNow = TimestampToDateTimeInTimezone(timestamp, NasfaqAPI.SERVER_TIMEZONE);
            DateTime nasfaqDividendTime = nasfaqTimeNow.Date.AddDays(-(int)nasfaqTimeNow.Date.DayOfWeek + (int)DayOfWeek.Saturday);
            if (nasfaqTimeNow.CompareTo(nasfaqDividendTime) > 0)
                nasfaqDividendTime = nasfaqDividendTime.AddDays(7);
            return DateTimeWithTimezoneToTimestamp(nasfaqDividendTime, NasfaqAPI.SERVER_TIMEZONE);
        }

        public static long GetLastDividendsTimestamp(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            return GetNextDividendsTimestamp(timestamp - WEEK);
        }

        public static int CyclesUntilAdjustement(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            DateTime nasfaqTimeNow = TimestampToDateTimeInTimezone(timestamp, NasfaqAPI.SERVER_TIMEZONE);
            DateTime nasfaqCycleTime = nasfaqTimeNow.Date.AddHours(9).AddMinutes(5);
            if (nasfaqTimeNow.CompareTo(nasfaqCycleTime) > 0)
                nasfaqCycleTime = nasfaqCycleTime.AddDays(1);
            return (int)((nasfaqCycleTime - nasfaqTimeNow).TotalSeconds / NasfaqAPI.CYCLE_LENGTH_IN_SECONDS);
        }

        public static long GetNextAdjustmentTimestamp(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            DateTime nasfaqTimeNow = TimestampToDateTimeInTimezone(timestamp, NasfaqAPI.SERVER_TIMEZONE);
            DateTime nasfaqCycleTime = nasfaqTimeNow.Date.AddHours(9).AddMinutes(5);
            if (nasfaqTimeNow.CompareTo(nasfaqCycleTime) > 0)
                nasfaqCycleTime = nasfaqCycleTime.AddDays(1);
            return DateTimeWithTimezoneToTimestamp(nasfaqCycleTime, NasfaqAPI.SERVER_TIMEZONE);
        }

        public static long GetLastAdjustmentTimestamp(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            return GetLastAdjustmentTimestamp(timestamp - DAY);
        }

        public static long GetNextSharesClosingTimestamp(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            DateTime nasfaqTimeNow = TimestampToDateTimeInTimezone(timestamp, NasfaqAPI.SERVER_TIMEZONE);
            DateTime nasfaqCycleTime = nasfaqTimeNow.Date.AddHours(16);
            if (nasfaqTimeNow.CompareTo(nasfaqCycleTime) > 0)
                nasfaqCycleTime = nasfaqCycleTime.AddDays(1);
            return DateTimeWithTimezoneToTimestamp(nasfaqCycleTime, NasfaqAPI.SERVER_TIMEZONE);
        }

        public static long GetNextSharesProcessingTimestamp(long timestamp = 0L)
        {
            if(timestamp == 0L) timestamp = GetCurrent();
            DateTime nasfaqTimeNow = TimestampToDateTimeInTimezone(timestamp, NasfaqAPI.SERVER_TIMEZONE);;
            DateTime nasfaqCycleTime = nasfaqTimeNow.Date.AddHours(16).AddMinutes(2);
            if (nasfaqTimeNow.CompareTo(nasfaqCycleTime) > 0)
                nasfaqCycleTime = nasfaqCycleTime.AddDays(1);
            return DateTimeWithTimezoneToTimestamp(nasfaqCycleTime, NasfaqAPI.SERVER_TIMEZONE);
        }

        public static DateTime TimestampToDateTime(long timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(timestamp);
            return dateTime;
        }

        public static DateTime TimestampToDateTimeInTimezone(long timestamp, string timezone)
        {
            return TimeZoneInfo.ConvertTime(TimestampToDateTime(timestamp), TimeZoneInfo.FindSystemTimeZoneById(timezone));
        }

        public static long DateTimeToTimestamp(DateTime time)
        {
            return ((DateTimeOffset)time).ToUnixTimeMilliseconds();
        }

        public static long DateTimeWithTimezoneToTimestamp(DateTime time, string timezone)
        {
            return ((DateTimeOffset)TimeZoneInfo.ConvertTimeToUtc(time, TimeZoneInfo.FindSystemTimeZoneById(NasfaqAPI.SERVER_TIMEZONE))).ToUnixTimeMilliseconds();
        }
    }
}