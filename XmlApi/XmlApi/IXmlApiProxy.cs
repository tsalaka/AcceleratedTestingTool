using System.Collections.Generic;
using AcceleratedTool.XmlApi.Contracts.Requests;
using AcceleratedTool.XmlApi.Contracts.Requests.PayCodeEdits;
using AcceleratedTool.XmlApi.Contracts.Requests.Schedules;
using AcceleratedTool.XmlApi.Contracts.Responses;
using Personality = AcceleratedTool.XmlApi.Contracts.Responses.Personality;
using WSAShiftGuarantee = AcceleratedTool.XmlApi.Contracts.Responses.ShiftGuarantee.WSAShiftGuarantee;

namespace AcceleratedTool.XmlApi
{
    public interface IXmlApiProxy
    {
        List<HyperFindResult> GetEmployeesPersonIdentities(HyperFindQuery query);

        List<Personality> LoadFullPersonalityData(List<Contracts.Requests.Personality> query);

        List<Contracts.Responses.PayRules.WSAPayRule> RetrieveAllForUpdateWsaPayrule(WSAPayRule query);

        List<Contracts.Responses.PayRules.WSAWorkRule> RetrieveAllForUpdateWsaWorkRule(WSAWorkRule query);

        List<Contracts.Responses.ExceptionRules.WSAExceptionRule> RetrieveAllForUpdateExceptionRule(WSAExceptionRule query);

        void DeleteScheduleData(List<Schedule> query);

        List<Contracts.Responses.Timesheets.Timesheet> LoadTimesheets(List<Timesheet> query);

        void DeletePunchData(List<Punch> query);

        void DeletePayCodeEditData(List<DeletePayCodeEdit> query);

        void AddOnlyPunchData(List<Punch> query);

        void AddScheduleItemData(List<Schedule> query);

        void AddOnlyPayCodeEditData(List<AddPayCodeEdit> query);

        void RemovePunch(List<Punch> query);

        void RemoveScheduleItems(List<Schedule> query);

        void RemovePayCodeEdit(List<AddPayCodeEdit> query);

        List<Contracts.Responses.OvertimeRules.WSAOvertimeRule> RetrieveAllForUpdateOvertimeRule(WSAOvertimeRule query);

        List<Contracts.Responses.BonusDeductRules.WSABonusDeductRule> RetrieveAllForUpdateBonuDeductRule(WSABonusDeductRule query);

        List<Contracts.Responses.WSAPayCode> RetrieveAllForUpdatePayCode(Contracts.Requests.WSAPayCode query);

        List<Contracts.Responses.WSAPunchRoundRule> RetrieveAllForUpdatePunchRoundRule(Contracts.Requests.WSAPunchRoundRule query);

        List<Contracts.Responses.WSABreakRule> RetrieveAllForUpdateBreakRule(Contracts.Requests.WSABreakRule query);

        List<WSAShiftGuarantee> RetrieveAllForUpdateShiftGuarantee(Contracts.Requests.WSAShiftGuarantee query);
    }
}
