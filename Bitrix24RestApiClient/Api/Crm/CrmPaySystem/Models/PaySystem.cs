using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmPaySystem.Models;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Api.Crm.CrmPaySystem.Models
{
    public class PaySystem: IAbstractEntity
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
		/// </summary>
		[JsonProperty(PaySystemFields.Name)]
		public string Name { get; set; }

		/// <summary>
		/// Активен			
		/// Тип: char
		/// </summary>
		[JsonIgnore]
		[CrmField(PaySystemFields.Active, CrmFieldSubTypeEnum.Char_YesNo)]
		public bool Active
		{
			get
			{
				return ActiveExt == YesNoEnum.Y.ToString("F");
			}
			set
			{
				ActiveExt = value
					? YesNoEnum.Y.ToString("F")
					: YesNoEnum.N.ToString("F");
			}
		}

		/// <summary>
		/// Активен			
		/// Тип: char
		/// </summary>
		[JsonProperty(PaySystemFields.Active)]
		public string ActiveExt { get; set; }

		/// <summary>
		/// Сортировка			
		/// Тип: integer
		/// </summary>
		[JsonProperty(PaySystemFields.Sort)]
		public int? Sort { get; set; }

		/// <summary>
		/// Описание			
		/// Тип: string
		/// </summary>
		[JsonProperty(PaySystemFields.Description)]
		public string Description { get; set; }

		/// <summary>
		/// Тип плательщика			
		/// Тип: integer
		/// </summary>
		[JsonProperty(PaySystemFields.PersonTypeId)]
		public int? PersonTypeId { get; set; }

		/// <summary>
		/// Файл обработчика
		/// Тип: string
		/// </summary>
		[JsonProperty(PaySystemFields.ActionFile)]
		public string ActionFile { get; set; }

		/// <summary>
		/// Обработчик
		/// Тип: string
		/// </summary>
		[JsonProperty(PaySystemFields.Handler)]
		public string Handler { get; set; }

		/// <summary>
		/// Код обработчика
		/// Тип: string
		/// </summary>
		[JsonProperty(PaySystemFields.HandlerCode)]
		public string HandlerCode { get; set; }

		/// <summary>
		/// Имя обработчика
		/// Тип: string
		/// </summary>
		[JsonProperty(PaySystemFields.HandlerName)]
		public string HandlerName { get; set; }
    }
}
