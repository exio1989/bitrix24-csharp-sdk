using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.CrmCompany.Models;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class CompanyTests : AbstractTest
    {
        [Test]
        public async Task AddTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            Company company = (await bitrix24.Crm.Companies.Get(companyId.Value)).Result;
            Assert.AreEqual(companyId.Value, company.Id);
        }

        [Test]
        public async Task ListTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            ListResponse<Company> response = await bitrix24.Crm.Companies.List(x=>x
                .AddFilter(x=>x.Id, companyId.Value)
                .AddSelect(x=>x.Title));

            Assert.AreEqual("test", response.Result.First().Title);
        }

        [Test]
        public async Task FirstTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            Company company = await bitrix24.Crm.Companies.First(x => x
                .AddFilter(x => x.Id, companyId.Value)
                .AddSelect(x => x.Title));

            Assert.AreEqual("test", company.Title);
        }

        [Test]
        public async Task UpdateTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "fizz"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            await bitrix24.Crm.Companies.Update(companyId.Value, x => x.SetField(x => x.Title, "buzz"));

            Company company = (await bitrix24.Crm.Companies.Get(companyId.Value, x=>x.Title)).Result;
            Assert.AreEqual("buzz", company.Title);
        }

        [Test]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Companies.Fields());
        }

        [Test]
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