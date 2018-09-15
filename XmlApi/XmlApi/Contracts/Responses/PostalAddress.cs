using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class PostalAddress
    {
        [XmlAttribute]
        public string State { get; set; }
    }
}
