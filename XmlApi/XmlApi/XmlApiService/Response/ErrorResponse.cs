using System.Collections.Generic;
using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Response
{
    public class ErrorResponse
    {
        [XmlAttribute]
        public string Message { get; set; }

        [XmlAttribute]
        public int ErrorCode { get; set; }

        public List<Error> DetailErrors { get; set; }
    }
}
