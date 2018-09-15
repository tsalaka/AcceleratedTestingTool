namespace AcceleratedTool.Jobs
{
    public class OutputDirectory
    {
        public string Path { get; set; }
        public string ExcelFolder { get; set; }
        public string SourceFolder { get; set; }

        public string ExcelFolderPath
        {
            get
            {
                return System.IO.Path.Combine(Path, ExcelFolder);
            }
        }

        public string SourceFolderPath
        {
            get
            {
                return System.IO.Path.Combine(Path, SourceFolder);
            }
        }

        public string ExcelFilePath(string fileName)
        {
            return System.IO.Path.Combine(ExcelFolderPath, fileName);
        }

        public string SourceFilePath(string fileName)
        {
            return System.IO.Path.Combine(SourceFolderPath, fileName);
        }

        public string XmlFilePath(string fileName)
        {
            return System.IO.Path.Combine(ExcelFolderPath, fileName);
        }
    }
}
