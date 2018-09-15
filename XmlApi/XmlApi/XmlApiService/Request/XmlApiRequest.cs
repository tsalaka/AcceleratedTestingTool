using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Request
{
    [XmlRoot("WFC")]
    public class XmlApiRequest<TRequestBody>
        where TRequestBody : class
    {
        private const string DefaultVersion = "1.0";
        private string _version;

        public XmlApiRequest()
        {
        }

        public XmlApiRequest(TRequestBody body, string action, string username, string password)
        {
            Body = new RequestBody<TRequestBody>()
            {
                Body = body,
                Action = action
            };
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

        [XmlElement(ElementName = "Request", Order = 3)]
        public LogoffRequest LogoffRequest
        {
            get { return new LogoffRequest(); }
            set { }
        }

        [XmlElement(ElementName = "Request", Order = 2)]
        public RequestBody<TRequestBody> Body { get; set; }
    }
}
