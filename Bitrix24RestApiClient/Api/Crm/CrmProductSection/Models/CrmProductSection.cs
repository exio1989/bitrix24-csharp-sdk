#nullable enable
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Api.Crm.CrmProductSection.Models
{
	/// <summary>
	/// Разделы товаров
	/// </summary>
	public class ProductSection : IAbstractEntity
	{
		/// <summary>
		/// ID
		/// Тип: integer
		/// Только для чтения
		/// </summary>
		[JsonProperty(ProductSectionFields.Id)]
		public int? Id { get; set; }

		/// <summary>
		/// Каталог
		/// Тип: integer
		/// </summary>
		[JsonProperty(ProductSectionFields.CatalogId)]
		public int? CatalogId { get; set; }

		/// <summary>
		/// Раздел
		/// Тип: integer
		/// </summary>
		[JsonProperty(ProductSectionFields.SectionId)]
		public int? SectionId { get; set; }

		/// <summary>
		/// Название
		/// Тип: string
		/// Обязательное поле
		/// </summary>
		[JsonProperty(ProductSectionFields.Name)]
		public string? Name { get; set; }

		/// <summary>
		/// Внешний код
		/// Тип: string
		/// </summary>
		[JsonProperty(ProductSectionFields.XmlId)]
		public string? XmlId { get; set; }

		/// <summary>
		/// Символьный код
		/// Тип: string
		/// </summary>
		[JsonProperty(ProductSectionFields.Code)]
		public string? Code { get; set; }

	}
}
