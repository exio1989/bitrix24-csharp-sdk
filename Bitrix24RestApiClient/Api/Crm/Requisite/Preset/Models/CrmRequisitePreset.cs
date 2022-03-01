#nullable enable
using System;
using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Preset.Models
{
	//TODO не задействовано в коде
	/// <summary>
	/// Шаблоны реквизитов
	/// </summary>
	public class CrmRequisitePreset:IAbstractEntity
	{
		/// <summary>
		/// Идентификатор			
		/// Тип: integer	
		/// Только для чтения
		/// </summary>
		[JsonProperty(AbstractEntityFields.Id)]
		public int? Id { get; set; }

		/// <summary>
		/// ID типа сущности
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.EntityTypeId)]
		public int? EntityTypeId { get; set; }

		/// <summary>
		/// ID страны
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.CountryId)]
		public int? CountryId { get; set; }

		/// <summary>
		/// Название
		/// Тип: string
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.Name)]
		public string? Name { get; set; }

		/// <summary>
		/// Дата создания
		/// Тип: datetime
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.DateCreate)]
		public DateTimeOffset? DateCreate { get; set; }

		/// <summary>
		/// Дата изменения
		/// Тип: datetime
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.DateModify)]
		public DateTimeOffset? DateModify { get; set; }

		/// <summary>
		/// Создал
		/// Тип: user
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.CreatedById)]
		public int? CreatedById { get; set; }

		/// <summary>
		/// Изменил
		/// Тип: user
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.ModifyById)]
		public int? ModifyById { get; set; }

		/// <summary>
		/// Активен
		/// Тип: char
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.Active)]
		public string? Active { get; set; }

		/// <summary>
		/// Сортировка
		/// Тип: integer
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.Sort)]
		public int? Sort { get; set; }

		/// <summary>
		/// Внешний код
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisitePresetFields.XmlId)]
		public string? XmlId { get; set; }

	}
}
