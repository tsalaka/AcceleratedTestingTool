using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.ShiftGuarantee
{
    public class WSAShiftGuarantee
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public bool? ReductByAmountTardy { get; set; }

        [XmlAttribute("ReductByAmountTardy")]
        public string ReductByAmountTardyString
        {
            get { return ReductByAmountTardy.ToApiBoolFormat(); }
            set { ReductByAmountTardy = value.ToApiBoolFormat(); }
        }

        [XmlAttribute]
        public string WorkRule { get; set; }

        [XmlIgnore]
        public TimeSpan? Sunday { get; set; }

        [XmlAttribute("Sunday")]
        public string SundayString
        {
            get { return Sunday.ToApi24HourTimeFormat(); }
            set { Sunday = value.ToApi24HourNullableTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? Monday { get; set; }

        [XmlAttribute("Monday")]
        public string MondayString
        {
            get { return Monday.ToApi24HourTimeFormat(); }
            set { Monday = value.ToApi24HourNullableTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? Tuesday { get; set; }

        [XmlAttribute("Tuesday")]
        public string TuesdayString
        {
            get { return Tuesday.ToApi24HourTimeFormat(); }
            set { Tuesday = value.ToApi24HourNullableTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? Wednesday { get; set; }

        [XmlAttribute("Wednesday")]
        public string WednesdayString
        {
            get { return Wednesday.ToApi24HourTimeFormat(); }
            set { Wednesday = value.ToApi24HourNullableTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? Thursday { get; set; }

        [XmlAttribute("Thursday")]
        public string ThursdayString
        {
            get { return Thursday.ToApi24HourTimeFormat(); }
            set { Thursday = value.ToApi24HourNullableTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? Friday { get; set; }

        [XmlAttribute("Friday")]
        public string FridayString
        {
            get { return Friday.ToApi24HourTimeFormat(); }
            set { Friday = value.ToApi24HourNullableTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan? Saturday { get; set; }

        [XmlAttribute("Saturday")]
        public string SaturdayString
        {
            get { return Saturday.ToApi24HourTimeFormat(); }
            set { Saturday = value.ToApi24HourNullableTimeFormat(); }
        }
    }
}
