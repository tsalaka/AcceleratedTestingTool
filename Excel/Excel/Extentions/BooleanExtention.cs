using System;

namespace AcceleratedTool.ExcelDocument.Extentions
{
    public static class BooleanExtention
    {
        public static string ToBoolFormat(this bool data)
        {
            return data ? "TRUE" : "FALSE";
        }

        public static bool ToBoolFormat(this string data)
        {
            string error = string.Format("'{0}' data cannot be casted to Bool", data);
            if (string.IsNullOrEmpty(data))
                throw new InvalidCastException(error);
            bool value;
            if (bool.TryParse(data.ToLower(), out value))
                return value;

            throw new InvalidCastException(error);
        }
    }
}