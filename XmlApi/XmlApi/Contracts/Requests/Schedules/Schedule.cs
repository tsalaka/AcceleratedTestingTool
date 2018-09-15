using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Requests.Schedules
{
    public class Schedule
    {
        [XmlIgnore]
        public DateTime? QueryDateStart { get; set; }

        [XmlIgnore]
        public DateTime? QueryDateEnd { get; set; }

        [XmlAttribute]
        public string QueryDateSpan
        {
            get
            {
                if (QueryDateStart.HasValue && QueryDateEnd.HasValue)
                    return DateRange.ToDateRangeDate(QueryDateStart.Value, QueryDateEnd.Value);
                return string.Empty;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public List<ScheduleShift> ScheduleItems { get; set; }

        public Employee Employees { get; set; }
    }
}
