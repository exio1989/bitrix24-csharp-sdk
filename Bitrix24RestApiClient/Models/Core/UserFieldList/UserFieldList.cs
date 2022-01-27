using Newtonsoft.Json;
namespace Bitrix24ApiClient.src.Models.Crm
{
    public class UserFieldList
    {
        [JsonProperty(UserFieldListFields.Id)]
        public string Id { get; set; }

        [JsonProperty(UserFieldListFields.Value)]
        public string Value { get; set; }
    }
}
