namespace Kronos.AcceleratedTool.License.Subclasses
{
    public interface ILicenseTimeZoneDetector
    {
        string TryToDetectTimeZoneShiftByAbbreviationName(string timeZoneAbbreviation);
    }
}