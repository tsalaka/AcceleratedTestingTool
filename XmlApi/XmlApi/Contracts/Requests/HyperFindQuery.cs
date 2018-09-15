using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Requests
{
    public class HyperFindQuery
    {
        [XmlAttribute]
        public string QueryPersonOrEmployee { get; set; }

        [XmlAttribute]
        public string Description { get; set; }

        [XmlAttribute]
        public string HyperFindQueryName { get; set; }

        [XmlIgnore]
        public DateTime? QueryDateStart { get; set; }

        [XmlIgnore]
        public DateTime? QueryDateEnd { get; set; }

        [XmlAttribute]
        public string VisibilityCode { get; set; }

        [XmlAttribute]
        public string QueryDateSpan
        {
            get
            {
                if (QueryDateStart.HasValue && QueryDateEnd.HasValue)
                    return DateRange.ToDateRangeDate(QueryDateStart.Value, QueryDateEnd.Value);
                return string.Empty;
            }
            set
            {
            }
        }
    }
}