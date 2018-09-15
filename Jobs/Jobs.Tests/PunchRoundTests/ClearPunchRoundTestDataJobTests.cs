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
    public class ClearPunchRoundTestDataJobTests : PunchRoundTestBaseJobTests
    {
        [SetUp]
        public new void SetUp()
        {
            Job = new CleanUpPunchRoundTestDataJob(CommandExecutor.Object, OutputDirectory, StatusTracker, Logger.Object);

            base.SetUp();
        }

        [Test]
        public void TestJobFailsIfPersonNumbersAreNull()
        {
            JobFailsIfPersonNumbersAreNull();
        }

        [Test]
        public void TestJobIsCompletedWithWarningIfThereAreNoScheduleDataToRemove()
        {
            JobIsCompletedWithWarningIfThereAreNoScheduleDataToProcess();
        }

        [Test]
        public void TestJobFailsIfThereScheduleDataIsOutOfDateRangeToRemove()
        {
            JobFailsIfThereScheduleDataIsOutOfDateRangeToProcess();
        }

        [Test]
        public void TestJobIsCompletedWithWarningIfThereAreNoPunchDataToRemove()
        {
            JobIsCompletedWithWarningIfThereAreNoPunchDataToProcess();
        }

        [Test]
        public void TestJobIsCompletedWithWarningIfThereIsAtLeastOneWarining()
        {
            JobIsCompletedWithWarningIfThereIsAtLeastOneWarining();
        }

        [Test]
        public void TestJobFailsIfTherePunchDataIsOutOfDateRangeToRemove()
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
