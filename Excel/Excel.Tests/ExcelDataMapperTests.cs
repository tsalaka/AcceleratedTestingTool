using System;
using System.Collections.Generic;
using AcceleratedTool.Excel.Models;
using AcceleratedTool.Excel.Models.Attributes;
using AcceleratedTool.Excel.Models.PayRuleBuilding;
using Moq;
using NUnit.Framework;

namespace AcceleratedTool.ExcelDocument.Tests
{
    [TestFixture]
    public class ExcelDataMapperTests
    {
        private readonly Mock<IExcelDataFormatConvertor> _excelDataConvertor = new Mock<IExcelDataFormatConvertor>();

        [Test]
        public void TestThatDifferentTypesConvertCorrectlyToExcelData()
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

            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[0].PersonNumber, null)).Returns("PersonNumber");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[0].AccrualProfileName, null)).Returns("AccrualProfileName");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[0].BirthDate, null)).Returns("11/1/1981");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[0].BaseWageHourly, null)).Returns("15.5");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[0].ProfessionalWorkRuleName, null)).Returns("ProfessionalWorkRuleName");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[0].TransferEmployeeFlag, null)).Returns("TRUE");

            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[1].PersonNumber, null)).Returns("PersonNumber2");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[1].AccrualProfileName, null)).Returns("AccrualProfileName2");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[1].BirthDate, null)).Returns("12/6/1991");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[1].HireDate, null)).Returns("1/1/2017");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[1].BaseWageHourly, null)).Returns("10.5");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[1].ProfessionalWorkRuleName, null)).Returns("ProfessionalWorkRuleName2");
            _excelDataConvertor.Setup(w => w.ConvertValueToString(persons[1].TransferEmployeeFlag, null)).Returns(string.Empty);

            var excelDataMapper = new ExcelDataMapper<Employee>(_excelDataConvertor.Object);
            var result = excelDataMapper.Map(persons, "Employee List");

            Assert.NotNull(result);
            Assert.AreEqual(2, result.DataRows.Count);
            Assert.AreEqual("Employee List", result.SheetName);
            Assert.AreEqual("Person Number", result.Headers[0]);
            Assert.AreEqual("Last Name", result.Headers[1]);
            Assert.AreEqual("Pay Rule Name", result.Headers[3]);

            Assert.AreEqual("PersonNumber", result.DataRows[0][0]);
            Assert.AreEqual("AccrualProfileName", result.DataRows[0][4]);
            Assert.AreEqual("11/1/1981", result.DataRows[0][5]);
            Assert.AreEqual("15.5", result.DataRows[0][8]);
            Assert.AreEqual("ProfessionalWorkRuleName", result.DataRows[0][25]);
            Assert.AreEqual("TRUE", result.DataRows[0][31]);

            Assert.AreEqual("PersonNumber2", result.DataRows[1][0]);
            Assert.AreEqual("AccrualProfileName2", result.DataRows[1][4]);
            Assert.AreEqual("12/6/1991", result.DataRows[1][5]);
            Assert.AreEqual("10.5", result.DataRows[1][8]);
            Assert.AreEqual("1/1/2017", result.DataRows[1][6]);
            Assert.AreEqual("ProfessionalWorkRuleName2", result.DataRows[1][25]);
            Assert.AreEqual(string.Empty, result.DataRows[1][31]);
        }

        [Test]
        public void TestThatEmptyExcelRowsAreNotAddedToResultSet()
        {
            ExcelData data = new ExcelData();

            var headers = new List<string>();
            headers.Add("Accrual Profile Name");
            headers.Add("Person Number");
            headers.Add("Test Name");
            headers.Add("Person Full Name");
            headers.Add("Company Hire Date");
            data.Headers = headers;

            var row1 = new List<string>();
            row1.Add("Accrual Profile Name1");
            row1.Add("Person Number1");
            row1.Add("Test Name1");
            row1.Add("Person Full Name1");
            row1.Add("5/24/2017");
            data.DataRows.Add(row1);
            data.DataRows.Add(new List<string>());
            data.DataRows.Add(new List<string>());
            data.DataRows.Add(new List<string>());
            data.DataRows.Add(new List<string>());

            _excelDataConvertor.Setup(w => w.ConvertStringToValue(row1[0], typeof(string), ExcelColumnFormat.None)).Returns("Accrual Profile Name1");
            _excelDataConvertor.Setup(w => w.ConvertStringToValue(row1[1], typeof(string), ExcelColumnFormat.None)).Returns("Person Number1");
            _excelDataConvertor.Setup(w => w.ConvertStringToValue(row1[2], typeof(string), ExcelColumnFormat.None)).Returns("Test Name1");
            _excelDataConvertor.Setup(w => w.ConvertStringToValue(row1[3], typeof(string), ExcelColumnFormat.None)).Returns("Person Full Name1");
            _excelDataConvertor.Setup(w => w.ConvertStringToValue(row1[4], typeof(DateTime?), ExcelColumnFormat.None)).Returns("5/24/2017");

            var excelDataMapper = new ExcelDataMapper<AccrualProfile>(_excelDataConvertor.Object);
            var result = excelDataMapper.Map(data);

            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Accrual Profile Name1", result[0].AccrualProfileName);
            Assert.AreEqual("Person Number1", result[0].PersonNumber);
            Assert.AreEqual("Person Full Name1", result[0].PersonFullName);
            Assert.AreEqual("Test Name1", result[0].TestName);
            Assert.AreEqual(new DateTime(2017, 5, 24), result[0].HireDate);
        }

        [Test]
        public void TestThatPunchDataMappCorrectly()
        {
            ExcelData excelData = new ExcelData
            {
                SheetName = "Punch",
                Headers = new List<string>
                {
                    "Date",
                    "Time",
                    "In Punch or Out Punch"
                },
                DataRows = new List<List<string>>
                {
                    new List<string>
                    {
                        "42829",
                        "0.31597222222222221",
                        "In Punch"
                    },
                    new List<string>
                    {
                        "42831",
                        "0.31319444444444444",
                        "In Punch"
                    },
                    new List<string>
                    {
                        "42838",
                        "0.69027777777777777",
                        "Out Punch"
                    },
                    new List<string>
                    {
                        string.Empty,
                        string.Empty,
                        string.Empty
                    }
                }
            };
        }
    }
}
