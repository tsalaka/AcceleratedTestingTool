using System;

namespace AcceleratedTool.Commands.Exceptions
{
    public class InvalidDataFormatException : Exception
    {
        public InvalidDataFormatException(string sheetName, string columnName, int rowNumber, Exception ex)
            : base(ex.Message, ex)
        {
            SheetName = sheetName;
            RowNumber = rowNumber;
            ColumnName = columnName;
        }

        public string SheetName { get; }
        public string ColumnName { get; }
        public int RowNumber { get; }
    }
}
