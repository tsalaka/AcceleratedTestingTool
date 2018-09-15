using System;
using AcceleratedTool.Commands.Exceptions;

namespace AcceleratedTool.Jobs.Exceptions
{
    public class SourceFileWasNotFoundException : FileNotExistException
    {
        public SourceFileWasNotFoundException(FileNotExistException ex)
            : base(ex.FileName, ex)
        {
        }
    }
}
