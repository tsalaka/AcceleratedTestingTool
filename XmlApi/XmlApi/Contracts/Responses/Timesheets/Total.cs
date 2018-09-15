using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Timesheets
{
    public class Total
    {
        [XmlAttribute]
        public string LaborAccountDescription { get; set; }

        [XmlAttribute]
        public string PayCodeName { get; set; }

        [XmlIgnore]
        public TimeSpan AmountInTime { get; set; }

        [XmlAttribute("AmountInTime")]
        public string AmountInTimeString
        {
            get { return AmountInTime.ToApi24HourTimeFormat(); }
            set { AmountInTime = value.ToApi24HourTimeFormat(); }
        }
    }
}
