using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class PersonAccessAssignment
    {
        [XmlAttribute]
        public string ManagerAccessOrganizationSetName { get; set; }

        [XmlAttribute]
        public string ManagerTransferOrganizationSetName { get; set; }

        [XmlAttribute]
        public string ProfessionalTransferOrganizationSetName { get; set; }
    }
}
