using System;
using System.IO;
using System.Net;
using System.Runtime.Remoting;

namespace AcceleratedTool.XmlApi.XmlApiService
{
    public class WebRequestAdapter : IWebRequest
    {
        private const int DefaultTimeout = 9000000;
        private readonly int _timeout;

        public WebRequestAdapter() { }

        public WebRequestAdapter(int timeout)
        {
            _timeout = timeout;
        }

        public string GetResponse(string url, byte[] contentArray, string method, string contentType)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Timeout = webRequest.ReadWriteTimeout = _timeout == default(int) ? DefaultTimeout : _timeout;
                webRequest.Method = method;
                webRequest.ContentType = contentType;
                webRequest.ContentLength = contentArray.Length;
                webRequest.GetRequestStream().Write(contentArray, 0, contentArray.Length);
                using (var response = (HttpWebResponse)webRequest.GetResponse())
                {
                    var responseStream = response.GetResponseStream();
                    if (responseStream == null)
                    {
                        throw new Exception("XmlApi response is empty");
                    }

                    var responseReader = new StreamReader(responseStream);
                    return responseReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    if (ex.Status == WebExceptionStatus.Timeout)
                        throw new WebException("The operation has timeout. You can update timeout value in configuration file.");

                    if (ex.Status == WebExceptionStatus.ProtocolError || response.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        throw new ServerException("XmlApi server is unavailable");
                    }
                }

                throw ex;
            }
        }
    }
}
