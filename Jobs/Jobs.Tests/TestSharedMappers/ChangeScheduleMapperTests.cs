using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Criterias;
using Kronos.AcceleratedTool.Jobs.TestSharedJobs.Mappers;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.TestSharedModel.Schedules;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.TestSharedMappers
{
    [TestFixture]
    public class ChangeScheduleMapperTests
    {
        public ChangeScheduleCriteria SetUp(int count, int year, int month, int day)
        {
            var data = new List<PayRule>();
            for (int i = 1; i <= count; i++)
            {
                data.Add(new PayRule
                {
                    PersonNumber = "PersonNumber" + i
                });
            }

            var criteria = new ChangeScheduleCriteria
            {
                PayRules = data,
                Schedules = new List<ChangeSchedule>
                {
                    new ChangeSchedule
                    {
                        StartDate = new DateTime(year, month, day),
                        EndDate = new DateTime(year, month, day + 1),
                        ShiftStartDayNumber = 1,
                        ShiftEndDayNumber = 1,
                        ShiftStartDate = new DateTime(year, month, day + 2),
                        ShiftStartTime = new TimeSpan(9, 15, 0),
                        ShiftEndTime = new TimeSpan(9, 20, 0)
                    },
                    new ChangeSchedule
                    {
                        StartDate = new DateTime(year, month, day),
                        EndDate = new DateTime(year, month, day + 2),
                        ShiftStartDayNumber = 2,
                        ShiftEndDayNumber = 2,
                        ShiftStartDate = new DateTime(year, month, day + 3),
                        ShiftStartTime = new TimeSpan(7, 5, 0),
                        ShiftEndTime = new TimeSpan(8, 20, 0)
                    }
                }
            };
            return criteria;
        }

        [Test]
        [TestCase(5, 2017, 2, 12)]
        [TestCase(9, 2017, 3, 12)]
        public void TestChangeScheduleCriteriaMapToChangePersonScheduleCorrectly(int count, int year, int month, int day)
        {
            var criteria = SetUp(count, year, month, day);

            var mapper = new ChangeScheduleMapper();

            var result = mapper.Map(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.Schedules.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.Schedules.Count; i++)
            {
                Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].StartDate);
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].EndDate);
                    Assert.AreEqual(new DateTime(year, month, day + 2), result[i - 1].ShiftStartDate);
                    Assert.AreEqual(new TimeSpan(9, 15, 0), result[i - 1].ShiftStartTime);
                    Assert.AreEqual(new TimeSpan(9, 20, 0), result[i - 1].ShiftEndTime);
                    Assert.AreEqual(1, result[i - 1].ShiftStartDayNumber);
                    Assert.AreEqual(1, result[i - 1].ShiftEndDayNumber);
                }
                else
                {

                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].StartDate);
                    Assert.AreEqual(new DateTime(year, month, day + 2), result[i - 1].EndDate);
                    Assert.AreEqual(new DateTime(year, month, day + 3), result[i - 1].ShiftStartDate);
                    Assert.AreEqual(new TimeSpan(7, 5, 0), result[i - 1].ShiftStartTime);
                    Assert.AreEqual(new TimeSpan(8, 20, 0), result[i - 1].ShiftEndTime);
                    Assert.AreEqual(2, result[i - 1].ShiftStartDayNumber);
                    Assert.AreEqual(2, result[i - 1].ShiftEndDayNumber);
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
        public void TestChangeScheduleCriteriaMapToAddPersonScheduleCorrectly(int count, int year, int month, int day)
        {
            var criteria = SetUp(count, year, month, day);
            criteria.ActionType = ActionType.Add;
            var mapper = new ChangeScheduleMapper();

            var result = mapper.MapToAddSchedules(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.Schedules.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.Schedules.Count; i++)
            {
                Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].StartDate);
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].EndDate);
                    Assert.AreEqual(new DateTime(year, month, day + 2), result[i - 1].ShiftStartDate);
                    Assert.AreEqual(new TimeSpan(9, 15, 0), result[i - 1].ShiftStartTime);
                    Assert.AreEqual(new TimeSpan(9, 20, 0), result[i - 1].ShiftEndTime);
                    Assert.AreEqual(1, result[i - 1].ShiftStartDayNumber);
                    Assert.AreEqual(1, result[i - 1].ShiftEndDayNumber);
                }
                else
                {

                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].StartDate);
                    Assert.AreEqual(new DateTime(year, month, day + 2), result[i - 1].EndDate);
                    Assert.AreEqual(new DateTime(year, month, day + 3), result[i - 1].ShiftStartDate);
                    Assert.AreEqual(new TimeSpan(7, 5, 0), result[i - 1].ShiftStartTime);
                    Assert.AreEqual(new TimeSpan(8, 20, 0), result[i - 1].ShiftEndTime);
                    Assert.AreEqual(2, result[i - 1].ShiftStartDayNumber);
                    Assert.AreEqual(2, result[i - 1].ShiftEndDayNumber);
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
        public void TestChangeScheduleCriteriaMapToRemovePersonScheduleCorrectly(int count, int year, int month, int day)
        {
            var criteria = SetUp(count, year, month, day);
            criteria.ActionType = ActionType.Remove;
            var mapper = new ChangeScheduleMapper();

            var result = mapper.MapToRemoveSchedules(criteria);
            Assert.NotNull(result);
            Assert.AreEqual(count * criteria.Schedules.Count, result.Count);
            var personIndex = 1;
            for (int i = 1; i <= count * criteria.Schedules.Count; i++)
            {
                Assert.AreEqual("PersonNumber" + personIndex, result[i - 1].PersonNumber);
                if (i % 2 != 0)
                {
                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].StartDate);
                    Assert.AreEqual(new DateTime(year, month, day + 1), result[i - 1].EndDate);
                    Assert.AreEqual(new DateTime(year, month, day + 2), result[i - 1].ShiftStartDate);
                    Assert.AreEqual(new TimeSpan(9, 15, 0), result[i - 1].ShiftStartTime);
                    Assert.AreEqual(new TimeSpan(9, 20, 0), result[i - 1].ShiftEndTime);
                    Assert.AreEqual(1, result[i - 1].ShiftStartDayNumber);
                    Assert.AreEqual(1, result[i - 1].ShiftEndDayNumber);
                }
                else
                {

                    Assert.AreEqual(new DateTime(year, month, day), result[i - 1].StartDate);
                    Assert.AreEqual(new DateTime(year, month, day + 2), result[i - 1].EndDate);
                    Assert.AreEqual(new DateTime(year, month, day + 3), result[i - 1].ShiftStartDate);
                    Assert.AreEqual(new TimeSpan(7, 5, 0), result[i - 1].ShiftStartTime);
                    Assert.AreEqual(new TimeSpan(8, 20, 0), result[i - 1].ShiftEndTime);
                    Assert.AreEqual(2, result[i - 1].ShiftStartDayNumber);
                    Assert.AreEqual(2, result[i - 1].ShiftEndDayNumber);
                    if (i == count)
                        personIndex = 1;
                    else
                        personIndex++;
                }
            }
        }
    }
}
