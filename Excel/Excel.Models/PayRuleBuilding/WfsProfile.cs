using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models.PayRuleBuilding
{
    public class WfsProfile
    {
        [ExcelColumn(Order = 1, Name = "Person Number")]
        public string PersonNumber { get; set; }

        [ExcelColumn(Order = 2, Name = "Person Full Name")]
        public string PersonFullName { get; set; }

        [ExcelColumn(Order = 3, Name = "Employee Rule Set Name")]
        public string EmployeeRuleSetName { get; set; }

        [ExcelColumn(Order = 4, Name ="Test Name")]
        public string TestName { get; set; }
    }
}
