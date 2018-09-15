using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Response
{
    public class Error
    {
        [XmlAttribute]
        public string Message { get; set; }

        [XmlAttribute]
        public int ErrorCode { get; set; }

        public string ErrorData { get; set; }
    }
}
