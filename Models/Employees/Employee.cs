using System;
using System.Collections.Generic;

namespace AcceleratedTool.Models.Employees
{
    public class Employee
    {
        public string PersonNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PayRuleName { get; set; }
        public string AccrualProfileName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public long? FullTimePercentage { get; set; }
        public decimal? BaseWageHourly { get; set; }
        public string SupervisorFullName { get; set; }
        public string SupervisorPersonNumber { get; set; }
        public string HomeAccountName { get; set; }
        public string EmploymentStatusName { get; set; }
        public string BadgeNumber { get; set; }
        public string AccessProfileName { get; set; }
        public string GroupScheduleName { get; set; }
        public string ManagerAccessSetName { get; set; }
        public string ManagerPayCodeName { get; set; }
        public string ManagerViewPayCodeName { get; set; }
        public string ManagerTransferSetName { get; set; }
        public string ManagerApprovalSetName { get; set; }
        public string ManagerWorkRuleName { get; set; }
        public string PreferenceProfileName { get; set; }
        public string ProfessionalPayCodeName { get; set; }
        public string ProfessionalTransferSetName { get; set; }
        public string ProfessionalWorkRuleName { get; set; }
        public string ReportName { get; set; }
        public string SchedulePatternName { get; set; }
        public string ShiftCodeName { get; set; }
        public string AvailabilityPatternName { get; set; }
        public string TimeEntryTypeName { get; set; }
        public string TransferEmployeeFlag { get; set; }
        public string DelegateProfileName { get; set; }
        public bool? ApproveOvertimeFlag { get; set; }
        public string HyperFindScheduleVisibilityName { get; set; }
        public string NotificationProfileName { get; set; }
        public string ManagerAccessOrganizationSetName { get; set; }
        public string ManagerTransferOrganizationSetName { get; set; }
        public string ProfessionalTransferOrganizationSetName { get; set; }
        public string LogonProfileName { get; set; }
        public string UserName { get; set; }
        public string TimeZoneName { get; set; }
        public string GDAPName { get; set; }
        public string GDAPRole { get; set; }
        public string EmploymentTermName { get; set; }
        public DateTime? EmpTermStartDate { get; set; }
        public DateTime? EmpTermEndDate { get; set; }
        public string State { get; set; }
        public List<EmployeeLicense> Licenses { get; set; }
        public List<CustomData> CustomDataList { get; set; }
        public List<CustomDate> CustomDates { get; set; }
    }
}
