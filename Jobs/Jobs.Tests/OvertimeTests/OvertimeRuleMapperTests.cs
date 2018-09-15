using System;
using System.Collections.Generic;
using System.Linq;
using Kronos.AcceleratedTool.Jobs.GetOvertimeTestData.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.OvertimeRules;
using Kronos.AcceleratedTool.Models.PayRuleBuilding;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.OvertimeTests
{
    [TestFixture]
    public class OvertimeRuleMapperTests
    {
        [Test]
        public void TestThatWtkfProfileAndOvertimeRuleAndBonusRuleModelsMapToOvertimeRulePerPayRuleCorrectly()
        {
            var payRuleCount = 2;
            var overtimeRulesCount = 3;
            var bonusDeductRulesCount = 1;
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
                    OvertimeRuleName = "OvertimeRuleName" + i,
                    BonusDeductRuleName = "BonusDeductRule" + i
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
                    OvertimeRuleName = "OvertimeRuleName" + i,
                    BonusDeductRuleName = "BonusDeductRule" + i
                };
                wtkProfiles.Add(wtkProfile2);
            }

            var overtimeRules = new List<OvertimeRule>();
            for (int i = 1; i <= overtimeRulesCount; i++)
            {
                var overtimeRule = new OvertimeRule
                {
                    Name = "OvertimeRuleName" + i,
                    Amount = new TimeSpan(0, 17 + i, 0),
                    ResetAtTime = new TimeSpan(8, 10 + i, 0),
                    RequiresApproval = true,
                    ResetDay = i,
                    UseRoundedTime = true
                };
                overtimeRules.Add(overtimeRule);
            }

            var bonusDeductRules = new List<BonusDeductRule>();
            for (int i = 1; i <= bonusDeductRulesCount; i++)
            {
                var bonusDeductRule = new BonusDeductRule
                {
                    Name = "BonusDeductRule" + i,
                    Amount = "Amount" + i,
                    PayCode = "PayCode" + i,
                    ShiftMinimumHours = new TimeSpan(8, 10 + i, 0),
                    Type = "Type" + i
                };
                bonusDeductRules.Add(bonusDeductRule);
            }

            var mapper = new OvertimeRuleMapper();

            var results = mapper.Map(wtkProfiles, overtimeRules, bonusDeductRules);
            Assert.NotNull(results);
            Assert.AreEqual(payRuleCount, results.Count);
            for (int i = 1; i <= payRuleCount; i++)
            {
                Assert.AreEqual("FullName" + i, results[i - 1].PayRule.FullName);
                Assert.AreEqual("PersonNumber" + i, results[i - 1].PayRule.PersonNumber);
                Assert.AreEqual("PayRuleName" + i, results[i - 1].PayRule.PayRuleName);

                if (overtimeRules.Any(s => s.Name.Equals("OvertimeRuleName" + i, StringComparison.OrdinalIgnoreCase)))
                {
                    Assert.AreEqual("OvertimeRuleName" + i, results[i - 1].OvertimeRule.Name);
                    Assert.AreEqual(new TimeSpan(0, 17 + i, 0), results[i - 1].OvertimeRule.Amount);
                    Assert.AreEqual(new TimeSpan(8, 10 + i, 0), results[i - 1].OvertimeRule.ResetAtTime);
                    Assert.AreEqual(true, results[i - 1].OvertimeRule.RequiresApproval);
                    Assert.AreEqual(true, results[i - 1].OvertimeRule.UseRoundedTime);
                    Assert.AreEqual(i, results[i - 1].OvertimeRule.ResetDay);
                }
                else
                    Assert.Null(results[i - 1].OvertimeRule);

                if (bonusDeductRules.Any(s => s.Name.Equals("BonusDeductRule" + i, StringComparison.OrdinalIgnoreCase)))
                {
                    Assert.AreEqual("BonusDeductRule" + i, results[i - 1].BonusDeductRule.Name);
                    Assert.AreEqual("Amount" + i, results[i - 1].BonusDeductRule.Amount);
                    Assert.AreEqual("PayCode" + i, results[i - 1].BonusDeductRule.PayCode);
                    Assert.AreEqual("Type" + i, results[i - 1].BonusDeductRule.Type);
                    Assert.AreEqual(new TimeSpan(8, 10 + i, 0), results[i - 1].BonusDeductRule.ShiftMinimumHours);
                }
                else
                {
                    Assert.Null(results[i - 1].BonusDeductRule);
                }
            }
        }
    }
}
