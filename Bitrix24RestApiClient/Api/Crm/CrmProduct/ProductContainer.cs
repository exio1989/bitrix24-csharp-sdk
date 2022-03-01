using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmProduct.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmProduct
{
    public class ProductContainer: AbstractEntities<Product>
    {
        public ProductContainer(IBitrix24Client client)
            :base(client, EntryPointPrefix.Product)
        {
        }
    }
}
