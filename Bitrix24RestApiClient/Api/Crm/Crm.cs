using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Crm
    {
        public Crm(IBitrix24Client client)
        {
            Leads = new Leads(client);
            Deals = new Deals(client);
            Companies = new Companies(client);
            Contacts = new Contacts(client);
            Timeline = new Timeline(client);
            Products = new Products(client);
            Invoices = new Invoices(client);
            PaySystems = new PaySystems(client);
            Statuses = new Statuses(client);
            SmartProcesses = new SmartProcesses(client);
        }
         
        public SmartProcesses SmartProcesses { get; private set; }
        public Companies Companies { get; private set; }
        public Leads Leads { get; private set; }
        public Deals Deals { get; private set; }
        public Contacts Contacts { get; private set; }
        public Timeline Timeline { get; private set; }
        public Products Products { get; private set; }
        public Invoices Invoices { get; private set; }
        public PaySystems PaySystems { get; private set; }
        public Statuses Statuses { get; private set; }
    }
}
