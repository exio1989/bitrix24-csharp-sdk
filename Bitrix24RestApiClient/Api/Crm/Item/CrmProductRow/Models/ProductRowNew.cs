#nullable enable
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Newtonsoft.Json;
using Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow.Models;

namespace Bitrix24RestApiClient.Api.Crm.Item.CrmProductRow.Models
{
	/// <summary>
	/// Товарные позиции
	/// </summary>
	public class ProductRowNew:IAbstractEntity
	{
		/// <summary>
		/// ID
		/// Тип: integer
		/// Только для чтения
		/// </summary>
		[JsonProperty(ProductRowNewFields.Id)]
		public int? Id { get; set; }

		/// <summary>
		/// ID владельца
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(ProductRowNewFields.Ownerid)]
		public int? Ownerid { get; set; }

		/// <summary>
		/// Тип владельца
		/// Тип: string
		/// Обязательное поле
		/// </summary>
		[JsonProperty(ProductRowNewFields.Ownertype)]
		public string? Ownertype { get; set; }

		/// <summary>
		/// Товар
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(ProductRowNewFields.Productid)]
		public int? Productid { get; set; }

		/// <summary>
		/// Название товара
		/// Тип: string
		/// </summary>
		[JsonProperty(ProductRowNewFields.Productname)]
		public string? Productname { get; set; }

		/// <summary>
		/// Цена
		/// Тип: double
		/// </summary>
		[JsonProperty(ProductRowNewFields.Price)]
		public decimal? Price { get; set; }

		/// <summary>
		/// Цена без налога со скидкой
		/// Тип: double
		/// Только для чтения
		/// </summary>
		[JsonProperty(ProductRowNewFields.Priceexclusive)]
		public decimal? Priceexclusive { get; set; }

		/// <summary>
		/// PRICE_NETTO
		/// Тип: double
		/// Только для чтения
		/// </summary>
		[JsonProperty(ProductRowNewFields.Pricenetto)]
		public decimal? Pricenetto { get; set; }

		/// <summary>
		/// PRICE_BRUTTO
		/// Тип: double
		/// Только для чтения
		/// </summary>
		[JsonProperty(ProductRowNewFields.Pricebrutto)]
		public decimal? Pricebrutto { get; set; }

		/// <summary>
		/// Количество
		/// Тип: double
		/// </summary>
		[JsonProperty(ProductRowNewFields.Quantity)]
		public decimal? Quantity { get; set; }

		/// <summary>
		/// Тип скидки
		/// Тип: integer
		/// </summary>
		[JsonProperty(ProductRowNewFields.Discounttypeid)]
		public int? Discounttypeid { get; set; }

		/// <summary>
		/// Величина скидки
		/// Тип: double
		/// </summary>
		[JsonProperty(ProductRowNewFields.Discountrate)]
		public decimal? Discountrate { get; set; }

		/// <summary>
		/// Сумма скидки
		/// Тип: double
		/// </summary>
		[JsonProperty(ProductRowNewFields.Discountsum)]
		public decimal? Discountsum { get; set; }

		/// <summary>
		/// Налог
		/// Тип: double
		/// </summary>
		[JsonProperty(ProductRowNewFields.Taxrate)]
		public decimal? Taxrate { get; set; }

		/// <summary>
		/// Налог включен в цену
		/// Тип: char
		/// </summary>
		[JsonProperty(ProductRowNewFields.Taxincluded)]
		public string? Taxincluded { get; set; }

		/// <summary>
		/// Изменен
		/// Тип: char
		/// </summary>
		[JsonProperty(ProductRowNewFields.Customized)]
		public string? Customized { get; set; }

		/// <summary>
		/// Код единицы измерения
		/// Тип: integer
		/// </summary>
		[JsonProperty(ProductRowNewFields.Measurecode)]
		public int? Measurecode { get; set; }

		/// <summary>
		/// Единица измерения
		/// Тип: string
		/// </summary>
		[JsonProperty(ProductRowNewFields.Measurename)]
		public string? Measurename { get; set; }

		/// <summary>
		/// Сортировка
		/// Тип: integer
		/// </summary>
		[JsonProperty(ProductRowNewFields.Sort)]
		public int? Sort { get; set; }

	}
}
