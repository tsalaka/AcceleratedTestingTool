using System;

namespace AcceleratedTool.Models.Employees
{
    public class Person
    {
        public DateTime? BirthDate { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public DateTime? HireDate { get; set; }
        public string LastName { get; set; }
        public string PersonNumber { get; set; }
        public string ShortName { get; set; }
        public string AccrualProfileName { get; set; }
        public decimal? BaseWageHourly { get; set; }
        public DateTime? ManagerSignoffThruDateTime { get; set; }
        public DateTime? PayrollLockoutThruDateTime { get; set; }
        public bool? HasKmailNotificationDelivery { get; set; }
        public bool? FingerRequiredFlag { get; set; }
        public string MiddleInitial { get; set; }
        public long? FullTimePercentage { get; set; }
        public string PhoneticFullName { get; set; }
        public double? EmployeeStandardHours { get; set; }
        public double? FullTimeStandardHours { get; set; }
        public string RomanizedFullName { get; set; }
    }
}
