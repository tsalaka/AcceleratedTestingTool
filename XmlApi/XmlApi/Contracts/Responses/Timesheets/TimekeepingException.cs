using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Timesheets
{
    public class TimekeepingException
    {
        [XmlAttribute]
        public string ExceptionTypeName { get; set; }
    }
}
