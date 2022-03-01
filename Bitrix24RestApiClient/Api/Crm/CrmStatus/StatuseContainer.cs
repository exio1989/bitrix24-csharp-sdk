using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmStatus.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmStatus
{
    public class StatuseContainer: AbstractEntities<Status>
    {
        public StatuseContainer(IBitrix24Client client)
            :base(client, EntryPointPrefix.Status)
        {
        }
    }
}
