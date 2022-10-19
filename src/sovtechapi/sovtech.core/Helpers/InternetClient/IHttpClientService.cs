using sovtech.core.Helpers.Autofac;

namespace Sovtech.Core.Helpers.InternetClient
{
    public interface IHttpClientService : IAutoDependencyCore
    {
        Task<HttpResponseMessage> MakeHttpCall(HttpMethod httpMethod, string url, object content = null, Dictionary<string, string> customHeaders = null);
    }
}