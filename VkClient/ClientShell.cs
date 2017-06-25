using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace VkClient
{
    public abstract class ClientShell : IDisposable
    {
        private readonly HttpClient _webClient = new HttpClient();

        private readonly string _scheme;
        private readonly string _host;

        public ClientShell(string scheme, string host)
        {
            _scheme = scheme;
            _host = host;
        }

        private Uri GetUri(string path, Dictionary<string, string> parameters)
        {
            var builder = new UriBuilder
            {
                Scheme = _scheme,
                Host = _host,
                Path = path,
                Query = string.Join("&", parameters.Select(pair => string.Format("{0}={1}", pair.Key, HttpUtility.UrlEncode(pair.Value))))
            };
            return builder.Uri;
        }

        protected async Task<T> ApiGet<T>(string path, Dictionary<string, string> parameters)
        {
            var uri = GetUri(path, parameters);
            var responseString = await _webClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }
    }
}
