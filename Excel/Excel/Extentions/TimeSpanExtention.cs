using System;
using System.Globalization;

namespace AcceleratedTool.ExcelDocument.Extentions
{
    public static class TimeSpanExtention
    {
        public const string DefaultTime24HourFormat = "H:mm";
        public const string Time12HourFormat = "h:mmtt";

        public static string ToTimeFormat(this TimeSpan time, string format = null)
        {
            if (time.TotalDays < 1)
                return DateTime.Today.Add(time).ToString(format ?? DefaultTime24HourFormat);

            if (format != null)
                throw new InvalidCastException(string.Format("'{0}' cannot be converted to {1} format", time, format));

            return string.Format("{0}:{1}", time.Days * 24 + time.Hours, time.ToString("mm"));
        }

        public static TimeSpan ToTimeFormat(this string time, string format = null)
        {
            try
            {
                // fix for invalid .net time which can retireved from Xml Api
                TimeSpan timeSpan;
                if (TryParseMidNightTime(time, out timeSpan))
                    return timeSpan;

                DateTime dt;
                if (DateTime.TryParseExact(time,
                    format ?? DefaultTime24HourFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dt))
                {
                    return dt.TimeOfDay;
                }

                var parts = time.Split(':');
                if (parts.Length == 2)
                {
                    return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
                }

                double aoDate;
                if (double.TryParse(time, out aoDate))
                {
                    return DateTime.FromOADate(aoDate).TimeOfDay;
                }

                throw new InvalidCastException();
            }
            catch (Exception)
            {
                throw new InvalidCastException(string.Format("'{0}' string cannot be converted to TimeSpan", time));
            }
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
