using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Criterias;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.TestSharedModel.Punches;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.TestSharedMappers
{
    [TestFixture]
    public class ChangePunchMapperTests
    {
        public ChangePunchCriteria SetUp(int count, int year, int month, int day)
        {
            var data = new List<PayRule>();
            for (int i = 1; i <= count; i++)
            {
                data.Add(new PayRule
                {
                    PersonNumber = "PersonNumber" + i
                });
            }
            var punches = new List<ChangePunch>
            {
                new ChangePunch
                {
                    Date = new DateTime(year, month, day),
                    Time = new TimeSpan(9, 0, 0),
                    Type = PunchType.InPunch
                },
                new ChangePunch
                {
                    Date = new DateTime(year, month, day + 1),
                    Time = new TimeSpan(12, 30, 0),
                    Type = PunchType.InPunch
                }
            };

            var criteria = new ChangePunchCriteria
            {
                PayRules = data,
                Punches = punches
            };

            return criteria;
        }

        [Test]
        [TestCase(5, 2017, 2, 12)]
        [TestCase(9, 2017, 3, 12)]
        public void TestChangePersonPunchCriteriaMapToChangePersonPunchCorrectly(int count, int year, int month, int day)
        {
            var mapper = new ChangePunchMapper();
            var criteria = SetUp(count, year, month, day);

            var result = mapper.Map(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.Punches.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.Punches.Count; i++)
            {
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(9, 0, 0), result[i - 1].Time);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual(PunchType.InPunch, result[i - 1].Type);
                }
                else
                {
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(12, 30, 0), result[i - 1].Time);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual(PunchType.InPunch, result[i - 1].Type);
                    if (i == count)
                        personIndex = 1;
                    else
                        personIndex++;
                }
            }
        }

        [Test]
        [TestCase(5, 2017, 2, 12)]
        [TestCase(9, 2017, 3, 12)]
        public void TestChangePersonPunchCriteriaMapToAddPersonPunchCorrectly(int count, int year, int month, int day)
        {
            var mapper = new ChangePunchMapper();
            var criteria = SetUp(count, year, month, day);
            criteria.ActionType = ActionType.Add;
            var result = mapper.MapCriteriaToAddPunches(criteria);

            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.Punches.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.Punches.Count; i++)
            {
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(9, 0, 0), result[i - 1].Time);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual(PunchType.InPunch, result[i - 1].Type);
                }
                else
                {
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(12, 30, 0), result[i - 1].Time);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual(PunchType.InPunch, result[i - 1].Type);
                    if (i == count)
                        personIndex = 1;
                    else
                        personIndex++;
                }
            }
        }

        [Test]
        [TestCase(5, 2017, 2, 12)]
        [TestCase(9, 2017, 3, 12)]
        public void TestChangePersonPunchCriteriaMapToRemovePersonPunchCorrectly(int count, int year, int month, int day)
        {
            var mapper = new ChangePunchMapper();
            var criteria = SetUp(count, year, month, day);
            criteria.ActionType = ActionType.Remove;

            var result = mapper.MapCriteriaToRemovePunches(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.Punches.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.Punches.Count; i++)
            {
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(9, 0, 0), result[i - 1].Time);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual(PunchType.InPunch, result[i - 1].Type);
                }
                else
                {
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(12, 30, 0), result[i - 1].Time);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual(PunchType.InPunch, result[i - 1].Type);
                    if (i == count)
                        personIndex = 1;
                    else
                        personIndex++;
                }
            }
        }
    }
}
