using System;
using System.Collections.Generic;

namespace AcceleratedTool.Jobs.Logs
{
    public interface ILogger
    {
        void Error(Exception ex, string jobName = null);

        void Error(string message, Exception ex, string jobName = null);

        void Error(string message, List<string> errors, Exception ex = null, string jobName = null);

        void Warn(string message, string jobName = null, Exception ex = null);

        void Warn(string message, List<string> errors, string jobName = null);

        void Info(string message, string jobName = null);
    }
}
