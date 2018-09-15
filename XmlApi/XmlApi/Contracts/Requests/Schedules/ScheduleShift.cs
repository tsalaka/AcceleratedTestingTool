using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Requests.Schedules
{
    public class ScheduleShift
    {
        [XmlIgnore]
        public DateTime StartDate { get; set; }

        [XmlAttribute("StartDate")]
        public string StartDateString
        {
            get { return StartDate.ToApiDateFormat(); }
            set { StartDate = value.ToApiDateFormat(); }
        }

        public List<ShiftSegment> ShiftSegments { get; set; }
    }
}
