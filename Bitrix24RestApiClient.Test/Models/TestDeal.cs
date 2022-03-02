using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Test.Models
{
    public class TestDeal
    {

        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}
