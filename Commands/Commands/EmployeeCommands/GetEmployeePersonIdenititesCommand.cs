using System.Collections.Generic;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Models.Employees;
using AcceleratedTool.XmlApi;

namespace AcceleratedTool.Commands.EmployeeCommands
{
    public class GetEmployeePersonIdenititesCommand : ICommand<HyperFindQuery, List<HyperFindResult>>
    {
        private readonly IXmlApiProxy _apiProxy;
        private readonly HyperFindMapper _hyperFindMapper;

        public GetEmployeePersonIdenititesCommand(IXmlApiProxy apiProxy, HyperFindMapper hyperFindMapper)
        {
            _apiProxy = apiProxy;
            _hyperFindMapper = hyperFindMapper;
        }

        public List<HyperFindResult> Execute(HyperFindQuery criteria)
        {
            var result = _apiProxy.GetEmployeesPersonIdentities(_hyperFindMapper.GetQueryWrapper(criteria));
            return _hyperFindMapper.GetResultWrapper(result);
        }
    }
}
