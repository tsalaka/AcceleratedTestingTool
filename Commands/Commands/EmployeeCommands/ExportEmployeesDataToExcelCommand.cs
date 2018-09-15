using System.IO;
using AcceleratedTool.Commands.Criterias;
using AcceleratedTool.Commands.Exceptions;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Excel.Models;
using AcceleratedTool.ExcelDocument;

namespace AcceleratedTool.Commands.EmployeeCommands
{
    public class ExportEmployeesDataToExcelCommand : IWriteCommand<ExportData<Models.Employees.Employee>>
    {
        private readonly ExcelDataComponent<Employee> _excelDataComponent;
        private readonly ExcelEmployeeMapper _excelEmployeeMapper;

        public ExportEmployeesDataToExcelCommand(ExcelDataComponent<Employee> excelDataComponent, ExcelEmployeeMapper excelEmployeeMapper)
        {
            _excelDataComponent = excelDataComponent;
            _excelEmployeeMapper = excelEmployeeMapper;
        }

        public void Execute(ExportData<Models.Employees.Employee> criteria)
        {
            try
            {
                _excelDataComponent.ConvertToCsv(_excelEmployeeMapper.Map(criteria.DataList), criteria.FilePath);
            }
            catch (IOException ex)
            {
                throw new FileNotAccessibleException(criteria.FileName, ex);
            }
        }
    }
}
