using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Xml;
using System.Xml.Serialization;
using AcceleratedTool.XmlApi.Exceptions;
using AcceleratedTool.XmlApi.XmlApiService.Response;

namespace AcceleratedTool.XmlApi.XmlApiService
{
    public class XmlApiWriteService<TRequest> : XmlApiService<TRequest, EmptyResponseBody>
        where TRequest : class
    {
        public XmlApiWriteService(XmlApiSettings apiSettings, IWebRequest webRequest)
            : base(apiSettings, webRequest)
        {
        }

        protected override EmptyResponseBody ParseXmlToEntity(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlApiEmptyResponse));
            EmptyResponseBody body;
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                var response = (XmlApiEmptyResponse)serializer.Deserialize(reader);
                if (!response.LogonResponse.Status.Equals("success", StringComparison.OrdinalIgnoreCase))
                {
                    throw new UnauthorizedAccessException(string.Format("XmlApi returns {0} status", response.LogonResponse.Status));
                }

                if (!response.ResponseBody.Status.Equals("success", StringComparison.OrdinalIgnoreCase))
                {
                    throw new XmlApiServerException(
                        string.Format("XmlApi returns {0} status", response.ResponseBody.Status), response.ResponseBody.Error);
                }

                body = response.ResponseBody;
            }

            return body;
        }
    }
}
