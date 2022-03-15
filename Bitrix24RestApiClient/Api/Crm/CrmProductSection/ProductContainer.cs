using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmProductSection.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmProduct
{
    public class ProductSectionContainer : AbstractEntities<ProductSection>
    {
        public ProductSectionContainer(IBitrix24Client client)
            :base(client, EntryPointPrefix.ProductSection)
        {
        }
    }
}
