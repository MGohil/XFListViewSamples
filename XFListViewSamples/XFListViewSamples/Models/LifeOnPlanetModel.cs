using Newtonsoft.Json;

namespace XFListViewSamples.Models
{
    public class LifeOnPlanetModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}