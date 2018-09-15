using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class CustomData
    {
        [XmlAttribute]
        public string Text { get; set; }

        [XmlAttribute]
        public string CustomDataTypeName { get; set; }
    }
}
