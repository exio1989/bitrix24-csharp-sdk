using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow.Models;

namespace Bitrix24RestApiClient.Core.Models.Response.ListItemsResponse
{
    public class ListProductRowsResponseResult
    {
        [JsonProperty("productrows")]
        public List<ProductRowNew> ProductRows { get; set; }
    }
}
