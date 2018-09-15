using System;

namespace AcceleratedTool.XmlApi.Extentions
{
    public static class BooleanExtention
    {
        public static string ToApiBoolFormat(this bool? data)
        {
            if (data.HasValue)
                return ToApiBoolFormat(data.Value);
            return string.Empty;
        }

        public static string ToApiBoolFormat(this bool data)
        {
            return data.ToString().ToLower();
        }

        public static bool? ToApiNullableBoolFormat(this string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;
          return ToApiBoolFormat(data);
        }

        public static bool ToApiBoolFormat(this string data)
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
