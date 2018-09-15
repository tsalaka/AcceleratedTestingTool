using System.Xml.Serialization;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PayRules
{
    public class WSAEffectiveWorkRule
    {
        [XmlAttribute]
        public string ExceptionRuleName { get; set; }

        [XmlAttribute]
        public string DayDivideOverride { get; set; }

        [XmlAttribute]
        public string PayCodeDistributionName { get; set; }

        [XmlAttribute]
        public string RoundRuleName { get; set; }

        [XmlAttribute]
        public string ShiftGuaranteeName { get; set; }

        public WorkRuleGeneral WorkRuleGeneral { get; set; }

        public WorkRulePCDistr WorkRulePCDistr { get; set; }
    }
}
