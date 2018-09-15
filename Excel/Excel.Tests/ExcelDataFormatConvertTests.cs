using System;
using System.Collections.Generic;
using AcceleratedTool.Excel.Models;
using AcceleratedTool.Excel.Models.Attributes;
using AcceleratedTool.Excel.Models.CustomTypes;
using NUnit.Framework;

namespace AcceleratedTool.ExcelDocument.Tests
{
    [TestFixture]
    public class ExcelDataFormatConvertTests
    {
        [Test]
        public void TestThatFormatByTypeIsReturnedCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            Assert.AreEqual("M/d/yyyy H:mm:ss", convertor.GetFormatByFormatType(ExcelColumnFormat.DateTime));
            Assert.AreEqual("M/d/yyyy", convertor.GetFormatByFormatType(ExcelColumnFormat.Date));
            Assert.AreEqual("h:mmtt", convertor.GetFormatByFormatType(ExcelColumnFormat.Hours12Time));
            Assert.AreEqual("H:mm", convertor.GetFormatByFormatType(ExcelColumnFormat.Hours24Time));
        }

        [Test]
        public void TestThatNullValueConvertToStringValueCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            Assert.AreEqual(string.Empty, convertor.ConvertValueToString(null, "MM/d/yyyy"));
            Assert.AreEqual(string.Empty, convertor.ConvertValueToString(null, "H:mm"));
        }

        [Test]
        public void TestThatDifferentTypesConvertToStringValuesCorrectly()
        {
            var persons = new List<Employee>();
            persons.Add(new Employee
            {
                PersonNumber = "PersonNumber",
                AccrualProfileName = "AccrualProfileName",
                BirthDate = new DateTime(1981, 11, 1),
                BaseWageHourly = (decimal)15.5,
                ProfessionalWorkRuleName = "ProfessionalWorkRuleName",
                TransferEmployeeFlag = true,
                FirstName = "FirstName1",
                LastName = "LastName1"
            });

            persons.Add(new Employee
            {
                PersonNumber = "PersonNumber2",
                AccrualProfileName = "AccrualProfileName2",
                BirthDate = new DateTime(1991, 12, 6),
                BaseWageHourly = (decimal)10.5,
                HireDate = new DateTime(2017, 1, 1),
                ProfessionalWorkRuleName = "ProfessionalWorkRuleName2",
                FirstName = "FirstName2",
                LastName = "LastName2"
            });

            var convertor = new ExcelDataFormatConvertor();

            Assert.AreEqual("PersonNumber", convertor.ConvertValueToString(persons[0].PersonNumber));
            Assert.AreEqual("AccrualProfileName", convertor.ConvertValueToString(persons[0].AccrualProfileName));
            Assert.AreEqual("11/1/1981", convertor.ConvertValueToString(persons[0].BirthDate));
            Assert.AreEqual("15.5", convertor.ConvertValueToString(persons[0].BaseWageHourly));
            Assert.AreEqual("ProfessionalWorkRuleName", convertor.ConvertValueToString(persons[0].ProfessionalWorkRuleName));
            Assert.AreEqual("TRUE", convertor.ConvertValueToString(persons[0].TransferEmployeeFlag));

            Assert.AreEqual("PersonNumber2", convertor.ConvertValueToString(persons[1].PersonNumber));
            Assert.AreEqual("AccrualProfileName2", convertor.ConvertValueToString(persons[1].AccrualProfileName));
            Assert.AreEqual("12/6/1991", convertor.ConvertValueToString(persons[1].BirthDate));
            Assert.AreEqual("10.5", convertor.ConvertValueToString(persons[1].BaseWageHourly));
            Assert.AreEqual("1/1/2017", convertor.ConvertValueToString(persons[1].HireDate));
            Assert.AreEqual("ProfessionalWorkRuleName2", convertor.ConvertValueToString(persons[1].ProfessionalWorkRuleName));
            Assert.AreEqual(string.Empty, convertor.ConvertValueToString(persons[1].TransferEmployeeFlag));
        }

        [Test]
        public void TestThatDateConvertToStringCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();

            Assert.AreEqual("24/10/2017", convertor.ConvertValueToString(new DateTime(2017, 10, 24), "dd/MM/yyyy"));
            Assert.AreEqual("10/2/2017", convertor.ConvertValueToString(new DateTime(2017, 10, 2, 14, 41, 10), "MM/d/yyyy"));
            Assert.AreEqual("8/2/2017 14:41:10", convertor.ConvertValueToString(new DateTime(2017, 8, 2, 14, 41, 10), "M/d/yyyy H:mm:ss"));
        }

        [Test]
        public void TestThatDateConvertToDefaultFormatCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();

            Assert.AreEqual("10/2/2017", convertor.ConvertValueToString(new DateTime(2017, 10, 2, 14, 41, 10)));
        }

        [Test]
        public void TestThatTimeConvertToStringCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();

            Assert.AreEqual("16:30", convertor.ConvertValueToString(new TimeSpan(16, 30, 45), "H:mm"));
            Assert.AreEqual("4:30PM", convertor.ConvertValueToString(new TimeSpan(16, 30, 45), "h:mmtt"));
        }

        [Test]
        public void TestThatTimeConvertToDefaultFormatCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            Assert.AreEqual("16:30", convertor.ConvertValueToString(new TimeSpan(16, 30, 45)));
        }

        [Test]
        public void TestThatDateStringConvertToDateCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();

            Assert.AreEqual(new DateTime(2017, 10, 24), convertor.ConvertStringToValue("10/24/2017", typeof(DateTime), ExcelColumnFormat.Date));
            Assert.AreEqual(new DateTime(2017, 10, 2),
                convertor.ConvertStringToValue("10/2/2017", typeof(DateTime), ExcelColumnFormat.Date));
            Assert.AreEqual(new DateTime(2017, 8, 2, 14, 41, 10),
                convertor.ConvertStringToValue("8/2/2017 14:41:10", typeof(DateTime), ExcelColumnFormat.DateTime));
            }

        [Test]
        public void TestThatDateStringConvertToDefaultDateFormatCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();

            Assert.AreEqual(new DateTime(2017, 10, 2), convertor.ConvertStringToValue("10/2/2017", typeof(DateTime?)));
        }

        [Test]
        public void TestThatDateRangeStringConvertToDateRangeCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();

            var result = (DateRange)convertor.ConvertStringToValue("10/24/2017 - 10/2/2017", typeof(DateRange));
            Assert.AreEqual(new DateTime(2017, 10, 24), result.StartDate);
            Assert.AreEqual(new DateTime(2017, 10, 2), result.EndDate);
        }

        [Test]
        public void TestThatDateRangeConvertToDateRangeStringCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            var dateRange = new DateRange
            {
                StartDate = new DateTime(2017, 10, 24),
                EndDate = new DateTime(2017, 10, 2)
            };

            var result = convertor.ConvertValueToString(dateRange, "dd/MM/yyyy");
            Assert.AreEqual("24/10/2017 - 02/10/2017", result);
        }

        [Test]
        public void TestThatDateRangeConvertToDefaultDateRangeStringCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            var dateRange = new DateRange
            {
                StartDate = new DateTime(2017, 10, 24),
                EndDate = new DateTime(2017, 10, 2)
            };

            var result = convertor.ConvertValueToString(dateRange);
            Assert.AreEqual("10/24/2017 - 10/2/2017", result);
        }

        [Test]
        public void TestThatTimeStringConvertToTimeCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();

            Assert.AreEqual(new TimeSpan(16, 30, 0), convertor.ConvertStringToValue("16:30", typeof(TimeSpan), ExcelColumnFormat.Hours24Time));
            Assert.AreEqual(new TimeSpan(16, 30, 0), convertor.ConvertStringToValue("4:30PM", typeof(TimeSpan), ExcelColumnFormat.Hours12Time));
        }

        [Test]
        public void TestThatTimeStringConvertToDefaultTimeFormatCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            Assert.AreEqual(new TimeSpan(16, 30, 0), convertor.ConvertStringToValue("16:30", typeof(TimeSpan)));
        }

        [Test]
        public void TestThatBoolStringConvertToBoolCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            Assert.AreEqual(true, convertor.ConvertStringToValue("TRUE", typeof(bool)));
            Assert.AreEqual(false, convertor.ConvertStringToValue("FALSE", typeof(bool)));
            Assert.AreEqual(false, convertor.ConvertStringToValue("FALSE", typeof(bool?)));
            Assert.AreEqual(false, convertor.ConvertStringToValue("FALSE", typeof(bool?)));
            Assert.Null(convertor.ConvertStringToValue(null, typeof(bool?)));
        }

        [Test]
        public void TestThatBoolConvertToStringCorrectly()
        {
            var convertor = new ExcelDataFormatConvertor();
            Assert.AreEqual("TRUE", convertor.ConvertValueToString(true));
            Assert.AreEqual("FALSE", convertor.ConvertValueToString(false));
        }
    }
}
