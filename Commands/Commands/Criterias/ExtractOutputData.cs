using System.IO;

namespace AcceleratedTool.Commands.Criterias
{
    public class ExtractOutputData
    {
        public ExtractOutputData() { }

        public ExtractOutputData(string filePath, string sheet = null)
        {
            FilePath = filePath;
            SheetName = sheet;
        }

        public string FilePath { get; set; }

        public string SheetName { get; set; }

        public string FileName
        {
            get { return Path.GetFileName(FilePath); }
        }
    }
}
