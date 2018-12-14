using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FacilityScheduler
{
    public class FacilityUtil
    {
        private const string TIME_FORMAT = "HH:mm:ss";
        private const string DATE_FORMAT = "MM/dd/yyyy";
        private const string DATE_FORMAT_CALENDAR = "yyyy-MM-dd";
        public static string ConvertDateTimeToTimeString (DateTime time)
        {
            return time.ToString(TIME_FORMAT);
        }
        public static DateTime ConvertTimeStringToDateTime(string time)
        {
            return DateTime.ParseExact(time, TIME_FORMAT, CultureInfo.InvariantCulture);
        }
        public static string ConvertDateTimeToDateString (DateTime date)
        {
            return date.ToString(DATE_FORMAT);
        }
        public static string ConvertDateTimeToDateStringCalendar (DateTime date)
        {
            return date.ToString(DATE_FORMAT_CALENDAR);
        }
        public static DateTime ConvertDateStringToDateTime(string date)
        {
            return DateTime.ParseExact(date, DATE_FORMAT, CultureInfo.InvariantCulture);
        }
        public static DateTime ConvertDateStringFromCalendarToDateTime(string date)
        {
            return DateTime.ParseExact(date, DATE_FORMAT_CALENDAR, CultureInfo.InvariantCulture);
        }

        public static DateTime ConvertDateTime(string hour, string minutes, string period)
        {
            string iString = "1990-01-01 " + hour + ":" + minutes + " " + period;
            DateTime dateTime = DateTime.ParseExact(iString, "yyyy-MM-dd h:mm tt", null);
            return dateTime;
        }
    }
}