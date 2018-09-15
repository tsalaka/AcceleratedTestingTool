using System;

namespace AcceleratedTool.ExcelDocument.Exceptions
{
    public class InvalidFormatOfExcelCellException : Exception
    {
        public InvalidFormatOfExcelCellException(string sheetName, string columnName, int rowNumber, Exception ex)
            : base(GetMessage(sheetName, columnName, rowNumber), ex)
        {
            SheetName = sheetName;
            ColumnName = columnName;
            RowNumber = rowNumber;
        }

        public string SheetName { get; }
        public string ColumnName { get; }
        public int RowNumber { get; }

        private static string GetMessage(string sheetName, string columnName, int rowNumber)
        {
            return string.Format("Input string was not in a correct format at '{0}' sheet, column '{1}', row {2}", sheetName, columnName, rowNumber);
        }
    }
}
