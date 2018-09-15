using System;
using AcceleratedTool.Commands.Exceptions;

namespace AcceleratedTool.Jobs.Exceptions
{
    public class DependentJobWasNotRunException : FileNotExistException
    {
        public DependentJobWasNotRunException(FileNotExistException ex)
            : base(ex.FileName, ex)
        {
        }
    }
}