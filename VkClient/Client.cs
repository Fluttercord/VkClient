using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace VkClient
{
    public class Client : IDisposable
    {
        private const string _usersGetMethod = "method/users.get";
        private const string _userAudiosGetMethod = "method/audio.get";

        private readonly HttpClient _webClient = new HttpClient();
        private readonly string _token;

        public Client(string token)
        {
            _token = token;
        }

        private Uri GetUri(string path, Dictionary<string, string> parameters)
        {
            var builder = new UriBuilder
            {
                Scheme = Uri.UriSchemeHttps,
                Host = "api.vk.com",
                Path = path,
                Query = string.Join("&", parameters.Select(pair => string.Format("{0}={1}", pair.Key, HttpUtility.UrlEncode(pair.Value))))
            };
            return builder.Uri;
        }

        private async Task<T> ApiGet<T>(string path, Dictionary<string, string> parameters)
        {
            var uri = GetUri(path, parameters);
            var responseString = await _webClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<UserInfo> GetUser(string userId)
        {
            var parameters = new Dictionary<string, string>
            { { "uids", userId } };
            var response = await ApiGet<VkResponse<UserInfo>>(_usersGetMethod, parameters);
            return response.Items[0];
        }

        public async Task<AudioInfo[]> GetUserAudios(string userId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "uid", userId },
                { "access_token", _token }
            };
            var response = await ApiGet<VkResponse<AudioInfo>>(_userAudiosGetMethod, parameters);
            return response.Items;
        }
        
        public void Dispose()
        {
            _webClient.Dispose();
        }
    }
}
