using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrix24RestApiClient.Api.Crm.Invoices.OldInvoices.Models
{
    /// <summary>
    /// 	Если клиент - компания, могут быть указаны ключи (все значения типа string):
    /// COMPANY - Название компании;
    /// COMPANY_ADR - Адрес;
    /// CONTACT_PERSON - Контактное лицо;
    /// EMAIL - E-mail;
    /// PHONE - Телефон;
    /// INN - ИНН;
    /// KPP - КПП;
    /// 
    /// Если клиент - контакт:
    /// 
    /// FIO - Ф.И.О.;
    /// ADDRESS - Адрес;
    /// EMAIL - E-mail;
    /// PHONE - Телефон;
    /// </summary>
    public class InvoiceProperty
    {
        /// <summary>
        /// COMPANY - Название компании;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.CompanyName)]
        public string CompanyName { get; set; }

        /// <summary>
        /// COMPANY_ADR - Адрес;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.CompanyAddress)]
        public string CompanyAddress { get; set; }

        /// <summary>
        /// CONTACT_PERSON - Контактное лицо;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.ContactPerson)]
        public string ContactPerson { get; set; }

        /// <summary>
        /// EMAIL - E-mail;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Email)]
        public string Email { get; set; }

        /// <summary>
        /// PHONE - Телефон;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Phone)]
        public string Phone { get; set; }

        /// <summary>
        /// Факс
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Fax)]
        public string Fax { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Zip)]
        public string Zip { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [JsonProperty(InvoicePropertyFields.City)]
        public string City { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Location)]
        public string Location { get; set; }

        /// <summary>
        /// INN - ИНН;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Inn)]
        public string Inn { get; set; }

        /// <summary>
        /// KPP - КПП;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Kpp)]
        public string Kpp { get; set; }

        /// <summary>
        /// FIO - Ф.И.О.;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Fio)]
        public string Fio { get; set; }

        /// <summary>
        /// ADDRESS - Адрес;
        /// </summary>
        [JsonProperty(InvoicePropertyFields.Address)]
        public string Address { get; set; }
    }
}
