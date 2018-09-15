using System.Collections.Generic;
using AcceleratedTool.XmlApi.Contracts.Responses.JobAssignments;
using AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations;
using AcceleratedTool.XmlApi.Contracts.Responses.Users;

namespace AcceleratedTool.XmlApi.Contracts.Responses
{
    public class Personality
    {
        public Identity Identity { get; set; }

        public JobAssignmentData JobAssignmentData { get; set; }

        public List<GDAPAssignment> GDAPAssignments { get; set; }

        public PersonInformationData PersonInformationData { get; set; }

        public UserData UserData { get; set; }
    }
}

