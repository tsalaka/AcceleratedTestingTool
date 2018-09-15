using System.IO;
using AcceleratedTool.Commands.Criterias;
using AcceleratedTool.Commands.Exceptions;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Excel.Models;
using AcceleratedTool.ExcelDocument;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.EmployeeCommands
{
    public class ExportEmployeesCustomDateToExcelCommand : IWriteCommand<ExportData<CustomDate>>
    {
        private readonly ExcelDataComponent<EmployeeCustomDate> _excelDataComponent;
        private readonly ExcelCustomDateMapper _customDateMapper;

        public ExportEmployeesCustomDateToExcelCommand(ExcelDataComponent<EmployeeCustomDate> excelDataComponent, ExcelCustomDateMapper customDateMapper)
        {
            _excelDataComponent = excelDataComponent;
            _customDateMapper = customDateMapper;
        }

        public void Execute(ExportData<CustomDate> criteria)
        {
            try
            {
                _excelDataComponent.ConvertToCsv(_customDateMapper.Map(criteria.DataList), criteria.FilePath);
            }
            catch (IOException ex)
            {
                throw new FileNotAccessibleException(criteria.FileName, ex);
            }
        }
    }
}
