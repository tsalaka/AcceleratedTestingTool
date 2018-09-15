using System;
using System.Configuration;
using System.IO;
using Kronos.AcceleratedTool.License;
using Kronos.AcceleratedTool.UI.Resources;

namespace Kronos.AcceleratedTool.UI.Validation
{
    using System.Linq;

    public class UiValidator : IUiValidator
    {
        private const char MaskSymbol = '/';
        private static readonly DateTime MinStartDate;

        private readonly ILicenseChecker _licenseChecker;

        static UiValidator()
        {
            MinStartDate = new DateTime(1900, 1, 1);
        }

        public UiValidator(ILicenseChecker licenseChecker)
        {
            _licenseChecker = licenseChecker;
        }

        public bool IsLicenseValid(string license)
        {
            string filePath = Path.Combine(ConfigurationManager.AppSettings["OutputDirectory"], ConfigurationManager.AppSettings["RelativeLicenseFilePath"]);
            bool licenseIsValid;

            try
            {
                licenseIsValid = _licenseChecker.IsLicenseValid(File.ReadAllBytes(filePath), license);
            }
            catch (DirectoryNotFoundException ex)
            {
                var physicalPath = GetPhysicalPathFromExceptionMessage(ex.Message) ?? filePath;
                throw new DirectoryNotFoundException(string.Format(ToolUI.LicenseIsNotFoundAt, physicalPath));
            }
            catch (FileNotFoundException ex)
            {
                var physicalPath = GetPhysicalPathFromExceptionMessage(ex.Message) ?? filePath;
                throw new DirectoryNotFoundException(string.Format(ToolUI.LicenseIsNotFoundAt, physicalPath));
            }

            return licenseIsValid;
        }

        public bool IsLoginValid(string userName, string password)
        {
            return !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);
        }

        public ValidatorState IsMaskedTextBoxDateStringValid(string dateString)
        {
            if (dateString.Count(f => f == MaskSymbol) != 2)
            {
                throw new Exceptions.DateStringMustBeInPredefinedFormat("String mask is supposed to be 'M/d/yyyy'");
            }

            var valuesArray = dateString.Split(MaskSymbol);
            int year, month, day;
            if (!int.TryParse(valuesArray[2], out year) || !int.TryParse(valuesArray[0], out month) || !int.TryParse(valuesArray[1], out day))
            {
                return ValidatorState.CanNotBeParsed;
            }

            try
            {
                var dateTime = new DateTime(year, month, day);
                if (dateTime.CompareTo(MinStartDate) <= 0)
                {
                    return ValidatorState.LessThanMinimumValue;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return ValidatorState.CanNotBeParsed;
            }

            return ValidatorState.FieldIsValid;
        }

        public bool IsUrlValid(string url)
        {
            return !string.IsNullOrEmpty(url);
        }

        private string GetPhysicalPathFromExceptionMessage(string message)
        {
            var pathRegex = new System.Text.RegularExpressions.Regex(@"[^']+");
            var pathMatch = pathRegex.Matches(message)[1];
            return pathMatch.Length > 1 ? pathMatch.Value : null;
        }
    }
}