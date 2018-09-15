using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class WSAPayCode
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string AmountType { get; set; }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public string ScheduleHoursType { get; set; }

        [XmlIgnore]
        public bool? CheckAvailabilitySchedule { get; set; }

        [XmlAttribute("CheckAvlbltySw")]
        public string CheckAvailabilityScheduleString
        {
            get { return CheckAvailabilitySchedule.ToApiBoolFormat(); }
            set { CheckAvailabilitySchedule = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? VisibleToUser { get; set; }

        [XmlAttribute("VisibleToUser")]
        public string VisibleToUserString
        {
            get { return VisibleToUser.ToApiBoolFormat(); }
            set { VisibleToUser = value.ToApiNullableBoolFormat(); }
        }
    }
}
