using System;
using System.Linq;
using Kronos.AcceleratedTool.UI.Exceptions;
using Kronos.AcceleratedTool.UI.Validation;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Tool.UI.Tests
{
    [TestFixture]
    public class UiValidatorStartDateTest
    {
        private readonly UiValidator _uiValidator;
        private readonly string[] _lessThanMinimuValue;
        private readonly string[] _invalidCharacters;
        private readonly string[] _thereAreSkippedNumbers;
        private readonly string[] _isValidDateAndMoreThanMinimum;
        private readonly string[] _isValidDateAndLessOrEqualToMinimum;
        private readonly string[] _outOfDayOrMonthRange;
        private readonly string[] _yearIsSplittedInTwoParts;
        private readonly string[] _dateOfInvalidFormat;
        private const string ExpectedMask = "00/00/0000";
        private const string Mask = "MM/dd/yyyy";

        private readonly DateTime _minimumDate = new DateTime(1900, 1, 1);

        public UiValidatorStartDateTest()
        {
            _uiValidator = new UiValidator(null);
            _lessThanMinimuValue = new string[] { "1 /1 /   1", "1 / 1/   1", " 1/ 1/   1", " 1/ 1/  1 " };
            _invalidCharacters = new string[] { "1*/1 /   1", "1 /*1/   1", " 1/ 1/ * 1", "*1/!1/ *1 " };
            _thereAreSkippedNumbers = new string[] { "  /1 /   1", "1 /  /   1", " 1/ 1/    ", "  /  /  1 ", "  /  /    " };
            _isValidDateAndMoreThanMinimum = new string[] { _minimumDate.AddDays(1).ToString(Mask), " 1/1 /2000", "1 / 1/2000", " 1/ 1/2000", "1 /1 /9999" };
            _isValidDateAndLessOrEqualToMinimum = new string[] { _minimumDate.ToString(Mask), " 1/1 / 11 ", "1 / 1/1800", " 1/ 1/0001", "1 /1 /100 " };
            _outOfDayOrMonthRange = new string[] { "-1/1 /1940", "99/ 1/0001", " 1/99/ 11 ", "99/99/2000" };
            _yearIsSplittedInTwoParts = new string[] { " 1/1 /9 40", " 1/1 /1 01", " 1/1 /1  1" };
            _dateOfInvalidFormat = new string[] { "01/1900", "anyText", "///" };
        }

        [Test]
        public void AreTestStringsValid()
        {
            var allTestStrings =
                this._lessThanMinimuValue
                    .Concat(_lessThanMinimuValue)
                    .Concat(_invalidCharacters)
                    .Concat(_thereAreSkippedNumbers)
                    .Concat(_isValidDateAndMoreThanMinimum)
                    .Concat(_isValidDateAndLessOrEqualToMinimum)
                    .Concat(_outOfDayOrMonthRange)
                    .Concat(_yearIsSplittedInTwoParts).ToArray();

            foreach (var maskedTextBoxDateTimeString in allTestStrings)
            {
                Assert.AreEqual(maskedTextBoxDateTimeString.Split('/').Length, 3);
                Assert.AreEqual(maskedTextBoxDateTimeString.Length, ExpectedMask.Length);
            }
        }

        [Test]
        public void LessThanMinimuValue()
        {
            Check(this._lessThanMinimuValue, ValidatorState.LessThanMinimumValue);
        }

        [Test]
        public void InvalidCharacters()
        {
            Check(this._invalidCharacters, ValidatorState.CanNotBeParsed);
        }

        [Test]
        public void ThereAreSkippedNumbers()
        {
            Check(this._thereAreSkippedNumbers, ValidatorState.CanNotBeParsed);
        }

        [Test]
        public void IsValidDateAndMoreThanMinimum()
        {
            Check(this._isValidDateAndMoreThanMinimum, ValidatorState.FieldIsValid);
        }

        [Test]
        public void IsValidDateAndLessOrEqualToMinimum()
        {
            Check(this._isValidDateAndLessOrEqualToMinimum, ValidatorState.LessThanMinimumValue);
        }

        [Test]
        public void OutOfDayOrMonthRange()
        {
            Check(this._outOfDayOrMonthRange, ValidatorState.CanNotBeParsed);
        }

        [Test]
        public void YearIsSplittedInTwoParts()
        {
            Check(this._yearIsSplittedInTwoParts, ValidatorState.CanNotBeParsed);
        }

        [Test]
        public void DateStringMustBeInPredefinedFormat()
        {
            foreach (var dateOfInvalidFormat in _dateOfInvalidFormat)
            {
                Assert.That(() => this._uiValidator.IsMaskedTextBoxDateStringValid(dateOfInvalidFormat),
                    Throws.TypeOf<DateStringMustBeInPredefinedFormat>());
            }
        }

        private void Check(string[] testStartDates, ValidatorState validatorState)
        {
            foreach (var maskedTextBoxDateTimeString in testStartDates)
            {
                var value = this._uiValidator.IsMaskedTextBoxDateStringValid(maskedTextBoxDateTimeString);
                Assert.AreEqual(value, validatorState);
            }
        }
    }
}
