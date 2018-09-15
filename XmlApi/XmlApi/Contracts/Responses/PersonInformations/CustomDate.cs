using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class CustomDate
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("Date")]
        public string DateString
        {
            get { return Date.ToApiDateFormat(); }
            set { Date = value.ToApiDateFormat(); }
        }

        [XmlAttribute]
        public string CustomDateTypeName { get; set; }
    }
}
