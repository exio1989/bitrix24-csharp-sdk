using Xunit;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Test.Utilities;
using Bitrix24RestApiClient.Core.Models.Response.BatchResponse;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items.Models;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class CompanyContactTests: AbstractTest
    {

        [Fact]
        public async Task GetFieldsTest()
        {            
            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            FieldsResponse fields = await bitrix24.Crm.Companies.Contacts.Fields();
        }

        [Fact]
        public async Task AddTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            List<CompanyContactItem> contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            await bitrix24.Crm.Companies.Contacts.Add(companyId.Value, x => x.SetField(x => x.ContactId, contactId));
            Assert.Empty(contactItems);

            contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            Assert.Equal(1, contactItems.Count);
            Assert.Equal(contactId, contactItems.First().ContactId);
        }

        [Fact]
        public async Task DeleteTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            List<CompanyContactItem> contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            await bitrix24.Crm.Companies.Contacts.Add(companyId.Value, x => x.SetField(x => x.ContactId, contactId));
            Assert.Empty(contactItems);

            contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            Assert.NotEmpty(contactItems);

            await bitrix24.Crm.Companies.Contacts.Delete(companyId.Value, contactId.Value);

            contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            Assert.Empty(contactItems);
        }

        [Fact]
        public async Task DeleteAllContactsTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            List<CompanyContactItem> contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            await bitrix24.Crm.Companies.Contacts.Add(companyId.Value, x => x.SetField(x => x.ContactId, contactId));
            Assert.Empty(contactItems);

            contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            Assert.NotEmpty(contactItems);

            await bitrix24.Crm.Companies.Contacts.Items.Delete(companyId.Value);

            contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            Assert.Empty(contactItems);
        }

        [Fact]
        public async Task SetContactsTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? contactId1 = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId1.Value);

            int? contactId2 = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId2.Value);

            List<CompanyContactItem> contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            await bitrix24.Crm.Companies.Contacts.Items.Set(companyId.Value, new List<CompanyContactItem>
                {
                    new CompanyContactItem
                    {
                        ContactId = contactId1
                    },
                    new CompanyContactItem
                    {
                        ContactId = contactId2
                    }
                });

            contactItems = (await bitrix24.Crm.Companies.Contacts.Items.Get(companyId.Value)).Result;
            Assert.Equal(2, contactItems.Count);
            Assert.True(contactItems.Any(x => x.ContactId == contactId1));
            Assert.True(contactItems.Any(x => x.ContactId == contactId2));
        }
    }
}
