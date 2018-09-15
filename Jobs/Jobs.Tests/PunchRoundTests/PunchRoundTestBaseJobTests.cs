using System;
using System.Collections.Generic;
using Kronos.AcceleratedTool.Commands.Criterias;
using Kronos.AcceleratedTool.Commands.Exceptions;
using Kronos.AcceleratedTool.Jobs.GetPunchRoundTestData.Criterias;
using Kronos.AcceleratedTool.Models.PayRuleBuilding;
using Moq;
using NUnit.Framework;
using Kronos.AcceleratedTool.Commands;
using Kronos.AcceleratedTool.Commands.Results;
using Kronos.AcceleratedTool.Jobs.Exceptions;
using Kronos.AcceleratedTool.Jobs.JobStatusTracking;
using Kronos.AcceleratedTool.Jobs.Logs;
using Kronos.AcceleratedTool.Models.Employees;
using Kronos.AcceleratedTool.Models.PunchRoundRules;
using Kronos.AcceleratedTool.Models.TestSharedModel;
using Kronos.AcceleratedTool.Models.TestSharedModel.PayCodeEdits;
using Kronos.AcceleratedTool.Models.TestSharedModel.Punches;
using Kronos.AcceleratedTool.Models.TestSharedModel.Schedules;

namespace Kronos.AcceleratedTool.Jobs.Tests.PunchRoundTests
{
    public class PunchRoundTestBaseJobTests
    {
        protected readonly Mock<ICommandExecutor> CommandExecutor = new Mock<ICommandExecutor>();
        protected readonly JobStatusTracker StatusTracker = new JobStatusTracker(new JobStatusNotifier());
        protected readonly Mock<ILogger> Logger = new Mock<ILogger>();
        protected readonly OutputFileDictionary OutputDirectory = new OutputFileDictionary(new OutputDirectory
        {
            ExcelFolder = "Excel",
            SourceFolder = "Source",
            Path = "Path"
        });

        protected IParameterisedJob<PunchRoundTestCriteria> Job;

        protected void SetUp()
        {
            var schedules = new List<PersonSchedule>
            {
                new PersonSchedule()
            };

            CommandExecutor.Setup(w => w.Execute<List<PersonSchedule>>()).Returns(schedules);
            var wtkProfiles = new List<WtkProfile>
            {
                new WtkProfile
                {
                    PayRule = new PayRule()
                }
            };

            CommandExecutor.Setup(w => w.Execute<WtkProfileExtractOutputData, List<WtkProfile>>(It.IsAny<WtkProfileExtractOutputData>())).Returns(wtkProfiles);
            CommandExecutor.Setup(w => w.Execute<List<PunchRoundRule>>()).Returns(new List<PunchRoundRule>());
            CommandExecutor.Setup(w => w.Execute<List<BreakRule>>()).Returns(new List<BreakRule>());
            var timesheets = new List<Timesheet>()
            {
                new Timesheet
                {
                    TotaledSpans = new List<TotaledSpan>
                    {
                        new TotaledSpan
                        {
                            PersonNumber = "PersonNumber",
                            InPunch = new PersonPunch(),
                            OutPunch = new PersonPunch()
                        }
                    },
                    PayCodeEditList = new List<PersonPayCodeEdit>
                    {
                        new PersonPayCodeEdit
                        {
                            PersonNumber = "PersonNumber"
                        }
                    }
                }
            };

            CommandExecutor.Setup(w => w.Execute<List<Timesheet>, List<Timesheet>>(It.IsAny<List<Timesheet>>())).Returns(timesheets);

            var punchDataResult = new TimesheetReadCommandResult<List<ChangePunch>>()
            {
                Data = new List<ChangePunch>
                {
                    new ChangePunch {Type = PunchType.InPunch, Date = new DateTime(2017, 4, 16)}
                }
            };

            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangePunch>>>(It.IsAny<TimesheetExtractOutputData>())).Returns(punchDataResult);

