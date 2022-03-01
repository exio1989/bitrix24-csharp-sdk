using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmCompany.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmCompany
{
    public class CompanyContainer : AbstractEntities<Company>
    {
        public CompanyContainer(IBitrix24Client client)
            : base(client, EntryPointPrefix.Company)
        {
        }
    }
}
