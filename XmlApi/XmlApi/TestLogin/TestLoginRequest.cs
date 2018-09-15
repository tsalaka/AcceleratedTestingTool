using System.Xml.Serialization;
using AcceleratedTool.XmlApi.XmlApiService.Request;

namespace AcceleratedTool.XmlApi.TestLogin
{
    [XmlRoot("WFC")]
    public class TestLoginRequest
    {
        private const string DefaultVersion = "1.0";
        private string _version;

        public TestLoginRequest() { }

        public TestLoginRequest(string username, string password)
        {
            LogonRequest = new LogonRequest
            {
                UserName = username,
                Password = password
            };
        }

        [XmlAttribute("version")]
        public string Version
        {
            get { return _version ?? DefaultVersion; }
            set { _version = value; }
        }

        [XmlElement(ElementName = "Request", Order = 1)]
        public LogonRequest LogonRequest { get; set; }

        [XmlElement(ElementName = "Request", Order = 2)]
        public LogoffRequest LogoffRequest { get; set; }
    }
}
