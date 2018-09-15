using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Response
{
    public class LoginResponse
    {
        [XmlAttribute]
        public string Status { get; set; }

        [XmlAttribute]
        public string Action { get; set; }
    }
}
