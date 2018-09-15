using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Mappers;
using Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests.Stubs;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class ScheduleExceptionMapperTests
    {
        [Test]
        [TestCase("8:01" , null, true)]
        public void TestExceptionMapToScheduleExceptionWithOverridePunchOutCorrectly(
            string overridePunchIn,
            string overridePunchOut,
            bool isEarly)
        {
            var exceptionPerPayRules = ExceptionRulePerPayRuleStub.GetData();
            var timesheets = TimesheetStub.GetData();

            var mapper = new ScheduleExceptionMapper();
            var dates = new List<DateTime> { new DateTime(2017, 1, 1), new DateTime(2017, 1, 2) };
            var punchIn = overridePunchIn != null ? TimeSpan.Parse(overridePunchIn) : (TimeSpan?)null;
            var punchOut = overridePunchOut != null ? TimeSpan.Parse(overridePunchOut) : (TimeSpan?)null;

            var result = mapper.Map(exceptionPerPayRules, timesheets, dates, punchIn, punchOut, isEarly);
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count);
            for (int i = 0; i <= 1; i++)
            {
                Assert.AreEqual(new DateTime(2017, 1, 1), result[i].Date);
                Assert.AreEqual(new TimeSpan(8, 0, 0), result[i].ScheduledIn);
                Assert.AreEqual(new TimeSpan(17, 0, 0), result[i].ScheduledOut);
                if (overridePunchIn != null)
                {
                    Assert.AreEqual(punchIn, result[i].InPuchTime);
                    Assert.AreEqual(new TimeSpan(13, 31, 0), result[i].OutPuchTime);
                    if (isEarly)
                        Assert.AreEqual(new TimeSpan(5, 13, 0), result[i].ExceptionConfigTime);
                    else
                        Assert.AreEqual(new TimeSpan(4, 9, 0), result[i].ExceptionConfigTime);
                }
                else
                {
                    Assert.AreEqual(new TimeSpan(8, 1, 0), result[i].InPuchTime);
                    Assert.AreEqual(punchOut, result[i].OutPuchTime);
                    if (isEarly)
                        Assert.AreEqual(new TimeSpan(22, 0, 0), result[i].ExceptionConfigTime);
                    else
                        Assert.AreEqual(new TimeSpan(5, 8, 0), result[i].ExceptionConfigTime);
                }

                Assert.AreEqual(true, result[i].ExceptionRulePerPayRule.ExceptionRule.Unscheduled);
                Assert.AreEqual("PayRuleName1", result[i].ExceptionRulePerPayRule.PayRule.PayRuleName);
                Assert.AreEqual("FullName1", result[i].ExceptionRulePerPayRule.PayRule.FullName);
                Assert.AreEqual("PersonNumber1", result[i].ExceptionRulePerPayRule.PayRule.PersonNumber);
            }

            Assert.AreEqual("ExceptionTypeName1_1", result[0].TimekeepingExceptionTypeName);
            Assert.AreEqual("ExceptionTypeName1_2", result[1].TimekeepingExceptionTypeName);

            Assert.AreEqual(new DateTime(2017, 1, 2), result[2].Date);
            Assert.AreEqual(new TimeSpan(8, 0, 0), result[2].ScheduledIn);
            Assert.AreEqual(new TimeSpan(17, 0, 0), result[2].ScheduledOut);
            if (overridePunchIn != null)
            {
                Assert.AreEqual(punchIn, result[2].InPuchTime);
                Assert.Null(result[2].OutPuchTime);
                if (isEarly)
                    Assert.AreEqual(new TimeSpan(5, 13, 0), result[2].ExceptionConfigTime);
                else
                    Assert.AreEqual(new TimeSpan(4, 9, 0), result[2].ExceptionConfigTime);
            }
            else
            {
                Assert.AreEqual(punchOut, result[2].OutPuchTime);
                Assert.AreEqual(new TimeSpan(12, 32, 0), result[2].InPuchTime);
                if (isEarly)
                    Assert.AreEqual(new TimeSpan(22, 0, 0), result[2].ExceptionConfigTime);
                else
                    Assert.AreEqual(new TimeSpan(5, 8, 0), result[2].ExceptionConfigTime);
            }

            Assert.AreEqual(true, result[2].ExceptionRulePerPayRule.ExceptionRule.Unscheduled);
            Assert.AreEqual("PayRuleName1", result[2].ExceptionRulePerPayRule.PayRule.PayRuleName);
            Assert.AreEqual("FullName1", result[2].ExceptionRulePerPayRule.PayRule.FullName);
            Assert.AreEqual("PersonNumber1", result[2].ExceptionRulePerPayRule.PayRule.PersonNumber);
            Assert.Null(result[2].TimekeepingExceptionTypeName);

            Assert.AreEqual(new DateTime(2017, 1, 1), result[3].Date);
            Assert.AreEqual(new TimeSpan(8, 0, 0), result[3].ScheduledIn);
            Assert.AreEqual(new TimeSpan(17, 0, 0), result[3].ScheduledOut);
            if (overridePunchIn != null)
            {
                Assert.AreEqual(punchIn, result[3].InPuchTime);
                Assert.Null(result[3].OutPuchTime);
                if (isEarly)
                    Assert.AreEqual(new TimeSpan(21, 0, 29), result[3].ExceptionConfigTime);
                else
                    Assert.AreEqual(new TimeSpan(5, 1, 0), result[3].ExceptionConfigTime);
            }
            else
            {
                Assert.AreEqual(punchOut, result[3].OutPuchTime);
                Assert.AreEqual(new TimeSpan(12, 31, 0), result[3].InPuchTime);
                if (isEarly)
                    Assert.AreEqual(new TimeSpan(13, 1, 45), result[3].ExceptionConfigTime);
                else
                    Assert.AreEqual(new TimeSpan(8, 0, 0), result[3].ExceptionConfigTime);
            }
            Assert.Null(result[3].ExceptionRulePerPayRule.ExceptionRule.Unscheduled);
            Assert.AreEqual("PayRuleName2", result[3].ExceptionRulePerPayRule.PayRule.PayRuleName);
            Assert.AreEqual("FullName2", result[3].ExceptionRulePerPayRule.PayRule.FullName);
            Assert.AreEqual("PersonNumber2", result[3].ExceptionRulePerPayRule.PayRule.PersonNumber);
            Assert.Null(result[3].TimekeepingExceptionTypeName);
        }
    }
}
