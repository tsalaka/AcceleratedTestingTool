using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class WSAPunchRoundRule
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public TimeSpan? InPunchEarlyChangePoint { get; set; }

        [XmlAttribute("InPunchEarlyChangePoint")]
        public string InPunchEarlyChangePointString
        {
            get { return InPunchEarlyChangePoint.ToApi24HourTimeFormat(); }
            set { InPunchEarlyChangePoint = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchEarlyInsideRound { get; set; }

        [XmlAttribute("InPunchEarlyInsideRound")]
        public string InPunchEarlyInsideRoundString
        {
            get { return InPunchEarlyInsideRound.ToApi24HourTimeFormat(); }
            set { InPunchEarlyInsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchEarlyInsideGrace { get; set; }

        [XmlAttribute("InPunchEarlyInsideGrace")]
        public string InPunchEarlyInsideGraceString
        {
            get { return InPunchEarlyInsideGrace.ToApi24HourTimeFormat(); }
            set { InPunchEarlyInsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchEarlyOutsideRound { get; set; }

        [XmlAttribute("InPunchEarlyOutsideRound")]
        public string InPunchEarlyOutsideRoundString
        {
            get { return InPunchEarlyOutsideRound.ToApi24HourTimeFormat(); }
            set { InPunchEarlyOutsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchEarlyOutsideGrace { get; set; }

        [XmlAttribute("InPunchEarlyOutsideGrace")]
        public string InPunchEarlyOutsideGraceString
        {
            get { return InPunchEarlyOutsideGrace.ToApi24HourTimeFormat(); }
            set { InPunchEarlyOutsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchLateChangePoint { get; set; }

        [XmlAttribute("InPunchLateChangePoint")]
        public string InPunchLateChangePointString
        {
            get { return InPunchLateChangePoint.ToApi24HourTimeFormat(); }
            set { InPunchLateChangePoint = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchLateInsideRound { get; set; }

        [XmlAttribute("InPunchLateInsideRound")]
        public string InPunchLateInsideRoundString
        {
            get { return InPunchLateInsideRound.ToApi24HourTimeFormat(); }
            set { InPunchLateInsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchLateInsideGrace { get; set; }

        [XmlAttribute("InPunchLateInsideGrace")]
        public string InPunchLateInsideGraceString
        {
            get { return InPunchLateInsideGrace.ToApi24HourTimeFormat(); }
            set { InPunchLateInsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchLateOutsideRound { get; set; }

        [XmlAttribute("InPunchLateOutsideRound")]
        public string InPunchLateOutsideRoundString
        {
            get { return InPunchLateOutsideRound.ToApi24HourTimeFormat(); }
            set { InPunchLateOutsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? InPunchLateOutsideGrace { get; set; }

        [XmlAttribute("InPunchLateOutsideGrace")]
        public string InPunchLateOutsideGraceString
        {
            get { return InPunchLateOutsideGrace.ToApi24HourTimeFormat(); }
            set { InPunchLateOutsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchEarlyChangePoint { get; set; }

        [XmlAttribute("OutPunchEarlyChangePoint")]
        public string OutPunchEarlyChangePointString
        {
            get { return OutPunchEarlyChangePoint.ToApi24HourTimeFormat(); }
            set { OutPunchEarlyChangePoint = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchEarlyInsideRound { get; set; }

        [XmlAttribute("OutPunchEarlyInsideRound")]
        public string OutPunchEarlyInsideRoundString
        {
            get { return OutPunchEarlyInsideRound.ToApi24HourTimeFormat(); }
            set { OutPunchEarlyInsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchEarlyInsideGrace { get; set; }

        [XmlAttribute("OutPunchEarlyInsideGrace")]
        public string OutPunchEarlyInsideGraceString
        {
            get { return OutPunchEarlyInsideGrace.ToApi24HourTimeFormat(); }
            set { OutPunchEarlyInsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchEarlyOutsideRound { get; set; }

        [XmlAttribute("OutPunchEarlyOutsideRound")]
        public string OutPunchEarlyOutsideRoundString
        {
            get { return OutPunchEarlyOutsideRound.ToApi24HourTimeFormat(); }
            set { OutPunchEarlyOutsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchEarlyOutsideGrace { get; set; }

        [XmlAttribute("OutPunchEarlyOutsideGrace")]
        public string OutPunchEarlyOutsideGraceString
        {
            get { return OutPunchEarlyOutsideGrace.ToApi24HourTimeFormat(); }
            set { OutPunchEarlyOutsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchLateChangePoint { get; set; }

        [XmlAttribute("OutPunchLateChangePoint")]
        public string OutPunchLateChangePointString
        {
            get { return OutPunchLateChangePoint.ToApi24HourTimeFormat(); }
            set { OutPunchLateChangePoint = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchLateInsideRound { get; set; }

        [XmlAttribute("OutPunchLateInsideRound")]
        public string OutPunchLateInsideRoundString
        {
            get { return OutPunchLateInsideRound.ToApi24HourTimeFormat(); }
            set { OutPunchLateInsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchLateInsideGrace { get; set; }

        [XmlAttribute("OutPunchLateInsideGrace")]
        public string OutPunchLateInsideGraceString
        {
            get { return OutPunchLateInsideGrace.ToApi24HourTimeFormat(); }
            set { OutPunchLateInsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchLateOutsideRound { get; set; }

        [XmlAttribute("OutPunchLateOutsideRound")]
        public string OutPunchLateOutsideRoundString
        {
            get { return OutPunchLateOutsideRound.ToApi24HourTimeFormat(); }
            set { OutPunchLateOutsideRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? OutPunchLateOutsideGrace { get; set; }

        [XmlAttribute("OutPunchLateOutsideGrace")]
        public string OutPunchLateOutsideGraceString
        {
            get { return OutPunchLateOutsideGrace.ToApi24HourTimeFormat(); }
            set { OutPunchLateOutsideGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? UnscheduledInRound { get; set; }

        [XmlAttribute("UnscheduledInRound")]
        public string UnscheduledInRoundString
        {
            get { return UnscheduledInRound.ToApi24HourTimeFormat(); }
            set { UnscheduledInRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? UnscheduledInGrace { get; set; }

        [XmlAttribute("UnscheduledInGrace")]
        public string UnscheduledInGraceString
        {
            get { return UnscheduledInGrace.ToApi24HourTimeFormat(); }
            set { UnscheduledInGrace = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? UnscheduledOutRound { get; set; }

        [XmlAttribute("UnscheduledOutRound")]
        public string UnscheduledOutRoundString
        {
            get { return UnscheduledOutRound.ToApi24HourTimeFormat(); }
            set { UnscheduledOutRound = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? UnscheduledOutGrace { get; set; }

        [XmlAttribute("UnscheduledOutGrace")]
        public string UnscheduledOutGraceString
        {
            get { return UnscheduledOutGrace.ToApi24HourTimeFormat(); }
            set { UnscheduledOutGrace = value.ToApi24HourTimeFormat(); }
        }
    }
}
