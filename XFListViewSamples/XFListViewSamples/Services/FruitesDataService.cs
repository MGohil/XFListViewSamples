using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XFListViewSamples.Models;

namespace XFListViewSamples.Services
{
    public class FruitesDataService
    {
        private readonly List<FruiteModel> fruites;
        private readonly string fruiteJsonData = null;

        public FruitesDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFListViewSamples.Data.fruites.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                fruiteJsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(fruiteJsonData))
                {
                    fruites = JsonConvert.DeserializeObject<List<FruiteModel>>(fruiteJsonData);
                }
            }
        }

        public async Task<bool> AddItemAsync(FruiteModel item)
        {
            fruites.Add(item);

            return await Task.FromResult(true);
        }
        
        public async Task<IEnumerable<FruiteModel>> GetItemsAsync(int page, int pageSize)
        {
            return fruites.ToList();
        }
    }
}