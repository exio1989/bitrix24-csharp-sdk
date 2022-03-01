#nullable enable
using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Preset.Field.Models
{
	//TODO не задействовано в коде
	/// <summary>
	/// Список полей из набора полей шаблона для определенного реквизита.
	/// </summary>
	public class CrmRequisitePresetField:IAbstractEntity
	{
		/// <summary>
		/// Идентификатор			
		/// Тип: integer	
		/// Только для чтения
		/// </summary>
		[JsonProperty(AbstractEntityFields.Id)]
		public int? Id { get; set; }

		/// <summary>
		/// Имя
		/// Тип: string
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisitePresetFieldFields.FieldName)]
		public string? FieldName { get; set; }

		/// <summary>
		/// Название в шаблоне
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisitePresetFieldFields.FieldTitle)]
		public string? FieldTitle { get; set; }

		/// <summary>
		/// Сортировка
		/// Тип: integer
		/// </summary>
		[JsonProperty(CrmRequisitePresetFieldFields.Sort)]
		public int? Sort { get; set; }

		/// <summary>
		/// Показывать в кратком списке
		/// Тип: char
		/// </summary>
		[JsonProperty(CrmRequisitePresetFieldFields.InShortList)]
		public string? InShortList { get; set; }

	}
}
