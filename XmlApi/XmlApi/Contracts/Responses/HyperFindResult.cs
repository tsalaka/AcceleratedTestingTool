using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class HyperFindResult
    {
        [XmlAttribute]
        public string FullName { get; set; }

        [XmlAttribute]
        public string PersonNumber { get; set; }
    }
}
