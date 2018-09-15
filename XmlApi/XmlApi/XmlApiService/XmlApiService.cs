using System;
using System.IO;
using System.Runtime.Remoting;
using System.Xml;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.XmlApiService.Request;
using AcceleratedTool.XmlApi.XmlApiService.Response;

namespace AcceleratedTool.XmlApi.XmlApiService
{
    public class XmlApiService<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        private const string MethodName = "POST";
        private const string ContentType = "text/xml";
        private readonly XmlApiSettings _apiSettings;
        private readonly IWebRequest _webRequest;

        public XmlApiService(XmlApiSettings apiSettings, IWebRequest webRequest)
        {
            _apiSettings = apiSettings;
            _webRequest = webRequest;
        }

        public TResponse GetResponse(TRequest body, string actionName)
        {
            var xmlRequest = new XmlApiRequest<TRequest>(
                                                        body,
                                                        actionName,
                                                        _apiSettings.UserName,
                                                        _apiSettings.Password);

            var xs = new XmlSerializer(typeof(XmlApiRequest<TRequest>));
            var xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add(string.Empty, string.Empty);
            byte[] contentArray;
            using (var buffer = new MemoryStream())
            {
                xs.Serialize(buffer, xmlRequest, xmlnsEmpty);
                buffer.Position = 0;
                contentArray = buffer.ToArray();
            }

            var response = _webRequest.GetResponse(_apiSettings.Url, contentArray, MethodName, ContentType);
            if (response == null)
            {
                throw new Exception("XmlApi response is empty");
            }

            return ParseXmlToEntity(response);
        }

        protected virtual TResponse ParseXmlToEntity(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlApiResponse<TResponse>));
            TResponse body;
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                var response = (XmlApiResponse<TResponse>)serializer.Deserialize(reader);
                if (!response.LogonResponse.Status.Equals("success", StringComparison.OrdinalIgnoreCase))
                {
                    throw new UnauthorizedAccessException(string.Format("XmlApi returns {0} status", response.LogonResponse.Status));
                }

                if (!response.ResponseBody.Status.Equals("success", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ServerException(string.Format("XmlApi returns {0} status", response.ResponseBody.Status));
                }

                body = response.ResponseBody.Body;
            }

            return body;
        }
    }
}
