using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class StageHistories
    {
        public StageHistories(IBitrix24Client client)
        {
            Deals = new DealStageHistories(client);
            Leads = new LeadStageHistories(client);
            Invoicies = new InvoiceStageHistories(client);
        }

        public DealStageHistories Deals { get; private set; }
        public LeadStageHistories Leads { get; private set; }
        public InvoiceStageHistories Invoicies { get; private set; }
    }
}
