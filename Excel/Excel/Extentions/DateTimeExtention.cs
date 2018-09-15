using System;
using System.Globalization;

namespace AcceleratedTool.ExcelDocument.Extentions
{
    public static class DateTimeExtention
    {
        public const string DefaultDateFormat = "M/d/yyyy";
        public const string DefaultDateTimeFormat = "M/d/yyyy H:mm:ss";

        public static string ToDateFormat(this DateTime date, string format = null)
        {
            return date.ToString(format ?? DefaultDateFormat);
        }

        public static DateTime ToDateFormat(this string date, string format = null)
        {
            try
            {
                DateTime dateTimeValue;
                if (DateTime.TryParseExact(
                    date,
                    format ?? DefaultDateFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dateTimeValue))
                {
                    return dateTimeValue;
                }

                return DateTime.FromOADate(Convert.ToDouble(date));
            }
            catch (Exception)
            {
                throw new InvalidCastException(string.Format("'{0}' string cannot be converted to DateTime", date));
            }
        }
    }
}
