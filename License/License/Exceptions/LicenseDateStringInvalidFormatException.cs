using System;

namespace Kronos.AcceleratedTool.License.Exceptions
{
    public class LicenseDateStringInvalidFormatException : Exception
    {
        public LicenseDateStringInvalidFormatException(string exactDateFormat) : 
            base(string.Format("Invalid license date format.", exactDateFormat))
        {
        }
    }
}
