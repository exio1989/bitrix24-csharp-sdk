using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Enums;

namespace Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models
{
    public class Invoice: IAbstractEntity
    {
        /// <summary>
        /// Идентификатор			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }

        /// <summary>
        /// Номер				
        /// Тип: string	
        /// Обязательное
        /// </summary>
        [JsonProperty(InvoiceFields.AccountNumber)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Комментарий менеджера				
        /// Тип: text
        /// </summary>
        [JsonProperty(InvoiceFields.Comments)]
        public string Comments { get; set; }

        /// <summary>
        /// Создано пользователем				
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.CreatedBy)]
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Идентификатор валюты				
        /// Тип: crm_currency	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.Currency)]
        public string Currency { get; set; }

        /// <summary>
        /// Дата выставления				
        /// Тип: date
        /// </summary>
        [JsonProperty(InvoiceFields.DateBill)]
        public DateTimeOffset? DateBill { get; set; }

        /// <summary>
        /// Дата создания				
        /// Тип: datetime	
        /// </summary>
        [JsonProperty(InvoiceFields.DateInsert)]
        public DateTimeOffset? DateInsert { get; set; }

        /// <summary>
        /// Дата отклонения				
        /// Тип: datetime	
        /// Указывается, если счёт отклонён
        /// </summary>
        [JsonProperty(InvoiceFields.DateMarked)]
        public DateTimeOffset? DateMarked { get; set; }

        /// <summary>
        /// Срок оплаты				
        /// Тип: date	
        /// </summary>
        [JsonProperty(InvoiceFields.DatePayBefore)]
        public DateTimeOffset? DatePayBefore { get; set; }

        /// <summary>
        /// Дата перевода в состояние оплаты				
        /// Тип: datetime	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.DatePayed)]
        public DateTimeOffset? DatePayed { get; set; }

        /// <summary>
        /// Дата изменения статуса				
        /// Тип: datetime	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.DateStatus)]
        public DateTimeOffset? DateStatus { get; set; }

