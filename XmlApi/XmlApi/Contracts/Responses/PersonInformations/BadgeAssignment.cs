using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class BadgeAssignment
    {
        [XmlAttribute]
        public string BadgeNumber { get; set; }
    }
}
