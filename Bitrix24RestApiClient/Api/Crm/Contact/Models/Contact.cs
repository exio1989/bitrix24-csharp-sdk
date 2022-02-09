using Bitrix24ApiClient.src.Models.Crm.Core;
using Bitrix24RestApiClient.Core.Models;
using Bitrix24RestApiClient.Models.Core.Attributes;
using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class Contact: AbstractEntity
    {
        /// <summary>
        /// Адрес контакта 		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.Address)]
        public string Address { get; set; }

        /// <summary>
        /// Вторая страница адреса 		
        /// Тип: string 
        /// В некоторых странах принято разбивать адрес на 2 части
        /// </summary>
        [JsonProperty(ContactFields.Address2)]
        public string Address2 { get; set; }

        /// <summary>
        ///    Город 		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.AddressCity)]
        public string AddressCity { get; set; }

        /// <summary>
        /// Страна 		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.AddressCountry)]
        public string AddressCountry { get; set; }

        /// <summary>
        /// Код страны  		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.AddressCountryCode)]
        public string AddressCountryCode { get; set; }

        /// <summary>
        /// Почтовый индекс 		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.AddressPostalCode)]
        public string AddressPostalCode { get; set; }

        /// <summary>
        /// Область 		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.AddressProvince)]
        public string AddressProvince { get; set; }

        /// <summary>
        /// Район 		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.AddressRegion)]
        public string AddressRegion { get; set; }

        /// <summary>
        /// Связано с пользователем по ID 		
        /// Тип: user
        /// </summary>
        [JsonProperty(ContactFields.AssignedById)]
        public int? AssignedById { get; set; }

        /// <summary>
        /// Дата рождения 		
        /// Тип: date
        /// </summary>
        [JsonProperty(ContactFields.BirthDate)]
        public DateTimeOffset? BirthDate { get; set; }

        /// <summary>
        /// Комментарии 		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.Comments)]
        public string Comments { get; set; }

        /// <summary>
        /// Привязка контакта к компании    		
        /// Тип: crm_company 
        /// Устаревший.Сохраняется для совместимости.
        /// </summary>
        [JsonProperty(ContactFields.CompanyId)]
        public int? CompanyId { get; set; }

        /// <summary>
        /// Привязка контакта к нескольким компаниям.			
        /// Тип: crm_company 
        /// Множественное.
        /// В методах crm.contact.update и crm.contact.add используется для подачи массива компаний. 
        /// В методах crm.contact.list и crm.contact.get поля нет и необходимо использовать crm.contact.company.items.get 
        /// для получения списка компаний.
        /// </summary>
        [JsonProperty(ContactFields.CompanyIds)]
        public List<int?> CompanyIds { get; set; }

        /// <summary>
        /// Кем создана 		
        /// Тип: user    
        /// Только для чтения
        /// </summary>
        [JsonProperty(ContactFields.CreatedById)]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Дата создания   		
        /// Тип: datetime 
        /// Только для чтения
        /// </summary>
        [JsonProperty(ContactFields.DateCreate)]
        public DateTimeOffset? DateCreate { get; set; }

        /// <summary>
        /// Дата изменения 		
        /// Тип: datetime    
        /// Только для чтения
        /// </summary>
        [JsonProperty(ContactFields.DateModify)]
        public DateTimeOffset? DateModify { get; set; }

        /// <summary>
        /// Адрес электронной почты 		
        /// Тип: crm_multifield  
        /// Множественное
        /// </summary>
        [JsonProperty(ContactFields.Email)]
        public List<CrmMultiFieldEmail> Emails { get; set; }

        /// <summary>
        /// Участвует ли контакт в экспорте.Eсли N, то выгрузить его невозможно.	
        /// Тип: char	
        /// Защита от сотрудников, которые хотят украсть базу клиентов.
        /// </summary>
        [JsonIgnore]
        [CrmField(ContactFields.Export, CrmFieldSubTypeEnum.Char_YesNo)]
        public bool Export
        {
            get
            {
                return ExportExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                ExportExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// Участвует ли контакт в экспорте.Eсли N, то выгрузить его невозможно.			
        /// Тип: char 
        /// Защита от сотрудников, которые хотят украсть базу клиентов.
        /// </summary>
        [JsonProperty(ContactFields.Export)]
        public string ExportExt { get; set; }

        /// <summary>
        /// Привязка к лицам из модуля faceid 		
        /// Тип: integer
        /// </summary>
        [JsonProperty(ContactFields.FaceId)]
        public int? FaceId { get; set; }

        /// <summary>
        /// Проверка заполненности поля электронной почты	
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(ContactFields.HasEmail, CrmFieldSubTypeEnum.Char_YesNo)]
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
        /// Тип: char	
        /// Только для чтения	
        /// </summary>
        [JsonProperty(ContactFields.HasEmail)]
        public string HasEmailExt { get; set; }

        /// <summary>
        /// Проверка заполненности поля телефон		
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(ContactFields.HasPhone, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(ContactFields.HasPhone)]
        public string HasPhoneExt { get; set; }

        /// <summary>
        /// Вид обращения 		
        /// Тип: crm_status
        /// </summary>
        [JsonProperty(ContactFields.Honorific)]
        public string Honorific { get; set; }

        /// <summary>
        ///  Мессенджеры 		
        /// Тип: crm_multifield  
        /// Множественное
        /// </summary>
        [JsonProperty(ContactFields.Im)]
        public List<CrmMultiField> Im { get; set; }

        /// <summary>
        /// Фамилия 		
        /// Тип: string 
        /// Обязательное
        /// </summary>
        [JsonProperty(ContactFields.LastName)]
        public string LastName { get; set; }

        /// <summary>
        /// Идентификатор лида, связанного с контактом 		
        /// Тип: crm_lead    
        /// Только для чтения
        /// </summary>
        [JsonProperty(ContactFields.LeadId)]
        public int? LeadId { get; set; }

        /// <summary>
        /// Идентификатор автора последнего изменения   		
        /// Тип: user 
        /// Только для чтения
        /// </summary>
        [JsonProperty(ContactFields.ModifyById)]
        public int? ModifyById { get; set; }

        /// <summary>
        /// Имя 		
        /// Тип: string 
        /// Обязательное
        /// </summary>
        [JsonProperty(ContactFields.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Доступен для всех		
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(ContactFields.Opened, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(ContactFields.Opened)]
        public string OpenedExt { get; set; }

        /// <summary>
        ///  Идентификатор источника данных  		
        /// Тип: string 
        /// Используется только для привязки к внешнему источнику.
        /// </summary>
        [JsonProperty(ContactFields.OriginatorId)]
        public string OriginatorId { get; set; }

        /// <summary>
        /// Идентификатор элемента в источнике данных   		
        /// Тип: string 
        /// Используется только для привязки к внешнему источнику.
        /// </summary>
        [JsonProperty(ContactFields.OriginId)]
        public string OriginId { get; set; }

        /// <summary>
        /// Оригинальная версия 		
        /// Тип: string 
        /// Используется для защиты данных от случайного перетирания внешней системой. 
        /// Если данные были импортированы и не изменялись во внешней системе, то такие данные могут быть редактированы в 
        /// CRM без опасения, что следующая выгрузка приведет к перетиранию данных
        /// </summary>
        [JsonProperty(ContactFields.OriginatorVersion)]
        public string OriginatorVersion { get; set; }

        /// <summary>
        /// Телефон контакта		
        /// Тип: crm_multifield	
        /// Множественное	
        /// </summary>
        [JsonProperty(CompanyFields.Phone)]
        public List<CrmMultiFieldPhone> Phones { get; set; }

        //TODO file
        /// <summary>
        /// Фото контакта 		
        /// Тип: file
        /// </summary>
        [JsonProperty(ContactFields.Photo)]
        public string Photo { get; set; }

        /// <summary>
        /// Должность   		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.Post)]
        public string Post { get; set; }

        /// <summary>
        /// Отчество    		
        /// Тип: string 
        /// Обязательное
        /// </summary>
        [JsonProperty(ContactFields.SecondName)]
        public string SecondName { get; set; }

        /// <summary>
        /// Описание источника  		
        /// Тип: string 
        /// Текстовое поле
        /// </summary>
        [JsonProperty(ContactFields.SourceDescription)]
        public string SourceDescription { get; set; }

        /// <summary>
        /// Идентификатор источника 		
        /// Тип: crm_status 
        /// Статус из справочника. 
        /// Список возможных идентификаторов можно получить методом crm.status.list с фильтром filter[ENTITY_ID]= SOURCE
        /// </summary>
        [JsonProperty(ContactFields.SourceId)]
        public string SourceId { get; set; }

        /// <summary>
        /// Идентификатор типа 		
        /// Тип: crm_status  
        /// Статус из справочника
        /// </summary>
        [JsonProperty(ContactFields.TypeId)]
        public string TypeId { get; set; }

        /// <summary>
        /// Обозначение рекламной кампании  		
        /// Тип: string
        /// </summary>
        [JsonProperty(ContactFields.UtmCampaign)]
        public string UtmCampaign { get; set; }

        /// <summary>
        /// Содержание кампании 		
        /// Тип: string 
        /// Например, для контекстных объявлений.
        /// </summary>
        [JsonProperty(ContactFields.UtmContent)]
        public string UtmContent { get; set; }

        /// <summary>
        /// Тип трафика 		
        /// Тип: string 
        /// CPC (объявления), CPM (баннеры)
        /// </summary>
        [JsonProperty(ContactFields.UtmMedium)]
        public string UtmMedium { get; set; }

        /// <summary>
        /// Рекламная система   		
        /// Тип: string 
        /// Yandex-Direct, Google-Adwords и другие.
        /// </summary>
        [JsonProperty(ContactFields.UtmSource)]
        public string UtmSource { get; set; }

        /// <summary>
        /// Условие поиска кампании 		
        /// Тип: string 
        /// Например, ключевые слова контекстной рекламы.
        /// </summary>
        [JsonProperty(ContactFields.UtmTerm)]
        public string UtmTerm { get; set; }

        /// <summary>
        /// URL ресурсов контакта   		
        /// Тип: crm_multifield 
        /// Множественное
        /// </summary>
        [JsonProperty(ContactFields.Web)]
        public List<CrmMultiField> Web { get; set; }
    }
}
