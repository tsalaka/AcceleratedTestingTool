using System;

namespace AcceleratedTool.XmlApi.Exceptions
{
    public class XmlApiLoginException : Exception
    {
        public XmlApiLoginException()
        {
        }

        public XmlApiLoginException(string message)
            : base(message)
        {
        }

        public XmlApiLoginException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
