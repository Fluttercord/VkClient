using Newtonsoft.Json;

namespace VkClient
{
    public class AudioInfo
    {
        [JsonProperty("aid")]
        public string Id { get; set; }
        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
