using System;

namespace Kronos.AcceleratedTool.License.Exceptions
{
    public class LicenseHasExpiredException : Exception
    {
        public LicenseHasExpiredException() : 
            base("License has expired.")
        {
        }
    }
}
