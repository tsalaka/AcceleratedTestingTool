using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class EmploymentStatus
    {
        [XmlAttribute]
        public string EmploymentStatusName { get; set; }
    }
}
