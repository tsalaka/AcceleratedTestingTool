using System;

namespace Kronos.AcceleratedTool.License.Subclasses
{
    public interface ILicenseDateParser
    {
        DateTimeOffset GetDateTimeOffsetFromLicenseDateString(string licenseDateString);
    }
}