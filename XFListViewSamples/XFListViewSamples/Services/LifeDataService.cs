using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XFListViewSamples.Models;

namespace XFListViewSamples.Services
{
    public class LifeDataService
    {
        private readonly List<LifeOnPlanetModel> livingItems;
        private readonly string livingItemsJsonData = null;

        public LifeDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFListViewSamples.Data.lifeonplanet.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                livingItemsJsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(livingItemsJsonData))
                {
                    livingItems = JsonConvert.DeserializeObject<List<LifeOnPlanetModel>>(livingItemsJsonData);
                }
            }
        }

        public async Task<bool> AddItemAsync(LifeOnPlanetModel item)
        {
            livingItems.Add(item);

            return await Task.FromResult(true);
        }
        
        public async Task<IEnumerable<LifeOnPlanetModel>> GetItemsAsync()
        {
            return livingItems.ToList();
        }
    }
}