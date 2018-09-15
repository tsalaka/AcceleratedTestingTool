using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations
{
    public class AccessAssignment
    {
        [XmlAttribute]
        public string AccessProfileName { get; set; }

        [XmlAttribute]
        public string GroupScheduleName { get; set; }

        [XmlAttribute]
        public string ManagerAccessSetName { get; set; }

        [XmlAttribute]
        public string ManagerPayCodeName { get; set; }

        [XmlAttribute]
        public string ManagerViewPayCodeName { get; set; }

        [XmlAttribute]
        public string ManagerTransferSetName { get; set; }

        [XmlAttribute]
        public string ManagerApprovalSetName { get; set; }

        [XmlAttribute]
        public string ManagerWorkRuleName { get; set; }

        [XmlAttribute]
        public string PreferenceProfileName { get; set; }

        [XmlAttribute]
        public string ProfessionalPayCodeName { get; set; }

        [XmlAttribute]
        public string ProfessionalTransferSetName { get; set; }

        [XmlAttribute]
        public string ProfessionalWorkRuleName { get; set; }

        [XmlAttribute]
        public string ReportName { get; set; }

        [XmlAttribute]
        public string SchedulePatternName { get; set; }

        [XmlAttribute]
        public string ShiftCodeName { get; set; }

        [XmlAttribute]
        public string AvailabilityPatternName { get; set; }

        [XmlAttribute]
        public string TimeEntryTypeName { get; set; }

        [XmlAttribute]
        public string TransferEmployeeFlag { get; set; }

        [XmlAttribute]
        public string DelegateProfileName { get; set; }

        [XmlIgnore]
        public bool? ApproveOvertimeFlag { get; set; }

        [XmlAttribute("ApproveOvertimeFlag")]
        public string ApproveOvertimeFlagString
        {
            get { return ApproveOvertimeFlag.ToApiBoolFormat(); }
            set { ApproveOvertimeFlag = value.ToApiNullableBoolFormat(); }
        }

        [XmlAttribute]
        public string HyperFindScheduleVisibilityName { get; set; }

        [XmlAttribute]
        public string NotificationProfileName { get; set; }
    }
}
