using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Enums;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response;
using Bitrix24RestApiClient.Test.Utilities;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class OldIncvoicesTests : AbstractTest
    {
        [Fact]
        public async Task AddTest()
        {
            string accountNumber = Guid.NewGuid().ToString();

            AddResponse addCompanyResponse = await bitrix24.Crm.Companies.Add();
            AllocatedCompanies.Add(addCompanyResponse.Result);

            int? paySystemId = (await bitrix24.Crm.PaySystems.List()).Result.First().Id;

            int productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId);

            int? invoiceId = (await bitrix24.Crm.Invoices.Old.Add(x => x
                .SetField(x => x.StatusId, InvoiceStatusEnum.НеОплачен)
                .SetField(x => x.PersonTypeId, 2)
                .SetField(x => x.PaySystemId, paySystemId)
                .SetField(x => x.AccountNumber, accountNumber)
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.UfCompanyId, addCompanyResponse.Result)
                .SetField(x => x.ProductRows, new List<ProductRow>
                {
                    new ProductRow
                    {
                        ProductId = productId,
                        Price = 1,
                        ProductName = "test",
                        Quantity = 1
                    }
                }))).Result;
            AllocatedOldInvoices.Add(invoiceId.Value);

            Invoice invoice = (await bitrix24.Crm.Invoices.Old.Get(invoiceId.Value)).Result;
            Assert.Equal(invoiceId.Value, invoice.Id);
        }

        [Fact]
        public async Task ListTest()
        {
            string accountNumber = Guid.NewGuid().ToString();

            AddResponse addCompanyResponse = await bitrix24.Crm.Companies.Add();
            AllocatedCompanies.Add(addCompanyResponse.Result);

            int? paySystemId = (await bitrix24.Crm.PaySystems.List()).Result.First().Id;

            int productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId);

            int? invoiceId = (await bitrix24.Crm.Invoices.Old.Add(x => x
                .SetField(x => x.StatusId, InvoiceStatusEnum.НеОплачен)
                .SetField(x => x.PersonTypeId, 2)
                .SetField(x => x.PaySystemId, paySystemId)
                .SetField(x => x.AccountNumber, accountNumber)
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.UfCompanyId, addCompanyResponse.Result)
                .SetField(x => x.ProductRows, new List<ProductRow>
                {
                    new ProductRow
                    {
                        ProductId = productId,
                        Price = 1,
                        ProductName = "test",
                        Quantity = 1
                    }
                }))).Result;
            AllocatedOldInvoices.Add(invoiceId.Value);

            ListResponse<Invoice> response = await bitrix24.Crm.Invoices.Old.List(x=>x
                .AddFilter(x=>x.Id, invoiceId.Value)
                .AddSelect(x=>x.AccountNumber));

            Assert.Equal(accountNumber, response.Result.First().AccountNumber);
        }

        [Fact]
        public async Task FirstTest()
        {
            string accountNumber = Guid.NewGuid().ToString();

            AddResponse addCompanyResponse = await bitrix24.Crm.Companies.Add();
            AllocatedCompanies.Add(addCompanyResponse.Result);

            int? paySystemId = (await bitrix24.Crm.PaySystems.List()).Result.First().Id;

            int productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId);

            int? invoiceId = (await bitrix24.Crm.Invoices.Old.Add(x => x
                .SetField(x => x.StatusId, InvoiceStatusEnum.НеОплачен)
                .SetField(x => x.PersonTypeId, 2)
                .SetField(x => x.PaySystemId, paySystemId)
                .SetField(x => x.AccountNumber, accountNumber)
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.UfCompanyId, addCompanyResponse.Result)
                .SetField(x => x.ProductRows, new List<ProductRow>
                {
                    new ProductRow
                    {
                        ProductId = productId,
                        Price = 1,
                        ProductName = "test",
                        Quantity = 1
                    }
                }))).Result;
            AllocatedOldInvoices.Add(invoiceId.Value);

            Invoice invoice = await bitrix24.Crm.Invoices.Old.First(x => x
                .AddFilter(x => x.Id, invoiceId.Value)
                .AddSelect(x => x.AccountNumber));

            Assert.Equal(accountNumber, invoice.AccountNumber);
        }

        [Fact]
        public async Task UpdateTest()
        {
            string accountNumber1 = Guid.NewGuid().ToString();
            string accountNumber2 = Guid.NewGuid().ToString();

            AddResponse addCompanyResponse = await bitrix24.Crm.Companies.Add();
            AllocatedCompanies.Add(addCompanyResponse.Result);

            int? paySystemId = (await bitrix24.Crm.PaySystems.List()).Result.First().Id;

            int productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId);

            int? invoiceId = (await bitrix24.Crm.Invoices.Old.Add(x => x
                .SetField(x => x.StatusId, InvoiceStatusEnum.НеОплачен)
                .SetField(x => x.PersonTypeId, 2)
                .SetField(x => x.PaySystemId, paySystemId)
                .SetField(x => x.AccountNumber, accountNumber1)
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.UfCompanyId, addCompanyResponse.Result)
                .SetField(x => x.ProductRows, new List<ProductRow>
                {
                    new ProductRow
                    {
                        ProductId = productId,
                        Price = 1,
                        ProductName = "test",
                        Quantity = 1
                    }
                }))).Result;
            AllocatedOldInvoices.Add(invoiceId.Value);

            await bitrix24.Crm.Invoices.Old.Update(invoiceId.Value, x => x.SetField(x => x.AccountNumber, accountNumber2));

            Invoice invoice = (await bitrix24.Crm.Invoices.Old.Get(invoiceId.Value, x=>x.AccountNumber)).Result;
            Assert.Equal(accountNumber2, invoice.AccountNumber);
        }

        [Fact]
        public async Task FieldsTest()
        {
            FieldsResponse fields = (await bitrix24.Crm.Invoices.Old.Fields());
        }

        [Fact]
        public async Task DeleteTest()
        {
            string accountNumber = Guid.NewGuid().ToString();

            AddResponse addCompanyResponse = await bitrix24.Crm.Companies.Add();
            AllocatedCompanies.Add(addCompanyResponse.Result);

            int? paySystemId = (await bitrix24.Crm.PaySystems.List()).Result.First().Id;

            int productId = (await bitrix24.Crm.Products.Add(x => x.SetField(x => x.Name, "test"))).Result;
            AllocatedProducts.Add(productId);

            int? invoiceId = (await bitrix24.Crm.Invoices.Old.Add(x => x
                .SetField(x => x.StatusId, InvoiceStatusEnum.НеОплачен)
                .SetField(x => x.PersonTypeId, 2)
                .SetField(x => x.PaySystemId, paySystemId)
                .SetField(x => x.AccountNumber, accountNumber)
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.OrderTopic, "test")
                .SetField(x => x.UfCompanyId, addCompanyResponse.Result)
                .SetField(x => x.ProductRows, new List<ProductRow>
                {
                    new ProductRow
                    {
                        ProductId = productId,
                        Price = 1,
                        ProductName = "test",
                        Quantity = 1
                    }
                }))).Result;
            AllocatedOldInvoices.Add(invoiceId.Value);

            DeleteResponse deleteResponse = (await bitrix24.Crm.Invoices.Old.Delete(invoiceId.Value));

            Assert.ThrowsAsync<Exception>(async ()=>
            {
                Invoice invoice = (await bitrix24.Crm.Invoices.Old.Get(invoiceId.Value)).Result;
            });
        }
    }
}
