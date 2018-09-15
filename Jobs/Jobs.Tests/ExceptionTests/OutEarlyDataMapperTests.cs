using System;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Mappers;
using Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests.Stubs;
using Kronos.AcceleratedTool.Models.TestSharedModel.Punches;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class OutEarlyDataMapperTests
    {
        [Test]
        public void TestsMapping()
        {
            var mapper = new OutEarlyDataMapper();
            var date = new DateTime(2017, 2, 25);
            var exceptionRules = ExceptionRulePerPayRuleStub.GetData();
            var result = mapper.Map(exceptionRules, date);

            Assert.NotNull(result);
            Assert.NotNull(result.Item1);
            Assert.NotNull(result.Item2);
            Assert.NotNull(result.Item3);

            Assert.AreEqual(date, result.Item1.Schedules[0].StartDate);
            Assert.AreEqual(date, result.Item1.Schedules[0].EndDate);
            Assert.AreEqual(new TimeSpan(8, 0, 0), result.Item1.Schedules[0].ShiftStartTime);
            Assert.AreEqual(new TimeSpan(17, 0, 0), result.Item1.Schedules[0].ShiftEndTime);
            Assert.AreEqual(1, result.Item1.Schedules[0].ShiftStartDayNumber);
            Assert.AreEqual(1, result.Item1.Schedules[0].ShiftEndDayNumber);

            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual(exceptionRules[0].PayRule.PersonNumber, result.Item2[0].PersonNumber);
            Assert.AreEqual(exceptionRules[1].PayRule.PersonNumber, result.Item2[1].PersonNumber);
            Assert.AreEqual(exceptionRules[2].PayRule.PersonNumber, result.Item2[2].PersonNumber);
            Assert.AreEqual(date, result.Item2[0].Date);
            Assert.AreEqual(date, result.Item2[1].Date);
            Assert.AreEqual(date, result.Item2[2].Date);
            Assert.AreEqual(PunchType.InPunch, result.Item2[0].Type);
            Assert.AreEqual(PunchType.InPunch, result.Item2[1].Type);
            Assert.AreEqual(PunchType.InPunch, result.Item2[2].Type);
            Assert.AreEqual(new TimeSpan(8, 0 ,0), result.Item2[0].Time);
            Assert.AreEqual(new TimeSpan(8, 0, 0), result.Item2[1].Time);
            Assert.AreEqual(new TimeSpan(8, 0, 0), result.Item2[2].Time);

            Assert.AreEqual(3, result.Item3.Count);
            Assert.AreEqual(exceptionRules[0].PayRule.PersonNumber, result.Item3[0].PersonNumber);
            Assert.AreEqual(exceptionRules[1].PayRule.PersonNumber, result.Item3[1].PersonNumber);
            Assert.AreEqual(exceptionRules[2].PayRule.PersonNumber, result.Item3[2].PersonNumber);
            Assert.AreEqual(date, result.Item3[0].Date);
            Assert.AreEqual(PunchType.OutPunch, result.Item3[0].Type);
            Assert.AreEqual(PunchType.OutPunch, result.Item3[1].Type);
            Assert.AreEqual(PunchType.OutPunch, result.Item3[2].Type);
            Assert.AreEqual(date, result.Item3[1].Date);
            Assert.AreEqual(date, result.Item3[2].Date);
            Assert.AreEqual(exceptionRules[0].ExceptionRule.OutEarly, result.Item3[0].Time);
            Assert.AreEqual(exceptionRules[1].ExceptionRule.OutEarly, result.Item3[1].Time);
            Assert.AreEqual(exceptionRules[2].ExceptionRule.OutEarly, result.Item3[2].Time);


        }
    }
}
