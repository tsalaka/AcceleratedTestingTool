using System;
using AcceleratedTool.Excel.Models.Attributes;
using AcceleratedTool.Excel.Models.CustomTypes;
using AcceleratedTool.ExcelDocument.Extentions;

namespace AcceleratedTool.ExcelDocument
{
    public class ExcelDataFormatConvertor : IExcelDataFormatConvertor
    {
        public string GetFormatByFormatType(ExcelColumnFormat type)
        {
            switch (type)
            {
                case ExcelColumnFormat.Date:
                    return DateTimeExtention.DefaultDateFormat;
                case ExcelColumnFormat.DateTime:
                    return DateTimeExtention.DefaultDateTimeFormat;
                case ExcelColumnFormat.Hours12Time:
                    return TimeSpanExtention.Time12HourFormat;
                case ExcelColumnFormat.Hours24Time:
                     return TimeSpanExtention.DefaultTime24HourFormat;
            }

            return null;
        }

        public string ConvertValueToString(object value, string format = null)
        {
            string stringValue = string.Empty;
            if (value != null)
            {
                var type = value.GetType();
                if (type == typeof(DateTime) || type == typeof(DateTime?))
                {
                    stringValue = (value as DateTime?).Value.ToDateFormat(format);
                }
                else if (type == typeof(DateRange))
                {
                    stringValue = (value as DateRange).ToDateRangeFormat(format);
                }
                else if (type == typeof(TimeSpan) || type == typeof(TimeSpan?))
                {
                    stringValue = (value as TimeSpan?).Value.ToTimeFormat(format);
                }
                else if (type == typeof(bool) || type == typeof(bool?))
                {
                    stringValue = (value as bool?).Value.ToBoolFormat();
                }
                else if (type == typeof(decimal) || type == typeof(decimal?))
                {
                    stringValue = ((decimal)value).ToString("G29");
                }
                else
                {
                    stringValue = value.ToString();
                }
            }

            return stringValue;
        }

        public object ConvertStringToValue(string value, Type type, ExcelColumnFormat format = ExcelColumnFormat.None)
        {
            var stringFormat = GetFormatByFormatType(format);
            object propertyValue = null;
            if (!string.IsNullOrEmpty(value))
            {
                if (type == typeof(DateTime) || type == typeof(DateTime?))
                {
                    propertyValue = value.ToDateFormat(stringFormat);
                }
                else if (type == typeof(DateRange))
                {
                    propertyValue = value.ToDateRangeFormat(stringFormat);
                }
                else if (type == typeof(TimeSpan) || type == typeof(TimeSpan?))
                {
                    propertyValue = value.ToTimeFormat(stringFormat);
                }
                else if (type == typeof(bool) || type == typeof(bool?))
                {
                    propertyValue = value.ToBoolFormat();
                }
                else if (type == typeof(decimal) || type == typeof(decimal?))
                {
                    decimal decimalValue;
                    if (decimal.TryParse(value, out decimalValue))
                        propertyValue = decimalValue;
                }
                else if (type == typeof(double) || type == typeof(double?))
                {
                    double doubleValue;
                    if (double.TryParse(value, out doubleValue))
                        propertyValue = doubleValue;
                }
                else
                {
                    propertyValue = value;
                }
            }

            return propertyValue;
        }
    }
}
