using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Contracts;
using AcceleratedTool.XmlApi.Contracts.Requests;
using AcceleratedTool.XmlApi.XmlApiService.Request;
using NUnit.Framework;
using Identity = AcceleratedTool.XmlApi.Contracts.Responses.Identity;
using Personality = AcceleratedTool.XmlApi.Contracts.Responses.Personality;
using PersonIdentity = AcceleratedTool.XmlApi.Contracts.Responses.PersonIdentity;

namespace AcceleratedTool.XmlApi.Tests
{
    [TestFixture]
    public class XmlApiRequestTests
    {
        [Test]
        public void SerializeApiRequestListToXml()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };
            var list = new List<HyperFindQuery>();
            list.Add(body);
            var body2 = new HyperFindQuery
            {
                HyperFindQueryName = "All Home2",
                VisibilityCode = "Public2",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };
            list.Add(body2);

            var xmlRequest = new XmlApiRequest<List<HyperFindQuery>>(list, "RunQuery", "user", "passowrd");
            var xs = new XmlSerializer(typeof(XmlApiRequest<List<HyperFindQuery>>));
            var xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add(string.Empty, string.Empty);
            using (var buffer = new MemoryStream())
            {
                xs.Serialize(buffer, xmlRequest, xmlnsEmpty);
                var xml = new XmlDocument();
                xml.LoadXml(Encoding.UTF8.GetString(buffer.ToArray()));
                Assert.NotNull(xml);
                Assert.AreEqual("WFC", xml.DocumentElement.Name);
                Assert.AreEqual("1.0", xml.DocumentElement.Attributes["version"].Value);
                var logon = xml.DocumentElement.SelectNodes("Request")[0];
                Assert.NotNull(logon);
                Assert.AreEqual("Logon", logon.Attributes["Action"].Value);
                var logoff = xml.DocumentElement.SelectNodes("Request")[2];
                Assert.NotNull(logoff);
                Assert.AreEqual("Logoff", logoff.Attributes["Action"].Value);
                var bodyRequest = xml.DocumentElement.SelectNodes("Request")[1].SelectNodes("HyperFindQuery")[0];
                Assert.NotNull(bodyRequest);
                Assert.AreEqual("All Home", bodyRequest.Attributes["HyperFindQueryName"].Value);
                Assert.AreEqual("Public", bodyRequest.Attributes["VisibilityCode"].Value);
                Assert.AreEqual("2/11/2017-2/12/2017", bodyRequest.Attributes["QueryDateSpan"].Value);
                var bodyRequest2 = xml.DocumentElement.SelectNodes("Request")[1].SelectNodes("HyperFindQuery")[1];
                Assert.NotNull(bodyRequest2);
                Assert.AreEqual("All Home2", bodyRequest2.Attributes["HyperFindQueryName"].Value);
                Assert.AreEqual("Public2", bodyRequest2.Attributes["VisibilityCode"].Value);
            }
        }

        [Test]
        public void SerializeHyperFindQueryToXml()
        {
            var body = new HyperFindQuery
            {
                HyperFindQueryName = "All Home",
                VisibilityCode = "Public",
                QueryDateStart = new DateTime(2017, 2, 11),
                QueryDateEnd = new DateTime(2017, 2, 12)
            };

            var xmlRequest = new XmlApiRequest<HyperFindQuery>(body, "RunQuery", "user", "passowrd");
            var xs = new XmlSerializer(typeof(XmlApiRequest<HyperFindQuery>));
            var xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add(string.Empty, string.Empty);
            using (var buffer = new MemoryStream())
            {
                xs.Serialize(buffer, xmlRequest, xmlnsEmpty);
                var xml = new XmlDocument();
                xml.LoadXml(Encoding.UTF8.GetString(buffer.ToArray()));
                Assert.NotNull(xml);
                Assert.AreEqual("WFC", xml.DocumentElement.Name);
                Assert.AreEqual("1.0", xml.DocumentElement.Attributes["version"].Value);
                var logon = xml.DocumentElement.SelectNodes("Request")[0];
                Assert.NotNull(logon);
                Assert.AreEqual("Logon", logon.Attributes["Action"].Value);
                var logoff = xml.DocumentElement.SelectNodes("Request")[2];
                Assert.NotNull(logoff);
                Assert.AreEqual("Logoff", logoff.Attributes["Action"].Value);
                var bodyRequest = xml.DocumentElement.SelectNodes("Request")[1].SelectNodes("HyperFindQuery")[0];
                Assert.NotNull(bodyRequest);
                Assert.AreEqual("All Home", bodyRequest.Attributes["HyperFindQueryName"].Value);
                Assert.AreEqual("Public", bodyRequest.Attributes["VisibilityCode"].Value);
                Assert.AreEqual("2/11/2017-2/12/2017", bodyRequest.Attributes["QueryDateSpan"].Value);
            }
        }

        [Test]
        public void SerializePersonalityToXml()
        {
            var body = new List<Personality>();
            body.Add(new Personality()
            {
              Identity = new Identity
              {
                  PersonIdentity = new PersonIdentity
                    {
                        PersonNumber = "adsasd",
                        EmployeeKey = 12344
                    }
                }
            });
            body.Add(new Personality()
            {
                Identity = new Identity
                {
                    PersonIdentity = new PersonIdentity
                    {
                        PersonNumber = "aaaaaa"
                    }
                }
            });

            var xmlRequest = new XmlApiRequest<List<Personality>>(body, "Load", "user", "passowrd");
            var xs = new XmlSerializer(typeof(XmlApiRequest<List<Personality>>));
            var xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add(string.Empty, string.Empty);
            using (var buffer = new MemoryStream())
            {
                xs.Serialize(buffer, xmlRequest, xmlnsEmpty);
                var xml = new XmlDocument();
                xml.LoadXml(Encoding.UTF8.GetString(buffer.ToArray()));
                Assert.NotNull(xml);
                Assert.AreEqual("WFC", xml.DocumentElement.Name);
                Assert.AreEqual("1.0", xml.DocumentElement.Attributes["version"].Value);
                var logon = xml.DocumentElement.SelectNodes("Request")[0];
                Assert.NotNull(logon);
                Assert.AreEqual("Logon", logon.Attributes["Action"].Value);
                var logoff = xml.DocumentElement.SelectNodes("Request")[2];
                Assert.NotNull(logoff);
                Assert.AreEqual("Logoff", logoff.Attributes["Action"].Value);
                var bodyRequest = xml.DocumentElement.SelectNodes("Request")[1].SelectNodes("Personality/Identity")[0];
                Assert.NotNull(bodyRequest);
            }
        }
    }
}
