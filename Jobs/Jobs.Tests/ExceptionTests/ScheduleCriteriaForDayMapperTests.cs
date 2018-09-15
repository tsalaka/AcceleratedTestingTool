using System;
using System.Collections.Generic;
using System.Linq;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Mappers;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Criterias;
using Kronos.AcceleratedTool.Models.Employees;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class ScheduleCriteriaForDayMapperTests
    {
        [Test]
        public void TestThatScheduleCriteriaAreGeneratedCorrectly()
        {
            var data = new List<PayRule>
            {
                new PayRule(),
                new PayRule()
            };

            var date = new DateTime(2017, 4, 17);
            var timeIn = new TimeSpan(9, 0, 0);
            var timeOut = new TimeSpan(10, 0, 0);
            var mapper = new ScheduleCriteriaForDayMapper();
            var result = mapper.Map(data, date, timeIn, timeOut);

            Assert.NotNull(result);
            Assert.IsInstanceOf<ChangeScheduleCriteria>(result);
            Assert.AreEqual(data.Count, result.PayRules.Count);
            Assert.AreEqual(1, result.Schedules.Count);
            Assert.AreEqual(1, result.Schedules.First().ShiftEndDayNumber);
            Assert.AreEqual(1, result.Schedules.First().ShiftStartDayNumber);
            Assert.AreEqual(timeOut, result.Schedules.First().ShiftEndTime);
            Assert.AreEqual(timeIn, result.Schedules.First().ShiftStartTime);
            Assert.AreEqual(date, result.Schedules.First().StartDate);
            Assert.AreEqual(date, result.Schedules.First().ShiftStartDate);
            
        }

        [Test]
        public void TestThatAgrumentNullExceptionThrowsIfPayRuleDataIsNull()
        {
            var date = new DateTime(2017, 4, 17);

            var mapper = new Plus1DayDataMapper();

            Assert.Throws<ArgumentNullException>(() => mapper.Map(null, date));
        }
    }
}
