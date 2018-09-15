using System;
using System.Collections.Generic;
using AcceleratedTool.XmlApi.Contracts.Requests;
using AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations;
using AcceleratedTool.XmlApi.XmlApiService;
using Moq;
using NUnit.Framework;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class XmlApiResponseTests
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
        public void TestThatBoolPropertyIsDeserialisedCorrectly()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };
            var response =
           @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='RunQuery'>
                  <AccessAssignment ManagerPayCodeName='Gallo, Leo' ApproveOvertimeFlag='false'/>
                  <AccessAssignment ManagerPayCodeName='Gallo, Leo' ApproveOvertimeFlag='true'/>
                  <AccessAssignment ManagerPayCodeName='Gallo, Leo' ApproveOvertimeFlag=''/>
                  <AccessAssignment ManagerPayCodeName='Gallo, Leo' ApproveOvertimeFlag='FALSE'/>
                  <AccessAssignment ManagerPayCodeName='Gallo, Leo' ApproveOvertimeFlag='TRUE'/>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);

            var xmlService = new XmlApiService<HyperFindQuery, List<AccessAssignment>>(_apiSettings, _webRequest.Object);
            var result = xmlService.GetResponse(body, "RunQuery");
            Assert.NotNull(result);
            Assert.AreEqual(false, result[0].ApproveOvertimeFlag);
            Assert.AreEqual(true, result[1].ApproveOvertimeFlag);
            Assert.AreEqual(null, result[2].ApproveOvertimeFlag);
            Assert.AreEqual(false, result[3].ApproveOvertimeFlag);
            Assert.AreEqual(true, result[4].ApproveOvertimeFlag);
        }

        [Test]
        public void TestThatDateTimePropertyIsDeserialisedCorrectly()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };
            var response =
            @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='RunQuery'>
                  <HomeAccount EffectiveDate='1/27/2018' ExpirationDate='12/7/2016'/>
                  <HomeAccount EffectiveDate='01/07/2018' ExpirationDate=''/>
                  <HomeAccount EffectiveDate='1/7/2018' ExpirationDate='12/30/2016'/>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);

            var xmlService = new XmlApiService<HyperFindQuery, List<HomeAccount>>(_apiSettings, _webRequest.Object);
            var result = xmlService.GetResponse(body, "RunQuery");
            Assert.NotNull(result);
            Assert.AreEqual(new DateTime(2018, 1, 27), result[0].EffectiveDate);
            Assert.AreEqual(new DateTime(2016, 12, 7), result[0].ExpirationDate);
            Assert.AreEqual(new DateTime(2018, 1, 7), result[1].EffectiveDate);
            Assert.AreEqual(null, result[1].ExpirationDate);
            Assert.AreEqual(new DateTime(2018, 1, 7), result[2].EffectiveDate);
            Assert.AreEqual(new DateTime(2016, 12, 30), result[2].ExpirationDate);
        }

        [Test]
        public void TestThatLongPropertyIsDeserialisedCorrectly()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };
            var response =
            @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='RunQuery'>
                  <PersonIdentity EmployeeKey='23423423432' PersonKey='123' />
                  <PersonIdentity UserKey='23423423'/>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);

            var xmlService = new XmlApiService<HyperFindQuery, List<Contracts.Responses.PersonIdentity>>(_apiSettings, _webRequest.Object);
            var result = xmlService.GetResponse(body, "RunQuery");
            Assert.NotNull(result);
            Assert.AreEqual(23423423432, result[0].EmployeeKey);
            Assert.AreEqual(123, result[0].PersonKey);
            Assert.AreEqual(null, result[0].UserKey);
            Assert.AreEqual(null, result[1].EmployeeKey);
            Assert.AreEqual(null, result[1].PersonKey);
            Assert.AreEqual(23423423, result[1].UserKey);
        }

        [Test]
        public void TestThatDecimalPropertyIsDeserialisedCorrectly()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };
            var response =
            @"<WFC>
               <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' Username='superuser' Object='System'>
               </Response>
               <Response Status='Success' Action='RunQuery'>
                  <Person BaseWageHourly='2.4535'/>
                  <Person/>
               </Response>
               <Response Status='Success' Action='Logoff' Object='System'>
               </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);

            var xmlService = new XmlApiService<HyperFindQuery, List<Contracts.Responses.Person>>(_apiSettings, _webRequest.Object);
            var result = xmlService.GetResponse(body, "RunQuery");
            Assert.NotNull(result);
            Assert.AreEqual(2.4535, result[0].BaseWageHourly);
            Assert.AreEqual(null, result[1].BaseWageHourly);
        }
    }
}
