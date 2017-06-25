using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VkClient
{
    public class Client : ClientShell
    {
        private const string _host = "api.vk.com";
        private const string _usersGetMethod = "method/users.get";
        private const string _userAudiosGetMethod = "method/audio.get";
        
        private readonly string _token;

        public Client(string token)
            : base(Uri.UriSchemeHttps, _host)
        {
            _token = token;
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
    }
}
