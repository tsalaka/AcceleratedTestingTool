using System.Collections.Generic;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PayRules
{
    public class WSAWorkRulePCDistr
    {
        public List<SimpleValue> ExtensionNames { get; set; }

        public List<SimpleValue> OvertimeRuleNames { get; set; }

        public List<SimpleValue> ZoneRuleNames { get; set; }

        public List<SimpleValue> ScheduleDeviationRuleNames { get; set; }
    }
}
