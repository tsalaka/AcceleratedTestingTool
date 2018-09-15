using System;
using AcceleratedTool.Excel.Models.Attributes;

namespace AcceleratedTool.Excel.Models.PayRuleBuilding
{
    public class PayRuleBuilding
    {
        [ExcelColumn(Order =1, Name = "Pay Rule Name")]
        public string PayruleName { get; set; }

        [ExcelColumn(Order = 2, Name = "Work Rule Transfers")]
        public bool? WorkRuleTransfers { get; set; }

        [ExcelColumn(Order = 3, Name = "Prepopulate Project")]
        public bool? PrepopulateProject { get; set; }

        [ExcelColumn(Order = 4, Name = "Qualified Sign Off Rule Name")]
        public bool? QualifiedSignOffRuleName { get; set; }

        [ExcelColumn(Order = 5, Name = "Terminal Rule Name")]
        public string TerminalRuleName { get; set; }

        [ExcelColumn(Order = 6, Name = "Effective Date")]
        public DateTime? EffectiveDate { get; set; }

        [ExcelColumn(Order = 7, Name = "Cancel PFS On Holidays")]
        public bool? CancelPfsOnHolidays { get; set; }

        [ExcelColumn(Order = 8, Name = "Labor Account And Job Transfers")]
        public bool? LaborAccountAndJobTransfers { get; set; }

        [ExcelColumn(Order = 9, Name = "Fixed Rule Name")]
        public string FixedRuleName { get; set; }

        [ExcelColumn(Order = 10, Name = "Pay From Schedule")]
        public bool? PayFromSchedule { get; set; }

        [ExcelColumn(Order = 11, Name = "Schedule Total")]
        public bool? ScheduleTotal { get; set; }

        [ExcelColumn(Order = 12, Name = "Apply Only")]
        public bool? ApplyOnly { get; set; }

        [ExcelColumn(Order = 13, Name = "Holiday Credit Rule Name")]
        public string HolidayCreditRuleName { get; set; }

        [ExcelColumn(Order = 14, Name = "Work Rule Name")]
        public string WorkRuleName { get; set; }

        [ExcelColumn(Order = 15, Name = "Transfer Regular Home")]
        public bool? TransferRegularHome { get; set; }

        [ExcelColumn(Order = 16, Name = "Exception Rule Name")]
        public string ExceptionRuleName { get; set; }

        [ExcelColumn(Order = 17, Name = "Day Divide Override")]
        public string DayDivideOverride { get; set; }

        [ExcelColumn(Order = 18, Name = "Pay Code Distribution Name")]
        public string PayCodeDistributionName { get; set; }

        [ExcelColumn(Order = 19, Name = "Round Rule Name")]
        public string RoundRuleName { get; set; }

        [ExcelColumn(Order = 20, Name = "Break Rule Names")]
        public string BreakRuleName { get; set; }

        [ExcelColumn(Order = 21, Name = "Bonus Deduct Rule Name")]
        public string BonusDeductRuleName { get; set; }

        [ExcelColumn(Order = 22, Name = "Schedule Deviation Rule Name")]
        public string ScheduleDeviationRuleName { get; set; }

        [ExcelColumn(Order = 23, Name = "Overtime Rule Name")]
        public string OvertimeRuleName { get; set; }

        [ExcelColumn(Order = 24, Name = "Zone Rule Names")]
        public string ZoneRuleName { get; set; }

        [ExcelColumn(Order = 25, Name = "Shift Guarantee Name")]
        public string ShiftGuaranteeName { get; set; }

