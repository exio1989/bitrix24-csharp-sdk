using Newtonsoft.Json;
using Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow.Models;

namespace Bitrix24RestApiClient.Core.Models.Response
{
    public class UpdateProductRowResponseResult
    {
        [JsonProperty("productRow")]
        public ProductRowNew ProductRow { get; set; }
    }
}
 