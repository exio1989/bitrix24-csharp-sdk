using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items.Models;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class DealContactTests: AbstractTest
    {
        [Test]
        public async Task GetFieldsTest()
        {            
            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            FieldsResponse fields = await bitrix24.Crm.Deals.Contacts.Fields();
        }

        [Test]
        public async Task AddTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            List<DealContactItem> contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            await bitrix24.Crm.Deals.Contacts.Add(dealId.Value, x => x.SetField(x => x.ContactId, contactId));
            Assert.IsEmpty(contactItems);

            contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            Assert.AreEqual(1, contactItems.Count);
            Assert.AreEqual(contactId, contactItems.First().ContactId);
        }

        [Test]
        public async Task DeleteTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            List<DealContactItem> contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            await bitrix24.Crm.Deals.Contacts.Add(dealId.Value, x => x.SetField(x => x.ContactId, contactId));
            Assert.IsEmpty(contactItems);

            contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            Assert.IsNotEmpty(contactItems);

            await bitrix24.Crm.Deals.Contacts.Delete(dealId.Value, contactId.Value);

            contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            Assert.IsEmpty(contactItems);
        }

        [Test]
        public async Task DeleteAllContactsTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            List<DealContactItem> contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            await bitrix24.Crm.Deals.Contacts.Add(dealId.Value, x => x.SetField(x => x.ContactId, contactId));
            Assert.IsEmpty(contactItems);

            contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            Assert.IsNotEmpty(contactItems);

            await bitrix24.Crm.Deals.Contacts.Items.Delete(dealId.Value);

            contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            Assert.IsEmpty(contactItems);
        }

        [Test]
        public async Task SetContactsTest()
        {
            int? dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
            AllocatedDeals.Add(dealId.Value);

            int? contactId1 = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId1.Value);

            int? contactId2 = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId2.Value);

            List<DealContactItem> contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            await bitrix24.Crm.Deals.Contacts.Items.Set(dealId.Value, new List<DealContactItem>
                {
                    new DealContactItem
                    {
                        ContactId = contactId1
                    },
                    new DealContactItem
                    {
                        ContactId = contactId2
                    }
                });

            contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
            Assert.AreEqual(2, contactItems.Count);
            Assert.True(contactItems.Any(x => x.ContactId == contactId1));
            Assert.True(contactItems.Any(x => x.ContactId == contactId2));
        }
    }
}