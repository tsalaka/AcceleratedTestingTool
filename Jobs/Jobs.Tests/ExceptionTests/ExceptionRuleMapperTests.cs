using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.GetExceptionTestData.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.ExceptionRules;
using Kronos.AcceleratedTool.Models.PayRuleBuilding;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ExceptionTests
{
    [TestFixture]
    public class ExceptionRuleMapperTests
    {
        [Test]
        public void TestThatWtkfProfileAndWsaExceptionRuleModelsMapToExceptionRulePerPayRuleCorrectly()
        {
            var payRuleCount = 2;
            var wsaExceptionRuleCount = 3;
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

            var wsaExceptionRules = new List<WsaExceptionRule>();
            for (int i = 1; i <= wsaExceptionRuleCount; i++)
            {
                var exceptionRule = new WsaExceptionRule
                {
                    Name = "ExceptionRuleName" + i,
                    InEarly = new TimeSpan(0, 17 + i, 0),
                    OutEarly = new TimeSpan(8, 10 + i, 0),
                    InVeryEarly = "InVeryEarly" + i,
                    OutVeryLate = "OutVeryLate" + i,
                    InLate = new TimeSpan(0, 15 + i, 0),
                    OutLate = new TimeSpan(4, 10 + i, 0),
                    EarlyOutNdPayCodeName = "EarlyOutNdPayCodeName" + i,
                    Unscheduled = i % 2 == 0,
                    Breaks = new List<string>
                    {
                        "Break" + i + 1,
                        "Break" + i + 2,
                        "Break" + i + 3
                    }
                };
                wsaExceptionRules.Add(exceptionRule);
            }

            var mapper = new ExceptionRuleMapper();

            var results = mapper.Map(wtkProfiles, wsaExceptionRules);
            Assert.NotNull(results);
            Assert.AreEqual(payRuleCount, results.Count);
            for (int i = 1; i <= payRuleCount; i++)
            {
                Assert.AreEqual("FullName" + i, results[i - 1].PayRule.FullName);
                Assert.AreEqual("PersonNumber" + i, results[i - 1].PayRule.PersonNumber);
                Assert.AreEqual("PayRuleName" + i, results[i - 1].PayRule.PayRuleName);

                Assert.AreEqual(new TimeSpan(0, 17 + i, 0), results[i - 1].ExceptionRule.InEarly);
                Assert.AreEqual(new TimeSpan(8, 10 + i, 0), results[i - 1].ExceptionRule.OutEarly);
                Assert.AreEqual(new TimeSpan(0, 15 + i, 0), results[i - 1].ExceptionRule.InLate);
                Assert.AreEqual("InVeryEarly" + i, results[i - 1].ExceptionRule.InVeryEarly);
                Assert.AreEqual("OutVeryLate" + i, results[i - 1].ExceptionRule.OutVeryLate);
                Assert.AreEqual(new TimeSpan(4, 10 + i, 0), results[i - 1].ExceptionRule.OutLate);
                Assert.AreEqual("EarlyOutNdPayCodeName" + i, results[i - 1].ExceptionRule.EarlyOutNdPayCodeName);
                Assert.AreEqual(i % 2 == 0, results[i - 1].ExceptionRule.Unscheduled);
                Assert.AreEqual("Break" + i + 3, results[i - 1].Break);
            }
        }

        [Test]
        public void TestThatWtkfProfileWillBeMappedToExceptionRulePerPayRuleIfExceptionRuleDoesntExist()
        {
            var wsaExceptionRuleCount = 3;
            var wtkProfiles = new List<WtkProfile>();
            var wtkProfile = new WtkProfile
            {
                PayRule = new PayRule
                {
                    FullName = "FullName",
                    PayRuleName = "PayRuleName",
                    PersonNumber = "PersonNumber"
                },
                ExceptionRuleName = "ExceptionRuleNameNotExist"
            };
            wtkProfiles.Add(wtkProfile);

            var wsaExceptionRules = new List<WsaExceptionRule>();
            for (int i = 1; i <= wsaExceptionRuleCount; i++)
            {
                var exceptionRule = new WsaExceptionRule
                {
                    Name = "ExceptionRuleName" + i,
                    InEarly = new TimeSpan(0, 17 + i, 0),
                    OutEarly = new TimeSpan(8, 10 + i, 0),
                    InVeryEarly = "InVeryEarly" + i,
                    OutVeryLate = "OutVeryLate" + i,
                    InLate = new TimeSpan(0, 15 + i, 0),
                    OutLate = new TimeSpan(4, 10 + i, 0),
                    EarlyOutNdPayCodeName = "EarlyOutNdPayCodeName" + i,
                    Unscheduled = i % 2 == 0,
                    Breaks = new List<string>
                    {
                        "Break" + i + 1,
                        "Break" + i + 2,
                        "Break" + i + 3
                    }
                };
                wsaExceptionRules.Add(exceptionRule);
            }

            var mapper = new ExceptionRuleMapper();

            var results = mapper.Map(wtkProfiles, wsaExceptionRules);
            Assert.NotNull(results);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("FullName", results[0].PayRule.FullName);
            Assert.AreEqual("PersonNumber", results[0].PayRule.PersonNumber);
            Assert.AreEqual("PayRuleName", results[0].PayRule.PayRuleName);

           Assert.AreEqual(null, results[0].ExceptionRule.Name);
        }
    }
}
