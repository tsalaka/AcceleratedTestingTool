using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Response
{
    [XmlRoot("WFC")]
    public class XmlApiResponse<TResponseBody>
        where TResponseBody : class
    {
        [XmlElement(ElementName = "Response", Order = 1)]
        public LoginResponse LogonResponse { get; set; }

        [XmlElement(ElementName = "Response", Order = 3)]
        public LoginResponse LogoffResponse { get; set; }

        [XmlElement(ElementName = "Response", Order = 2)]
        public ResponseBody<TResponseBody> ResponseBody { get; set; }
    }
}
