using Newtonsoft.Json;

namespace VkClient
{
    public class UserInfo
    {
        public string Uid { get; set; }
        [JsonProperty("First_name")]
        public string FirstName { get; set; }
        [JsonProperty("Last_name")]
        public string LastName { get; set; }
        public string Photo { get; set; }
    }
}
