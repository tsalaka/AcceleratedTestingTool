using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Commands.Exceptions;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData.Criterias;
using Kronos.AcceleratedTool.Models.TestSharedModel.Schedules;
using Moq;
using NUnit.Framework;

namespace Kronos.AcceleratedTool.Jobs.Tests.PunchRoundTests
{
    [TestFixture]
    public class PopulatePunchRoundTestDataJobTests : PunchRoundTestBaseJobTests
    {
        [SetUp]
        public new void SetUp()
        {
            Job = new PopulatePunchRoundTestDataJob(CommandExecutor.Object, OutputDirectory, StatusTracker, Logger.Object);

            base.SetUp();
        }

        [Test]
        public void TestJobFailsIfPersonNumbersAreNull()
        {
            JobFailsIfPersonNumbersAreNull();
        }

        [Test]
        public void TestJobIsCompletedSuccessfullyIfAnExceptionOccursDuringScheduleRemoving()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };
            var exception = new RemoveTimesheetItemException(null, null, TimesheetItemType.Schedule);
            CommandExecutor.Setup(w => w.Execute<List<PersonSchedule>>(It.IsAny<List<PersonSchedule>>())).Throws(exception);
            var jobStatus = Job.Run(criteria);
            Assert.AreEqual(JobStatus.Success, jobStatus);
        }

        [Test]
        public void TestJobIsCompletedWithWarningIfThereAreNoScheduleDataToAdd()
        {
            JobIsCompletedWithWarningIfThereAreNoScheduleDataToProcess();
        }

        [Test]
        public void TestJobFailsIfThereScheduleDataIsOutOfDateRangeToAdd()
        {
            JobFailsIfThereScheduleDataIsOutOfDateRangeToProcess();
        }

        [Test]
        public void TestJobIsCompletedWithWarningIfThereAreNoPunchDataToAdd()
        {
            JobIsCompletedWithWarningIfThereAreNoPunchDataToProcess();
        }

        [Test]
        public void TestJobIsCompletedWithWarningIfThereIsAtLeastOneWarining()
        {
            JobIsCompletedWithWarningIfThereIsAtLeastOneWarining();
        }

        [Test]
        public void TestJobFailsIfTherePunchDataIsOutOfDateRangeToAdd()
        {
           JobFailsIfTherePunchDataIsOutOfDateRangeToProcess();
        }

        [Test]
        public void TestJobThrowsDependentJobWasNotRunException()
        {
            JobThrowsDependentJobWasNotRunException();
        }

        [Test]
        public void TestJobThrowsSourceFileWasNotFoundException()
        {
            JobThrowsSourceFileWasNotFoundException();
        }

        [Test]
        public void TestJobThrowsFileNotAccessibleException()
        {
            JobThrowsFileNotAccessibleException();
        }
    }
}
