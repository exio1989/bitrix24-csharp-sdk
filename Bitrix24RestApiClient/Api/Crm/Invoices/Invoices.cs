using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Invoices
    {
        public Invoices(IBitrix24Client client)
        {
            Old = new OldInvoices(client);
        }

        public OldInvoices Old { get; private set; }
    }
}
