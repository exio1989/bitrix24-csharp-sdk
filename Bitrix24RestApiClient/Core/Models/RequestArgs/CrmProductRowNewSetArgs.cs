using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow.Models;

namespace Bitrix24RestApiClient.Core.Models.RequestArgs
{
    public class CrmProductRowNewSetArgs
    {
        [JsonProperty("ownerType")]
        public string OwnerType { get; set; }

        [JsonProperty("ownerId")]
        public int OwnerId { get; set; }

        [JsonProperty("productRows")]
        public List<ProductRowNew> ProductRows { get; set; }
    }
}
