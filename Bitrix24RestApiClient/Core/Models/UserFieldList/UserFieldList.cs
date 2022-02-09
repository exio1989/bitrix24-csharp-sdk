using Bitrix24RestApiClient.Core.Models;
using Newtonsoft.Json;
namespace Bitrix24ApiClient.src.Models.Crm
{
    public class UserFieldList: AbstractEntity
    {
        [JsonProperty(UserFieldListFields.Value)]
        public string Value { get; set; }
    }
}
