using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Deal;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Invoice;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Lead;

namespace Bitrix24RestApiClient.Api.Crm.CrmStageHistory
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
