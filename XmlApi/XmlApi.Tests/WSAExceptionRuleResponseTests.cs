using System;
using System.Collections.Generic;
using System.Globalization;
using AcceleratedTool.XmlApi.Contracts.Requests;
using AcceleratedTool.XmlApi.Contracts.Responses.PersonInformations;
using AcceleratedTool.XmlApi.XmlApiService;
using Moq;
using NUnit.Framework;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class WSAExceptionRuleResponseTests
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
            var body = new WSAExceptionRule();
            var response =
           @"<WFC TimeStamp='2/22/2017 2:01AM GMT-05:00' version='1.0' WFCVersion='8.0.10.532'>
   <Response Status='Success' Timeout='1800' PersonNumber='SUPERUSER' Action='Logon' PersonKey='-1' UserName='superuser' Object='System'>
   </Response>
   <Response Status='Success' Action='RetrieveAllForUpdate'>
      <WSAExceptionRule EarlyOutNdPayCodeName='' Grace='0:00' InEarly='1:30' InLate='0:30' OutLate='0:30' Name='30 min, E + L, Unsch' LateInNdPayCodeName='' OutEarly='0:30' Round='0:01' LongInterval='99:00' InVeryEarly='24:00' OutVeryLate='24:00' ShortShift='0:00' Unscheduled='true'>
         <TotalBreakExceptions>
         </TotalBreakExceptions>
      </WSAExceptionRule>
      <WSAExceptionRule EarlyOutNdPayCodeName='' Grace='0:00' InEarly='0:08' InLate='0:18' OutLate='0:08' Name='8 min, Early &amp; Late, In &amp; Out' LateInNdPayCodeName='' OutEarly='0:08' Round='0:01' LongInterval='99:00' InVeryEarly='0:35' OutVeryLate='0:35' ShortShift='0:00' Unscheduled='false'>
         <TotalBreakExceptions>
         </TotalBreakExceptions>
      </WSAExceptionRule>
      <WSAExceptionRule EarlyOutNdPayCodeName='' Grace='0:00' InEarly='24:00' InLate='24:00' OutLate='24:00' Name='Unscheduled' LateInNdPayCodeName='' OutEarly='22:50' Round='0:01' LongInterval='99:00' InVeryEarly='24:00' OutVeryLate='24:00' ShortShift='0:00' Unscheduled='true'>
         <TotalBreakExceptions>
         </TotalBreakExceptions>
      </WSAExceptionRule>
   </Response>
   <Response Status='Success' Action='Logoff' Object='System'>
   </Response></WFC>";

            _webRequest.Setup(w => w.GetResponse(It.IsAny<string>(), new byte[] { It.IsAny<byte>() }, It.IsAny<string>(), It.IsAny<string>()));
            _webRequest.SetReturnsDefault(response);

            var xmlService = new XmlApiService<WSAExceptionRule, List<Contracts.Responses.ExceptionRules.WSAExceptionRule>>(_apiSettings, _webRequest.Object);
            var result = xmlService.GetResponse(body, "RetrieveAllForUpdate");
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("30 min, E + L, Unsch", result[0].Name);
            Assert.AreEqual("8 min, Early & Late, In & Out", result[1].Name);
            Assert.AreEqual(new TimeSpan(0, 30, 0), result[0].InLate);
            Assert.AreEqual(new TimeSpan(0, 18, 0), result[1].InLate);
            Assert.AreEqual(new TimeSpan(24, 0, 0), result[2].InLate);
            Assert.AreEqual(new TimeSpan(0, 30, 0), result[0].OutLate);
            Assert.AreEqual(new TimeSpan(0, 8, 0), result[1].OutLate);
            Assert.AreEqual(new TimeSpan(24, 0, 0), result[2].OutLate);
            Assert.AreEqual(new TimeSpan(1, 30, 0), result[0].InEarly);
            Assert.AreEqual(new TimeSpan(0, 8, 0), result[1].InEarly);
            Assert.AreEqual(new TimeSpan(24, 0, 0), result[2].InEarly);
            Assert.AreEqual(new TimeSpan(0, 30, 0), result[0].OutEarly);
            Assert.AreEqual(new TimeSpan(0, 8, 0), result[1].OutEarly);
            Assert.AreEqual(new TimeSpan(22, 50, 0), result[2].OutEarly);
            Assert.AreEqual(true, result[0].Unscheduled);
            Assert.AreEqual(false, result[1].Unscheduled);
            Assert.AreEqual(true, result[2].Unscheduled);
        }
    }
}
