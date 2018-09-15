using System;
using System.Collections.Generic;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace AcceleratedTool.Commands.Tests.Mappers.Employees
{
    [TestFixture]
    public class ExcelCustomDateMapperTests
    {
        [Test]
        public void TestMappingForEmployeeCustomDateEntity()
        {
            var inputDataList = new List<CustomDate>
            {
                new CustomDate
                {
                    Person = new PersonData
                    {
                        PersonNumber = "PersonNumber",
                        FirstName = "FirstName",
                        LastName = "LastName",
                        FullName = "FullName"
                    },
                    CustomDateTypeName = "CustomDateTypeName",
                    Date = new DateTime(2017, 2, 15)
                },
                new CustomDate
                {
                    Person = new PersonData
                    {
                        PersonNumber = "PersonNumber2",
                        FirstName = "FirstName2",
                        LastName = "LastName2",
                        FullName = "FullName2"
                    },
                    CustomDateTypeName = "CustomDateTypeName2",
                    Date = new DateTime(2017, 2, 16)
                }
            };

            var mapper = new ExcelCustomDateMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.NotNull(mappedData);
            Assert.AreEqual(2, mappedData.Count);
            Assert.AreEqual("PersonNumber", mappedData[0].PersonNumber);
            Assert.AreEqual("LastName", mappedData[0].LastName);
            Assert.AreEqual("FirstName", mappedData[0].FirstName);
            Assert.AreEqual("CustomDateTypeName", mappedData[0].CustomDateTypeName);
            Assert.AreEqual(new DateTime(2017, 2, 15), mappedData[0].Date);

            Assert.AreEqual("PersonNumber2", mappedData[1].PersonNumber);
            Assert.AreEqual("LastName2", mappedData[1].LastName);
            Assert.AreEqual("FirstName2", mappedData[1].FirstName);
            Assert.AreEqual("CustomDateTypeName2", mappedData[1].CustomDateTypeName);
            Assert.AreEqual(new DateTime(2017, 2, 16), mappedData[1].Date);
        }

        [Test]
        public void TestMappingForEmployeeCustomDateEntityIfInputIsNullOrEmpty()
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
