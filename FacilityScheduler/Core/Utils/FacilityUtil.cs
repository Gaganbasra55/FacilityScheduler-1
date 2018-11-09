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
    }
}