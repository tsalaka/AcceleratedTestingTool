using AcceleratedTool.Commands.Criterias;

namespace AcceleratedTool.Jobs
{
    public class OutputFileDictionary
    {
        private readonly OutputDirectory _outputDirectory;

        public OutputFileDictionary(OutputDirectory outputDirectory)
        {
            _outputDirectory = outputDirectory;
        }

        public ExtractOutputData OneEePerPayRule
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("OneEEperPayrule.xlsx"),
                    SheetName = "Included for Testing"
                };
            }
        }

        public ExtractOutputData OneEePerPayRuleExtra
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("OneEEperPayruleExtra.xlsx"),
                    SheetName = "Excluded for Testing"
                };
            }
        }

        public ExtractOutputData PayRuleBuilding
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("PayruleBuildingBlockResult.xlsx")
                };
            }
        }

        public ExtractOutputData PayRuleBuildingReformat
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("PayruleBuildingBlockResult_Reformat.xlsx"),
                    SheetName = "Payrules"
                };
            }
        }

        public ExtractOutputData TestingSummaryReport
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("TestingSummaryReport.xlsx")
                };
            }
        }

        public ExtractOutputData OneEePerAccrualProfile
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("OneEEperAccrualProfile.xlsx")
                };
            }
        }

        public ExtractOutputData ProfileAssignment
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("ProfileAssignment.xlsx")
                };
            }
        }

        public ExtractOutputData OneEePerWatProfile
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("OneEEperWATProfile.xlsx")
                };
            }
        }

        public ExtractOutputData EmployeeRuleSet
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("EmployeeRuleSet.xlsx")
                };
            }
        }

        public ExtractOutputData OvertimeDailyData
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("OvertimeTestingWorkbook.xlsx"),
                    SheetName = "DailyOvertime"
                };
            }
        }

        public ExtractOutputData OvertimWeeklyData
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("OvertimeTestingWorkbook.xlsx"),
                    SheetName = "WeeklyOvertime"
                };
            }
        }

        public ExtractOutputData OvertimBiWeeklyData
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("OvertimeTestingWorkbook.xlsx"),
                    SheetName = "Bi-Weekly & PayPeriod Overtime"
                };
            }
        }

        public ExtractOutputData TimesheetSourcePunch
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.SourceFilePath("TimesheetSource.xlsx"),
                    SheetName = "Punch"
                };
            }
        }

        public ExtractOutputData TimesheetSourceSchedule
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.SourceFilePath("TimesheetSource.xlsx"),
                    SheetName = "Schedule"
                };
            }
        }

        public ExtractOutputData TimesheetSourcePaycodeEdit
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.SourceFilePath("TimesheetSource.xlsx"),
                    SheetName = "PaycodeEdit"
                };
            }
        }

        public ExtractOutputData PunchRoundPunchSource
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.SourceFilePath("PunchRoundSource.xlsx"),
                    SheetName = "Punch"
                };
            }
        }

        public ExtractOutputData PunchRoundScheduleSource
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.SourceFilePath("PunchRoundSource.xlsx"),
                    SheetName = "Schedule"
                };
            }
        }

        public ExtractOutputData PunchRoundTestingWorkBook
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("PunchRoundTestingWorkbook.xlsx"),
                    SheetName = "PunchRound"
                };
            }
        }

        public ExtractOutputData ShiftGuaranteeTestingWorkbook
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("ShiftGuaranteeTestingWorkbook.xlsx"),
                    SheetName = "ShiftGuarantee"
                };
            }
        }

        public ExtractOutputData TimecardDailyData
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("TimesheetTestingWorkbook.xlsx"),
                    SheetName = "DailyTotal"
                };
            }
        }

        public ExtractOutputData TimecardPeriodData
        {
            get
            {
                return new ExtractOutputData
                {
                    FilePath = _outputDirectory.ExcelFilePath("TimesheetTestingWorkbook.xlsx"),
                    SheetName = "PayperiodTotal"
                };
            }
        }
    }
}
