using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Criterias;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.TestSharedMappers
{
    [TestFixture]
    public class ScheduleMapperTests
    {
        [Test]
        [TestCase(5, 2017, 2, 12)]
        [TestCase(9, 2017, 3, 12)]
        public void TestWtkProfileMapToScheduleCorrectly(int count, int year, int month, int day)
        {
            var data = new List<PayRule>();
            for (int i = 1; i <= count; i++)
            {
                data.Add(
                    new PayRule
                    {
                        PersonNumber = "PersonNumber" + i
                    });
            }

            var mapper = new ScheduleMapper();
            var criteria = new GroupScheduleCriteria
            {
                PayRules = data,
                StartDate = new DateTime(year, month, day),
                EndDate = new DateTime(year, month, day + 1)
            };
            var result = mapper.Map(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count, result.Count);
            for (int i = 1; i <= count; i++)
            {
                Assert.AreEqual(new DateTime(year, month, day), result[i - 1].StartDate);
                Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].EndDate);
                Assert.AreEqual("PersonNumber" + i, result[i - 1].PersonNumber);
            }
        }
    }
}
