using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models
{
    public class EmployeeLicense
    {
        [ExcelColumn(Order = 1, Name = "Person Number")]
        public string PersonNumber { get; set; }

        [ExcelColumn(Order = 2, Name = "Last Name")]
        public string LastName { get; set; }

        [ExcelColumn(Order = 3, Name = "First Name")]
        public string FirstName { get; set; }

        [ExcelColumn(Order = 4, Name = "License Active Flag")]
        public bool? LicenseActiveFlag { get; set; }

        [ExcelColumn(Order = 5, Name = "License Type Name")]
        public string LicenseTypeName { get; set; }
    }
}
