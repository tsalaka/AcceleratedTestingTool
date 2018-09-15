using System;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Mappers;
using Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests.Stubs;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class UnscheduleExceptionMapperTests
    {
        [Test]
        public void TestExceptionMapToUnscheduleExceptionCorrectly()
        {
            var exceptionPerPayRules = ExceptionRulePerPayRuleStub.GetData();
            var timesheets = TimesheetStub.GetData();

            var mapper = new UnscheduleExceptionMapper();
            var date = new DateTime(2017, 1, 1);
            var scheduleInOut = "scheduleInOut";

            var result = mapper.Map(exceptionPerPayRules, timesheets, date, scheduleInOut);
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
            for (int i = 0; i <= 1; i++)
            {
                Assert.AreEqual(date, result[i].Date);
                Assert.AreEqual(new TimeSpan(12, 31, 0), result[i].InPuchTime);
                Assert.AreEqual(new TimeSpan(13, 31, 0), result[i].OutPuchTime);
                Assert.AreEqual("scheduleInOut", result[i].ScheduledInOut);
                Assert.AreEqual(true, result[i].ExceptionRulePerPayRule.ExceptionRule.Unscheduled);
                Assert.AreEqual("PayRuleName1", result[i].ExceptionRulePerPayRule.PayRule.PayRuleName);
                Assert.AreEqual("FullName1", result[i].ExceptionRulePerPayRule.PayRule.FullName);
                Assert.AreEqual("PersonNumber1", result[i].ExceptionRulePerPayRule.PayRule.PersonNumber);
            }

            Assert.AreEqual("ExceptionTypeName1_1", result[0].TimekeepingExceptionTypeName);
            Assert.AreEqual("ExceptionTypeName1_2", result[1].TimekeepingExceptionTypeName);

            Assert.AreEqual(date, result[2].Date);
            Assert.AreEqual(new TimeSpan(12, 31, 0), result[2].InPuchTime);
            Assert.Null(result[2].OutPuchTime);
            Assert.AreEqual("scheduleInOut", result[2].ScheduledInOut);
            Assert.Null(result[2].ExceptionRulePerPayRule.ExceptionRule.Unscheduled);
            Assert.AreEqual("PayRuleName2", result[2].ExceptionRulePerPayRule.PayRule.PayRuleName);
            Assert.AreEqual("FullName2", result[2].ExceptionRulePerPayRule.PayRule.FullName);
            Assert.AreEqual("PersonNumber2", result[2].ExceptionRulePerPayRule.PayRule.PersonNumber);
            Assert.Null(result[2].TimekeepingExceptionTypeName);


            date = new DateTime(2017, 1, 2);

            result = mapper.Map(exceptionPerPayRules, timesheets, date, scheduleInOut);
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(date, result[0].Date);
            Assert.AreEqual(new TimeSpan(12, 32, 0), result[0].InPuchTime);
            Assert.Null(result[0].OutPuchTime);
            Assert.AreEqual("scheduleInOut", result[0].ScheduledInOut);
            Assert.AreEqual(true, result[0].ExceptionRulePerPayRule.ExceptionRule.Unscheduled);
            Assert.AreEqual("PayRuleName1", result[0].ExceptionRulePerPayRule.PayRule.PayRuleName);
            Assert.AreEqual("FullName1", result[0].ExceptionRulePerPayRule.PayRule.FullName);
            Assert.AreEqual("PersonNumber1", result[0].ExceptionRulePerPayRule.PayRule.PersonNumber);
            Assert.Null(result[0].TimekeepingExceptionTypeName);
        }
    }
}
