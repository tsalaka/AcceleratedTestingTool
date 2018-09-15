using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using AcceleratedTool.XmlApi.Contracts.Requests;
using AcceleratedTool.XmlApi.Contracts.Responses;
using AcceleratedTool.XmlApi.XmlApiService;
using Moq;
using NUnit.Framework;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class XmlApiServiceTests
    {
        private readonly Mock<IWebRequest> _webRequest = new Mock<IWebRequest>();
        private XmlApiSettings _apiSettings;
        private string _responseListString;
        private string _responseString;

        [SetUp]
        public void SetUp()
        {
            _apiSettings = new XmlApiSettings
            {
                Url = "url",
                UserName = "UserName",
                Password = "Password"
            };

            _responseString =
             @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='RunQuery'>
                  <HyperFindResult FullName='Gallo, Leo' PersonNumber='46'/>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _responseListString =
            @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='RunQuery'>
                  <HyperFindResult FullName='Gallo, Leo' PersonNumber='46'/>
                  <HyperFindResult FullName='Super, Pat' PersonNumber='45'/>

               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";
        }

        [Test]
        public void DeserialiseXmlToApiResponseEntity()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(_responseString);

            var xmlService = new XmlApiService<HyperFindQuery, HyperFindResult>(_apiSettings, _webRequest.Object);
            var result = xmlService.GetResponse(body, "RunQuery");
            Assert.NotNull(result);
            Assert.AreEqual("Gallo, Leo", result.FullName);
            Assert.AreEqual("46", result.PersonNumber);
        }

        [Test]
        public void DeserialiseXmlToApiResponseList()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(_responseListString);

            var xmlService = new XmlApiService<HyperFindQuery, List<HyperFindResult>>(_apiSettings, _webRequest.Object);
            var results = xmlService.GetResponse(body, "RunQuery");
            Assert.NotNull(results);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("Gallo, Leo", results.First().FullName);
            Assert.AreEqual("46", results.First().PersonNumber);
            Assert.AreEqual("Super, Pat", results.Skip(1).Take(1).First().FullName);
            Assert.AreEqual("45", results.Skip(1).Take(1).First().PersonNumber);
        }

        [Test]
        public void TestThatXmlApiServiceThrowsAnExceptionIsLogonStatusIsNotSuccess()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };

            var responseString =
            @"<WFC>
               <Response Status='Failed' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='RunQuery'>
                  <HyperFindResult FullName='Gallo, Leo' PersonNumber='46'/>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(responseString);

            var xmlService = new XmlApiService<HyperFindQuery, List<HyperFindResult>>(_apiSettings, _webRequest.Object);

            Assert.Throws<UnauthorizedAccessException>(() => xmlService.GetResponse(body, "RunQuery"));
        }

        [Test]
        public void TestThatXmlApiServiceThrowsAnExceptionIsResultBodyStatusIsNotSuccess()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };

            var responseString =
            @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Failed' Action='RunQuery'>
                  <HyperFindResult FullName='Gallo, Leo' PersonNumber='46'/>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(responseString);

            var xmlService = new XmlApiService<HyperFindQuery, List<HyperFindResult>>(_apiSettings, _webRequest.Object);
            Assert.Throws<ServerException>(() => xmlService.GetResponse(body, "RunQuery"));
        }
    }
}
