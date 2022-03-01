using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core;

namespace Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices
{
    public class OldInvoiceContainer : AbstractEntities<Invoice>
    {
        public OldInvoiceContainer(IBitrix24Client client)
            :base(client, EntryPointPrefix.Invoice)
        {
        }

    }
}
