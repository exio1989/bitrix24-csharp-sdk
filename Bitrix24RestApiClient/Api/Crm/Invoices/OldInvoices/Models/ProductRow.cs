using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Models.Core.Attributes;
using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models
{
    public class ProductRow: AbstractEntity
    {
        /// <summary>
        /// Цена			
        /// Тип: double
        /// </summary>
        [JsonProperty(ProductRowFields.Price)]
        public decimal? Price { get; set; }

        /// <summary>
        /// Количество			
        /// Тип: double
        /// </summary>
        [JsonProperty(ProductRowFields.Quantity)]
        public decimal? Quantity { get; set; }
        
        /// <summary>
        /// Скидка на единицу товара	
        /// Тип: double
        /// </summary>
        [JsonProperty(ProductRowFields.DiscountPrice)]
        public decimal? DiscountPrice { get; set; }

        /// <summary>
        /// Идентификатор товара в каталоге		
        /// Тип: integer
        /// 0 - если не из каталога	
        /// </summary>
        [JsonProperty(ProductRowFields.ProductId)]
        public int? ProductId { get; set; }

        /// <summary>
        /// Наименование товарной позиции	
        /// Тип: string
        /// </summary>
        [JsonProperty(ProductRowFields.ProductName)]
        public string ProductName { get; set; }

        /// <summary>
        /// Коэффициент ставки НДС			
        /// Тип: double
        /// </summary>
        [JsonProperty(ProductRowFields.VatRate)]
        public decimal? VatRate { get; set; }

        /// <summary>
        /// НДС включён в цену
        /// Тип: char	
        /// ('Y' или 'N')	
        /// </summary>
        [JsonIgnore]
        [CrmField(ProductRowFields.VatIncluded, CrmFieldSubTypeEnum.Char_YesNo)]
        public bool VatIncluded
        {
            get
            {
                return VatIncludedExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                VatIncludedExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// НДС включён в цену		
        /// Тип: char
        /// ('Y' или 'N')	
        /// </summary>
        [JsonProperty(ProductRowFields.VatIncluded)]
        public string VatIncludedExt { get; set; }

        /// <summary>
        /// Код единицы измерения			
        /// Тип: integer
        /// </summary>
        [JsonProperty(ProductRowFields.MeasureCode)]
        public int? MeasureCode { get; set; }

        /// <summary>
        /// Условное обозначение единицы измерения			
        /// Тип: string
        /// </summary>
        [JsonProperty(ProductRowFields.MeasureName)]
        public string MeasureName { get; set; }

        /// <summary>
        /// Внешний код каталога		
        /// Тип: string
        /// Только для чтения	
        /// </summary>
        [JsonProperty(ProductRowFields.CatalogXmlId)]
        public string CatalogXmlId { get; set; }

        /// <summary>
        /// Внешний код товарной позиции			
        /// Тип: string
        /// Совпадает с внешним кодом товара, если он из каталога. Только для чтения.
        /// </summary>
        [JsonProperty(ProductRowFields.ProductXmlId)]
        public string ProductXmlId { get; set; }
    }
}
