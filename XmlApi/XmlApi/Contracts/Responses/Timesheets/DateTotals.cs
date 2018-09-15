using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Timesheets
{
    public class DateTotals
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("Date")]
        public string DateString
        {
            get { return Date.ToApiDateFormat(); }
            set { Date = value.ToApiDateFormat(); }
        }

        public List<Total> Totals { get; set; }
    }
}
