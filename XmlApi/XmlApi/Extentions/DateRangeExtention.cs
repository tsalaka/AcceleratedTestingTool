using System;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Extentions
{
    public static class DateRange
    {
        private const string DateRangePattern = "{0}-{1}";
        public static string ToDateRangeDate(DateTime dateFrom, DateTime dateTo)
        {
            return string.Format(DateRangePattern, dateFrom.ToApiDateFormat(), dateTo.ToApiDateFormat());
        }

        public static Tuple<DateTime, DateTime> ToDates(this string dateRange)
        {
            if (string.IsNullOrEmpty(dateRange))
                throw new InvalidCastException(string.Format("'{0}' can't be parsed to dates", dateRange));

            var dateStrings = dateRange.Split('-');
            if (dateStrings.Length != 2)
                throw new InvalidCastException(string.Format("'{0}' can't be parsed to dates", dateRange));

            try
            {
                var startDate = dateStrings[0].Trim().ToApiDateFormat();
                var endDate = dateStrings[1].Trim().ToApiDateFormat();

                return new Tuple<DateTime, DateTime>(startDate, endDate);
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(string.Format("'{0}' can't be parsed to dates", dateRange));
            }
        }
    }
}
