using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Timesheets
{
    public class PeriodTotals
    {
        [XmlIgnore]
        public DateTime PeriodDateStart { get; set; }

        [XmlIgnore]
        public DateTime PeriodDateEnd { get; set; }

        [XmlAttribute]
        public string PeriodDateSpan
        {
            get
            {
                if (PeriodDateStart != DateTime.MinValue && PeriodDateEnd != DateTime.MinValue)
                    return DateRange.ToDateRangeDate(PeriodDateStart, PeriodDateEnd);
                return string.Empty;
            }
            set
            {
                var tupleDates = value.ToDates();
                PeriodDateStart = tupleDates.Item1;
                PeriodDateEnd = tupleDates.Item2;
            }
        }

        public List<Total> Totals { get; set; }
    }
}
