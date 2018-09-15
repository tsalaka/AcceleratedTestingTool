namespace Kronos.AcceleratedTool.ExcelDocument
{
    public class ExcelStatus
    {
        public string Message { get; set; }
        public bool Success
        {
            get { return string.IsNullOrWhiteSpace(Message); }
        }
    }
}
