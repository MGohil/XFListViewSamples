using Newtonsoft.Json;

namespace XFListViewSamples.Models
{
    public class IncomeExpenseModel
    {
        [JsonProperty("income")]
        public int Income { get; set; }
        [JsonProperty("expense")]
        public int Expense { get; set; }
        [JsonProperty("month")]
        public string Month { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
