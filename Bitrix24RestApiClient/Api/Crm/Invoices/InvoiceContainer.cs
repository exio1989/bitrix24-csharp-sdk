using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices;

namespace Bitrix24RestApiClient.Api.Crm.Invoices
{
    public class InvoiceContainer
    {
        public InvoiceContainer(IBitrix24Client client)
        {
            Old = new OldInvoiceContainer(client);
        }

        public OldInvoiceContainer Old { get; private set; }
    }
}