        /// <summary>
        /// Дата изменения				
        /// Тип: datetime	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.DateUpdate)]
        public DateTimeOffset? DateUpdate { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который последним перевёл счёт в состояние "оплачен"				
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.EmpPayedId)]
        public int? EmpPayedId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который последним поменял статус счёта				
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.EmpStatusId)]
        public int? EmpStatusId { get; set; }

        /// <summary>
        /// Идентификатор сайта				
        /// Тип: string	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.LId)]
        public string LId { get; set; }

        /// <summary>
        /// Внешний код	string	
        /// </summary>
        [JsonProperty(InvoiceFields.XmlId)]
        public string XmlId { get; set; }

        /// <summary>
        /// Тема				
        /// Тип: string	
        /// Обязательное
        /// </summary>
        [JsonProperty(InvoiceFields.OrderTopic)]
        public string OrderTopic { get; set; }

        /// <summary>
        /// Идентификатор печатной формы				
        /// Тип: integer	
        /// Обязательное
        /// </summary>
        [JsonProperty(InvoiceFields.PaySystemId)]
        public int? PaySystemId { get; set; }

        /// <summary>
        /// Дата оплаты				
        /// Тип: date	
        /// Указывается, если счёт оплачен
        /// </summary>
        [JsonProperty(InvoiceFields.PayVoucherDate)]
        public DateTimeOffset? PayVoucherDate { get; set; }

        /// <summary>
        /// Номер документа оплаты				
        /// Тип: string	
        /// Указывается, если счёт оплачен
        /// </summary>
        [JsonProperty(InvoiceFields.PayVoucherNum)]
        public string PayVoucherNum { get; set; }

        /// <summary>
        /// Признак оплаченности				
        /// Тип: char	
        /// Только для чтения
        /// </summary>
        [JsonIgnore]
        [CrmField(InvoiceFields.Payed, CrmFieldSubTypeEnum.Char_YesNo)]
        public bool Payed
        {
            get
            {
                return PayedExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                PayedExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// Признак оплаченности				
        /// Тип: char	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.Payed)]
        public string PayedExt { get; set; }

        //TODO
        /// <summary>
        /// Идентификатор типа плательщика				
        /// Тип: integer	
        /// Обязательное
        /// </summary>
        [JsonProperty(InvoiceFields.PersonTypeId)]
        public int? PersonTypeId { get; set; }

        /// <summary>
        /// Сумма				
        /// Тип: double	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.Price)]
        public decimal? Price { get; set; }

        /// <summary>
        /// Комментарий статуса				
        /// Тип: string	
        /// Указывается, если счёт оплачен или отклонён
        /// </summary>
        [JsonProperty(InvoiceFields.ReasonMarked)]
        public string ReasonMarked { get; set; }

        /// <summary>
        /// E-mail ответственного				
        /// Тип: string	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsibleEmail)]
        public string ResponsibleEmail { get; set; }

        /// <summary>
        /// Идентификатор ответственного				
        /// Тип: integer	
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsibleId)]
        public int? ResponsibleId { get; set; }

        /// <summary>
        /// Фамилия ответственного				
        /// Тип: string	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsibleLastName)]
        public string ResponsibleLastName { get; set; }

        /// <summary>
        /// Логин ответственного				
        /// Тип: string	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsibleLogin)]
        public string ResponsibleLogin { get; set; }

        /// <summary>
        /// Имя ответственного				
        /// Тип: string	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsibleName)]
        public string ResponsibleName { get; set; }

        /// <summary>
        /// Идентификатор фото ответственного				
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsiblePersonalPhoto)]
        public int? ResponsiblePersonalPhoto { get; set; }

        /// <summary>
        /// Отчество ответственного				
        /// Тип: string	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsibleSecondName)]
        public string ResponsibleSecondName { get; set; }

        /// <summary>
        /// Должность ответственного				
        /// Тип: string	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.ResponsibleWorkPosition)]
        public string ResponsibleWorkPosition { get; set; }

        /// <summary>
        /// Идентификатор статуса				
        /// Тип: crm_status	
        /// Идентификатор справочника "INVOICE_STATUS"
        /// </summary>
        [JsonIgnore]
        [CrmField(InvoiceFields.StatusId, CrmFieldSubTypeEnum.String_InvoiceStatusEnum)]
        public InvoiceStatusEnum StatusId 
        {
            get
            {
                return new InvoiceStatusEnum(StatusIdExt);
            }

            set
            {
                StatusIdExt = value.StatusId;
            }
        }

        /// <summary>
        /// Идентификатор статуса				
        /// Тип: crm_status	
        /// Идентификатор справочника "INVOICE_STATUS"
        /// </summary>
        [JsonProperty(InvoiceFields.StatusId)]
        public string StatusIdExt { get; set; }

        /// <summary>
        /// Сумма налога				
        /// Тип: double	
        /// Только для чтения
        /// </summary>
        [JsonProperty(InvoiceFields.TaxValue)]
        public decimal? TaxValue { get; set; }

        /// <summary>
        /// Идентификатор компании				
        /// Тип: integer	
        /// Указывается, если плательщик "Юридическое лицо"
        /// </summary>
        [JsonProperty(InvoiceFields.UfCompanyId)]
        public int? UfCompanyId { get; set; }

        /// <summary>
        /// Идентификатор контакта				
        /// Тип: integer	
        /// Указывается, если плательщик "Физическое лицо", либо в качестве контактного лица компании
        /// </summary>
        [JsonProperty(InvoiceFields.UfContactId)]
        public int? UfContactId { get; set; }

        /// <summary>
        /// Идентификатор своей компании				
        /// Тип: integer	
        /// Указывается в качестве компании с реквизитами счёта (привязка к реквизитам устанавливается отдельно)
        /// </summary>
        [JsonProperty(InvoiceFields.UfMyCompanyId)]
        public int? UfMyCompanyId { get; set; }

        /// <summary>
        /// Идентификатор связанной сделки				
        /// Тип: integer	
        /// </summary>
        [JsonProperty(InvoiceFields.UfDealId)]
        public int? UfDealId { get; set; }

        /// <summary>
        /// Комментарий				
        /// Тип: string	
        /// </summary>
        [JsonProperty(InvoiceFields.UserDescription)]
        public string UserDescription { get; set; }

        /// <summary>
        /// Идентификатор местоположения				
        /// Тип: integer	
        /// Обязательное, если используется режим налога на документ
        /// </summary>
        [JsonProperty(InvoiceFields.PrLocation)]
        public int? PrLocation { get; set; }

        /// <summary>
        /// Список свойств				
        /// Тип: array
        /// </summary>
        [JsonProperty(InvoiceFields.InvoiceProperties)]
        public InvoiceProperty InvoiceProperties { get; set; }

        /// <summary>
        /// Список товарных позиций				
        /// Тип: array
        /// </summary>
        [JsonProperty(InvoiceFields.ProductRows)]
        public List<ProductRow> ProductRows { get; set; }
    }
}
