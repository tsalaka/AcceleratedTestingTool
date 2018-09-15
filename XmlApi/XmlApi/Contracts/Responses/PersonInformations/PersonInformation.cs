using System.Collections.Generic;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class PersonInformation
    {
        public List<EmploymentStatus> EmploymentStatusList { get; set; }

        public List<HomeAccount> HomeAccounts { get; set; }
        public List<PersonLicenseType> PersonLicenseTypes { get; set; }

        public List<BadgeAssignment> BadgeAssignments { get; set; }

        public AccessAssignmentData AccessAssignmentData { get; set; }
        public PersonData PersonData { get; set; }
        public List<PostalAddress> PostalAddresses { get; set; }

        public List<PersonAccessAssignment> PersonAccessAssignments { get; set; }
        public List<CustomData> CustomDataList { get; set; }
        public List<CustomDate> CustomDates { get; set; }
    }
}
