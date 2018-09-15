using System;
using System.Globalization;
using System.Linq;
using Kronos.AcceleratedTool.License.Exceptions;

namespace Kronos.AcceleratedTool.License.Subclasses
{
    public class LicenseDateParser : ILicenseDateParser
    {
        private const int TimeZoneSubstringIndex = 4;
        private const int DateTimeSectionsCount = 6;
        private const char Delimiter = ' ';
        private const string DateFormat = "ddd MMM d HH:mm:ss yyyy";
        private const string ExactDateFormat = "ddd MMM d HH:mm:ss zzz yyyy";
        private readonly ILicenseTimeZoneDetector _licenseTimeZoneDetector;

        public LicenseDateParser()
        {
            _licenseTimeZoneDetector = new LicenseTimeZoneDetector();
        }

        public LicenseDateParser(ILicenseTimeZoneDetector licenseTimeZoneDetector)
        {
            _licenseTimeZoneDetector = licenseTimeZoneDetector;
        }

        public DateTimeOffset GetDateTimeOffsetFromLicenseDateString(string licenseDateString)
        {
            if (string.IsNullOrWhiteSpace(licenseDateString))
            {
                throw new LicenseDateCanNotBeNullException();
            }

            var list = licenseDateString.Split(Delimiter).ToList();

            if (list.Count != DateTimeSectionsCount)
            {
                throw new LicenseDateStringInvalidFormatException(ExactDateFormat);
            }

            var timeZone = _licenseTimeZoneDetector.TryToDetectTimeZoneShiftByAbbreviationName(list[TimeZoneSubstringIndex]);
            if (timeZone == null)
            {
                list.RemoveAt(TimeZoneSubstringIndex);
            }
            else
            {
                list[TimeZoneSubstringIndex] = timeZone;
            }

            try
            {
                string dateString = string.Join(Delimiter.ToString(), list.ToArray());
                var dateFormat = timeZone == null ? DateFormat : ExactDateFormat;
                return DateTimeOffset.ParseExact(dateString, dateFormat, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                throw new LicenseDateStringInvalidFormatException(ExactDateFormat);
            }
        }
    }
}
