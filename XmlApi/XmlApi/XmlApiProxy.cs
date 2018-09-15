using System.Collections.Generic;
using AcceleratedTool.XmlApi.Contracts.Requests;
using AcceleratedTool.XmlApi.Contracts.Requests.PayCodeEdits;
using AcceleratedTool.XmlApi.Contracts.Requests.Schedules;
using AcceleratedTool.XmlApi.Contracts.Responses;
using AcceleratedTool.XmlApi.XmlApiService;
using Personality = AcceleratedTool.XmlApi.Contracts.Responses.Personality;
using Punch = AcceleratedTool.XmlApi.Contracts.Requests.Punch;
using Timesheet = AcceleratedTool.XmlApi.Contracts.Requests.Timesheet;
using WSABonusDeductRule = AcceleratedTool.XmlApi.Contracts.Responses.BonusDeductRules.WSABonusDeductRule;
using WSABreakRule = AcceleratedTool.XmlApi.Contracts.Responses.WSABreakRule;
using WSAExceptionRule = AcceleratedTool.XmlApi.Contracts.Responses.ExceptionRules.WSAExceptionRule;
using WSAOvertimeRule = AcceleratedTool.XmlApi.Contracts.Responses.OvertimeRules.WSAOvertimeRule;
using WSAPayCode = AcceleratedTool.XmlApi.Contracts.Responses.WSAPayCode;
using WSAPayRule = AcceleratedTool.XmlApi.Contracts.Responses.PayRules.WSAPayRule;
using WSAPunchRoundRule = AcceleratedTool.XmlApi.Contracts.Responses.WSAPunchRoundRule;
using WSAShiftGuarantee = AcceleratedTool.XmlApi.Contracts.Responses.ShiftGuarantee.WSAShiftGuarantee;
using WSAWorkRule = AcceleratedTool.XmlApi.Contracts.Responses.PayRules.WSAWorkRule;

namespace AcceleratedTool.XmlApi
{
    public class XmlApiProxy : IXmlApiProxy
    {
        private readonly XmlApiSettings _apiSettings;
        private readonly IWebRequest _webRequest;

        public XmlApiProxy(XmlApiSettings apiSettings, IWebRequest webRequest)
        {
            _apiSettings = apiSettings;
            _webRequest = webRequest;
        }

        public List<HyperFindResult> GetEmployeesPersonIdentities(HyperFindQuery query)
        {
            var xmlApiService = new XmlApiService<HyperFindQuery, List<HyperFindResult>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RunQuery");
        }

        public List<Personality> LoadFullPersonalityData(List<Contracts.Requests.Personality> query)
        {
            var xmlApiService = new XmlApiService<List<Contracts.Requests.Personality>, List<Personality>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "Load");
        }

        public List<WSAPayRule> RetrieveAllForUpdateWsaPayrule(Contracts.Requests.WSAPayRule query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSAPayRule, List<WSAPayRule>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public List<WSAWorkRule> RetrieveAllForUpdateWsaWorkRule(Contracts.Requests.WSAWorkRule query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSAWorkRule, List<WSAWorkRule>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public List<WSAExceptionRule> RetrieveAllForUpdateExceptionRule(Contracts.Requests.WSAExceptionRule query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSAExceptionRule, List<WSAExceptionRule>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public void DeleteScheduleData(List<Schedule> query)
        {
            var xmlApiService = new XmlApiWriteService<List<Schedule>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "Delete");
        }

        public List<Contracts.Responses.Timesheets.Timesheet> LoadTimesheets(List<Timesheet> query)
        {
            var xmlApiService = new XmlApiService<List<Timesheet>, List<Contracts.Responses.Timesheets.Timesheet>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "Load");
        }

        public void DeletePunchData(List<Punch> query)
        {
            var xmlApiService = new XmlApiWriteService<List<Punch>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "Delete");
        }

        public void DeletePayCodeEditData(List<DeletePayCodeEdit> query)
        {
            var xmlApiService = new XmlApiWriteService<List<DeletePayCodeEdit>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "Delete");
        }

        public void AddOnlyPunchData(List<Punch> query)
        {
            var xmlApiService = new XmlApiWriteService<List<Punch>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "AddOnly");
        }

        public void AddScheduleItemData(List<Schedule> query)
        {
            var xmlApiService = new XmlApiWriteService<List<Schedule>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "AddScheduleItems");
        }

        public void AddOnlyPayCodeEditData(List<AddPayCodeEdit> query)
        {
            var xmlApiService = new XmlApiWriteService<List<AddPayCodeEdit>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "AddOnly");
        }

        public void RemovePunch(List<Punch> query)
        {
            var xmlApiService = new XmlApiWriteService<List<Punch>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "Delete");
        }

        public void RemoveScheduleItems(List<Schedule> query)
        {
            var xmlApiService = new XmlApiWriteService<List<Schedule>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "RemoveScheduleItems");
        }

        public void RemovePayCodeEdit(List<AddPayCodeEdit> query)
        {
            var xmlApiService = new XmlApiWriteService<List<AddPayCodeEdit>>(_apiSettings, _webRequest);
            xmlApiService.GetResponse(query, "Delete");
        }

        public List<WSAOvertimeRule> RetrieveAllForUpdateOvertimeRule(Contracts.Requests.WSAOvertimeRule query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSAOvertimeRule, List<WSAOvertimeRule>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public List<WSABonusDeductRule> RetrieveAllForUpdateBonuDeductRule(Contracts.Requests.WSABonusDeductRule query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSABonusDeductRule, List<WSABonusDeductRule>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public List<WSAPayCode> RetrieveAllForUpdatePayCode(Contracts.Requests.WSAPayCode query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSAPayCode, List<WSAPayCode>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public List<WSAPunchRoundRule> RetrieveAllForUpdatePunchRoundRule(Contracts.Requests.WSAPunchRoundRule query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSAPunchRoundRule, List<WSAPunchRoundRule>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public List<WSABreakRule> RetrieveAllForUpdateBreakRule(Contracts.Requests.WSABreakRule query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSABreakRule, List<WSABreakRule>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }

        public List<WSAShiftGuarantee> RetrieveAllForUpdateShiftGuarantee(Contracts.Requests.WSAShiftGuarantee query)
        {
            var xmlApiService = new XmlApiService<Contracts.Requests.WSAShiftGuarantee, List<WSAShiftGuarantee>>(_apiSettings, _webRequest);
            return xmlApiService.GetResponse(query, "RetrieveAllForUpdate");
        }
    }
}