using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;
using Bitrix24RestApiClient.src.Core;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class OldInvoices : AbstractEntities<Invoice>
    {
        public OldInvoices(IBitrix24Client client)
            :base(client, EntryPointPrefix.Invoice)
        {
        }

    }
}
