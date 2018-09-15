using System.Collections.Generic;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PayRules
{
    public class WSAWorkRuleGeneral
    {
        public List<SimpleValue> BonusDeductRuleNames { get; set; }

        public List<SimpleValue> BreakRuleNames { get; set; }
    }
}
