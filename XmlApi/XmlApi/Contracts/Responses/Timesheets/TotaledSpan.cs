using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Timesheets
{
    public class TotaledSpan
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("Date")]
        public string DateString
        {
            get { return Date.ToApiDateFormat(); }
            set { Date = value.ToApiDateFormat(); }
        }

        public Employee Employee { get; set; }

        public InPunch InPunch { get; set; }

        public OutPunch OutPunch { get; set; }

        public List<TimekeepingException> Exceptions { get; set; }
    }
}
