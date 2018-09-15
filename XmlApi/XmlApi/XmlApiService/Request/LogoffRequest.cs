using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Request
{
    public class LogoffRequest
    {
        [XmlAttribute]
        public string Object
        {
            get
            {
                return "System";
            }
            set
            {
            }
        }

        [XmlAttribute]
        public string Action
        {
            get
            {
                return "Logoff";
            }
            set
            {
            }
        }
    }
}
