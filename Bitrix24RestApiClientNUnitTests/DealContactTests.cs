using Bitrix24ApiClient.src;
using Bitrix24ApiClient.src.Models;
using Bitrix24ApiClient.src.Models.Crm.Core;
using Bitrix24RestApiClient.Api.Crm.Deal.Contact.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests
{
    public class DealContactTests:IDisposable
    {
        [Test]
        public async Task GetFieldsTest()
        {            
            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            FieldsResponse fields = await bitrix24.Crm.Deals.Contacts.Fields();
        }

        [Test]
        public async Task AddContactTest()
        {
            int? dealId = null;
            int? contactId = null;

            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            try
            {
                dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
                contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;

                List<DealContactItem> contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                await bitrix24.Crm.Deals.Contacts.Add(dealId.Value, x => x.SetField(x => x.ContactId, contactId));
                Assert.IsEmpty(contactItems);

                contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                Assert.AreEqual(1, contactItems.Count);
                Assert.AreEqual(contactId, contactItems.First().ContactId);
            }
            finally
            {
                if (dealId != null)
                    await bitrix24.Crm.Deals.Delete(dealId.Value);

                if (contactId != null)
                    await bitrix24.Crm.Contacts.Delete(contactId.Value);
            }
        }

        [Test]
        public async Task DeleteContactTest()
        {
            int? dealId = null;
            int? contactId = null;

            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            try
            {
                dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
                contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;

                List<DealContactItem> contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                await bitrix24.Crm.Deals.Contacts.Add(dealId.Value, x => x.SetField(x => x.ContactId, contactId));
                Assert.IsEmpty(contactItems);

                contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                Assert.IsNotEmpty(contactItems);

                await bitrix24.Crm.Deals.Contacts.Delete(dealId.Value, contactId.Value);

                contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                Assert.IsEmpty(contactItems);
            }
            finally
            {
                if (dealId != null)
                    await bitrix24.Crm.Deals.Delete(dealId.Value);

                if (contactId != null)
                    await bitrix24.Crm.Contacts.Delete(contactId.Value);
            }
        }

        [Test]
        public async Task DeleteAllContactsTest()
        {
            int? dealId = null;
            int? contactId = null;

            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            try
            {
                dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
                contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;

                List<DealContactItem> contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                await bitrix24.Crm.Deals.Contacts.Add(dealId.Value, x => x.SetField(x => x.ContactId, contactId));
                Assert.IsEmpty(contactItems);

                contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                Assert.IsNotEmpty(contactItems);

                await bitrix24.Crm.Deals.Contacts.Items.Delete(dealId.Value);

                contactItems = (await bitrix24.Crm.Deals.Contacts.Items.Get(dealId.Value)).Result;
                Assert.IsEmpty(contactItems);
            }
            finally
            {
                if (dealId != null)
                    await bitrix24.Crm.Deals.Delete(dealId.Value);

                if (contactId != null)
                    await bitrix24.Crm.Contacts.Delete(contactId.Value);
            }
        }

        [Test]
        public async Task SetContactsTest()
        {
            int? dealId = null;
            int? contactId1 = null;
            int? contactId2 = null;

            Bitrix24Client client = new Bitrix24Client(Constants.WebhookUrl, new DummyLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);

            try
            {
                dealId = (await bitrix24.Crm.Deals.Add(x => x.SetField(x => x.Title, "test"))).Result;
                contactId1 = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
                contactId2 = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;

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
                Assert.True(contactItems.Any(x=>x.ContactId == contactId1));
                Assert.True(contactItems.Any(x=>x.ContactId == contactId2));
            }
            finally
            {
                if (dealId != null)
                    await bitrix24.Crm.Deals.Delete(dealId.Value);

                if (contactId1 != null)
                    await bitrix24.Crm.Contacts.Delete(contactId1.Value);

                if (contactId2 != null)
                    await bitrix24.Crm.Contacts.Delete(contactId2.Value);
            }
        }

        public void Dispose()
        {
        }
    }
}