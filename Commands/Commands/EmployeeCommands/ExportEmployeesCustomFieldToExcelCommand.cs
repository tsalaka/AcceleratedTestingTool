using System.IO;
using AcceleratedTool.Commands.Criterias;
using AcceleratedTool.Commands.Exceptions;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Excel.Models;
using AcceleratedTool.ExcelDocument;
using AcceleratedTool.Models.Employees;

namespace AcceleratedTool.Commands.EmployeeCommands
{
    public class ExportEmployeesCustomFieldToExcelCommand : IWriteCommand<ExportData<CustomData>>
    {
        private readonly ExcelDataComponent<EmployeeCustomField> _excelDataComponent;
        private readonly ExcelCustomFieldMapper _customFieldMapper;

        public ExportEmployeesCustomFieldToExcelCommand(ExcelDataComponent<EmployeeCustomField> excelDataComponent, ExcelCustomFieldMapper customFieldMapper)
        {
            _excelDataComponent = excelDataComponent;
            _customFieldMapper = customFieldMapper;
        }

        public void Execute(ExportData<CustomData> criteria)
        {
            try
            {
                _excelDataComponent.ConvertToCsv(_customFieldMapper.Map(criteria.DataList), criteria.FilePath);
            }
            catch (IOException ex)
            {
                throw new FileNotAccessibleException(criteria.FileName, ex);
            }
        }
    }
}
