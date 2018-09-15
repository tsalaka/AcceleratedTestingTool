using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcceleratedTool.XmlApi.XmlApiService.Response;

namespace AcceleratedTool.XmlApi.Exceptions
{
    public class XmlApiServerException : Exception
    {
        private readonly string _message;

        public XmlApiServerException()
        {
        }

        public XmlApiServerException(string message)
        {
            _message = message;
        }

        public XmlApiServerException(string message, List<ErrorResponse> response)
        {
            _message = message;

            if (response == null)
                return;

            Errors = new List<XmlApiErrorStatus>();
            Messages = new List<string>();

            foreach (var errorResponse in response)
            {
                if (errorResponse.DetailErrors != null && errorResponse.DetailErrors.Any())
                {
                    Errors.AddRange(errorResponse.DetailErrors.Select(s => (XmlApiErrorStatus)s.ErrorCode).ToList());
                    Messages.AddRange(errorResponse.DetailErrors
                        .Select(s =>
                            string.Format("{0}{1}{2}", s.Message, string.IsNullOrEmpty(s.ErrorData) ? string.Empty : ": ", s.ErrorData)).ToList());
                }
                else
                {
                    Errors.Add((XmlApiErrorStatus)errorResponse.ErrorCode);
                    Messages.Add(errorResponse.Message);
                }
            }
        }

        public override string Message
        {
            get
            {
                var message = new StringBuilder();
                message.AppendLine(_message);
                message.AppendLine(FormatMessages(Messages));

                return message.ToString();
            }
        }

        public virtual List<XmlApiErrorStatus> Errors { get; }

        public virtual List<string> Messages { get; }

        private string FormatMessages(List<string> errors)
        {
            if (errors == null)
                return string.Empty;

            var error = new StringBuilder();
            errors.Distinct().ToList().ForEach(m => error.AppendLine(m));
            return error.ToString();
        }
    }
}