            var scheduleDataResult = new TimesheetReadCommandResult<List<ChangeSchedule>>()
            {
                Data = new List<ChangeSchedule>
                {
                    new ChangeSchedule { StartDate = new DateTime(2017, 4, 16)}
                }
            };
            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangeSchedule>>>(It.IsAny<TimesheetExtractOutputData>())).Returns(scheduleDataResult);
        }

        public void JobFailsIfPersonNumbersAreNull()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };
            CommandExecutor.Setup(w => w.Execute<WtkProfileExtractOutputData, List<WtkProfile>>(It.IsAny<WtkProfileExtractOutputData>())).Returns(new List<WtkProfile>());

            var jobStatus = Job.Run(criteria);
            Assert.AreEqual(JobStatus.SuccessWithWarnings, jobStatus);
        }

        protected void JobThrowsFileNotAccessibleException()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var exception = new FileNotAccessibleException("fileName", null);
            CommandExecutor.Setup(w => w.Execute<WtkProfileExtractOutputData, List<WtkProfile>>(It.IsAny<WtkProfileExtractOutputData>()))
                 .Throws(exception);

            Assert.Throws<FileNotAccessibleException>(() => Job.Run(criteria));
        }

        protected void JobThrowsSourceFileWasNotFoundException()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var exception = new FileNotExistException("fileName", null);
            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangePunch>>>(It.IsAny<TimesheetExtractOutputData>())).Throws(exception);


            Assert.Throws<SourceFileWasNotFoundException>(() => Job.Run(criteria));
        }

        protected void JobThrowsDependentJobWasNotRunException()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var exception = new FileNotExistException("fileName", null);
            CommandExecutor.Setup(w => w.Execute<WtkProfileExtractOutputData, List<WtkProfile>>(It.IsAny<WtkProfileExtractOutputData>()))
                .Throws(exception);

            Assert.Throws<DependentJobWasNotRunException>(() => Job.Run(criteria));
        }

        protected void JobFailsIfTherePunchDataIsOutOfDateRangeToProcess()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var data = new TimesheetReadCommandResult<List<ChangePunch>>()
            {
                Data = new List<ChangePunch>()
                {
                    new ChangePunch { Date = new DateTime(2016, 1, 1)},
                    new ChangePunch { Date = new DateTime(2016, 4, 16)}
                }
            };
            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangePunch>>>(It.IsAny<TimesheetExtractOutputData>())).Returns(data);

            Assert.Throws<DateOutOfRangeValidationException>(() => Job.Run(criteria));
        }

        public void JobIsCompletedWithWarningIfThereAreNoScheduleDataToProcess()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var scheduleDataResult = new TimesheetReadCommandResult<List<ChangeSchedule>>()
            {
                Data = new List<ChangeSchedule>()
            };
            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangeSchedule>>>(It.IsAny<TimesheetExtractOutputData>())).Returns(scheduleDataResult);

            var jobStatus = Job.Run(criteria);
            Logger.Verify(m => m.Warn("There is no valid schedule data", It.IsAny<string>(), null));

            Assert.AreEqual(JobStatus.SuccessWithWarnings, jobStatus);
        }

        public void JobFailsIfThereScheduleDataIsOutOfDateRangeToProcess()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var scheduleDataResult = new TimesheetReadCommandResult<List<ChangeSchedule>>()
            {
                Data = new List<ChangeSchedule>()
                {
                    new ChangeSchedule { StartDate = new DateTime(2016, 1, 1)},
                    new ChangeSchedule { EndDate = new DateTime(2018, 1, 1)}
                }
            };
            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangeSchedule>>>(It.IsAny<TimesheetExtractOutputData>())).Returns(scheduleDataResult);

            Assert.Throws<DateOutOfRangeValidationException>(() => Job.Run(criteria));
        }

        public void JobIsCompletedWithWarningIfThereAreNoPunchDataToProcess()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var data = new TimesheetReadCommandResult<List<ChangePunch>>()
            {
                Data = new List<ChangePunch>()
            };
            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangePunch>>>(It.IsAny<TimesheetExtractOutputData>())).Returns(data);

            var jobStatus = Job.Run(criteria);
            Logger.Verify(m => m.Warn("There are no valid punches", It.IsAny<string>(), null));

            Assert.AreEqual(JobStatus.SuccessWithWarnings, jobStatus);
        }

        public void JobIsCompletedWithWarningIfThereIsAtLeastOneWarining()
        {
            var criteria = new PunchRoundTestCriteria()
            {
                StartDate = new DateTime(2017, 4, 10)
            };

            var data = new TimesheetReadCommandResult<List<ChangePunch>>()
            {
                Data = new List<ChangePunch> { new ChangePunch { Date = new DateTime(2017, 4, 16) } },
                Warnings = new List<TimesheetValidationType> { TimesheetValidationType.PunchEmptyDay }
            };
            CommandExecutor.Setup(w => w.Execute<TimesheetExtractOutputData, TimesheetReadCommandResult<List<ChangePunch>>>(It.IsAny<TimesheetExtractOutputData>())).Returns(data);

            var jobStatus = Job.Run(criteria);
            Assert.AreEqual(JobStatus.SuccessWithWarnings, jobStatus);
        }
    }
}
