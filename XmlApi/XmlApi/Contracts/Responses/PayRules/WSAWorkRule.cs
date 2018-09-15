using System.Collections.Generic;
using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PayRules
{
    public class WSAWorkRule
    {
        [XmlAttribute]
        public string Name { get; set; }

        public List<WSAEffectiveWorkRule> EffectiveWorkRules { get; set; }
    }
}
