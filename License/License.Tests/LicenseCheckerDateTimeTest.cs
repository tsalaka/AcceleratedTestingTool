using System.Text;
using Kronos.AcceleratedTool.License.Exceptions;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.License.Tests
{
    [TestFixture]
    public class LicenseCheckerDateTimeTest
    {
        private readonly ILicenseChecker _licenseChecker;

        public LicenseCheckerDateTimeTest()
        {
            _licenseChecker = new LicenseChecker();
        }

        [Test]
        public void LicenseHasNoDate()
        {
            var anyHash = "test";
            var licenseHasNoDate = "test\r\ntest\r\n\r\n";
            byte[] licenseBytes = Encoding.ASCII.GetBytes(licenseHasNoDate);
            Assert.That(() => _licenseChecker.IsLicenseValid(licenseBytes, anyHash), Throws.TypeOf<CanNotReadDateFromLicenseFileException>());
        }

        [Test]
        public void LicenseHasDateInWrongFormat()
        {
            var anyHash = "test";
            string[] licenseWithInvalidSectionCount = new[]
            {
                "test\r\ntest\r\n017\r\n",
                "test\r\ntest\r\n05:09:36 EDT 017\r\n",
                "test\r\ntest\r\n20 05:09:36 EDT 017\r\n",
                "test\r\ntest\r\nApr 20 05:09:36 EDT 017 something\r\n"
            };

            foreach (var date in licenseWithInvalidSectionCount)
            {
                byte[] licenseBytes = Encoding.ASCII.GetBytes(date);
                Assert.That(() => _licenseChecker.IsLicenseValid(licenseBytes, anyHash), Throws.TypeOf<LicenseDateStringInvalidFormatException>());
            }
        }

        [Test]
        public void CheckThatLicenseDateIsParsedCorrectlyEvenWhenTimezoneAbbreviationIsNotFound()
        {
            var anyHash = "test";
            string[] licenseWithInvalidSectionCount = new[]
            {
                "test\r\ntest\r\nMon May 01 01:00:00 EDT 2000\r\n",
                "test\r\ntest\r\nMon May 01 01:00:00 UNKNOWN_TIMEZONE_ABBREVIATION 2000\r\n"
            };

            foreach (var date in licenseWithInvalidSectionCount)
            {
                byte[] licenseBytes = Encoding.ASCII.GetBytes(date);
                Assert.DoesNotThrow(() => _licenseChecker.IsLicenseValid(licenseBytes, anyHash));
            }
        }
    }
}
