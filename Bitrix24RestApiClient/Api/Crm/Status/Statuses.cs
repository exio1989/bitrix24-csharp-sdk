using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Statuses: AbstractEntity<Status>
    {
        public Statuses(IBitrix24Client client)
            :base(client, EntityTypePrefix.Lead)
        {
        }
    }
}
