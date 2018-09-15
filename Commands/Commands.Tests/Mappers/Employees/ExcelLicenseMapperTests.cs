using System.Collections.Generic;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace AcceleratedTool.Commands.Tests.Mappers.Employees
{
    [TestFixture]
    public class ExcelLicenseMapperTests
    {
        [Test]
        public void TestMappingForEmployeeLicenseEntity()
        {
            var inputDataList = new List<EmployeeLicense>
            {
                new EmployeeLicense
                {
                    Person = new PersonData
                    {
                        PersonNumber = "PersonNumber",
                        FirstName = "FirstName",
                        LastName = "LastName",
                        FullName = "FullName"
                    },
                    ActiveFlag = true,
                    LicenseTypeName = "LicenseTypeName"
                },
                new EmployeeLicense
                {
                    Person = new PersonData
                    {
                        PersonNumber = "PersonNumber2",
                        FirstName = "FirstName2",
                        LastName = "LastName2",
                        FullName = "FullName2"
                    },
                    ActiveFlag = false,
                    LicenseTypeName = "LicenseTypeName2"
                }
            };

            var mapper = new ExcelEmployeeLicenseMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.NotNull(mappedData);
            Assert.AreEqual(2, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].PersonNumber);
            Assert.AreEqual("LastName", mappedData[0].LastName);
            Assert.AreEqual("FirstName", mappedData[0].FirstName);
            Assert.AreEqual(true, mappedData[0].LicenseActiveFlag);
            Assert.AreEqual("LicenseTypeName", mappedData[0].LicenseTypeName);

            Assert.AreEqual("PersonNumber2", mappedData[1].PersonNumber);
            Assert.AreEqual("LastName2", mappedData[1].LastName);
            Assert.AreEqual("FirstName2", mappedData[1].FirstName);
            Assert.AreEqual(false, mappedData[1].LicenseActiveFlag);
            Assert.AreEqual("LicenseTypeName2", mappedData[1].LicenseTypeName);
        }

        [Test]
        public void TestMappingForEmployeeLicenseIfInputIsNullOrEmpty()
        {
            List<CustomDate> inputDataList = null;
            var mapper = new ExcelCustomDateMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.AreEqual(0, mappedData.Count);

            inputDataList = new List<CustomDate>();
            mappedData = mapper.Map(inputDataList);
            Assert.AreEqual(0, mappedData.Count);
        }
    }
}
