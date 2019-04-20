using Newtonsoft.Json;

namespace XFListViewSamples.Models
{
    public class FruiteModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string ImageURL { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }
    }
}