namespace AcceleratedTool.ExcelDocument
{
    public class ExcelFileData : ExcelData
    {
        public ExcelFileData(ExcelData data)
        {
            Headers = data.Headers;
            DataRows = data.DataRows;
            ColumnConfigurations = data.ColumnConfigurations;
            SheetName = data.SheetName;
        }

        public string FilePath { get; set; }

        public bool UpdateExistingFile { get; set; }
    }
}