        public PayRuleBuilding FindIntersection(PayRuleBuilding itemToCompare)
        {
            var resultOfComparison = new PayRuleBuilding();

            if (PayruleName == null || !PayruleName.Equals(itemToCompare.PayruleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.PayruleName = itemToCompare.PayruleName;

            if (WorkRuleTransfers != itemToCompare.WorkRuleTransfers)
                resultOfComparison.WorkRuleTransfers = itemToCompare.WorkRuleTransfers;

            if (PrepopulateProject != itemToCompare.PrepopulateProject)
                resultOfComparison.PrepopulateProject = itemToCompare.PrepopulateProject;

            if (QualifiedSignOffRuleName != itemToCompare.QualifiedSignOffRuleName)
                resultOfComparison.QualifiedSignOffRuleName = itemToCompare.QualifiedSignOffRuleName;

            if (TerminalRuleName == null || !TerminalRuleName.Equals(itemToCompare.TerminalRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.TerminalRuleName = itemToCompare.TerminalRuleName;

            if (!EffectiveDate.HasValue || EffectiveDate.Value.CompareTo(itemToCompare.EffectiveDate) != 0)
                resultOfComparison.EffectiveDate = itemToCompare.EffectiveDate;

            if (CancelPfsOnHolidays != itemToCompare.CancelPfsOnHolidays)
                resultOfComparison.CancelPfsOnHolidays = itemToCompare.CancelPfsOnHolidays;

            if (LaborAccountAndJobTransfers != itemToCompare.LaborAccountAndJobTransfers)
                resultOfComparison.LaborAccountAndJobTransfers = itemToCompare.LaborAccountAndJobTransfers;

            if (FixedRuleName == null || !FixedRuleName.Equals(itemToCompare.FixedRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.FixedRuleName = itemToCompare.FixedRuleName;

            if (PayFromSchedule != itemToCompare.PayFromSchedule)
                resultOfComparison.PayFromSchedule = itemToCompare.PayFromSchedule;

            if (ScheduleTotal != itemToCompare.ScheduleTotal)
                resultOfComparison.ScheduleTotal = itemToCompare.ScheduleTotal;

            if (ApplyOnly != itemToCompare.ApplyOnly)
                resultOfComparison.ApplyOnly = itemToCompare.ApplyOnly;

            if (HolidayCreditRuleName == null || !HolidayCreditRuleName.Equals(itemToCompare.HolidayCreditRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.HolidayCreditRuleName = itemToCompare.HolidayCreditRuleName;

            if (WorkRuleName == null || !WorkRuleName.Equals(itemToCompare.WorkRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.WorkRuleName = itemToCompare.WorkRuleName;

            if (TransferRegularHome != itemToCompare.TransferRegularHome)
                resultOfComparison.TransferRegularHome = itemToCompare.TransferRegularHome;

            if (ExceptionRuleName == null || !ExceptionRuleName.Equals(itemToCompare.ExceptionRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.ExceptionRuleName = itemToCompare.ExceptionRuleName;

            if (DayDivideOverride == null || !DayDivideOverride.Equals(itemToCompare.DayDivideOverride, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.DayDivideOverride = itemToCompare.DayDivideOverride;

            if (PayCodeDistributionName == null || !PayCodeDistributionName.Equals(itemToCompare.PayCodeDistributionName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.PayCodeDistributionName = itemToCompare.PayCodeDistributionName;

            if (RoundRuleName == null || !RoundRuleName.Equals(itemToCompare.RoundRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.RoundRuleName = itemToCompare.RoundRuleName;

            if (BreakRuleName == null || !BreakRuleName.Equals(itemToCompare.BreakRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.BreakRuleName = itemToCompare.BreakRuleName;

            if (BonusDeductRuleName == null || !BonusDeductRuleName.Equals(itemToCompare.BonusDeductRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.BonusDeductRuleName = itemToCompare.BonusDeductRuleName;

            if (ScheduleDeviationRuleName == null || !ScheduleDeviationRuleName.Equals(itemToCompare.ScheduleDeviationRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.ScheduleDeviationRuleName = itemToCompare.ScheduleDeviationRuleName;

            if (OvertimeRuleName == null || !OvertimeRuleName.Equals(itemToCompare.OvertimeRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.OvertimeRuleName = itemToCompare.OvertimeRuleName;

            if (ZoneRuleName == null || !ZoneRuleName.Equals(itemToCompare.ZoneRuleName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.ZoneRuleName = itemToCompare.ZoneRuleName;

            if (ShiftGuaranteeName == null || !ShiftGuaranteeName.Equals(itemToCompare.ShiftGuaranteeName, StringComparison.OrdinalIgnoreCase))
                resultOfComparison.ShiftGuaranteeName = itemToCompare.ShiftGuaranteeName;

            return resultOfComparison;
        }

        public PayRuleBuilding CopyTo()
        {
            var copy = new PayRuleBuilding
            {
                ApplyOnly = ApplyOnly,
                BonusDeductRuleName = BonusDeductRuleName,
                BreakRuleName = BreakRuleName,
                CancelPfsOnHolidays = CancelPfsOnHolidays,
                DayDivideOverride = DayDivideOverride,
                EffectiveDate = EffectiveDate,
                ExceptionRuleName = ExceptionRuleName,
                FixedRuleName = FixedRuleName,
                HolidayCreditRuleName = HolidayCreditRuleName,
                LaborAccountAndJobTransfers = LaborAccountAndJobTransfers,
                ZoneRuleName = ZoneRuleName,
                ShiftGuaranteeName = ShiftGuaranteeName,
                OvertimeRuleName = OvertimeRuleName,
                ScheduleDeviationRuleName = ScheduleDeviationRuleName,
                ScheduleTotal = ScheduleTotal,
                PayFromSchedule = PayFromSchedule,
                WorkRuleName = WorkRuleName,
                WorkRuleTransfers = WorkRuleTransfers,
                RoundRuleName = RoundRuleName,
                TransferRegularHome = TransferRegularHome,
                QualifiedSignOffRuleName = QualifiedSignOffRuleName,
                PayruleName = PayruleName,
                PayCodeDistributionName = PayCodeDistributionName,
                TerminalRuleName = TerminalRuleName,
                PrepopulateProject = PrepopulateProject
            };

            return copy;
        }
    }
}
