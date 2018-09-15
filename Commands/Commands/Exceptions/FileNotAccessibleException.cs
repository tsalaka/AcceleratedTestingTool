using System;

namespace AcceleratedTool.Commands.Exceptions
{
    public class FileNotAccessibleException : Exception
    {
        public FileNotAccessibleException(string fileName, Exception ex)
            : base(string.Format("{0} file is used by another process", fileName), ex)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}
