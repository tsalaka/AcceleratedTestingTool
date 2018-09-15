using System;

namespace AcceleratedTool.Jobs.Exceptions
{
    public class DateOutOfRangeValidationException : Exception
    {
        public DateOutOfRangeValidationException(DateTime startDate, DateTime endDate, string filename)
        {
            StartDate = startDate;
            EndDate = endDate;
            Filename = filename;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Filename { get; }

        public override string Message
        {
            get
            {
                return string.Format("All dates in the spreadsheet should be in range {0} and {1}", StartDate.ToShortDateString(), EndDate.ToShortDateString());
            }
        }
    }
}
