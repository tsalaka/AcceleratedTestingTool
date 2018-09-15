using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models.PayRuleBuilding
{
    public class WatProfile
    {
        [ExcelColumn(Order = 1, Name = "WAT Profile Name")]
        public string ProfileName { get; set; }

        [ExcelColumn(Order = 2, Name = "Profile Description")]
        public string ProfileDescription { get; set; }

        [ExcelColumn(Order = 3, Name = "Person Number")]
        public string PersonNumber { get; set; }

        [ExcelColumn(Order = 4, Name = "Test Name")]
        public string TestName { get; set; }

        [ExcelColumn(Order = 5, Name = "Person Full Name")]
        public string PersonFullName { get; set; }

        [ExcelColumn(Order = 6)]
        public int Sequence { get; set; }
    }
}
