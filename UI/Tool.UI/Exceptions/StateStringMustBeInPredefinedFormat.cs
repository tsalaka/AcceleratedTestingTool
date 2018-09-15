using System;

namespace Kronos.AcceleratedTool.UI.Exceptions
{
    public class DateStringMustBeInPredefinedFormat : Exception
    {
        public DateStringMustBeInPredefinedFormat(string message)
            : base(message)
        {
        }
    }
}
