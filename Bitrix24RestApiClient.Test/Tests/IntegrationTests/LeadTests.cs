using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.CrmLead.Models;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class LeadTests : AbstractTest
    {
        [Fact]
        public async Task AddTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedLeads.Add(leadId.Value);

            Lead lead = (await bitrix24.Crm.Leads.Get(leadId.Value)).Result;
            Assert.Equal(leadId.Value, lead.Id);
        }

        [Fact]
        public async Task ListTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedLeads.Add(leadId.Value);

            ListResponse<Lead> response = await bitrix24.Crm.Leads.List(x=>x
                .AddFilter(x=>x.Id, leadId.Value)
                .AddSelect(x=>x.Title));

            Assert.Equal("test", response.Result.First().Title);
        }

        [Fact]
        public async Task FirstTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedLeads.Add(leadId.Value);

            Lead lead = await bitrix24.Crm.Leads.First(x => x
                .AddFilter(x => x.Id, leadId.Value)
                .AddSelect(x => x.Title));

            Assert.Equal("test", lead.Title);
        }

        [Fact]
        public async Task UpdateTest()
        {
            int? leadId = (await bitrix24.Crm.Leads.Add(x => x.SetField(x => x.Title, "fizz"))).Result;
            AllocatedLeads.Add(leadId.Value);

            await bitrix24.Crm.Leads.Update(leadId.Value, x => x.SetField(x => x.Title, "buzz"));

            Lead lead = (await bitrix24.Crm.Leads.Get(leadId.Value, x=>x.Title)).Result;
            Assert.Equal("buzz", lead.Title);
        }

        [Fact]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Leads.Fields());
        }

        [Fact]
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
