using System.Collections.Generic;
using System.IO;

namespace AcceleratedTool.Commands.Criterias
{
    public class ExportData<TEntity>
    {
        public List<TEntity> DataList { get; set; }
        public string FilePath { get; set; }
        public string SheetName { get; set; }
        public bool UpdateExistingFile { get; set; }

        public string FileName { get { return Path.GetFileName(FilePath); } }
    }
}
