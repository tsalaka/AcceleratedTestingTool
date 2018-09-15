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
    public class Plus1DayDataMapperTests
    {
        [Test]
        public void TestThatTimesheetCriteriaAreGeneratedCorrectly()
        {
            var data = new List<PayRule>
            {
                new PayRule(),
                new PayRule()
            };

            var date = new DateTime(2017, 4, 17);

            var mapper = new Plus1DayDataMapper();
            var result = mapper.Map(data, date);

            Assert.NotNull(result);
            Assert.IsInstanceOf<ChangeScheduleCriteria>(result.Item1);
            Assert.IsInstanceOf<ChangePunchCriteria>(result.Item2);
            Assert.IsInstanceOf<ChangePunchCriteria>(result.Item3);

            Assert.AreEqual(data.Count, result.Item1.PayRules.Count);
            Assert.AreEqual(1, result.Item1.Schedules.Count);

            Assert.AreEqual(data.Count, result.Item2.PayRules.Count);
            Assert.AreEqual(data, result.Item2.PayRules);
            Assert.AreEqual(1, result.Item2.Punches.Count);
            Assert.AreEqual(date, result.Item2.Punches.First().Date);
            Assert.AreEqual(new TimeSpan(9, 0, 0), result.Item2.Punches.First().Time);

            Assert.AreEqual(data, result.Item3.PayRules);
            Assert.AreEqual(1, result.Item3.Punches.Count);
            Assert.AreEqual(date, result.Item3.Punches.First().Date);
            Assert.AreEqual(new TimeSpan(15, 0, 0), result.Item3.Punches.First().Time);
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
