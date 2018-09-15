using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Criterias;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.TestSharedModel.PayCodeEdits;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.TestSharedMappers
{
    [TestFixture]
    public class ChangePayCodeEditMapperTests
    {
        public ChangePayCodeEditCriteria SetUp(int count, int year, int month, int day)
        {
            var data = new List<PayRule>();
            for (int i = 1; i <= count; i++)
            {
                data.Add(new PayRule
                {
                    PersonNumber = "PersonNumber" + i
                });
            }

            var mapper = new ChangePayCodeEditMapper();
            var criteria = new ChangePayCodeEditCriteria
            {
                PayRules = data,
                PayCodeEditList = new List<ChangePayCodeEdit>
                {
                    new ChangePayCodeEdit
                    {
                        Date = new DateTime(year, month, day),
                        StartTime = new TimeSpan(9, 0, 0),
                        PayCodeName = "PayCodeName",
                        AmountInTimeOrCurrency = "AmountInTimeOrCurrency"
                    },
                    new ChangePayCodeEdit
                    {
                        Date = new DateTime(year, month, day + 1),
                        StartTime = new TimeSpan(12, 45, 0),
                        PayCodeName = "PayCodeName2",
                        AmountInTimeOrCurrency = "AmountInTimeOrCurrency2"
                    }
                }
            };

            return criteria;
        }

        [Test]
        [TestCase(5, 2017, 2, 12)]
        [TestCase(9, 2017, 3, 12)]
        public void TestChangePayCodeEditCriteriaMapToChangePayCodeEditCorrectly(int count, int year, int month, int day)
        {
            var criteria = SetUp(count, year, month, day);
            var mapper = new ChangePayCodeEditMapper();

            var result = mapper.Map(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.PayCodeEditList.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count*criteria.PayCodeEditList.Count; i++)
            {
                if (i%2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(9, 0, 0), result[i - 1].StartTime);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual("AmountInTimeOrCurrency", result[i - 1].AmountInTimeOrCurrency);
                    Assert.AreEqual("PayCodeName", result[i - 1].PayCodeName);
                }
                else
                {
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(12, 45, 0), result[i - 1].StartTime);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual("AmountInTimeOrCurrency2", result[i - 1].AmountInTimeOrCurrency);
                    Assert.AreEqual("PayCodeName2", result[i - 1].PayCodeName);
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
        public void TestChangePayCodeEditCriteriaMapToAddPayCodeEditCorrectly(int count, int year, int month, int day)
        {
            var criteria = SetUp(count, year, month, day);
            criteria.ActionType = ActionType.Add;
            var mapper = new ChangePayCodeEditMapper();

            var result = mapper.MapCriteriaToAddPayCodeEdits(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.PayCodeEditList.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.PayCodeEditList.Count; i++)
            {
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(9, 0, 0), result[i - 1].StartTime);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual("AmountInTimeOrCurrency", result[i - 1].AmountInTimeOrCurrency);
                    Assert.AreEqual("PayCodeName", result[i - 1].PayCodeName);
                }
                else
                {
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(12, 45, 0), result[i - 1].StartTime);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual("AmountInTimeOrCurrency2", result[i - 1].AmountInTimeOrCurrency);
                    Assert.AreEqual("PayCodeName2", result[i - 1].PayCodeName);
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
        public void TestChangePayCodeEditCriteriaMapToRemovePayCodeEditCorrectly(int count, int year, int month, int day)
        {
            var criteria = SetUp(count, year, month, day);
            criteria.ActionType = ActionType.Remove;
            var mapper = new ChangePayCodeEditMapper();

            var result = mapper.MapCriteriaToRemoveCodeEdits(criteria);

            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.PayCodeEditList.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.PayCodeEditList.Count; i++)
            {
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(9, 0, 0), result[i - 1].StartTime);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual("AmountInTimeOrCurrency", result[i - 1].AmountInTimeOrCurrency);
                    Assert.AreEqual("PayCodeName", result[i - 1].PayCodeName);
                }
                else
                {
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].Date);
                    Assert.AreEqual(new TimeSpan(12, 45, 0), result[i - 1].StartTime);
                    Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                    Assert.AreEqual("AmountInTimeOrCurrency2", result[i - 1].AmountInTimeOrCurrency);
                    Assert.AreEqual("PayCodeName2", result[i - 1].PayCodeName);
                    if (i == count)
                        personIndex = 1;
                    else
                        personIndex++;
                }
            }
        }
    }
}
