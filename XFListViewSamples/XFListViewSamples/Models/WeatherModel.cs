using Newtonsoft.Json;
using System;

namespace XFListViewSamples.Models
{
    public class WeatherModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("small_icon_url")]
        public string SmallIconURL { get; set; }

        [JsonProperty("large_icon_url")]
        public string LargeIconURL { get; set; }

        [JsonProperty("min")]
        public int MinTemp { get; set; }

        [JsonProperty("max")]
        public int MaxTemp { get; set; }
    }
}