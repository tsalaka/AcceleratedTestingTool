using System;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Extentions;

namespace AcceleratedTool.XmlApi.Contracts.Responses.PayRules
{
    public class WSAEffectivePayRule
    {
        [XmlIgnore]
        public bool? WorkRuleTransfers { get; set; }

        [XmlAttribute("WorkRuleTransfers")]
        public string WorkRuleTransfersString
        {
            get { return WorkRuleTransfers.ToApiBoolFormat(); }
            set { WorkRuleTransfers = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? PrepopulateProject { get; set; }

        [XmlAttribute("PrepopulateProject")]
        public string PrepopulateProjectString
        {
            get { return PrepopulateProject.ToApiBoolFormat(); }
            set { PrepopulateProject = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? QualifiedSignOffRuleName { get; set; }

        [XmlAttribute("QualifiedSignOffRuleName")]
        public string QualifiedSignOffRuleNameString
        {
            get { return QualifiedSignOffRuleName.ToApiBoolFormat(); }
            set { QualifiedSignOffRuleName = value.ToApiNullableBoolFormat(); }
        }

        [XmlAttribute]
        public string TerminalRuleName { get; set; }

        [XmlAttribute]
        public string FixedRuleName { get; set; }

        [XmlAttribute]
        public string HolidayCreditRuleName { get; set; }

        [XmlAttribute]
        public string WorkRuleName { get; set; }

        [XmlIgnore]
        public DateTime EffectiveDate { get; set; }

        [XmlAttribute("EffectiveDate")]
        public string EffectiveDateString
        {
            get { return EffectiveDate.ToApiDateFormat(); }
            set { EffectiveDate = value.ToApiDateFormat(); }
        }

        [XmlIgnore]
        public bool? CancelPFSOnHolidays { get; set; }

        [XmlAttribute("CancelPFSOnHolidays")]
        public string CancelPFSOnHolidaysString
        {
            get { return CancelPFSOnHolidays.ToApiBoolFormat(); }
            set { CancelPFSOnHolidays = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? LaborAccountAndJobTransfers { get; set; }

        [XmlAttribute("LaborAccountAndJobTransfers")]
        public string LaborAccountAndJobTransfersString
        {
            get { return LaborAccountAndJobTransfers.ToApiBoolFormat(); }
            set { LaborAccountAndJobTransfers = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? PayFromSchedule { get; set; }

        [XmlAttribute("PayFromSchedule")]
        public string PayFromScheduleString
        {
            get { return PayFromSchedule.ToApiBoolFormat(); }
            set { PayFromSchedule = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? ScheduleTotal { get; set; }

        [XmlAttribute("ScheduleTotal")]
        public string ScheduleTotalString
        {
            get { return ScheduleTotal.ToApiBoolFormat(); }
            set { ScheduleTotal = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? ApplyOnly { get; set; }

        [XmlAttribute("ApplyOnly")]
        public string ApplyOnlyString
        {
            get { return ApplyOnly.ToApiBoolFormat(); }
            set { ApplyOnly = value.ToApiNullableBoolFormat(); }
        }

        [XmlIgnore]
        public bool? TransferRegularHome { get; set; }

        [XmlAttribute("TransferRegularHome")]
        public string TransferRegularHomeString
        {
            get { return TransferRegularHome.ToApiBoolFormat(); }
            set { TransferRegularHome = value.ToApiNullableBoolFormat(); }
        }
    }
}
