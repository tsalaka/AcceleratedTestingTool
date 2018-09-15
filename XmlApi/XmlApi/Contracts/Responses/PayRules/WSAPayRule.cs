using System.Collections.Generic;
using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PayRules
{
    public class WSAPayRule
    {
        [XmlAttribute]
        public string Name { get; set; }

        public List<WSAEffectivePayRule> EffectivePayRules { get; set; }
    }
}
