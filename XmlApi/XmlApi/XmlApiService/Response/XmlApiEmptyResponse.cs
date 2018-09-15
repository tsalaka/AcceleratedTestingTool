using System.Collections.Generic;
using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Response
{
    [XmlRoot("WFC")]
    public class XmlApiEmptyResponse
    {
        [XmlElement(ElementName = "Response", Order = 1)]
        public LoginResponse LogonResponse { get; set; }

        [XmlElement(ElementName = "Response", Order = 3)]
        public LoginResponse LogoffResponse { get; set; }

        [XmlElement(ElementName = "Response", Order = 2)]
        public EmptyResponseBody ResponseBody { get; set; }
    }
}
