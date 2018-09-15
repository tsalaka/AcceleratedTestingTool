using System;
using System.Globalization;

namespace AcceleratedTool.XmlApi.Extentions
{
    public static class TimeSpanExtention
    {
        private const string Time12HourFormat = "h:mmtt";
        private const string Time24HourFormat = "H:mm";

        public static string ToApiTimeFormat(this TimeSpan? time, string timeFormat)
        {
            if (time.HasValue)
                return ToApiTimeFormat(time.Value, timeFormat);
            return string.Empty;
        }

        public static string ToApiTimeFormat(this TimeSpan time, string timeFormat)
        {
            if (string.IsNullOrEmpty(timeFormat))
                throw new ArgumentNullException(nameof(timeFormat));

            return DateTime.Today.Add(time).ToString(timeFormat);
        }

        public static TimeSpan ToApiTimeFormat(this string time, string timeFormat)
        {
            if (string.IsNullOrEmpty(timeFormat))
                throw new ArgumentNullException(nameof(timeFormat));

            // fix for invalid .net time which can retireved from Xml Api
            TimeSpan timeSpan;
            if (TryParseMidNightTime(time, out timeSpan))
                return timeSpan;

            DateTime dt;
            if (DateTime.TryParseExact(time,
                timeFormat,
                CultureInfo.InvariantCulture,
                 DateTimeStyles.None,
                out dt))
            {
                return dt.TimeOfDay;
            }

            throw new InvalidCastException(string.Format("'{0}' string cannot be converted to TimeSpan", time));
        }

        public static string ToApi12HourTimeFormat(this TimeSpan? time)
        {
            return ToApiTimeFormat(time, Time12HourFormat);
        }

        public static string ToApi12HourTimeFormat(this TimeSpan time)
        {
            return ToApiTimeFormat(time, Time12HourFormat);
        }

        public static TimeSpan ToApi12HourTimeFormat(this string time)
        {
            return ToApiTimeFormat(time, Time12HourFormat);
        }

        public static TimeSpan? ToApi12HourNullableTimeFormat(this string time)
        {
            if (string.IsNullOrEmpty(time))
                return null;

            return ToApiTimeFormat(time, Time12HourFormat);
        }

        public static string ToApi24HourTimeFormat(this TimeSpan? time)
        {
            if (time?.TotalDays < 1)
                return ToApiTimeFormat(time, Time24HourFormat);

            throw new InvalidCastException(string.Format("'{0}' cannot be converted to {1} format", time, Time24HourFormat));
        }

        public static string ToApi24HourTimeFormat(this TimeSpan time)
        {
            if (time.TotalDays < 1)
                return ToApiTimeFormat(time, Time24HourFormat);

            throw new InvalidCastException(string.Format("'{0}' cannot be converted to {1} format", time, Time24HourFormat));
        }

        public static TimeSpan ToApi24HourTimeFormat(this string time)
        {
            try
            {
                return ToApiTimeFormat(time, Time24HourFormat);
            }
            catch (InvalidCastException)
            {
                var parts = time.Split(':');
                if (parts.Length == 2)
                {
                    return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
                }

                throw;
            }
        }

        public static TimeSpan? ToApi24HourNullableTimeFormat(this string time)
        {
            if (string.IsNullOrEmpty(time))
                return null;

            return ToApiTimeFormat(time, Time24HourFormat);
        }

        private static bool TryParseMidNightTime(string time, out TimeSpan timeSpan)
        {
            if (time == "24:00")
            {
                timeSpan = new TimeSpan(1, 0, 0, 0);
                return true;
            }

            timeSpan = default(TimeSpan);
            return false;
        }
    }
}
