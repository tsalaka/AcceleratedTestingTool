using AcceleratedTool.XmlApi.TestLogin;

namespace AcceleratedTool.Commands
{
    public class TestApiLoginCommand : ICommand
    {
        private readonly ITestLoginXmlApiService _loginXmlApiService;

        public TestApiLoginCommand(ITestLoginXmlApiService loginXmlApiService)
        {
            _loginXmlApiService = loginXmlApiService;
        }

        public bool Execute()
        {
            return _loginXmlApiService.Test();
        }
    }
}
