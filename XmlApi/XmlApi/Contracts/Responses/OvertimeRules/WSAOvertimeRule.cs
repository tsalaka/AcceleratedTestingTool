using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.OvertimeRules
{
    public class WSAOvertimeRule
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlIgnore]
        public TimeSpan ResetAtTime { get; set; }

        [XmlAttribute("ResetAtTime")]
        public string ResetAtTimeString
        {
            get { return ResetAtTime.ToApi24HourTimeFormat(); }
            set { ResetAtTime = value.ToApi24HourTimeFormat(); }
        }

        [XmlIgnore]
        public TimeSpan Amount { get; set; }

        [XmlAttribute("Amount")]
        public string AmountString
        {
            get { return Amount.ToApi24HourTimeFormat(); }
            set { Amount = value.ToApi24HourTimeFormat(); }
        }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlIgnore]
        public bool? UseRoundedTime { get; set; }

        [XmlAttribute("UseRoundedTime")]
        public string UseRoundedTimeString
        {
            get { return UseRoundedTime.ToApiBoolFormat(); }
            set { UseRoundedTime = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? RequiresApproval { get; set; }

        [XmlAttribute("RequiresApproval")]
        public string RequiresApprovalString
        {
            get { return RequiresApproval.ToApiBoolFormat(); }
            set { RequiresApproval = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public int? ResetDay { get; set; }

        [XmlAttribute("ResetDay")]
        public string ResetDayString
        {
            get
            {
                return ResetDay == null ? null : ResetDay.ToString();
            }
            set
            {
                int resetDay;
                if (int.TryParse(value, out resetDay))
                    ResetDay = resetDay;
            }
        }
    }
}
