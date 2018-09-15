using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Requests.PayCodeEdits
{
    [XmlType(TypeName = "PayCodeEdit")]
    public class AddPayCodeEdit : PayCodeEditBase
    {
        [XmlIgnore]
        public TimeSpan StartTime { get; set; }

        [XmlAttribute("StartTime")]
        public string StartTimeString
        {
            get { return StartTime.ToApi12HourTimeFormat(); }
            set { StartTime = value.ToApi12HourTimeFormat(); }
        }
    }
}
