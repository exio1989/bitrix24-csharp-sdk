using System;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Utilities
{
    public abstract class AbstractTest : IDisposable
    {
        protected Bitrix24 bitrix24;
        protected List<int> AllocatedDeals = new List<int>();
        protected List<int> AllocatedProducts = new List<int>();
        protected List<int> AllocatedContacts = new List<int>();
        protected List<int> AllocatedLeads = new List<int>();
        protected List<int> AllocatedCompanies = new List<int>();
        protected List<int> AllocatedRequisites = new List<int>();
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

            foreach (var id in AllocatedRequisites)
                tasks.Add(bitrix24.Crm.Requisites.Delete(id));

            Task.WaitAll(tasks.ToArray());
        }
    }
}
