using System.Collections.Generic;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.Timesheets
{
    public class Timesheet
    {
        [XmlIgnore]
        public bool TotalsUpToDateFlag { get; set; }

        [XmlAttribute("TotalsUpToDateFlag")]
        public string TotalsUpToDateFlagString
        {
            get { return TotalsUpToDateFlag.ToApiBoolFormat(); }
            set { TotalsUpToDateFlag = value.ToApiBoolFormat(); }
        }

        public Employee Employee { get; set; }

        public Period Period { get; set; }

        public List<TotaledSpan> TotaledSpans { get; set; }

        public List<PayCodeEdit> TotaledPayCodeEdits { get; set; }

        public List<DateTotals> DailyTotals { get; set; }

        public PeriodTotalData PeriodTotalData { get; set; }
    }
}
