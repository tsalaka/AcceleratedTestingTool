using System;
using System.Collections.Generic;
using System.Linq;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.PayRuleBuilding;
using Kronos.AcceleratedTool.Models.PunchRoundRules;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.PunchRoundTests
{
    [TestFixture]
    public class PunchRoundRuleMapperTests
    {
        [Test]
        public void TestThatWtkfProfileAndPunchRoundRuleAndBreakRuleModelsMapToPunchRoundRulePerPayRuleCorrectly()
        {
            var payRuleCount = 2;
            var punchRoundRulesCount = 3;
            var breakRulesCount = 1;
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
                    BreakRuleNames = "BreakRuleNames" + i,
                    RoundRuleName = "RoundRuleName" + i
                };
                wtkProfiles.Add(wtkProfile);
                var wtkProfile2 = new WtkProfile
                {
                    PayRule = new PayRule
                    {
                        FullName = "FullName2" + i,
                        PayRuleName = "PayRuleName" + i,
                        PersonNumber = "PersonNumber2" + i
                    },
                    BreakRuleNames = "BreakRuleNames" + i,
                    RoundRuleName = "RoundRuleName" + i
                };
                wtkProfiles.Add(wtkProfile2);
            }

            var punchRoundRules = new List<PunchRoundRule>();
            for (int i = 1; i <= punchRoundRulesCount; i++)
            {
                var punchRoundRule = new PunchRoundRule
                {
                    Name = "RoundRuleName" + i,
                    InPunchEarlyChangePoint = new TimeSpan(0, 10 + i, 0),
                    InPunchEarlyInsideRound = new TimeSpan(0, 11 + i, 0),
                    InPunchEarlyInsideGrace = new TimeSpan(0, 12 + i, 0),
                    OutPunchEarlyChangePoint = new TimeSpan(0, 10 + i, 0),
                    OutPunchEarlyInsideRound = new TimeSpan(0, 11 + i, 0),
                    OutPunchEarlyInsideGrace = new TimeSpan(0, 12 + i, 0)
                };
                punchRoundRules.Add(punchRoundRule);
            }

            var breakRules = new List<BreakRule>();
            for (int i = 1; i <= breakRulesCount; i++)
            {
                var breakRule = new BreakRule
                {
                    Name = "BreakRuleNames" + i,
                    LongChangePoint = new TimeSpan(0, i, 0),
                    LongGrace = new TimeSpan(0, 1 + i, 0),
                    LongRound = new TimeSpan(0, 2 + i, 0),
                    ShortChangePoint = new TimeSpan(0, i, 0),
                    ShortGrace = new TimeSpan(0, 1 + i, 0),
                    ShortRound = new TimeSpan(0, 2 + i, 0),
                    UseUnscheduledPunchRounding = true
                };
                breakRules.Add(breakRule);
            }

            var mapper = new PunchRoundRuleMapper();

            var results = mapper.Map(wtkProfiles, punchRoundRules, breakRules);
            Assert.NotNull(results);
            Assert.AreEqual(payRuleCount, results.Count);
            for (int i = 1; i <= payRuleCount; i++)
            {
                Assert.AreEqual("FullName" + i, results[i - 1].PayRule.FullName);
                Assert.AreEqual("PersonNumber" + i, results[i - 1].PayRule.PersonNumber);
                Assert.AreEqual("PayRuleName" + i, results[i - 1].PayRule.PayRuleName);

                if (punchRoundRules.Any(s => s.Name.Equals("RoundRuleName" + i, StringComparison.OrdinalIgnoreCase)))
                {
                    Assert.AreEqual("RoundRuleName" + i, results[i - 1].PunchRoundRule.Name);
                    Assert.AreEqual(new TimeSpan(0, 10 + i, 0), results[i - 1].PunchRoundRule.InPunchEarlyChangePoint);
                    Assert.AreEqual(new TimeSpan(0, 11 + i, 0), results[i - 1].PunchRoundRule.InPunchEarlyInsideRound);
                    Assert.AreEqual(new TimeSpan(0, 12 + i, 0), results[i - 1].PunchRoundRule.InPunchEarlyInsideGrace);
                    Assert.AreEqual(new TimeSpan(0, 10 + i, 0), results[i - 1].PunchRoundRule.OutPunchEarlyChangePoint);
                    Assert.AreEqual(new TimeSpan(0, 11 + i, 0), results[i - 1].PunchRoundRule.OutPunchEarlyInsideRound);
                    Assert.AreEqual(new TimeSpan(0, 12 + i, 0), results[i - 1].PunchRoundRule.OutPunchEarlyInsideGrace);
                }
                else
                    Assert.Null(results[i - 1].PunchRoundRule);

                if (breakRules.Any(s => s.Name.Equals("BreakRuleNames" + i, StringComparison.OrdinalIgnoreCase)))
                {
                    Assert.AreEqual("BreakRuleNames" + i, results[i - 1].BreakRule.Name);
                    Assert.AreEqual(new TimeSpan(0, i, 0), results[i - 1].BreakRule.LongChangePoint);
                    Assert.AreEqual(new TimeSpan(0, 1 + i, 0), results[i - 1].BreakRule.LongGrace);
                    Assert.AreEqual(new TimeSpan(0, 2 + i, 0), results[i - 1].BreakRule.LongRound);
                    Assert.AreEqual(new TimeSpan(0, i, 0), results[i - 1].BreakRule.ShortChangePoint);
                    Assert.AreEqual(new TimeSpan(0, 1 + i, 0), results[i - 1].BreakRule.ShortGrace);
                    Assert.AreEqual(new TimeSpan(0, 2 + i, 0), results[i - 1].BreakRule.ShortRound);
                    Assert.AreEqual(true, results[i - 1].BreakRule.UseUnscheduledPunchRounding);
                }
                else
                {
                    Assert.Null(results[i - 1].BreakRule);
                }
            }
        }
    }
}
