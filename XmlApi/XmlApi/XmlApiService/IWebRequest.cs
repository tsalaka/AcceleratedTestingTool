namespace AcceleratedTool.XmlApi.XmlApiService
{
    public interface IWebRequest
    {
        string GetResponse(string url, byte[] contentArray, string method, string contentType);
    }
}
