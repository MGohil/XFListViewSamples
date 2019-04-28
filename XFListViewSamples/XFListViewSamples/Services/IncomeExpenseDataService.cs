using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XFListViewSamples.Models;

namespace XFListViewSamples.Services
{
    public class IncomeExpenseDataService
    {
        private readonly List<IncomeExpenseModel> incomeExpenses;
        private readonly string incomeExpenseJsonData = null;

        public IncomeExpenseDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XFListViewSamples.Data.incomeexpence.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                incomeExpenseJsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(incomeExpenseJsonData))
                {
                    incomeExpenses = JsonConvert.DeserializeObject<List<IncomeExpenseModel>>(incomeExpenseJsonData);
                }
            }
        }
        
        public async Task<IEnumerable<IncomeExpenseModel>> GetItemsAsync(int page, int pageSize)
        {
            return incomeExpenses.ToList();
        }
    }
}