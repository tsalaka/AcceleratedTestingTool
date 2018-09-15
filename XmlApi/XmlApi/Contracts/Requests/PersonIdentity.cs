using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Requests
{
    public class PersonIdentity
    {
        [XmlAttribute]
        public string PersonNumber { get; set; }
    }
}
