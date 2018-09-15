using System.Xml.Serialization;
using AcceleratedTool.XmlApi.XmlApiService.Request;
using AcceleratedTool.XmlApi.XmlApiService.Response;

namespace AcceleratedTool.XmlApi.TestLogin
{
    [XmlRoot("WFC")]
    public class TestLoginResponse
    {
        [XmlElement(ElementName = "Response")]
        public LoginResponse LogonResponse { get; set; }
    }
}
