using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class User
    {
        [JsonProperty(UserFields.Id)]
        public string Id { get; set; }

        [JsonProperty(UserFields.Email)]
        public string Email { get; set; }

        [JsonProperty(UserFields.Name)]
        public string Name { get; set; }

        [JsonProperty(UserFields.LastName)]
        public string LastName { get; set; }
    }
}
