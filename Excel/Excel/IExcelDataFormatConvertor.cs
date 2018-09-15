using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceleratedTool.Excel.Models.Attributes;
using AcceleratedTool.ExcelDocument.Extentions;

namespace AcceleratedTool.ExcelDocument
{
    public interface IExcelDataFormatConvertor
    {
        string GetFormatByFormatType(ExcelColumnFormat type);

        string ConvertValueToString(object value, string format = null);

        object ConvertStringToValue(string value, Type type, ExcelColumnFormat format);
    }
}
