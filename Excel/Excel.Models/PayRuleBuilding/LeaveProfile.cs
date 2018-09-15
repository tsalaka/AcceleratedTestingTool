using System;
using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models.PayRuleBuilding
{
    public class LeaveProfile
    {
        [ExcelColumn(Order = 1, Name = "Leave Profile")]
        public string ProfileName { get; set; }

        [ExcelColumn(Order = 2, Name = "Person Number")]
        public string PersonNumber { get; set; }

        [ExcelColumn(Order = 3, Name = "Test Name")]
        public string TestName { get; set; }

        [ExcelColumn(Order = 4, Name = "Person Full Name")]
        public string PersonFullName { get; set; }

        [ExcelColumn(Order = 5, Name = "Company Hire Date")]
        public DateTime? CompanyHireDate { get; set; }
    }
}
