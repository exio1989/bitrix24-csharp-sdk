using Newtonsoft.Json;
using Bitrix24RestApiClient.Api.Crm.Requisite.Link.Models;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Link.Models
{
	//TODO не задействовано в коде
	/// <summary>
	/// Связи реквизитов. Связи определяют, какие реквизиты выбраны для сделки, предложения или счёта. При этом реквизиты должны принадлежать выбранной компании или контакту. Так, если в счёте в качестве покупателя выбрана компания, то реквизиты покупателя должны принадлежать этой компании. В качестве продавца может быть выбрана только компания из справочника "Реквизиты ваших компаний".
	/// </summary>
	public class CrmRequisiteLink
	{
		/// <summary>
		/// ID типа сущности
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteLinkFields.EntityTypeId)]
		public int? EntityTypeId { get; set; }

		/// <summary>
		/// ID сущности
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteLinkFields.EntityId)]
		public int? EntityId { get; set; }

		/// <summary>
		/// Привязка к реквизитам
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteLinkFields.RequisiteId)]
		public int? RequisiteId { get; set; }

		/// <summary>
		/// Привязка к банковским реквизитам
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteLinkFields.BankDetailId)]
		public int? BankDetailId { get; set; }

		/// <summary>
		/// Привязка к реквизитам моей компании
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteLinkFields.McRequisiteId)]
		public int? McRequisiteId { get; set; }

		/// <summary>
		/// Привязка к банковским реквизитам моей компании
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteLinkFields.McBankDetailId)]
		public int? McBankDetailId { get; set; }

	}
}
