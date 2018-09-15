using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace AcceleratedTool.Jobs.Logs
{
    public class Logger : ILogger
    {
        private readonly ILog _logger;

        public Logger(string name)
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(name);
        }

        public void Error(Exception ex, string jobName = null)
        {
            ThreadContext.Properties["JobName"] = jobName ?? string.Empty;
            var error = new StringBuilder();
            error.Append(ex.Message);
            error.AppendLine(ex.StackTrace);
            error.Append(LogInnerException(ex));

            _logger.Error(error);
        }

        public void Error(string message, Exception ex, string jobName = null)
        {
            ThreadContext.Properties["JobName"] = jobName ?? string.Empty;
            var error = new StringBuilder();
            error.Append(message);
            error.AppendLine(ex.StackTrace);
            error.Append(LogInnerException(ex));

            _logger.Error(error);
        }

        public void Error(string message, List<string> errors, Exception ex = null, string jobName = null)
        {
            ThreadContext.Properties["JobName"] = jobName ?? string.Empty;
            var error = new StringBuilder();
            error.AppendLine(string.Format("{0}:", message));
            error.AppendLine(FormatErrors(errors));
            if (ex != null)
            {
                error.AppendLine(ex.StackTrace);
                error.Append(LogInnerException(ex));
            }

            _logger.Error(error);
        }

        public void Warn(string message, string jobName = null, Exception ex = null)
        {
            ThreadContext.Properties["JobName"] = jobName ?? string.Empty;
            var warning = new StringBuilder();
            warning.AppendLine(message);
            if (ex != null)
            {
                warning.AppendLine(ex.StackTrace);
                warning.Append(LogInnerException(ex));
            }

            _logger.Warn(warning);
        }

        public void Warn(string message, List<string> errors, string jobName = null)
        {
            ThreadContext.Properties["JobName"] = jobName ?? string.Empty;
            var warning = new StringBuilder();
            warning.AppendLine(string.Format("{0}:", message));
            warning.AppendLine(FormatErrors(errors));

            _logger.Warn(warning);
        }

        public void Info(string message, string jobName = null)
        {
            ThreadContext.Properties["JobName"] = jobName ?? string.Empty;
            _logger.Info(message);
        }

        private string LogInnerException(Exception ex)
        {
            var log = new StringBuilder();
            var innerException = ex.InnerException;
            while (innerException != null)
            {
                if (innerException.InnerException == null)
                {
                    log.Append(innerException.Message);
                    log.AppendLine(innerException.StackTrace);
                }

                innerException = innerException.InnerException;
            }

            return log.ToString();
        }

        private string FormatErrors(List<string> errors)
        {
            if (errors == null)
                return string.Empty;

            var error = new StringBuilder();
            errors.Distinct().ToList().ForEach(m => error.AppendLine(m));
            return error.ToString();
        }
    }
}
