using System;
using System.Data;
using System.Globalization;

namespace AcceleratedTool.XmlApi.Extentions
{
    public static class DateTimeExtention
    {
        private const string DateFormat = "M/d/yyyy";

        public static string ToApiDateFormat(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString(DateFormat);
            return string.Empty;
        }

        public static string ToApiDateFormat(this DateTime date)
        {
           return date.ToString(DateFormat);
        }

        public static DateTime ToApiDateFormat(this string date)
        {
            DateTime dt;
            if (DateTime.TryParseExact(date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                return dt;
            }

            throw new InvalidCastException(string.Format("'{0}' string cannot be converted to Date", date));
        }

        public static DateTime? ToApiNullableDateFormat(this string date)
        {
            if (string.IsNullOrEmpty(date))
                return null;
            return ToApiDateFormat(date);
        }
    }
}
