using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Requests
{
    public class TimeFramePeriod
    {
        [XmlAttribute]
        public string TimeFrameName { get; set; }

        [XmlIgnore]
        public DateTime? PeriodDateStart { get; set; }

        [XmlIgnore]
        public DateTime? PeriodDateEnd { get; set; }

        [XmlAttribute]
        public string PeriodDateSpan
        {
            get
            {
                if (PeriodDateStart.HasValue && PeriodDateEnd.HasValue)
                    return DateRange.ToDateRangeDate(PeriodDateStart.Value, PeriodDateEnd.Value);
                return string.Empty;
            }
            set
            {
                var tupleDates = value.ToDates();
                PeriodDateStart = tupleDates.Item1;
                PeriodDateEnd = tupleDates.Item2;
            }
        }
    }
}
