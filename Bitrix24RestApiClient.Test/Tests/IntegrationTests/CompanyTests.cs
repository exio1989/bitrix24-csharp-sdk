using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.CrmCompany.Models;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class CompanyTests : AbstractTest
    {
        [Fact]
        public async Task AddTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            Company company = (await bitrix24.Crm.Companies.Get(companyId.Value)).Result;
            Assert.Equal(companyId.Value, company.Id);
        }

        [Fact]
        public async Task ListTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            ListResponse<Company> response = await bitrix24.Crm.Companies.List(x=>x
                .AddFilter(x=>x.Id, companyId.Value)
                .AddSelect(x=>x.Title));

            Assert.Equal("test", response.Result.First().Title);
        }

        [Fact]
        public async Task FirstTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            Company company = await bitrix24.Crm.Companies.First(x => x
                .AddFilter(x => x.Id, companyId.Value)
                .AddSelect(x => x.Title));

            Assert.Equal("test", company.Title);
        }

        [Fact]
        public async Task UpdateTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "fizz"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            await bitrix24.Crm.Companies.Update(companyId.Value, x => x.SetField(x => x.Title, "buzz"));

            Company company = (await bitrix24.Crm.Companies.Get(companyId.Value, x=>x.Title)).Result;
            Assert.Equal("buzz", company.Title);
        }

        [Fact]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Companies.Fields());
        }

        [Fact]
        public async Task DeleteTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;

            DeleteResponse deleteResponse = (await bitrix24.Crm.Companies.Delete(companyId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                Company company = (await bitrix24.Crm.Companies.Get(companyId.Value)).Result;
            });
        }
    }
}
