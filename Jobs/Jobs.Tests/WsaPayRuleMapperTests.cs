using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.GetPayRuleBuildingData.Mappers;
using Kronos.AcceleratedTool.Models.PayRuleBuilding;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests
{
    [TestFixture]
    public class WsaPayRuleMapperTests
    {
        [Test]
        public void TestThatWsaPayRuleModelMapToExcelEntityCorrectly()
        {
            var payRuleData = new List<WsaPayRule>
            {
                new WsaPayRule
                {
                    Name = "Name",
                    WorkRuleTransfers = true,
                    ApplyOnly = true,
                    CancelPfsOnHolidays = true,
                    EffectiveDate = new DateTime(2017, 1, 23),
                    FixedRuleName = "FixedRuleName",
                    HolidayCreditRuleName = "HolidayCreditRuleName",
                    LaborAccountAndJobTransfers = true,
                    PrepopulateProject = true,
                    QualifiedSignOffRuleName = true,
                    TerminalRuleName = "TerminalRuleName",
                    WorkRuleName = "WorkRuleName",
                    PayFromSchedule = true,
                    ScheduleTotal = true,
                    TransferRegularHome = true
                },
                new WsaPayRule
                {
                    WorkRuleTransfers = false,
                    ApplyOnly = false,
                    CancelPfsOnHolidays = false,
                    EffectiveDate = new DateTime(2017, 1, 24),
                    FixedRuleName = "FixedRuleName2",
                    HolidayCreditRuleName = "HolidayCreditRuleName2",
                    LaborAccountAndJobTransfers = false,
                    PrepopulateProject = false,
                    QualifiedSignOffRuleName = false,
                    TerminalRuleName = "TerminalRuleName2",
                    WorkRuleName = "WorkRuleName2",
                    PayFromSchedule = false,
                    ScheduleTotal = false,
                    TransferRegularHome = false
                }
            };

            var workRuleData = new List<WsaWorkRule>
            {
                new WsaWorkRule
                {
                    DayDivideOverride = "DayDivideOverride",
                    ExceptionRuleName = "ExceptionRuleName",
                    Name = "WorkRuleName",
                    RoundRuleName = "RoundRuleName",
                    WsaRuleNamesList = new List<WsaRuleNames>
                    {
                        new WsaRuleNames
                        {
                            BonusDeductRuleName = "BonusDeductRuleName",
                            BreakRuleName = "BreakRuleName"
                        },
                        new WsaRuleNames
                        {
                            BonusDeductRuleName = "BonusDeductRuleName",
                            BreakRuleName = "BreakRuleName2"
                        }
                    }
                },
                new WsaWorkRule
                {
                    DayDivideOverride = "DayDivideOverride2",
                    ExceptionRuleName = "ExceptionRuleName2",
                    Name = "WorkRuleName",
                    RoundRuleName = "RoundRuleName2",
                    WsaRuleNamesList = new List<WsaRuleNames>
                    {
                        new WsaRuleNames
                        {
                            BonusDeductRuleName = "BonusDeductRuleName",
                            BreakRuleName = "BreakRuleName"
                        },
                        new WsaRuleNames
                        {
                            BonusDeductRuleName = "BonusDeductRuleName2",
                            BreakRuleName = "BreakRuleName"
                        }
                    }
                }
            };

            var mapper = new WsaPayRuleMapper();
            var results = mapper.Map(payRuleData, workRuleData);
            Assert.NotNull(results);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(2, results[0].WorkRules.Count);
            Assert.AreEqual("WorkRuleName", results[0].WorkRules[0].Name);
            Assert.AreEqual("DayDivideOverride", results[0].WorkRules[0].DayDivideOverride);
            Assert.AreEqual("ExceptionRuleName", results[0].WorkRules[0].ExceptionRuleName);
            Assert.AreEqual("RoundRuleName", results[0].WorkRules[0].RoundRuleName);
            Assert.AreEqual("WorkRuleName", results[0].WorkRules[1].Name);
            Assert.AreEqual("DayDivideOverride2", results[0].WorkRules[1].DayDivideOverride);
            Assert.AreEqual("ExceptionRuleName2", results[0].WorkRules[1].ExceptionRuleName);
            Assert.AreEqual("RoundRuleName2", results[0].WorkRules[1].RoundRuleName);
            Assert.AreEqual(true, results[0].ApplyOnly);
            Assert.AreEqual(true, results[0].CancelPfsOnHolidays);
            Assert.AreEqual(true, results[0].LaborAccountAndJobTransfers);
            Assert.AreEqual(true, results[0].PayFromSchedule);
            Assert.AreEqual(true, results[0].PrepopulateProject);
            Assert.AreEqual("HolidayCreditRuleName", results[0].HolidayCreditRuleName);
            Assert.AreEqual("FixedRuleName", results[0].FixedRuleName);

            Assert.AreEqual(0, results[1].WorkRules.Count);
            Assert.AreEqual(false, results[1].ApplyOnly);
            Assert.AreEqual(false, results[1].CancelPfsOnHolidays);
            Assert.AreEqual(false, results[1].LaborAccountAndJobTransfers);
            Assert.AreEqual(false, results[1].PayFromSchedule);
            Assert.AreEqual(false, results[1].PrepopulateProject);
            Assert.AreEqual("HolidayCreditRuleName2", results[1].HolidayCreditRuleName);
            Assert.AreEqual("FixedRuleName2", results[1].FixedRuleName);
        }
    }
}
