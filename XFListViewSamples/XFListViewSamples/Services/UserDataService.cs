using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XFListViewSamples.Models;

namespace XFListViewSamples.Services
{
    /// <summary>
    /// Mock Data Downloaded from : https://mockaroo.com/
    /// </summary>
    public class UserDataService
    {
        private List<UserModel> users;
        private string userJsonData = null;

        public UserDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFListViewSamples.Data.users.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                userJsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(userJsonData))
                {
                    users = JsonConvert.DeserializeObject<List<UserModel>>(userJsonData);
                }
            }
        }

        public async Task<bool> AddItemAsync(UserModel item)
        {
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(UserModel item)
        {
            var oldItem = users.Where((UserModel arg) => arg.Id == item.Id).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = users.Where((UserModel arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<UserModel> GetItemAsync(int id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<UserModel>> GetItemsAsync(int page, int pageSize)
        {
            return users.Skip(page * pageSize).Take(pageSize).ToList();
        }
    }
}