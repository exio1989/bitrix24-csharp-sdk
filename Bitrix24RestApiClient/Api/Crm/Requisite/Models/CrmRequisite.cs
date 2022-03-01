#nullable enable
using System;
using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Models
{
	/// <summary>
	/// Реквизиты
	/// </summary>
	public class CrmRequisite:IAbstractEntity
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
		[JsonProperty(CrmRequisiteFields.EntityTypeId)]
		public int? EntityTypeId { get; set; }

		/// <summary>
		/// ID сущности
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteFields.EntityId)]
		public int? EntityId { get; set; }

		/// <summary>
		/// ID пресета
		/// Тип: integer
		/// Обязательное поле
		/// </summary>
		[JsonProperty(CrmRequisiteFields.PresetId)]
		public int? PresetId { get; set; }

		/// <summary>
		/// Дата создания
		/// Тип: datetime
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteFields.DateCreate)]
		public DateTimeOffset? DateCreate { get; set; }

		/// <summary>
		/// Дата изменения
		/// Тип: datetime
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteFields.DateModify)]
		public DateTimeOffset? DateModify { get; set; }

		/// <summary>
		/// Создал
		/// Тип: user
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteFields.CreatedById)]
		public int? CreatedById { get; set; }

		/// <summary>
		/// Изменил
		/// Тип: user
		/// Только для чтения
		/// </summary>
		[JsonProperty(CrmRequisiteFields.ModifyById)]
		public int? ModifyById { get; set; }

		/// <summary>
		/// Название
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.Name)]
		public string? Name { get; set; }

		/// <summary>
		/// Код
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.Code)]
		public string? Code { get; set; }

		/// <summary>
		/// Внешний код
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.XmlId)]
		public string? XmlId { get; set; }

		/// <summary>
		/// ORIGINATOR_ID
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.OriginatorId)]
		public string? OriginatorId { get; set; }

		/// <summary>
		/// Активен
		/// Тип: char
		/// </summary>
		[JsonProperty(CrmRequisiteFields.Active)]
		public string? Active { get; set; }

		/// <summary>
		/// ADDRESS_ONLY
		/// Тип: char
		/// </summary>
		[JsonProperty(CrmRequisiteFields.AddressOnly)]
		public string? AddressOnly { get; set; }

		/// <summary>
		/// Сортировка
		/// Тип: integer
		/// </summary>
		[JsonProperty(CrmRequisiteFields.Sort)]
		public int? Sort { get; set; }

		/// <summary>
		/// Ф.И.О.
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqName)]
		public string? RqName { get; set; }

		/// <summary>
		/// Имя
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqFirstName)]
		public string? RqFirstName { get; set; }

		/// <summary>
		/// Фамилия
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqLastName)]
		public string? RqLastName { get; set; }

		/// <summary>
		/// Отчество
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqSecondName)]
		public string? RqSecondName { get; set; }

		/// <summary>
		/// Сокращенное наименование организации
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqCompanyName)]
		public string? RqCompanyName { get; set; }

		/// <summary>
		/// Полное наименование организации
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqCompanyFullName)]
		public string? RqCompanyFullName { get; set; }

		/// <summary>
		/// Дата государственной регистрации
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqCompanyRegDate)]
		public string? RqCompanyRegDate { get; set; }

		/// <summary>
		/// Ген. директор
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqDirector)]
		public string? RqDirector { get; set; }

		/// <summary>
		/// Гл. бухгалтер
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqAccountant)]
		public string? RqAccountant { get; set; }

		/// <summary>
		/// RQ_CEO_NAME
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqCeoName)]
		public string? RqCeoName { get; set; }

		/// <summary>
		/// RQ_CEO_WORK_POS
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqCeoWorkPos)]
		public string? RqCeoWorkPos { get; set; }

		/// <summary>
		/// Контактное лицо
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqContact)]
		public string? RqContact { get; set; }

		/// <summary>
		/// E-Mail
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqEmail)]
		public string? RqEmail { get; set; }

		/// <summary>
		/// Телефон
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqPhone)]
		public string? RqPhone { get; set; }

		/// <summary>
		/// Факс
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqFax)]
		public string? RqFax { get; set; }

		/// <summary>
		/// RQ_IDENT_TYPE
		/// Тип: crm_status
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentType)]
		public string? RqIdentType { get; set; }

		/// <summary>
		/// Вид документа
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentDoc)]
		public string? RqIdentDoc { get; set; }

		/// <summary>
		/// серия
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentDocSer)]
		public string? RqIdentDocSer { get; set; }

		/// <summary>
		/// номер
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentDocNum)]
		public string? RqIdentDocNum { get; set; }

		/// <summary>
		/// RQ_IDENT_DOC_PERS_NUM
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentDocPersNum)]
		public string? RqIdentDocPersNum { get; set; }

		/// <summary>
		/// дата выдачи
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentDocDate)]
		public string? RqIdentDocDate { get; set; }

		/// <summary>
		/// кем выдан
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentDocIssuedBy)]
		public string? RqIdentDocIssuedBy { get; set; }

		/// <summary>
		/// код подразделения
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIdentDocDepCode)]
		public string? RqIdentDocDepCode { get; set; }

		/// <summary>
		/// ИНН
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqInn)]
		public string? RqInn { get; set; }

		/// <summary>
		/// КПП
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqKpp)]
		public string? RqKpp { get; set; }

		/// <summary>
		/// RQ_USRLE
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqUsrle)]
		public string? RqUsrle { get; set; }

		/// <summary>
		/// ИФНС
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIfns)]
		public string? RqIfns { get; set; }

		/// <summary>
		/// ОГРН
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqOgrn)]
		public string? RqOgrn { get; set; }

		/// <summary>
		/// ОГРНИП
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqOgrnip)]
		public string? RqOgrnip { get; set; }

		/// <summary>
		/// ОКПО
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqOkpo)]
		public string? RqOkpo { get; set; }

		/// <summary>
		/// ОКТМО
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqOktmo)]
		public string? RqOktmo { get; set; }

		/// <summary>
		/// ОКВЭД
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqOkved)]
		public string? RqOkved { get; set; }

		/// <summary>
		/// RQ_EDRPOU
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqEdrpou)]
		public string? RqEdrpou { get; set; }

		/// <summary>
		/// RQ_DRFO
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqDrfo)]
		public string? RqDrfo { get; set; }

		/// <summary>
		/// RQ_KBE
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqKbe)]
		public string? RqKbe { get; set; }

		/// <summary>
		/// RQ_IIN
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqIin)]
		public string? RqIin { get; set; }

		/// <summary>
		/// RQ_BIN
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqBin)]
		public string? RqBin { get; set; }

		/// <summary>
		/// Серия св. о гос. регистрации
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqStCertSer)]
		public string? RqStCertSer { get; set; }

		/// <summary>
		/// Номер св. о гос. регистрации
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqStCertNum)]
		public string? RqStCertNum { get; set; }

		/// <summary>
		/// Дата св. о гос. регистрации
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqStCertDate)]
		public string? RqStCertDate { get; set; }

		/// <summary>
		/// RQ_VAT_PAYER
		/// Тип: char
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqVatPayer)]
		public string? RqVatPayer { get; set; }

		/// <summary>
		/// RQ_VAT_ID
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqVatId)]
		public string? RqVatId { get; set; }

		/// <summary>
		/// RQ_VAT_CERT_SER
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqVatCertSer)]
		public string? RqVatCertSer { get; set; }

		/// <summary>
		/// RQ_VAT_CERT_NUM
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqVatCertNum)]
		public string? RqVatCertNum { get; set; }

		/// <summary>
		/// RQ_VAT_CERT_DATE
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqVatCertDate)]
		public string? RqVatCertDate { get; set; }

		/// <summary>
		/// RQ_RESIDENCE_COUNTRY
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqResidenceCountry)]
		public string? RqResidenceCountry { get; set; }

		/// <summary>
		/// RQ_BASE_DOC
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqBaseDoc)]
		public string? RqBaseDoc { get; set; }

		/// <summary>
		/// RQ_REGON
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqRegon)]
		public string? RqRegon { get; set; }

		/// <summary>
		/// RQ_KRS
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqKrs)]
		public string? RqKrs { get; set; }

		/// <summary>
		/// RQ_PESEL
		/// Тип: string
		/// </summary>
		[JsonProperty(CrmRequisiteFields.RqPesel)]
		public string? RqPesel { get; set; }

	}
}
