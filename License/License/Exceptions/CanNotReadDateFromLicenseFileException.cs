using System;

namespace Kronos.AcceleratedTool.License.Exceptions
{
    public class CanNotReadDateFromLicenseFileException : Exception
    {
        public CanNotReadDateFromLicenseFileException(int licenseDateIsAtLine) : 
            base(string.Format("Can not read date from license file line number {0}.", licenseDateIsAtLine))
        {
        }
    }
}
