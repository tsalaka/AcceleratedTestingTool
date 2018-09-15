using System;
using AcceleratedTool.XmlApi.Exceptions;
using AcceleratedTool.XmlApi.TestLogin;
using AcceleratedTool.XmlApi.XmlApiService;
using Moq;
using NUnit.Framework;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class TestLoginXmlApiServiceTests
    {
        private readonly Mock<IWebRequest> _webRequest = new Mock<IWebRequest>();
        private XmlApiSettings _apiSettings;

        [SetUp]
        public void SetUp()
        {
            _apiSettings = new XmlApiSettings
            {
                Url = "url",
                UserName = "UserName",
                Password = "Password"
            };
        }

        [Test]
        public void TestThatLoginIsSuccessfull()
        {
            var response =
         @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);

            var testLoginXmlApiService = new TestLoginXmlApiService(_apiSettings, _webRequest.Object);
            var result = testLoginXmlApiService.Test();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestThatLoginIsUnSuccessfull()
        {
            var response =
         @"<WFC>
               <Response Status='Failed' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'></Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);

            var testLoginXmlApiService = new TestLoginXmlApiService(_apiSettings, _webRequest.Object);
            var result = testLoginXmlApiService.Test();
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestThatLoginIsUnSuccessfullIfResponseIsEmpty()
        {
            string response = null;

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);
            var testLoginXmlApiService = new TestLoginXmlApiService(_apiSettings, _webRequest.Object);
            var exception = Assert.Throws<XmlApiLoginException>(() => testLoginXmlApiService.Test());
            Assert.AreEqual("Xml APi test is failed", exception.Message);
        }
    }
}
