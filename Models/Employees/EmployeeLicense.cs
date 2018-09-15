namespace AcceleratedTool.Models.Employees
{
    public class EmployeeLicense
    {
        public bool ActiveFlag { get; set; }

        public string LicenseTypeName { get; set; }

        public PersonData Person { get; set; }
    }
}