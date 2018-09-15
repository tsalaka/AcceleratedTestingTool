using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Timesheets
{
    public class PayCodeEdit
    {
        [XmlAttribute]
        public string AmountInTimeOrCurrency { get; set; }

        [XmlAttribute]
        public string PayCodeName { get; set; }

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("Date")]
        public string DateString
        {
            get { return Date.ToApiDateFormat(); }
            set { Date = value.ToApiDateFormat(); }
        }

        public Employee Employee { get; set; }
    }
}
