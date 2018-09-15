using System;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Mappers;
using Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests.Stubs;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class FirstBunchDataCalculatorTests
    {
        [Test]
        public void TestThanFirstBunchDataCalculateCorrectly()
        {
            

            var calculator = new FirstBunchDataCalculator();
            var results = calculator.Recalculate(ExceptionRulePerPayRuleStub.GetData());
            Assert.NotNull(results);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("PersonNumber1", results[0].PayRule.PersonNumber);
            Assert.AreEqual(new TimeSpan(13, 7, 0), results[0].ExceptionRule.InLate);
            Assert.AreEqual(new TimeSpan(21, 8, 0), results[0].ExceptionRule.OutLate);
            Assert.AreEqual(new TimeSpan(8, 0, 0), results[0].ExceptionRule.InEarly);
            Assert.AreEqual(new TimeSpan(11, 48, 0), results[0].ExceptionRule.OutEarly);

            Assert.AreEqual("PersonNumber2", results[1].PayRule.PersonNumber);
            Assert.AreEqual(new TimeSpan(8, 0, 0), results[1].ExceptionRule.InLate);
            Assert.AreEqual(new TimeSpan(22, 0, 0), results[1].ExceptionRule.OutLate);
            Assert.AreEqual(new TimeSpan(8, 0, 0), results[1].ExceptionRule.InEarly);
            Assert.AreEqual(new TimeSpan(17, 0, 0), results[1].ExceptionRule.OutEarly);

            Assert.AreEqual("PersonNumber3", results[2].PayRule.PersonNumber);
            Assert.AreEqual(new TimeSpan(8, 0, 0), results[2].ExceptionRule.InLate);
            Assert.AreEqual(new TimeSpan(22, 0, 0), results[2].ExceptionRule.OutLate);
            Assert.AreEqual(new TimeSpan(4, 41, 0), results[2].ExceptionRule.InEarly);
            Assert.AreEqual(new TimeSpan(17, 0, 0), results[2].ExceptionRule.OutEarly);
        }
    }
}
