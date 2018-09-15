using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.GetTimecardTestData.Mappers;
using Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests.Stubs;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.PayRuleBuilding;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.TimecardTests
{
    [TestFixture]
    public class DailyTimecardMapperTests
    {
        [Test]
        public void TestThatDataMapCorrectly()
        {
            var payRuleCount = 3;
            var wtkProfiles = new List<WtkProfile>();
            for (int i = 1; i <= payRuleCount; i++)
            {
                var wtkProfile = new WtkProfile
                {
                    PayRule = new PayRule
                    {
                        FullName = "FullName" + i,
                        PayRuleName = "PayRuleName" + i,
                        PersonNumber = "PersonNumber" + i
                    },
                    ExceptionRuleName = "ExceptionRuleName" + i
                };
                wtkProfiles.Add(wtkProfile);
            }

            var timesheets = TimesheetStub.GetData();

            var mapper = new DailyTimecardMapper();
            var result = mapper.Map(wtkProfiles, timesheets);

            Assert.AreEqual(payRuleCount, result.Count);
            for (int i = 0; i < payRuleCount; i++)
            {
                Assert.AreEqual(wtkProfiles[i], result[i].Profile);
                if (i < payRuleCount - 1)
                {
                    Assert.True(result[i].TotalsUpToDateFlag);
                }
                else
                {
                    Assert.False(result[i].TotalsUpToDateFlag);
                }
            }

            Assert.AreEqual(1, result[0].PunchDateTotals.Count);
            Assert.AreEqual(new TimeSpan(12, 31, 0), result[0].PunchDateTotals[0].PunchIn.Time);
            Assert.AreEqual(new TimeSpan(13, 31, 0), result[0].PunchDateTotals[0].PunchOut.Time);
            Assert.AreEqual(new DateTime(2017, 1, 1), result[0].PunchDateTotals[0].Date);
            Assert.AreEqual(1, result[0].PunchDateTotals[0].Totals.Count);
            Assert.AreEqual(new TimeSpan(9, 0, 0), result[0].PunchDateTotals[0].Totals[0].AmountInTime);
            Assert.AreEqual("LaborAccountDescription", result[0].PunchDateTotals[0].Totals[0].LaborAccountDescription);
            Assert.AreEqual("PayCodeName", result[0].PunchDateTotals[0].Totals[0].PayCodeName);

            Assert.AreEqual(0, result[2].PunchDateTotals.Count);
        }
    }
}
