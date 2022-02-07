using Bitrix24ApiClient.src.Models;
using Bitrix24RestApiClientNUnitTests.Utilities;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class ContactTests : AbstractTest
    {
        [Test]
        public async Task AddTest()
        {
            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            Contact contact = (await bitrix24.Crm.Contacts.Get(contactId.Value)).Result;
            Assert.AreEqual(contactId.Value, contact.Id);
        }

        [Test]
        public async Task ListTest()
        {
            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            ListResponse<Contact> response = await bitrix24.Crm.Contacts.List(x=>x
                .AddFilter(x=>x.Id, contactId.Value)
                .AddSelect(x=>x.Name));

            Assert.AreEqual("test", response.Result.First().Name);
        }

        [Test]
        public async Task FirstTest()
        {
            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedContacts.Add(contactId.Value);

            Contact contact = await bitrix24.Crm.Contacts.First(x => x
                .AddFilter(x => x.Id, contactId.Value)
                .AddSelect(x => x.Name));

            Assert.AreEqual("test", contact.Name);
        }

        [Test]
        public async Task UpdateTest()
        {
            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "fizz"))).Result;
            AllocatedContacts.Add(contactId.Value);

            await bitrix24.Crm.Contacts.Update(contactId.Value, x => x.SetField(x => x.Name, "buzz"));

            Contact contact = (await bitrix24.Crm.Contacts.Get(contactId.Value, x=>x.Name)).Result;
            Assert.AreEqual("buzz", contact.Name);
        }

        [Test]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Contacts.Fields());
        }

        [Test]
        public async Task DeleteTest()
        {
            int? contactId = (await bitrix24.Crm.Contacts.Add(x => x.SetField(x => x.Name, "test"))).Result;

            DeleteResponse deleteResponse = (await bitrix24.Crm.Contacts.Delete(contactId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                Contact contact = (await bitrix24.Crm.Contacts.Get(contactId.Value)).Result;
            });
        }
    }
}