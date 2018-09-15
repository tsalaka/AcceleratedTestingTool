using System;

namespace Kronos.AcceleratedTool.License.Exceptions
{
    public class LicenseDateCanNotBeNullException : Exception
    {
        public LicenseDateCanNotBeNullException() : base("License date can not be null.")
        {
        }
    }
}
