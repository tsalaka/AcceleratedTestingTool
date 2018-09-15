using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Criterias;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.TestSharedMappers
{
    [TestFixture]
    public class TimesheetMapperTests
    {
        [Test]
        [TestCase(5, 2017, 2, 12)]
        [TestCase(9, 2017, 3, 12)]
        public void TestWtkProfileMapToTimesheetCorrectly(int count, int year, int month, int day)
        {
            var data = new List<PayRule>();
            for (int i = 1; i <= count; i++)
            {
                data.Add( new PayRule
                    {
                        PersonNumber = "PersonNumber" + i
                    });
            }

            var mapper = new TimesheetMapper();
            var timesheetCriteria = new TimesheetCriteria
            {
                PayRules = data,
                StartDate = new DateTime(year, month, day),
                EndDate = new DateTime(year, month, day + 1),
                TimeFrameName = "9"
            };
            var result = mapper.Map(timesheetCriteria);
            Assert.NotNull(result);
            Assert.AreEqual(count, result.Count);
            for (int i = 1; i <= count; i++)
            {
                Assert.AreEqual(new DateTime(year, month, day), result[i - 1].PeriodStartDate);
                Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].PeriodEndDate);
                Assert.AreEqual("PersonNumber" + i, result[i - 1].PersonNumber);
                Assert.AreEqual("9", result[i - 1].TimeFrameName);
            }
        }
    }
}
