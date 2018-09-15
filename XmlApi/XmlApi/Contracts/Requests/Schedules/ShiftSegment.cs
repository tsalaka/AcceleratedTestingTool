using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Requests.Schedules
{
    public class ShiftSegment
    {
        [XmlAttribute]
        public int StartDayNumber { get; set; }

        [XmlIgnore]
        public TimeSpan StartTime { get; set; }

        [XmlAttribute("StartTime")]
        public string StartTimeString
        {
            get { return StartTime.ToApi24HourTimeFormat(); }
            set { StartTime = value.ToApi24HourTimeFormat(); }
        }

        [XmlAttribute]
        public int EndDayNumber { get; set; }

        [XmlIgnore]
        public TimeSpan EndTime { get; set; }

        [XmlAttribute("EndTime")]
        public string EndTimeString
        {
            get { return EndTime.ToApi24HourTimeFormat(); }
            set { EndTime = value.ToApi24HourTimeFormat(); }
        }
    }
}
