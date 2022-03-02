using Xunit;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Test.Models;
using Bitrix24RestApiClient.Test.Utilities;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;
using Bitrix24RestApiClient.Api.Crm.CrmProduct.Models;
using Bitrix24RestApiClient.Test.Tests.IntegrationTests;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.ProductRows.Models;
using Bitrix24RestApiClient.Api.Crm.CrmStageHistory.Deal.Models;

namespace Bitrix24RestApiClient.Test.Tests.IntegrationTests
{
    public class BatchOperationsTests : AbstractTest
    {
        [Fact]
        public async Task SmartProcessListGetStrategyTest()
        {
            IAsyncEnumerable<TestDeal> items = bitrix24.Crm.SmartProcesses.ByEntityId(EntityTypeIdEnum.Deal.EntityTypeId).BatchOperations.ListGetStrategy.ListAll<TestDeal>(x=>x.Id, x => x
                .AddFilter(y => y.Id, 1, FilterOperator.GreateThan)
                .AddFilter(y => y.Id, 100, FilterOperator.LessThan));

            List<TestDeal> deals = new List<TestDeal>();
            await foreach (var item in items) 
                deals.Add(item);
        }

        [Fact]
        public async Task ListGetStrategyTest()
        {
            IAsyncEnumerable<Deal> items = bitrix24.Crm.Deals.BatchOperations.ListGetStrategy.ListAll<Deal>(x=>x.Id, x=>x
                .AddFilter(y=>y.DateModify, "2022-02-01", FilterOperator.GreateThanOrEqual)
                .AddFilter(y => y.DateModify, "2022-02-02", FilterOperator.LessThan));

            List<Deal> deals = new List<Deal>();
            await foreach (var item in items)
                deals.Add(item);
        }

        [Fact]
        public async Task ListItemsStrategyTest()
        {
            IAsyncEnumerable<DealStageHistory> items = bitrix24.Crm.StageHistories.Deals.BatchOperations.ListStrategy.ListItemsAll<DealStageHistory>(x=>x.Id, x => x
                .SetEntityTypeId(EntityTypeIdEnum.Deal)
                .AddFilter(y => y.Id, 132700, FilterOperator.GreateThan));

            List<DealStageHistory> dealStageHistory = new List<DealStageHistory>();
            await foreach (var item in items)
                dealStageHistory.Add(item);
        }


        [Fact]
        public async Task ListStrategyTest()
        {
            IAsyncEnumerable<Product> items = bitrix24.Crm.Products.BatchOperations.ListStrategy.ListAll<Product>(x => x.Id, x => x
                .AddFilter(y => y.Id, 0, FilterOperator.GreateThan));

            List<Product> products = new List<Product>();
            await foreach (var item in items)
                products.Add(item);
        }
    }

    public static class PersisDealFields
    {
        public const string ПочемуНеПокупают = "UF_CRM_1642491608176";
        public const string ПричинаОтказа = "UF_CRM_1642491506867";
        public const string ПричинаОтказаДетальноеОписание = "UF_CRM_1642491562718";
        public const string ТочкаМаршрута = "UF_CRM_1642603594744";
        public const string Описание = "UF_CRM_1642603610353";
        public const string Договоренность = "UF_CRM_1642603625435";
        public const string Date = "UF_CRM_1642603644877";
        public const string ДатаВыполнения = "UF_CRM_1642603661551";
        public const string ОтложитьДо = "UF_CRM_1642603675663";
        public const string Срок = "UF_CRM_1642603688942";
        public const string CrmRef = "UF_CRM_1642603846875";
        public const string ПроцедураЗаключенияДоговора = "UF_CRM_1642664899678";
        public const string СпособОбменаДоговора = "UF_CRM_1642664924274";
        public const string ТипЗаявки = "UF_CRM_1643785582238";
        public const string Источник = "UF_CRM_1643785609208";
        public const string ОписаниеИсточника = "UF_CRM_1643785639159";
        public const string Ценность = "UF_CRM_1643898651534";
    }

    public class PersisDeal : Deal
    {

        [JsonProperty(PersisDealFields.ПочемуНеПокупают)]
        public string ПочемуНеПокупают { get; set; }

        [JsonProperty(PersisDealFields.ПричинаОтказа)]
        public string ПричинаОтказа { get; set; }

        [JsonProperty(PersisDealFields.ПричинаОтказаДетальноеОписание)]
        public string ПричинаОтказаДетальноеОписание { get; set; }

        [JsonProperty(PersisDealFields.ТочкаМаршрута)]
        public string ТочкаМаршрута { get; set; }

        [JsonProperty(PersisDealFields.Описание)]
        public string Описание { get; set; }

        [JsonProperty(PersisDealFields.Договоренность)]
        public string Договоренность { get; set; }

        [JsonProperty(PersisDealFields.Date)]
        public string Date { get; set; }

        [JsonProperty(PersisDealFields.ДатаВыполнения)]
        public string ДатаВыполнения { get; set; }

        [JsonProperty(PersisDealFields.ОтложитьДо)]
        public string ОтложитьДо { get; set; }

        [JsonProperty(PersisDealFields.Срок)]
        public string Срок { get; set; }

        [JsonProperty(PersisDealFields.CrmRef)]
        public string CrmRef { get; set; }

        [JsonProperty(PersisDealFields.ПроцедураЗаключенияДоговора)]
        public string ПроцедураЗаключенияДоговора { get; set; }

        [JsonProperty(PersisDealFields.СпособОбменаДоговора)]
        public string СпособОбменаДоговора { get; set; }

        [JsonProperty(PersisDealFields.ТипЗаявки)]
        public string ТипЗаявки { get; set; }

        [JsonProperty(PersisDealFields.Источник)]
        public string Источник { get; set; }

        [JsonProperty(PersisDealFields.ОписаниеИсточника)]
        public string ОписаниеИсточника { get; set; }

        [JsonIgnore]
        public int? Ценность
        {
            get
            {
                string str = ЦенностьExt;
                if (str == "false")
                    return null;

                return JsonConvert.DeserializeObject<int?>(str);
            }

            set
            {
                ЦенностьExt = JsonConvert.SerializeObject(value);
            }
        }

        [JsonProperty(PersisDealFields.Ценность)]
        public string ЦенностьExt { get; set; }


        public List<DealProductRow> ProductRows { get; set; }
    }
}
