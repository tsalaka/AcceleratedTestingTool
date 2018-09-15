using System;
using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models
{
    public class Employee
    {
        [ExcelColumn(Order = 1, Name = "Person Number")]
        public string PersonNumber { get; set; }
        [ExcelColumn(Order = 3, Name = "First Name")]
        public string FirstName { get; set; }
        [ExcelColumn(Order = 2, Name = "Last Name")]
        public string LastName { get; set; }
        [ExcelColumn(Order = 4, Name = "Pay Rule Name")]
        public string PayRuleName { get; set; }
        [ExcelColumn(Order = 5, Name = "Accrual Profile Name")]
        public string AccrualProfileName { get; set; }
        [ExcelColumn(Order = 6, Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [ExcelColumn(Order = 7, Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        [ExcelColumn(Order = 8, Name = "Full Time Percentage")]
        public long? FullTimePercentage { get; set; }
        [ExcelColumn(Order = 9, Name = "Base Wage Hourly")]
        public decimal? BaseWageHourly { get; set; }
        [ExcelColumn(Order = 10, Name = "Supervisor Full Name")]
        public string SupervisorFullName { get; set; }
        [ExcelColumn(Order = 11, Name = "Supervisor Person Number")]
        public string SupervisorPersonNumber { get; set; }
        [ExcelColumn(Order = 12, Name = "Home Account Name")]
        public string HomeAccountName { get; set; }
        [ExcelColumn(Order = 13, Name = "Employment Status Name")]
        public string EmploymentStatusName { get; set; }
        [ExcelColumn(Order = 14, Name = "Badge Number")]
        public string BadgeNumber { get; set; }
        [ExcelColumn(Order = 15, Name = "Access Profile Name")]
        public string AccessProfileName { get; set; }
        [ExcelColumn(Order = 16, Name = "Group Schedule Name")]
        public string GroupScheduleName { get; set; }
        [ExcelColumn(Order = 17, Name = "Manager Access Set Name")]
        public string ManagerAccessSetName { get; set; }
        [ExcelColumn(Order = 18, Name = "Manager Pay Code Name")]
        public string ManagerPayCodeName { get; set; }
        [ExcelColumn(Order = 19, Name = "Manager View Pay Code Name")]
        public string ManagerViewPayCodeName { get; set; }
        [ExcelColumn(Order = 20, Name = "Manager Transfer Set Name")]
        public string ManagerTransferSetName { get; set; }
        [ExcelColumn(Order = 21, Name = "Manager Approval Set Name")]
        public string ManagerApprovalSetName { get; set; }
        [ExcelColumn(Order = 22, Name = "Manager Work Rule Name")]
        public string ManagerWorkRuleName { get; set; }
        [ExcelColumn(Order = 23, Name = "Preference Profile Name")]
        public string PreferenceProfileName { get; set; }
        [ExcelColumn(Order = 24, Name = "Professional Pay Code Name")]
        public string ProfessionalPayCodeName { get; set; }
        [ExcelColumn(Order = 25, Name = "Professional Transfer Set Name")]
        public string ProfessionalTransferSetName { get; set; }
        [ExcelColumn(Order = 26, Name = "Professional Work Rule Name")]
        public string ProfessionalWorkRuleName { get; set; }
        [ExcelColumn(Order = 27, Name = "Report Name")]
        public string ReportName { get; set; }
        [ExcelColumn(Order = 28, Name = "Schedule Pattern Name")]
        public string SchedulePatternName { get; set; }
        [ExcelColumn(Order = 29, Name = "Shift Code Name")]
        public string ShiftCodeName { get; set; }
        [ExcelColumn(Order = 30, Name = "Availability Pattern Name")]
        public string AvailabilityPatternName { get; set; }

        // from AccessAssignment
        [ExcelColumn(Order = 31, Name = "Time Entry Type Name")]
        public string TimeEntryTypeName { get; set; }

        [ExcelColumn(Order = 32, Name = "Transfer Employee Flag")]
        public bool? TransferEmployeeFlag { get; set; }
        [ExcelColumn(Order = 33, Name = "Delegate Profile Name")]
        public string DelegateProfileName { get; set; }
        [ExcelColumn(Order = 34, Name = "Approve Overtime Flag")]
        public bool? ApproveOvertimeFlag { get; set; }
        [ExcelColumn(Order = 35, Name = "Hyper Find Schedule Visibility Name")]
        public string HyperFindScheduleVisibilityName { get; set; }
        [ExcelColumn(Order = 36, Name = "Notification Profile Name")]
        public string NotificationProfileName { get; set; }
        [ExcelColumn(Order = 37, Name = "Manager Access Organization Set Name")]
        public string ManagerAccessOrganizationSetName { get; set; }
        [ExcelColumn(Order = 38, Name = "Manager Transfer Organization Set Name")]
        public string ManagerTransferOrganizationSetName { get; set; }
        [ExcelColumn(Order = 39, Name = "Professional Transfer Organization Set Name")]
        public string ProfessionalTransferOrganizationSetName { get; set; }
        [ExcelColumn(Order = 40, Name = "Logon Profile Name")]
        public string LogonProfileName { get; set; }
        [ExcelColumn(Order = 41, Name = "User Name")]
        public string UserName { get; set; }
        [ExcelColumn(Order = 42, Name = "Time Zone Name")]
        public string TimeZoneName { get; set; }
        [ExcelColumn(Order = 43, Name = "GDAP Name")]
        public string GDAPName { get; set; }
        [ExcelColumn(Order = 44, Name = "GDAP Role")]
        public string GDAPRole { get; set; }
        [ExcelColumn(Order = 45, Name = "Employment Term Name")]
        public string EmploymentTermName { get; set; }
        [ExcelColumn(Order = 46, Name = "Emp Term Start Date")]
        public DateTime? EmpTermStartDate { get; set; }
        [ExcelColumn(Order = 47, Name = "Emp Term End Date")]
        public DateTime? EmpTermEndDate { get; set; }
        [ExcelColumn(Order = 48)]
        public string State { get; set; }
    }
}
