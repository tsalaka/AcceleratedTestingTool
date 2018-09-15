using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PayRules
{
    public class SimpleValue
    {
        [XmlAttribute]
        public string Value { get; set; }
    }
}
