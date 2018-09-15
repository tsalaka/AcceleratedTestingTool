using AcceleratedTool.XmlApi.TestLogin;
using Moq;
using NUnit.Framework;

namespace AcceleratedTool.Commands.Tests
{
    [TestFixture]
    public class TestApiLoginCommandTests
    {
        private readonly Mock<ITestLoginXmlApiService> _testLoginXmlApiService = new Mock<ITestLoginXmlApiService>();

        [Test]
        public void TestThanTestApiLoginCommandReturnTrueIfXmlApiServiceReturnsTrue()
        {
            _testLoginXmlApiService.Setup(w => w.Test()).Returns(() => true);

            var testApiLoginCommand = new TestApiLoginCommand(_testLoginXmlApiService.Object);
            var result = testApiLoginCommand.Execute();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestThanTestApiLoginCommandReturnFalseIfXmlApiServiceReturnsFalse()
        {
            _testLoginXmlApiService.Setup(w => w.Test()).Returns(() => false);

            var testApiLoginCommand = new TestApiLoginCommand(_testLoginXmlApiService.Object);
            var result = testApiLoginCommand.Execute();
            Assert.AreEqual(false, result);
        }
    }
}
