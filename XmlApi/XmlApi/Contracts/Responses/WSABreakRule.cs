using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class WSABreakRule
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public TimeSpan? ShortChangePoint { get; set; }

        [XmlAttribute("ShortChgPoint")]
        public string ShortChangePointString
        {
            get { return ShortChangePoint.ToApi24HourTimeFormat(); }
            set { ShortChangePoint = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? ShortRound { get; set; }

        [XmlAttribute("ShortRound")]
        public string ShortRoundString
        {
            get { return ShortRound.ToApi24HourTimeFormat(); }
            set { ShortRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? ShortGrace { get; set; }

        [XmlAttribute("ShortGrace")]
        public string ShortGraceString
        {
            get { return ShortGrace.ToApi24HourTimeFormat(); }
            set { ShortGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? LongChangePoint { get; set; }

        [XmlAttribute("LongChgPoint")]
        public string LongChangePointString
        {
            get { return LongChangePoint.ToApi24HourTimeFormat(); }
            set { LongChangePoint = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? LongRound { get; set; }

        [XmlAttribute("LongRound")]
        public string LongRoundString
        {
            get { return LongRound.ToApi24HourTimeFormat(); }
            set { LongRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? LongGrace { get; set; }

        [XmlAttribute("LongGrace")]
        public string LongGraceString
        {
            get { return LongGrace.ToApi24HourTimeFormat(); }
            set { LongGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? MediumRound { get; set; }

        [XmlAttribute("MediumRound")]
        public string MediumRoundString
        {
            get { return MediumRound.ToApi24HourTimeFormat(); }
            set { MediumRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? MediumGrace { get; set; }

        [XmlAttribute("MediumGrace")]
        public string MediumGraceString
        {
            get { return MediumGrace.ToApi24HourTimeFormat(); }
            set { MediumGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public bool? UseUnscheduledPunchRounding { get; set; }

        [XmlAttribute("UsePunchRoundingSW")]
        public string UseUnscheduledPunchRoundingString
        {
            get { return UseUnscheduledPunchRounding.ToApiBoolFormat(); }
            set { UseUnscheduledPunchRounding = value.ToApiNullableBoolFormat(); }
        }
    }
}
