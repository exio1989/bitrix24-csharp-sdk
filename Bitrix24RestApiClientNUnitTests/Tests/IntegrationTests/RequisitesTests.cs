using System;
using System.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClientNUnitTests.Utilities;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Api.Crm.Requisite.Models;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClientNUnitTests.Tests.IntegrationTests
{
    public class RequisitesTests : AbstractTest
    {
        [Test]
        public async Task AddTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add()).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? requisiteId = (await bitrix24.Crm.Requisites.Add(x => x
                .SetField(x => x.EntityTypeId, EntityTypeIdEnum.Company.EntityTypeId)
                .SetField(x => x.EntityId, companyId)
                .SetField(x => x.PresetId, 1)
                .SetField(x => x.Name, "test")
                .SetField(x => x.RqEmail, "t@t.ru"))).Result;
            AllocatedRequisites.Add(requisiteId.Value);

            CrmRequisite requisite = (await bitrix24.Crm.Requisites.Get(requisiteId.Value)).Result;
            Assert.AreEqual(requisiteId.Value, requisite.Id);
        }

        [Test]
        public async Task ListTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add()).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? requisiteId = (await bitrix24.Crm.Requisites.Add(x => x
                .SetField(x => x.EntityTypeId, EntityTypeIdEnum.Company.EntityTypeId)
                .SetField(x => x.EntityId, companyId)
                .SetField(x => x.PresetId, 1)
                .SetField(x => x.Name, "test")
                .SetField(x => x.RqEmail, "t@t.ru"))).Result;
            AllocatedRequisites.Add(requisiteId.Value);

            ListResponse<CrmRequisite> response = await bitrix24.Crm.Requisites.List(x=>x
                .AddFilter(x=>x.Id, requisiteId.Value)
                .AddSelect(x=>x.RqEmail));

            Assert.AreEqual("t@t.ru", response.Result.First().RqEmail);
        }

        [Test]
        public async Task FirstTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add()).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? requisiteId = (await bitrix24.Crm.Requisites.Add(x => x
                 .SetField(x => x.EntityTypeId, EntityTypeIdEnum.Company.EntityTypeId)
                 .SetField(x => x.EntityId, companyId)
                .SetField(x => x.PresetId, 1)
                .SetField(x => x.Name, "test")
                 .SetField(x => x.RqEmail, "t@t.ru"))).Result;
            AllocatedRequisites.Add(requisiteId.Value);

            CrmRequisite requisite = await bitrix24.Crm.Requisites.First(x => x
                .AddFilter(x => x.Id, requisiteId.Value)
                .AddSelect(x => x.RqEmail));

            Assert.AreEqual("t@t.ru", requisite.RqEmail);
        }

        [Test]
        public async Task UpdateTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add()).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? requisiteId = (await bitrix24.Crm.Requisites.Add(x => x
                .SetField(x => x.EntityTypeId, EntityTypeIdEnum.Company.EntityTypeId)
                .SetField(x => x.EntityId, companyId)
                .SetField(x => x.PresetId, 1)
                .SetField(x => x.Name, "test")
                .SetField(x => x.RqEmail, "t@t.ru"))).Result;
            AllocatedRequisites.Add(requisiteId.Value);

            await bitrix24.Crm.Requisites.Update(requisiteId.Value, x => x.SetField(x => x.RqEmail, "f@f.ru"));

            CrmRequisite requisite = (await bitrix24.Crm.Requisites.Get(requisiteId.Value, x=>x.RqEmail)).Result;
            Assert.AreEqual("f@f.ru", requisite.RqEmail);
        }

        [Test]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Requisites.Fields());
        }

        [Test]
        public async Task DeleteTest()
        {
            int? companyId = (await bitrix24.Crm.Companies.Add()).Result;
            AllocatedCompanies.Add(companyId.Value);

            int? requisiteId = (await bitrix24.Crm.Requisites.Add(x => x
                .SetField(x => x.EntityTypeId, EntityTypeIdEnum.Company.EntityTypeId)
                .SetField(x => x.EntityId, companyId)
                .SetField(x => x.PresetId, 1)
                .SetField(x => x.Name, "test")
                .SetField(x => x.RqEmail, "t@t.ru"))).Result;
            AllocatedRequisites.Add(requisiteId.Value);

            DeleteResponse deleteResponse = (await bitrix24.Crm.Requisites.Delete(requisiteId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                CrmRequisite requisite = (await bitrix24.Crm.Requisites.Get(requisiteId.Value)).Result;
            });
        }
    }
}