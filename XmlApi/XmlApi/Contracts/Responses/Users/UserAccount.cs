using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Users
{
    public class UserAccount
    {
        [XmlAttribute]
        public string LogonProfileName { get; set; }

        [XmlAttribute]
        public string UserName { get; set; }
    }
}
