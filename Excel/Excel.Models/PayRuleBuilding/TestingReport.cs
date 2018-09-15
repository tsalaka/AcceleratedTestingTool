using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models.PayRuleBuilding
{
    public class TestingReport
    {
        [ExcelColumn(Order = 1, Name = "Person Full Name")]
        public string PersonFullName { get; set; }

        [ExcelColumn(Order = 2, Name = "Person Number")]
        public string PersonNumber { get; set; }

        [ExcelColumn(Order = 3, Name = "Test Name")]
        public string TestName { get; set; }

        [ExcelColumn(Order = 4, Name = "Payrule Name")]
        public string PayruleName { get; set; }

        [ExcelColumn(Order = 5, Name = "Exception Rule Name")]
        public string ExceptionRuleName { get; set; }

        [ExcelColumn(Order = 6, Name = "Overtime Rule Name")]
        public string OvertimeRuleName { get; set; }

        [ExcelColumn(Order = 7, Name = "Zone Rule Name")]
        public string ZoneRuleName { get; set; }

        [ExcelColumn(Order = 8, Name = "Bonus Deduct Rule Name")]
        public string BonusDeductRuleName { get; set; }

        [ExcelColumn(Order = 9, Name = "Schedule Deviation Rule Name")]
        public string ScheduleDeviationRuleName { get; set; }

        [ExcelColumn(Order = 10, Name = "Pay Code Distribution Name")]
        public string PayCodeDistributionName { get; set; }

        [ExcelColumn(Order = 11, Name = "Shift Guarantee Name")]
        public string ShiftGuaranteeName { get; set; }

        [ExcelColumn(Order = 14, Name = "Round Rule Name")]
        public string RoundRuleName { get; set; }
    }
}
