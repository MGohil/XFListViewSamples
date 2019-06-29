using Newtonsoft.Json;

namespace XFListViewSamples.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("profile_pic")]
        public string ProfilePic { get; set; }

        [JsonIgnore]
        public string FullName { get { return $"{ FirstName } { LastName }"; } }
    }
}