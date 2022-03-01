#nullable enable
using System;
using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Bankdetail.Models
{
	/// <summary>
	/// Банковские реквизиты
	/// </summary>
	public class CrmRequisiteBankdetail:IAbstractEntity
	{
		/// <summary>
		/// Идентификатор			
		/// Тип: integer	
		/// Только для чтения
		/// </summary>
		[JsonProperty(AbstractEntityFields.Id)]
		public int? Id { get; set; }

		/// <summary>
		/// ID сущности
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.EntityId)]
		public int? EntityId { get; set; }

		/// <summary>
		/// ID страны
		/// Тип: integer
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.CountryId)]
		public int? CountryId { get; set; }

		/// <summary>
		/// Дата создания
		/// Тип: datetime
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.DateCreate)]
		public DateTimeOffset? DateCreate { get; set; }

		/// <summary>
		/// Дата изменения
		/// Тип: datetime
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.DateModify)]
		public DateTimeOffset? DateModify { get; set; }

		/// <summary>
		/// Создал
		/// Тип: user
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.CreatedById)]
		public int? CreatedById { get; set; }

		/// <summary>
		/// Изменил
		/// Тип: user
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.ModifyById)]
		public int? ModifyById { get; set; }

		/// <summary>
		/// Название
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.Name)]
		public string? Name { get; set; }

		/// <summary>
		/// Код
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.Code)]
		public string? Code { get; set; }

		/// <summary>
		/// Внешний код
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.XmlId)]
		public string? XmlId { get; set; }

		/// <summary>
		/// Активен
		/// Тип: char
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.Active)]
		public string? Active { get; set; }

		/// <summary>
		/// Сортироква
		/// Тип: integer
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.Sort)]
		public int? Sort { get; set; }

		/// <summary>
		/// Наименование банка
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqBankName)]
		public string? RqBankName { get; set; }

		/// <summary>
		/// Адрес банка
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqBankAddr)]
		public string? RqBankAddr { get; set; }

		/// <summary>
		/// RQ_BANK_ROUTE_NUM
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqBankRouteNum)]
		public string? RqBankRouteNum { get; set; }

		/// <summary>
		/// БИК
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqBik)]
		public string? RqBik { get; set; }

		/// <summary>
		/// RQ_MFO
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqMfo)]
		public string? RqMfo { get; set; }

		/// <summary>
		/// RQ_ACC_NAME
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqAccName)]
		public string? RqAccName { get; set; }

		/// <summary>
		/// Расчетный счёт
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqAccNum)]
		public string? RqAccNum { get; set; }

		/// <summary>
		/// RQ_IIK
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqIik)]
		public string? RqIik { get; set; }

		/// <summary>
		/// Валюта счёта
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqAccCurrency)]
		public string? RqAccCurrency { get; set; }

		/// <summary>
		/// Кор. счёт
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqCorAccNum)]
		public string? RqCorAccNum { get; set; }

		/// <summary>
		/// RQ_IBAN
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqIban)]
		public string? RqIban { get; set; }

		/// <summary>
		/// SWIFT
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqSwift)]
		public string? RqSwift { get; set; }

		/// <summary>
		/// RQ_BIC
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.RqBic)]
		public string? RqBic { get; set; }

		/// <summary>
		/// Комментарий
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.Comments)]
		public string? Comments { get; set; }

		/// <summary>
		/// Внешний источник
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteBankdetailFields.OriginatorId)]
		public string? OriginatorId { get; set; }

	}
}
