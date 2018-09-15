using System;

namespace AcceleratedTool.Commands.Exceptions
{
    public class FileNotExistException : Exception
    {
        public FileNotExistException(string fileName, Exception ex)
            : base(string.Format("{0} file is not found", fileName), ex)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}
