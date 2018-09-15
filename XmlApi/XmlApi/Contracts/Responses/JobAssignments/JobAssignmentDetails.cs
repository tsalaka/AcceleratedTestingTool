using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.JobAssignments
{
    public class JobAssignmentDetails
    {
        [XmlAttribute]
        public string SupervisorName { get; set; }

        [XmlAttribute]
        public string TimeZoneName { get; set; }

        [XmlAttribute]
        public string SupervisorPersonNumber { get; set; }

        [XmlAttribute]
        public string PayRuleName { get; set; }
    }
}
