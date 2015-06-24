using System;

namespace JC.Utils.Extensions
{
    public static class DateTimeExtension
    {
        public static long DateTimeToUnixTimestamp(this DateTime dateTime, bool toMillsecond = false)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64(toMillsecond ? (dateTime - start).TotalMilliseconds : (dateTime - start).TotalSeconds);
        }

        public static DateTime UnixTimestampToDateTime(this DateTime dateTime, long timestamp, bool fromMillsecond = false)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return fromMillsecond ? start.AddMilliseconds(timestamp) : start.AddSeconds(timestamp);
        }
    }
}
