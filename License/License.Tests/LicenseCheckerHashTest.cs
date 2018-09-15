using System.Text;
using Kronos.AcceleratedTool.License.Exceptions;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.License.Tests
{

    [TestFixture]
    public class LicenseCheckerHashTest
    {
        [Test]
        public void ValidLicenseAndValidHash()
        {
            var validHash = "8eb5d4c39bf21f52328d2634f5aa591e0c279f34";
            var validLicense = "kronos\r\n7631539612\r\nThu Apr 20 05:09:36 EDT 2017\r\n";
            Assert.IsTrue(Check(validLicense, validHash));
        }

        [Test]
        public void ValidLicenseAndInvalidHash()
        {
            var anyText = "invalid hash";
            var hashFromOtherLicense = "ae30430ce50464f61304ff595ff06a2be2397c3d";
            var validLicense = "kronos\r\n7631539612\r\nThu Apr 20 05:09:36 EDT 2017\r\n";
            Assert.IsFalse(Check(validLicense, anyText));
            Assert.IsFalse(Check(validLicense, hashFromOtherLicense));
        }

        [Test]
        public void LicenseIsOutdated()
        {
            var validButOutdatedLicense = "outdatedLicense\r\n6773730876\r\nMon May 01 01:00:00 MSD 2000\r\n";
            var validHash = "1b778710e6a437869e2fc8b42ec41d3f27322a84";
            Assert.That(() => Check(validButOutdatedLicense, validHash), Throws.TypeOf<LicenseHasExpiredException>());
        }

        [Test]
        public void NoThirdLineInLicenseFileException()
        {
            var noThirdLineLicense = "kronos\r\n7631539612\r\n";
            var validHash  = "8eb5d4c39bf21f52328d2634f5aa591e0c279f34";
            Assert.That(() => Check(noThirdLineLicense, validHash), Throws.TypeOf<CanNotReadDateFromLicenseFileException>());
        }

        private bool Check(string license, string hash)
        {
            byte[] licenseBytes = Encoding.ASCII.GetBytes(license);
            return new LicenseChecker().IsLicenseValid(licenseBytes, hash);
        }
    }
}
