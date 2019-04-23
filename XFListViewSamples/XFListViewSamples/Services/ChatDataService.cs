using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XFListViewSamples.Models;

namespace XFListViewSamples.Services
{
    public class ChatDataService
    {
        private readonly List<ChatMessageModel> chatMessages;
        private readonly string chatJsonData = null;

        public ChatDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFListViewSamples.Data.chatmessages.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                chatJsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(chatJsonData))
                {
                    chatMessages = JsonConvert.DeserializeObject<List<ChatMessageModel>>(chatJsonData);
                }
            }
        }
        
        public async Task<IEnumerable<ChatMessageModel>> GetItemsAsync(int page, int pageSize)
        {
            return chatMessages.ToList();
        }
    }
}