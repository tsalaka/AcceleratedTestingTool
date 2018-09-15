using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.BonusDeductRules
{
    public class WSABonusDeductRule
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public string Amount { get; set; }

        [XmlAttribute]
        public string PayCode { get; set; }

        [XmlIgnore]
        public TimeSpan? ShiftMinimumHours { get; set; }

        [XmlAttribute("ShfLenMin")]
        public string ShiftMinimumHoursString
        {
            get { return ShiftMinimumHours.ToApi24HourTimeFormat(); }
            set { ShiftMinimumHours = value.ToApi24HourNullableTimeFormat(); }
        }
    }
}
