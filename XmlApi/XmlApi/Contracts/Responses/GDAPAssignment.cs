using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class GDAPAssignment
    {
        [XmlAttribute]
        public string GDAPName { get; set; }

        [XmlAttribute]
        public string Role { get; set; }
    }
}
