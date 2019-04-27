using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XFListViewSamples.Models;

namespace XFListViewSamples.Services
{
    public class WeatherDataService
    {
        private readonly List<WeatherModel> weatherHistory;
        private readonly string weatherJsonData = null;

        public WeatherDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFListViewSamples.Data.weather.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                weatherJsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(weatherJsonData))
                {
                    weatherHistory = JsonConvert.DeserializeObject<List<WeatherModel>>(weatherJsonData);
                }
            }
        }
        
        public async Task<IEnumerable<WeatherModel>> GetItemsAsync(int page, int pageSize)
        {
            return weatherHistory.ToList();
        }
    }
}