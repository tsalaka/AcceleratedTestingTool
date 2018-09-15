using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AcceleratedTool.ExcelDocument
{
    public class ExcelData
    {
        public ExcelData()
        {
            Headers = new List<string>();
            DataRows = new List<List<string>>();
        }

        public static string DefaultSheetName => "Sheet1";

        public Columns ColumnConfigurations { get; set; }
        public List<string> Headers { get; set; }
        public List<List<string>> DataRows { get; set; }
        public string SheetName { get; set; }
    }
}
