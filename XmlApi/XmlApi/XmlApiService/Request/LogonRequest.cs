using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.XmlApiService.Request
{
    public class LogonRequest
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
                return "Logon";
            }
            set
            {
            }
        }

        [XmlAttribute]
        public string UserName { get; set; }

        [XmlAttribute]
        public string Password { get; set; }
    }
}
