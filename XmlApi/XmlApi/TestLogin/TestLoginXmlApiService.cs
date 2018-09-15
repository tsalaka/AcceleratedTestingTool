using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Exceptions;
using AcceleratedTool.XmlApi.XmlApiService;

namespace AcceleratedTool.XmlApi.TestLogin
{
    public class TestLoginXmlApiService : ITestLoginXmlApiService
    {
        private const string MethodName = "POST";
        private const string ContentType = "text/xml";
        private readonly XmlApiSettings _apiSettings;
        private readonly IWebRequest _webRequest;

        public TestLoginXmlApiService(XmlApiSettings apiSettings, IWebRequest webRequest)
        {
            _apiSettings = apiSettings;
            _webRequest = webRequest;
        }

        public bool Test()
        {
            try
            {
                var contentArray = CreateRequestContent();

                var response = _webRequest.GetResponse(_apiSettings.Url, contentArray, MethodName, ContentType);
                if (response == null)
                {
                    throw new XmlApiLoginException("XmlApi response is empty");
                }

                XmlSerializer serializer = new XmlSerializer(typeof(TestLoginResponse));
                using (var reader = XmlReader.Create(new StringReader(response)))
                {
                    var deserializedResponse = (TestLoginResponse)serializer.Deserialize(reader);
                    if (!deserializedResponse.LogonResponse.Status.Equals("success", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new XmlApiLoginException("Xml APi test is failed", ex);
            }

            return true;
        }

        private byte[] CreateRequestContent()
        {
            var xmlRequest = new TestLoginRequest(_apiSettings.UserName, _apiSettings.Password);

            var xs = new XmlSerializer(typeof(TestLoginRequest));
            var xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add(string.Empty, string.Empty);
            using (var buffer = new MemoryStream())
            {
                xs.Serialize(buffer, xmlRequest, xmlnsEmpty);
                buffer.Position = 0;
                return buffer.ToArray();
            }
        }
    }
}
