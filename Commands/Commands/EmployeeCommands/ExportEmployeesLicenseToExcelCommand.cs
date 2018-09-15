using System.IO;
using AcceleratedTool.Commands.Criterias;
using AcceleratedTool.Commands.Exceptions;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.ExcelDocument;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.EmployeeCommands
{
    public class ExportEmployeesLicenseToExcelCommand : IWriteCommand<ExportData<EmployeeLicense>>
    {
        private readonly ExcelDataComponent<Excel.Models.EmployeeLicense> _excelDataComponent;
        private readonly ExcelEmployeeLicenseMapper _excelEmployeeDataComponent;

        public ExportEmployeesLicenseToExcelCommand(ExcelDataComponent<Excel.Models.EmployeeLicense> excelDataComponent, ExcelEmployeeLicenseMapper excelEmployeeDataComponent)
        {
            _excelDataComponent = excelDataComponent;
            _excelEmployeeDataComponent = excelEmployeeDataComponent;
        }

        public void Execute(ExportData<EmployeeLicense> criteria)
        {
            try
            {
                _excelDataComponent.ConvertToCsv(_excelEmployeeDataComponent.Map(criteria.DataList), criteria.FilePath);
            }
            catch (IOException ex)
            {
                throw new FileNotAccessibleException(criteria.FileName, ex);
            }
        }
    }
}
