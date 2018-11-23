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
        public static string ConvertDateTimeToTimeString (DateTime time)
        {
            return time.ToString(TIME_FORMAT);
        }
        public static DateTime ConvertTimeStringToDateTime(string time)
        {
            return DateTime.ParseExact(time, TIME_FORMAT, CultureInfo.InvariantCulture);
        }

        public static DateTime ConvertDateTime(string hour, string minutes, string period)
        {
            string iString = "1990-01-01 " + hour + ":" + minutes + " " + period;
            DateTime dateTime = DateTime.ParseExact(iString, "yyyy-MM-dd h:mm tt", null);
            return dateTime;
        }
    }
}