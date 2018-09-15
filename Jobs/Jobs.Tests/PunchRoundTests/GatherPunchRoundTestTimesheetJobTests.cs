using System;
using Kronos.AcceleratedTool.Commands;
using Kronos.AcceleratedTool.Commands.Criterias.PunchRounds;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData.Criterias;
using Kronos.AcceleratedTool.Models.PunchRoundRules;
using NUnit.Framework;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Models.TestSharedModel.Schedules;
using Moq;

namespace Kronos.AcceleratedTool.Jobs.Tests.PunchRoundTests
{
    [TestFixture]
    public class GatherPunchRoundTestTimesheetJobTests : PunchRoundTestBaseJobTests
    {
        [SetUp]
        public new void SetUp()
        {
            Job = new GatherPunchRoundTestTimesheetJob(CommandExecutor.Object, OutputDirectory, StatusTracker, Logger.Object);

            base.SetUp();
        }

        [Test]
        public void TestJobThrowsDependentJobWasNotRunException()
        {
            JobThrowsDependentJobWasNotRunException();
        }

        [Test]
        public void TestJobThrowsFileNotAccessibleException()
        {
            JobThrowsFileNotAccessibleException();
        }

        [Test]
        public void TestGetDataRequestIsCalledWithCOrrectDateRange()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var personPunchRounds = new List<PersonPunchRound>
            {
                new PersonPunchRound()
            };
            CommandExecutor.Setup(
                    w => w.Execute<PersonPunchRoundCriteria, List<PersonPunchRound>>(It.IsAny<PersonPunchRoundCriteria>()))
                .Returns(personPunchRounds);

            CommandExecutor.Setup(w => w.Execute<PunchRoundExportData>(It.IsAny<PunchRoundExportData>()));

           var status =  Job.Run(criteria);

            CommandExecutor.Verify(m => m.Execute<PersonPunchRoundCriteria, List<PersonPunchRound>>
                (It.Is<PersonPunchRoundCriteria>(t => t.StartDate == criteria.StartDate && t.EndDate == criteria.StartDate.AddDays(63))),
                Times.Once);

            CommandExecutor.Verify(m => m.Execute<PunchRoundExportData>
                (It.Is<PunchRoundExportData>(p => p.PersonPunchRounds == personPunchRounds)),
                Times.Once);
            Assert.AreEqual(JobStatus.Success, status);
        }
    }
}
