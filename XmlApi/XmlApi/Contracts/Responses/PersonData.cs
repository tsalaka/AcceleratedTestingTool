using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class PersonData
    {
        [XmlElement]
        public Person Person { get; set; }
    }
}
