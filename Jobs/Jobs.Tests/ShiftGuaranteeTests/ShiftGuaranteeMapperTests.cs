using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.GetShiftGuaranteeTestData.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.PayRuleBuilding;
using Kronos.AcceleratedTool.Models.ShiftGuarantees;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.ShiftGuaranteeTests
{
    [TestFixture]
    public class ShiftGuaranteeMapperTests
    {
        [Test]
        public void TestThatWtkfProfileAndShiftGuaranteeMapToShiftGuaranteePerPayRuleCorrectly()
        {
            var payRuleCount = 2;

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
                    WorkruleName = "WorkruleName" + i,
                    BreakRuleNames = "BreakRuleNames" + i,
                    BonusDeductRuleName = "BonusDeductRuleName" + i,
                    ShiftGuaranteeName = "ShiftGuarantee" + i
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
                    WorkruleName = "WorkruleName" + i,
                    BreakRuleNames = "BreakRuleNames" + i,
                    BonusDeductRuleName = "BonusDeductRuleName" + i,
                    ShiftGuaranteeName = "ShiftGuarantee" + i
                };
                wtkProfiles.Add(wtkProfile2);
            }

            var data = new List<ShiftGuarantee>
            {
                new ShiftGuarantee
                {
                    ReductByAmountTardy = true,
                    Sunday = new TimeSpan(13, 10, 0),
                    Monday = new TimeSpan(13, 11, 0),
                    Tuesday = new TimeSpan(13, 12, 0),
                    Wednesday = new TimeSpan(13, 13, 0),
                    Thursday = new TimeSpan(13, 14, 0),
                    Friday = new TimeSpan(13, 15, 0),
                    Saturday = new TimeSpan(13, 16, 0),
                    Name = "ShiftGuarantee1",
                    WorkRule = "WorkRule0"
                },
                new ShiftGuarantee
                {
                    ReductByAmountTardy = true,
                    Sunday = new TimeSpan(14, 10, 0),
                    Monday = new TimeSpan(14, 11, 0),
                    Tuesday = new TimeSpan(14, 12, 0),
                    Wednesday = new TimeSpan(14, 13, 0),
                    Thursday = new TimeSpan(14, 14, 0),
                    Friday = new TimeSpan(14, 15, 0),
                    Saturday = new TimeSpan(14, 16, 0),
                    Name = "ShiftGuarantee1",
                    WorkRule = "WorkRule1"
                },
                new ShiftGuarantee
                {
                    ReductByAmountTardy = true,
                    Sunday = new TimeSpan(15, 10, 0),
                    Monday = new TimeSpan(15, 11, 0),
                    Tuesday = new TimeSpan(15, 12, 0),
                    Wednesday = new TimeSpan(15, 13, 0),
                    Thursday = new TimeSpan(15, 14, 0),
                    Friday = new TimeSpan(15, 15, 0),
                    Saturday = new TimeSpan(15, 16, 0),
                    Name = "ShiftGuarantee2",
                    WorkRule = "WorkRule2"
                }
            };

            var mapper = new ShiftGuaranteeMapper();
            var result = mapper.Map(wtkProfiles, data);

            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            var ind = 1;
            for (int i = 0; i <= 1; i++)
            {
                if (i == 1)
                    ind = 2;
                Assert.AreEqual("FullName" + ind, result[i].PayRule.FullName);
                Assert.AreEqual("PersonNumber" + ind, result[i].PayRule.PersonNumber);
                Assert.AreEqual("PayRuleName" + ind, result[i].PayRule.PayRuleName);
                Assert.AreEqual("BonusDeductRuleName" + ind, result[i].BonusDeductRuleName);
                Assert.AreEqual("BreakRuleNames" + ind, result[i].BreakRuleNames);
                Assert.AreEqual("WorkruleName" + ind, result[i].WorkruleName);
                Assert.AreEqual(true, result[i].ShiftGuarantee.ReductByAmountTardy);
                Assert.AreEqual("ShiftGuarantee" + ind, result[i].ShiftGuarantee.Name);
                Assert.AreEqual("WorkRule" + ind, result[i].ShiftGuarantee.WorkRule);
                Assert.AreEqual(new TimeSpan(14 + ind - 1, 10, 0), result[i].ShiftGuarantee.Sunday);
                Assert.AreEqual(new TimeSpan(14 + ind - 1, 11, 0), result[i].ShiftGuarantee.Monday);
                Assert.AreEqual(new TimeSpan(14 + ind - 1, 12, 0), result[i].ShiftGuarantee.Tuesday);
                Assert.AreEqual(new TimeSpan(14 + ind - 1, 13, 0), result[i].ShiftGuarantee.Wednesday);
                Assert.AreEqual(new TimeSpan(14 + ind - 1, 14, 0), result[i].ShiftGuarantee.Thursday);
                Assert.AreEqual(new TimeSpan(14 + ind - 1, 15, 0), result[i].ShiftGuarantee.Friday);
                Assert.AreEqual(new TimeSpan(14 + ind - 1, 16, 0), result[i].ShiftGuarantee.Saturday);
            }
        }
    }
}
