#nullable enable
using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Api.Crm.SmartProcessTypes.Models
{
	/// <summary>
	/// Типы смарт-процессов
	/// </summary>
	public class SmartProcessType:IAbstractEntity
	{
		/// <summary>
		/// Идентификатор			
		/// Тип: integer	
		/// Только для чтения
		/// </summary>
		[JsonProperty(AbstractEntityFields.Id)]
		public int? Id { get; set; }

		/// <summary>
		/// Название
		/// Тип: string
		/// Обязательное поле
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.Title)]
		public string? Title { get; set; }

		/// <summary>
		/// Символьный код
		/// Тип: string
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.Code)]
		public string? Code { get; set; }

		/// <summary>
		/// Кем создан
		/// Тип: user
		/// Только для чтения
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.CreatedBy)]
		public int? CreatedBy { get; set; }

		/// <summary>
		/// Идентификатор типа смарт-процесса
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.EntityTypeId)]
		public int? EntityTypeId { get; set; }

		/// <summary>
		/// Использовать в смарт-процессе свои направления и туннели продаж
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsCategoriesEnabled)]
		public string? IsCategoriesEnabled { get; set; }

		/// <summary>
		/// Использовать в смарт-процессе свои стадии и канбан
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsStagesEnabled)]
		public string? IsStagesEnabled { get; set; }

		/// <summary>
		/// Поля "Дата начала" и "Дата завершения"
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsBeginCloseDatesEnabled)]
		public string? IsBeginCloseDatesEnabled { get; set; }

		/// <summary>
		/// Поле "Клиент"
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsClientEnabled)]
		public string? IsClientEnabled { get; set; }

		/// <summary>
		/// Использовать в пользовательском поле
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsUseInUserfieldEnabled)]
		public string? IsUseInUserfieldEnabled { get; set; }

		/// <summary>
		/// Привязка товаров каталога
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsLinkWithProductsEnabled)]
		public string? IsLinkWithProductsEnabled { get; set; }

		/// <summary>
		/// Поле "Реквизиты Вашей компании"
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsMycompanyEnabled)]
		public string? IsMycompanyEnabled { get; set; }

		/// <summary>
		/// Печать документов
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsDocumentsEnabled)]
		public string? IsDocumentsEnabled { get; set; }

		/// <summary>
		/// Поля "Источник" и "Дополнительно об источнике"
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsSourceEnabled)]
		public string? IsSourceEnabled { get; set; }

		/// <summary>
		/// Поле "Наблюдатели"
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsObserversEnabled)]
		public string? IsObserversEnabled { get; set; }

		/// <summary>
		/// Использовать корзину
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsRecyclebinEnabled)]
		public string? IsRecyclebinEnabled { get; set; }

		/// <summary>
		/// Использовать в смарт-процессе роботы и триггеры
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsAutomationEnabled)]
		public string? IsAutomationEnabled { get; set; }

		/// <summary>
		/// Использовать в смарт-процессе дизайнер бизнес-процессов
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsBizProcEnabled)]
		public string? IsBizProcEnabled { get; set; }

		/// <summary>
		/// Делать новые направления доступными для всех
		/// Тип: boolean
		/// </summary>
		[JsonProperty(SmartProcessTypeFields.IsSetOpenPermissions)]
		public string? IsSetOpenPermissions { get; set; }

	}
}
