using System.Collections.Generic;

namespace AcceleratedTool.XmlApi.Contracts.Responses.JobAssignments
{
    public class JobAssignmentData
    {
        public JobAssignment JobAssignment { get; set; }
        public List<EmploymentTermAssignment> EmploymentTermAssignments { get; set; }
    }
}
