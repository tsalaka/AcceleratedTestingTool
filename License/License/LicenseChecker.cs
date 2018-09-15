using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Kronos.AcceleratedTool.License.Exceptions;
using Kronos.AcceleratedTool.License.Subclasses;

namespace Kronos.AcceleratedTool.License
{
    public class LicenseChecker : ILicenseChecker
    {
        private const int BytesCountForHashGeneration = 1024;
        private const int LicenseDateIsAtLine = 3;
        private const string HexFormat = "X";
        private readonly ILicenseDateParser _licenseDateParser;

        public LicenseChecker()
        {
            _licenseDateParser = new LicenseDateParser();
        }

        public LicenseChecker(ILicenseDateParser licenseDateParser)
        {
            _licenseDateParser = licenseDateParser;
        }

        public bool IsLicenseValid(byte[] licenseBytes, string licenseHash)
        {
            var isLicenseHashValid = LicenseHashVerification(licenseBytes, licenseHash);
            DateTimeOffset dateFromLicenseFile = GetLicenseDate(licenseBytes);
            bool licenseIsOutdated = dateFromLicenseFile.CompareTo(DateTimeOffset.Now) < 0;

            if (isLicenseHashValid && licenseIsOutdated)
            {
                throw new LicenseHasExpiredException();
            }

            return isLicenseHashValid;
        }

        private bool LicenseHashVerification(byte[] licenseBytes, string inputHash)
        {
            var lcnsDtRslt = GenerateLicenseHash(licenseBytes);
            return string.Compare(inputHash, lcnsDtRslt, StringComparison.OrdinalIgnoreCase) == 0;
        }

        private DateTimeOffset GetLicenseDate(byte[] licenseBytes)
        {
            string license = Encoding.UTF8.GetString(licenseBytes);
            string licenseDateString = license.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ElementAtOrDefault(LicenseDateIsAtLine-1);

            if (string.IsNullOrWhiteSpace(licenseDateString))
            {
                throw new CanNotReadDateFromLicenseFileException(LicenseDateIsAtLine);
            } 

            return _licenseDateParser.GetDateTimeOffsetFromLicenseDateString(licenseDateString);
        }

        private string GenerateLicenseHash(byte[] bytes)
        {
            var firstBytes = bytes.Take(BytesCountForHashGeneration).ToArray();
            var shaGenerator = SHA1.Create();
            var digestBytes = shaGenerator.ComputeHash(firstBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < digestBytes.Length; i++)
            {
                sb.Append(((digestBytes[i] & 0xff) + 0x100).ToString(HexFormat).Substring(1));
            }

            return sb.ToString();
        }
    }
}
