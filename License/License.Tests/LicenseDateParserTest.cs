using System;
using Kronos.AcceleratedTool.License.Exceptions;
using Kronos.AcceleratedTool.License.Subclasses;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.License.Tests
{
    [TestFixture]
    public class LicenseTimeZoneTest
    {
        private readonly ILicenseDateParser _licenseDateParser;

        public LicenseTimeZoneTest()
        {
            _licenseDateParser = new LicenseDateParser();
        }

        [Test]
        public void LicenseHasNoDate()
        {
            string[] emptyStrings = new[] {null, string.Empty, " "};

            foreach (var value in emptyStrings)
            {
                Assert.That(() => _licenseDateParser.GetDateTimeOffsetFromLicenseDateString(value),
                    Throws.TypeOf<LicenseDateCanNotBeNullException>());
            }
        }

        [Test]
        public void EasternDaylightTime()
        {
            DateTimeOffset easternDaylightTime =
                _licenseDateParser.GetDateTimeOffsetFromLicenseDateString("Mon May 01 01:00:00 EDT 2000");
            DateTimeOffset expectedOffsetResult = DateTimeOffset.Parse("5/1/2000 1:00:00 AM -04:00");
            Assert.IsTrue(easternDaylightTime.CompareTo(expectedOffsetResult) == 0);
        }

        [Test]
        public void CentralStandardTime()
        {
            DateTimeOffset centralStandardTime =
                _licenseDateParser.GetDateTimeOffsetFromLicenseDateString("Mon May 01 01:00:00 CST 2000");
            DateTimeOffset expectedOffsetResult = DateTimeOffset.Parse("5/1/2000 1:00:00 AM -06:00");
            Assert.IsTrue(centralStandardTime.CompareTo(expectedOffsetResult) == 0);
        }

        [Test]
        public void AmbiguityForCst()
        {
            DateTimeOffset centralStandardTime =
                _licenseDateParser.GetDateTimeOffsetFromLicenseDateString("Mon May 01 01:00:00 CST 2000");
            DateTimeOffset chinaStandartTime = DateTimeOffset.Parse("5/1/2000 1:00:00 AM +08:00");
            DateTimeOffset cubaStandartTime = DateTimeOffset.Parse("5/1/2000 1:00:00 AM -04:00");
            Assert.IsTrue(centralStandardTime.CompareTo(chinaStandartTime) != 0);
            Assert.IsTrue(centralStandardTime.CompareTo(cubaStandartTime) != 0);
        }
    }
}
