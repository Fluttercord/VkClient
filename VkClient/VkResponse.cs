using Newtonsoft.Json;

namespace VkClient
{
    public class VkResponse<T>
    {
        [JsonProperty("response")]
        public T[] Items { get; set; }
    }
}
