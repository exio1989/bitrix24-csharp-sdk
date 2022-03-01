using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmLead.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmLead
{
    public class LeadContainer: AbstractEntities<Lead>
    {
        public LeadContainer(IBitrix24Client client)
            :base(client, EntryPointPrefix.Lead)
        {
        }
    }
}
