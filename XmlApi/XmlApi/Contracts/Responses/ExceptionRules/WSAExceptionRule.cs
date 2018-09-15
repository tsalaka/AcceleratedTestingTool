using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.ExceptionRules
{
    public class WSAExceptionRule
    {
        [XmlIgnore]
        public TimeSpan? OutLate { get; set; }

        [XmlAttribute("OutLate")]
        public string OutLateString
        {
            get { return OutLate.ToApi24HourTimeFormat(); }
            set { OutLate = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InLate { get; set; }

        [XmlAttribute("InLate")]
        public string InLateString
        {
            get { return InLate.ToApi24HourTimeFormat(); }
            set { InLate = value.ToApi24HourTimeFormat(); }
        }

        [XmlAttribute]
        public string InVeryEarly { get; set; }

        [XmlAttribute]
        public string EarlyOutNdPayCodeName { get; set; }

        [XmlAttribute]
        public string Round { get; set; }

        [XmlIgnore]
        public TimeSpan? InEarly { get; set; }

        [XmlAttribute("InEarly")]
        public string InEarlyString
        {
            get { return InEarly.ToApi24HourTimeFormat(); }
            set { InEarly = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutEarly { get; set; }

        [XmlAttribute("OutEarly")]
        public string OutEarlyString
        {
            get { return OutEarly.ToApi24HourTimeFormat(); }
            set { OutEarly = value.ToApi24HourTimeFormat(); }
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string ShortShift { get; set; }

        [XmlAttribute]
        public string LateInNdPayCodeName { get; set; }

        [XmlAttribute]
        public string LongInterval { get; set; }

        [XmlAttribute]
        public string OutVeryLate { get; set; }

        [XmlIgnore]
        public bool? Unscheduled { get; set; }

        [XmlAttribute("Unscheduled")]
        public string UnscheduledString
        {
            get { return Unscheduled.ToApiBoolFormat(); }
            set { Unscheduled = value.ToApiNullableBoolFormat(); }
        }
    }
}
