using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Requests
{
    public class Punch
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("Date")]
        public string DateString
        {
            get { return Date.ToApiDateFormat(); }
            set { Date = value.ToApiDateFormat(); }
        }

        [XmlIgnore]
        public TimeSpan Time { get; set; }

        [XmlAttribute("Time")]
        public string TimeString
        {
            get { return Time.ToApi12HourTimeFormat(); }
            set { Time = value.ToApi12HourTimeFormat(); }
        }

        [XmlAttribute]
        public string OverrideTypeName { get; set; }

        public Employee Employee { get; set; }
    }
}
