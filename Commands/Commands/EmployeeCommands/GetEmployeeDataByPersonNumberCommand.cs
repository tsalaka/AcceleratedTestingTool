using System.Collections.Generic;
using AcceleratedTool.Commands.Mappers;
using AcceleratedTool.Models.Employees;
using AcceleratedTool.XmlApi;

namespace AcceleratedTool.Commands.EmployeeCommands
{
    public class GetEmployeeDataByPersonNumberCommand : ICommand<List<HyperFindResult>, List<Employee>>
    {
        private readonly IXmlApiProxy _apiProxy;
        private readonly PersonalityMapper _personalityMapper;

        public GetEmployeeDataByPersonNumberCommand(IXmlApiProxy apiProxy, PersonalityMapper personalityMapper)
        {
            _apiProxy = apiProxy;
            _personalityMapper = personalityMapper;
        }

        public List<Employee> Execute(List<HyperFindResult> criteria)
        {
            var personalities = _personalityMapper.Map(criteria);
            var result = _apiProxy.LoadFullPersonalityData(personalities);
            return _personalityMapper.Map(result);
        }
    }
}
