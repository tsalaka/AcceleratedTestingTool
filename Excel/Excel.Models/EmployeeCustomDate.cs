using System;
using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models
{
    public class EmployeeCustomDate
    {
        [ExcelColumn(Order = 1, Name = "Person Number")]
        public string PersonNumber { get; set; }

        [ExcelColumn(Order = 2, Name = "Last Name")]
        public string LastName { get; set; }

        [ExcelColumn(Order = 3, Name = "First Name")]
        public string FirstName { get; set; }

        [ExcelColumn(Order = 4, Name = "Custom Date Type Name")]
        public string CustomDateTypeName { get; set; }

        [ExcelColumn(Order = 5)]
        public DateTime? Date { get; set; }
    }
}
