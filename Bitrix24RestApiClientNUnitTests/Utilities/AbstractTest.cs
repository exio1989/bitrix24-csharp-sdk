using Bitrix24ApiClient.src;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Utilities
{
    public abstract class AbstractTest : IDisposable
    {
        protected Bitrix24 bitrix24;
        protected List<int> AllocatedDeals = new List<int>();
        protected List<int> AllocatedProducts = new List<int>();
        protected List<int> AllocatedContacts = new List<int>();
        protected List<int> AllocatedLeads = new List<int>();
        protected List<int> AllocatedCompanies = new List<int>();
        protected List<int> AllocatedOldInvoices = new List<int>();
        protected List<int> AllocatedTimelineComments = new List<int>();

        public AbstractTest()
        {
            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            bitrix24 = new Bitrix24(client);
        }

        public void Dispose()
        {
            List<Task> tasks = new List<Task>();

            foreach (var id in AllocatedOldInvoices)
                tasks.Add(bitrix24.Crm.Invoices.Old.Delete(id));

            foreach (var id in AllocatedTimelineComments)
                tasks.Add(bitrix24.Crm.Timeline.Comments.Delete(id));

            foreach (var id in AllocatedCompanies)
                tasks.Add(bitrix24.Crm.Companies.Delete(id));

            foreach (var id in AllocatedDeals)
                tasks.Add(bitrix24.Crm.Deals.Delete(id));

            foreach (var id in AllocatedLeads)
                tasks.Add(bitrix24.Crm.Leads.Delete(id));

            foreach (var id in AllocatedContacts)
                tasks.Add(bitrix24.Crm.Contacts.Delete(id));

            foreach (var id in AllocatedProducts)
                tasks.Add(bitrix24.Crm.Products.Delete(id));

            Task.WaitAll(tasks.ToArray());
        }
    }
}
