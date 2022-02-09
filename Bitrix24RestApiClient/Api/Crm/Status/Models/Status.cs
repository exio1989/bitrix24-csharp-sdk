using Bitrix24RestApiClient.Api.Crm.Status.Models;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Models.Core.Attributes;
using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src.Models
{
    public class Status: AbstractEntity
	{
		/// <summary>
		/// ID элемента сущности		
		/// Тип: string
		/// </summary>
		[JsonProperty(StatusFields.EntityId)]
		public string EntityId { get; set; }

		/// <summary>
		/// Статус	
		/// Тип: string
		/// </summary>
		[JsonProperty(StatusFields.StatusId)]
		public string StatusId { get; set; }

		/// <summary>
		/// Сортировка	
		/// Тип: integer
		/// </summary>
		[JsonProperty(StatusFields.Sort)]
		public int? Sort { get; set; }

		/// <summary>
		/// Название	
		/// Тип: string
		/// </summary>
		[JsonProperty(StatusFields.Name)]
		public string Name { get; set; }

		/// <summary>
		/// Название по умолчанию	
		/// Тип: string
		/// </summary>
		[JsonProperty(StatusFields.NameInit)]
		public string NameInit { get; set; }

		/// <summary>
		/// Системный	
		/// Тип: char
		/// </summary>
		[JsonIgnore]
		[CrmField(StatusFields.System, CrmFieldSubTypeEnum.Char_YesNo)]
		public bool System
		{
			get
			{
				return SystemExt == YesNoEnum.Y.ToString("F");
			}
			set
			{
				SystemExt = value
					? YesNoEnum.Y.ToString("F")
					: YesNoEnum.N.ToString("F");
			}
		}


		/// <summary>
		/// Системный	
		/// Тип: char
		/// </summary>
		[JsonProperty(StatusFields.System)]
		public string SystemExt { get; set; }

		/// <summary>
		/// CATEGORY_ID	
		/// Тип: integer
		/// </summary>
		[JsonProperty(StatusFields.CategoryId)]
		public int? CategoryId { get; set; }

		/// <summary>
		/// COLOR	
		/// Тип: string
		/// </summary>
		[JsonProperty(StatusFields.Color)]
		public string Color { get; set; }

		//TODO
		/// <summary>
		/// SEMANTICS	
		/// Тип: char
		/// </summary>
		[JsonProperty(StatusFields.Semantics)]
		public string Semantics { get; set; }

		//TODO
		/// <summary>
		/// Дополнительные поля	
		/// Тип: crm_status_extra
		/// </summary>
		[JsonProperty(StatusFields.Extra)]
		public StatusExtra Extra { get; set; }
    }
}
