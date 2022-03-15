using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Api.Crm.Item;
using Bitrix24RestApiClient.Api.Crm.CrmDeal;
using Bitrix24RestApiClient.Api.Crm.CrmLead;
using Bitrix24RestApiClient.Api.Crm.Invoices;
using Bitrix24RestApiClient.Api.Crm.Timeline;
using Bitrix24RestApiClient.Api.Crm.CrmStatus;
using Bitrix24RestApiClient.Api.Crm.Requisite;
using Bitrix24RestApiClient.Api.Crm.CrmCompany;
using Bitrix24RestApiClient.Api.Crm.CrmProduct;
using Bitrix24RestApiClient.Api.Crm.CrmContact;
using Bitrix24RestApiClient.Api.Crm.CrmPaySystem;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory;
using Bitrix24RestApiClient.Api.Crm.SmartProcessTypes;

namespace Bitrix24RestApiClient.Api.Crm
{
    public class CrmContainer
    {
        public CrmContainer(IBitrix24Client client)
        {
            Leads = new LeadContainer(client);
            Deals = new DealContainer(client);
            Companies = new CompanyContainer(client);
            Contacts = new ContactContainer(client);
            Timeline = new TimelineContainer(client);
            Products = new ProductContainer(client);
            Invoices = new InvoiceContainer(client);
            PaySystems = new PaySystemContainer(client);
            Statuses = new StatuseContainer(client);
            SmartProcessTypes = new SmartProcessTypeContainer(client);
            StageHistories = new StageHistories(client);
            SmartProcesses = new ItemContainer(client);
            Requisites = new RequisitesContainer(client);
            ProductSections = new ProductSectionContainer(client);
        }
         
        public ProductSectionContainer ProductSections { get; private set; }
        public RequisitesContainer Requisites { get; private set; }
        public ItemContainer SmartProcesses { get; private set; }
        public SmartProcessTypeContainer SmartProcessTypes { get; private set; }
        public CompanyContainer Companies { get; private set; }
        public LeadContainer Leads { get; private set; }
        public DealContainer Deals { get; private set; }
        public ContactContainer Contacts { get; private set; }
        public TimelineContainer Timeline { get; private set; }
        public ProductContainer Products { get; private set; }
        public InvoiceContainer Invoices { get; private set; }
        public PaySystemContainer PaySystems { get; private set; }
        public StatuseContainer Statuses { get; private set; }
        public StageHistories StageHistories { get; private set; }
    }
}
