using System;

namespace AcceleratedTool.Commands.Criterias
{
    public class TimesheetExtractOutputData : ExtractOutputData
    {
        public TimesheetExtractOutputData(DateTime startDate, string filePath, string sheet = null)
            : base(filePath, sheet)
        {
            StartDate = startDate;
        }

        public DateTime StartDate { get; set; }
    }
}
