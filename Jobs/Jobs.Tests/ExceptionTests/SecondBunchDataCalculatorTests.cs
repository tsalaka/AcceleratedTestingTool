using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.ExceptionRules;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class SecondBunchDataCalculatorTests
    {
        [Test]
        public void TestThanSecondBunchDataCalculateCorrectly()
        {
            var exceptionPerPayRules = new List<ExceptionRulePerPayRule>();
            var exceptionPerPayRule1 = new ExceptionRulePerPayRule();
            exceptionPerPayRule1.PayRule = new PayRule
            {
                PersonNumber = "PersonNumber1"
            };
            exceptionPerPayRule1.ExceptionRule = new ExceptionRule
            {
                Name = "ExceptionRule1",
                InLate = new TimeSpan(21, 0, 0), //8:00
                OutLate = new TimeSpan(4, 9, 0), //21:9
                InEarly = new TimeSpan(22, 0, 0), //8:00
                OutEarly = new TimeSpan(5, 0, 0) //17:00
            };
            exceptionPerPayRules.Add(exceptionPerPayRule1);

            var exceptionPerPayRule2 = new ExceptionRulePerPayRule();
            exceptionPerPayRule2.PayRule = new PayRule
            {
                PersonNumber = "PersonNumber2"
            };
            exceptionPerPayRule2.ExceptionRule = new ExceptionRule
            {
                Name = "ExceptionRule2",
                InLate = new TimeSpan(8, 5, 0), //16:04
                OutLate = new TimeSpan(5, 0, 0), //17:00
                InEarly = new TimeSpan(3, 1, 45), //4:59
                OutEarly = new TimeSpan(10, 40, 49) // 6:20
            };
            exceptionPerPayRules.Add(exceptionPerPayRule2);

            var calculator = new SecondBunchDataCalculator();
            var results = calculator.Recalculate(exceptionPerPayRules);
            Assert.NotNull(results);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("PersonNumber1", results[0].PayRule.PersonNumber);
            Assert.AreEqual(new TimeSpan(8, 0, 0), results[0].ExceptionRule.InLate);
            Assert.AreEqual(new TimeSpan(21, 9, 0), results[0].ExceptionRule.OutLate);
            Assert.AreEqual(new TimeSpan(8, 0, 0), results[0].ExceptionRule.InEarly);
            Assert.AreEqual(new TimeSpan(17, 00, 0), results[0].ExceptionRule.OutEarly);

            Assert.AreEqual("PersonNumber2", results[1].PayRule.PersonNumber);
            Assert.AreEqual(new TimeSpan(16, 5, 0), results[1].ExceptionRule.InLate);
            Assert.AreEqual(new TimeSpan(17, 0, 0), results[1].ExceptionRule.OutLate);
            Assert.AreEqual(new TimeSpan(4, 59, 0), results[1].ExceptionRule.InEarly);
            Assert.AreEqual(new TimeSpan(6, 20, 0), results[1].ExceptionRule.OutEarly);
        }

        [Test]
        public void TestThanSecondBunchDataSkipNullableExceptionRules()
        {
            var exceptionPerPayRules = new List<ExceptionRulePerPayRule>();
            var exceptionPerPayRule1 = new ExceptionRulePerPayRule();
            exceptionPerPayRule1.PayRule = new PayRule
            {
                PersonNumber = "PersonNumber1"
            };
            exceptionPerPayRule1.ExceptionRule = new ExceptionRule();
            exceptionPerPayRules.Add(exceptionPerPayRule1);

            var exceptionPerPayRule2 = new ExceptionRulePerPayRule();
            exceptionPerPayRule2.PayRule = new PayRule
            {
                PersonNumber = "PersonNumber2"
            };
            exceptionPerPayRules.Add(exceptionPerPayRule2);

            var calculator = new SecondBunchDataCalculator();
            var results = calculator.Recalculate(exceptionPerPayRules);
            Assert.NotNull(results);
            Assert.AreEqual(0, results.Count);
        }
    }
}
