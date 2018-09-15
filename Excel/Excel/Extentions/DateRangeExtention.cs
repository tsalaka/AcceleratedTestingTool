using System;
using AcceleratedTool.Excel.Models.CustomTypes;

namespace AcceleratedTool.ExcelDocument.Extentions
{
    public static class DateRangeExtention
    {
        public const string DefaultDateFormat = "M/d/yyyy";
        public const string DefaultDateTimeFormat = "M/d/yyyy H:mm:ss";
        private const char Separator = '-';

        public static string ToDateRangeFormat(this DateRange dateRange, string format = null)
        {
            var startDate = dateRange.StartDate.ToDateFormat(format);
            var endDate = dateRange.EndDate.ToDateFormat(format);
            return string.Format("{0} {2} {1}", startDate, endDate, Separator);
        }

        public static DateRange ToDateRangeFormat(this string dateRange, string format = null)
        {
            var error = string.Format("'{0}' string cannot be converted to DateRange", dateRange);
            var dates = dateRange.Split(Separator);
            if (dates.Length < 2)
                throw new InvalidCastException(error);
            try
            {
                var startDate = dates[0].Trim().ToDateFormat(format);
                var endDate = dates[1].Trim().ToDateFormat(format);

                return new DateRange {StartDate = startDate, EndDate = endDate};
            }
            catch (Exception)
            {
                throw new InvalidCastException(error);
            }
        }
    }
}
