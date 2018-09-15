using System.Collections.Generic;
using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Response
{
    public class EmptyResponseBody
    {
        [XmlAttribute]
        public string Action { get; set; }

        [XmlAttribute]
        public string Status { get; set; }

        [XmlElement("Error")]
        public List<ErrorResponse> Error { get; set; }
    }
}
