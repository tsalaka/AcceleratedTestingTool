using System.Collections.Generic;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace AcceleratedTool.Commands.Tests.Mappers.Employees
{
    [TestFixture]
    public class ExcelEmployeeMapperTests
    {
        [Test]
        public void TestMappingForEmployeeEntity()
        {
            var inputDataList = new List<Employee>
            {
                new Employee
                {
                    PersonNumber = "PersonNumber1",
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    AccrualProfileName = "AccrualProfileName1",
                    AccessProfileName = "AccessProfileName1",
                    HomeAccountName = "HomeAccountName1",
                    BadgeNumber = "BadgeNumber1",
                    BaseWageHourly = 25,
                },
                new Employee
                {
                    PersonNumber = "PersonNumber2",
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    AccrualProfileName = "AccrualProfileName2",
                    AccessProfileName = "AccessProfileName2",
                    HomeAccountName = "HomeAccountName2",
                    BadgeNumber = "BadgeNumber2",
                    BaseWageHourly = 26,
                }
            };

            var mapper = new ExcelEmployeeMapper();
            var mappedData = mapper.Map(inputDataList);
            Assert.NotNull(mappedData);
            Assert.AreEqual(2, mappedData.Count);
            for (int i = 0; i < 2; i++)
            {
                var ind = i + 1;
                Assert.AreEqual("PersonNumber" + ind, mappedData[i].PersonNumber);
                Assert.AreEqual("LastName" + ind, mappedData[i].LastName);
                Assert.AreEqual("FirstName" + ind, mappedData[i].FirstName);
                Assert.AreEqual("AccrualProfileName" + ind, mappedData[i].AccrualProfileName);
                Assert.AreEqual("AccessProfileName" + ind, mappedData[i].AccessProfileName);
                Assert.AreEqual("HomeAccountName" + ind, mappedData[i].HomeAccountName);
                Assert.AreEqual("BadgeNumber" + ind, mappedData[i].BadgeNumber);
                Assert.AreEqual(25 + i, mappedData[i].BaseWageHourly);
            }
        }
    }
}
