using Bitrix24ApiClient.src.Models.Crm.Core;
using Bitrix24RestApiClient.Models.Core.Attributes;
using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bitrix24ApiClient.src.Models
{
    public class Company
    {
        /// <summary>
        /// Адрес компании		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.Address)]
        public string Address { get; set; }

        /// <summary>
        /// Вторая страница адреса		
        /// Тип: string	
        /// В некоторых странах принято разбивать адрес на 2 части	
        /// </summary>
        [JsonProperty(CompanyFields.Address2)]
        public string Address2 { get; set; }

        /// <summary>
        /// Город		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.AddressCity)]
        public string AddressCity { get; set; }

        /// <summary>
        /// Страна		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.AddressCountry)]
        public string AddressCountry { get; set; }

        /// <summary>
        /// Код страны		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.AddressCountryCode)]
        public string AddressCountryCode { get; set; }

        /// <summary>
        ///  			
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.AddressLegal)]
        public string AddressLegal { get; set; }

        /// <summary>
        /// Почтовый индекс		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.AddressPostalCode)]
        public string AddressPostalCode { get; set; }

        /// <summary>
        /// Область		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.AddressProvince)]
        public string AddressProvince { get; set; }

        /// <summary>
        /// Район		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.AddressRegion)]
        public string AddressRegion { get; set; }

        /// <summary>
        /// Связано с пользователем по ID		
        /// Тип: user		
        /// </summary>
        [JsonProperty(CompanyFields.AssignedById)]
        public int? AssignedById { get; set; }

        /// <summary>
        /// Банковские реквизиты		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.BankingDetails)]
        public string BankingDetails { get; set; }

        /// <summary>
        /// Комментарии		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.Comments)]
        public string Comments { get; set; }

        //TODO crm_status
        /// <summary>
        /// COMPANY_TYPE 	Тип компании		
        /// Тип: crm_status		
        /// </summary>
        [JsonProperty(CompanyFields.CompanyType)]
        public string CompanyType { get; set; }

        /// <summary>
        /// Кем создана		
        /// Тип: user	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.CreatedById)]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Валюта		
        /// Тип: crm_currency		
        /// </summary>
        [JsonProperty(CompanyFields.CurrencyId)]
        public string CurrencyId { get; set; }

        /// <summary>
        /// Дата создания		
        /// Тип: datetime	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.DateCreate)]
        public DateTimeOffset? DateCreate { get; set; }

        /// <summary>
        /// Дата изменения		
        /// Тип: datetime	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.DateModify)]
        public DateTimeOffset? DateModify { get; set; }

        /// <summary>
        /// Адрес электронной почты		
        /// Тип: crm_multifield	
        /// Множественное	
        /// </summary>
        [JsonProperty(CompanyFields.Email)]
        public List<CrmMultiFieldEmail> Emails { get; set; }

        //TODO crm_status
        /// <summary>
        /// Количество сотрудников		
        /// Тип: crm_status		
        /// </summary>
        [JsonProperty(CompanyFields.Employees)]
        public string Employees { get; set; }

        /// <summary>
        /// Проверка заполненности поля электронной почты	
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmYesNoFieldType(CompanyFields.HasEmail)]
        public bool HasEmail
        {
            get
            {
                return HasEmailExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                HasEmailExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// Проверка заполненности поля электронной почты		
        /// Тип: char	Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.HasEmail)]
        public string HasEmailExt { get; set; }

        /// <summary>
        /// Проверка заполненности поля телефон		
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmYesNoFieldType(CompanyFields.HasPhone)]
        public bool HasPhone
        {
            get
            {
                return HasEmailExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                HasPhoneExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// Проверка заполненности поля телефон		
        /// Тип: char	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.HasPhone)]
        public string HasPhoneExt { get; set; }

        /// <summary>
        /// Идентификатор компании		
        /// Тип: integer	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.Id)]
        public int? Id { get; set; }

        //TODO CrmMultiField
        /// <summary>
        /// Мессенджеры		
        /// Тип: crm_multifield	Множественное	
        /// </summary>
        [JsonProperty(CompanyFields.Im)]
        public CrmMultiField Im { get; set; }

        //TODO crm_status
        /// <summary>
        /// Сфера деятельности		
        /// Тип: crm_status		
        /// </summary>
        [JsonProperty(CompanyFields.Industry)]
        public string Industry { get; set; }

        /// <summary>
        ///  				
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmYesNoFieldType(CompanyFields.IsMyCompany)]
        public bool IsMyCompany
        {
            get
            {
                return IsMyCompanyExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                IsMyCompanyExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        ///  			
        /// Тип: char		
        /// </summary>
        [JsonProperty(CompanyFields.IsMyCompany)]
        public string IsMyCompanyExt { get; set; }

        /// <summary>
        /// Идентификатор лида, связанного с компанией		
        /// Тип: crm_lead	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.LeadId)]
        public int? LeadId { get; set; }

        //TODO file
        /// <summary>
        /// LOGO 	Логотип		
        /// Тип: file		
        /// </summary>
        [JsonProperty(CompanyFields.Logo)]
        public string Logo { get; set; }

        /// <summary>
        /// Идентификатор автора последнего изменения		
        /// Тип: user	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(CompanyFields.ModifyById)]
        public int? ModifyById { get; set; }

        /// <summary>
        /// Доступен для всех		
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmYesNoFieldType(CompanyFields.Opened)]
        public bool Opened
        {
            get
            {
                return OpenedExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                OpenedExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// Доступен для всех		
        /// Тип: char		
        /// </summary>
        [JsonProperty(CompanyFields.Opened)]
        public string OpenedExt { get; set; }

        /// <summary>
        /// Идентификатор источника данных		
        /// Тип: string	
        /// Используется только для привязки к внешнему источнику.	
        /// </summary>
        [JsonProperty(CompanyFields.OriginatorId)]
        public string OriginatorId { get; set; }

        /// <summary>
        /// Идентификатор элемента в источнике данных		
        /// Тип: string	
        /// Используется только для привязки к внешнему источнику.	
        /// </summary>
        [JsonProperty(CompanyFields.OriginId)]
        public string OriginId { get; set; }

        /// <summary>
        /// Оригинальная версия		
        /// Тип: string	
        /// Используется для защиты данных от случайного перетирания внешней системой. Если данные были импортированы и не изменялись во внешней системе, то такие данные могут быть редактированы в CRM без опасения, что следующая выгрузка приведет к перетиранию данных	
        /// </summary>
        [JsonProperty(CompanyFields.OriginVersion)]
        public string OriginVersion { get; set; }

        /// <summary>
        /// Телефон компании		
        /// Тип: crm_multifield	
        /// Множественное	
        /// </summary>
        [JsonProperty(CompanyFields.Phone)]
        public List<CrmMultiFieldPhone> Phones { get; set; }

        /// <summary>
        /// Юридический адрес компании		
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddress)]
        public string RegAddress { get; set; }

        /// <summary>
        /// Вторая страница юридического адреса		
        /// Тип: string	
        /// В некоторых странах принято разбивать адрес на 2 части. Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddress2)]
        public string RegAddress2 { get; set; }

        /// <summary>
        /// Город юридического адреса		
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddressCity)]
        public string RegAddressCity { get; set; }

        /// <summary>
        /// Страна юридического адреса		
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddressCountry)]
        public string RegAddressCountry { get; set; }

        /// <summary>
        /// Код страны юридического адреса		
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddressCountryCode)]
        public string RegAddressCountryCode { get; set; }

        /// <summary>
        /// REG_ADDRESS_LEGAL 			
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddressLegal)]
        public string RegAddressLegal { get; set; }

        /// <summary>
        /// Почтовый индекс юридического адреса		
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddressPostalCode)]
        public string RegAddressPostalCode { get; set; }

        /// <summary>
        /// Область юридического адреса		
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddressProvince)]
        public string RegAddressProvince { get; set; }

        /// <summary>
        /// Район юридического адреса		
        /// Тип: string	
        /// Устарел, использутся для совместимости.	
        /// </summary>
        [JsonProperty(CompanyFields.RegAddressRegion)]
        public string RegAddressRegion { get; set; }

        /// <summary>
        /// Годовой оборот		
        /// Тип: double		
        /// </summary>
        [JsonProperty(CompanyFields.Revenue)]
        public string Revenue { get; set; }

        /// <summary>
        /// TITLE 	Название		
        /// Тип: string	
        /// Обязательное	
        /// </summary>
        [JsonProperty(CompanyFields.Title)]
        public string Title { get; set; }

        /// <summary>
        /// Обозначение рекламной кампании		
        /// Тип: string		
        /// </summary>
        [JsonProperty(CompanyFields.UtmCampaign)]
        public string UtmCampaign { get; set; }

        /// <summary>
        /// Содержание кампании		
        /// Тип: string	
        /// Например, для контекстных объявлений.	
        /// </summary>
        [JsonProperty(CompanyFields.UtmContent)]
        public string UtmContent { get; set; }

        /// <summary>
        /// Тип трафика		
        /// Тип: string	
        /// CPC (объявления), CPM (баннеры)	
        /// </summary>
        [JsonProperty(CompanyFields.UtmMedium)]
        public string UtmMedium { get; set; }

        /// <summary>
        /// Рекламная система		
        /// Тип: string	
        /// Yandex-Direct, Google-Adwords и другие.	
        /// </summary>
        [JsonProperty(CompanyFields.UtmSource)]
        public string UtmSource { get; set; }

        /// <summary>
        /// Условие поиска кампании		
        /// Тип: string	
        /// Например, ключевые слова контекстной рекламы.	
        /// </summary>
        [JsonProperty(CompanyFields.UtmTerm)]
        public string UtmTerm { get; set; }

        //TODO CrmMultiField
        /// <summary>
        /// URL ресурсов компании		
        /// Тип: crm_multifield	
        /// Множественное	
        /// </summary>
        [JsonProperty(CompanyFields.Web)]
        public CrmMultiField Web { get; set; }

    }
}
