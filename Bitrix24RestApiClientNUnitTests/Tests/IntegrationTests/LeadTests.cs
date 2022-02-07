using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class LeadTests : AbstractTest
    {
        [Test]
        public async Task AddTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedLeads.Add(leadId.Value);

            Lead lead = (await bitrix24.Crm.Leads.Get(leadId.Value)).Result;
            Assert.AreEqual(leadId.Value, lead.Id);
        }

        [Test]
        public async Task ListTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedLeads.Add(leadId.Value);

            ListResponse<Lead> response = await bitrix24.Crm.Leads.List(x=>x
                .AddFilter(x=>x.Id, leadId.Value)
                .AddSelect(x=>x.Title));

            Assert.AreEqual("test", response.Result.First().Title);
        }

        [Test]
        public async Task FirstTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedLeads.Add(leadId.Value);

            Lead lead = await bitrix24.Crm.Leads.First(x => x
                .AddFilter(x => x.Id, leadId.Value)
                .AddSelect(x => x.Title));

            Assert.AreEqual("test", lead.Title);
        }

        [Test]
        public async Task UpdateTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "fizz"))).Result;
            AllocatedLeads.Add(leadId.Value);

            await bitrix24.Crm.Leads.Update(leadId.Value, x => x.SetField(x => x.Title, "buzz"));

            Lead lead = (await bitrix24.Crm.Leads.Get(leadId.Value, x=>x.Title)).Result;
            Assert.AreEqual("buzz", lead.Title);
        }

        [Test]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Leads.Fields());
        }

        [Test]
        public async Task DeleteTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "test"))).Result;

            DeleteResponse deleteResponse = (await bitrix24.Crm.Leads.Delete(leadId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                Lead lead = (await bitrix24.Crm.Leads.Get(leadId.Value)).Result;
            });
        }
    }
}