using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Models;
using Bitrix24RestApiClient.Core.Models.CrmMultiField;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;
using Bitrix24RestApiClient.Core.Models.CrmMultiField.implementations;

namespace Bitrix24RestApiClient.Api.Crm.CrmLead.Models
{
    public class Lead: IAbstractEntity
    {
        /// <summary>
        /// Идентификатор			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }

        /// <summary>
        /// Адрес контакта			
        /// Тип: string
        /// </summary>
        [JsonProperty(LeadFields.Address)]
        public string Address { get; set; }

        /// <summary>
        /// Вторая страница адреса			
        /// Тип: string	
        /// В некоторых странах принято разбивать адрес на 2 части
        /// </summary>
        [JsonProperty(LeadFields.Address2)]
        public string Address2 { get; set; }

        /// <summary>
        /// Город			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.AddressCity)]
        public string AddressCity { get; set; }

        /// <summary>
        /// Страна			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.AddressCountry)]
        public string AddressCountry { get; set; }

        /// <summary>
        /// Код страны			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.AddressCountryCode)]
        public string AddressCountryCode { get; set; }

        /// <summary>
        /// Почтовый индекс			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.AddressPostalCode)]
        public string AddressPostalCode { get; set; }

        /// <summary>
        /// Область			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.AddressProvince)]
        public string AddressProvince { get; set; }

        /// <summary>
        /// Район			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.AddressRegion)]
        public string AddressRegion { get; set; }

        /// <summary>
        /// Связано с пользователем по ID			
        /// Тип: user
        /// </summary>
        [JsonProperty(LeadFields.AssignedById)]
        public int? AssignedById { get; set; }

        /// <summary>
        /// Дата рождения			
        /// Тип: date	
        /// </summary>
        [JsonProperty(LeadFields.BirthDate)]
        public DateTimeOffset? BirthDate { get; set; }

        /// <summary>
        /// Комментарии			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.Comments)]
        public string Comments { get; set; }

        /// <summary>
        /// Привязка лида к компании			
        /// Тип: crm_company	
        /// </summary>
        [JsonProperty(LeadFields.CompanyId)]
        public int? CompanyId { get; set; }

        //TODO string
        /// <summary>
        /// Название компании, привязанной к лиду			
        /// Тип: crm_company	
        /// </summary>
        [JsonProperty(LeadFields.CompanyTitle)]
        public string CompanyTitle { get; set; }

        /// <summary>
        /// Привязка лида к контакту			
        /// Тип: crm_contact	
        /// </summary>
        [JsonProperty(LeadFields.ContactId)]
        public int? ContactId { get; set; }

        //TODO user
        /// <summary>
        /// Кем создана			
        /// Тип: user	
        /// Только для чтения
        /// </summary>
        [JsonProperty(LeadFields.CreatedById)]
        public int? CreatedById { get; set; }

        /// <summary>
        /// Идентификатор валюты	
        /// crm_currency	
        /// </summary>
        [JsonProperty(LeadFields.CurrencyId)]
        public string CurrencyId { get; set; }

        /// <summary>
        /// Дата закрытия			
        /// Тип: datetime	
        /// Только для чтения
        /// </summary>
        [JsonProperty(LeadFields.DateClosed)]
        public DateTimeOffset? DateClosed { get; set; }

        /// <summary>
        /// Дата создания			
        /// Тип: datetime	
        /// Только для чтения
        /// </summary>
        [JsonProperty(LeadFields.DateCreate)]
        public DateTimeOffset? DateCreate { get; set; }

        /// <summary>
        /// Дата изменения			
        /// Тип: datetime	
        /// Только для чтения
        /// </summary>
        [JsonProperty(LeadFields.DateModify)]
        public DateTimeOffset? DateModify { get; set; }

        /// <summary>
        /// Адрес электронной почты			
        /// Тип: crm_multifield	
        /// Множественное
        /// </summary>
        [JsonProperty(LeadFields.Email)]
        public List<CrmMultiFieldEmail> Emails { get; set; }

        /// <summary>
        /// Проверка заполненности поля электронной почты	
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(LeadFields.HasEmail, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(LeadFields.HasEmail)]
        public string HasEmailExt { get; set; }

        /// <summary>
        /// Проверка заполненности поля телефон		
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(LeadFields.HasPhone, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(LeadFields.HasPhone)]
        public string HasPhoneExt { get; set; }

        //TODO crm_status
        /// <summary>
        /// Вид обращения			
        /// Тип: crm_status	
        /// </summary>
        [JsonProperty(LeadFields.Honorific)]
        public string Honorific { get; set; }

        //TODO CrmMultiField
        /// <summary>
        /// Мессенджеры			
        /// Тип: crm_multifield	
        /// Множественное
        /// </summary>
        [JsonProperty(LeadFields.Im)]
        public List<CrmMultiField> Im { get; set; }

        /// <summary>
        /// IS_RETURN_CUSTOMER	Признак повторного лида			
        /// Тип: char	
        /// Только для чтения
        /// </summary>
        [JsonIgnore]
        [CrmField(LeadFields.IsReturnCustomer, CrmFieldSubTypeEnum.Char_YesNo)]
        public bool IsReturnCustomer
        {
            get
            {
                return IsReturnCustomerExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                IsReturnCustomerExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// Признак повторного лида			
        /// Тип: char	
        /// Только для чтения
        /// </summary>
        [JsonProperty(LeadFields.IsReturnCustomer)]
        public string IsReturnCustomerExt { get; set; }

        /// <summary>
        /// Фамилия			
        /// Тип: string	
        /// Обязательное
        /// </summary>
        [JsonProperty(LeadFields.LastName)]
        public string LastName { get; set; }

        //TODO user
        /// <summary>
        /// Идентификатор автора последнего изменения			
        /// Тип: user	
        /// Только для чтения
        /// </summary>
        [JsonProperty(LeadFields.ModifyById)]
        public int? ModifyById { get; set; }

        /// <summary>
        /// Имя			
        /// Тип: string	
        /// Обязательное
        /// </summary>
        [JsonProperty(LeadFields.Name)]
        public string Name { get; set; }

        /// <summary>
        /// Доступен для всех		
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(LeadFields.Opened, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(DealFields.Opened)]
        public string OpenedExt { get; set; }

        /// <summary>
        /// Предполагаемая сумма			
        /// Тип: double	
        /// </summary>
        [JsonProperty(LeadFields.Opportunity)]
        public decimal? Opportunity { get; set; }

        /// <summary>
        /// Идентификатор источника данных			
        /// Тип: string	
        /// Используется только для привязки к внешнему источнику.
        /// </summary>
        [JsonProperty(LeadFields.OriginatorId)]
        public string OriginatorId { get; set; }

        /// <summary>
        /// Идентификатор элемента в источнике данных			
        /// Тип: string	
        /// Используется только для привязки к внешнему источнику.
        /// </summary>
        [JsonProperty(LeadFields.OriginId)]
        public string OriginId { get; set; }

        /// <summary>
        /// Оригинальная версия			
        /// Тип: string	
        /// Используется для защиты данных от случайного перетирания внешней системой. Если данные были импортированы и не изменялись во внешней системе, то такие данные могут быть редактированы в CRM без опасения, что следующая выгрузка приведет к перетиранию данных
        /// </summary>
        [JsonProperty(LeadFields.OriginatorVersion)]
        public string OriginatorVersion { get; set; }

        /// <summary>
        /// Телефон контакта			
        /// Тип: crm_multifield	
        /// Множественное
        /// </summary>
        [JsonProperty(LeadFields.Phone)]
        public List<CrmMultiFieldPhone> Phone { get; set; }

        /// <summary>
        /// Должность			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.Post)]
        public string Post { get; set; }

        /// <summary>
        /// Отчество			
        /// Тип: string	
        /// Обязательное
        /// </summary>
        [JsonProperty(LeadFields.SecondName)]
        public string SecondName { get; set; }

        /// <summary>
        /// Описание источника			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.SourceDescription)]
        public string SourceDescription { get; set; }

        //TODO crm_status
        /// <summary>
        /// Идентификатор источника			
        /// Тип: crm_status	
        /// Статус из справочника. Список возможных идентификаторов можно получить методом crm.status.list с фильтром filter[ENTITY_ID]=SOURCE
        /// </summary>
        [JsonProperty(LeadFields.SourceId)]
        public string SourceId { get; set; }

        /// <summary>				
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.StatusDescription)]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.StatusId)]
        public string StatusId { get; set; }

        /// <summary>
        /// Тип: string	
        /// F (failed) - обработан неуспешно,
        /// S (success) - обработан успешно,
        /// P (processing) - лид в обработке.
        /// </summary>
        [JsonIgnore]
        [CrmField(LeadFields.StatusSemanticId, CrmFieldSubTypeEnum.String_StatusSemanticIdEnum)]
        public StatusSemanticIdEnum StatusSemanticId
        {
            get
            {
                switch (StatusSemanticIdExt)
                {
                    case "F":
                        return StatusSemanticIdEnum.Failed;
                    case "S":
                        return StatusSemanticIdEnum.Success;
                    case "P":
                        return StatusSemanticIdEnum.Processing;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                switch (value)
                {
                    case StatusSemanticIdEnum.Failed:
                        StatusSemanticIdExt = "F";
                        break;
                    case StatusSemanticIdEnum.Success:
                        StatusSemanticIdExt = "S";
                        break;
                    case StatusSemanticIdEnum.Processing:
                        StatusSemanticIdExt = "P";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Тип: string	
        /// F (failed) - обработан неуспешно,
        /// S (success) - обработан успешно,
        /// P (processing) - лид в обработке.
        /// </summary>
        [JsonProperty(LeadFields.StatusSemanticId)]
        public string StatusSemanticIdExt { get; set; }

        /// <summary>
        /// Название лида			
        /// Тип: string	
        /// Обязательное
        /// </summary>
        [JsonProperty(LeadFields.Title)]
        public string Title { get; set; }

        /// <summary>
        /// Обозначение рекламной кампании			
        /// Тип: string	
        /// </summary>
        [JsonProperty(LeadFields.UtmCampaign)]
        public string UtmCampaign { get; set; }

        /// <summary>
        /// Содержание кампании			
        /// Тип: string	
        /// Например, для контекстных объявлений.
        /// </summary>
        [JsonProperty(LeadFields.UtmContent)]
        public string UtmContent { get; set; }

        /// <summary>
        /// Тип трафика			
        /// Тип: string	
        /// CPC (объявления), CPM (баннеры)
        /// </summary>
        [JsonProperty(LeadFields.UtmMedium)]
        public string UtmMedium { get; set; }

        /// <summary>
        /// Рекламная система			
        /// Тип: string	
        /// Yandex-Direct, Google-Adwords и другие.
        /// </summary>
        [JsonProperty(LeadFields.UtmSource)]
        public string UtmSource { get; set; }

        /// <summary>
        /// Условие поиска кампании			
        /// Тип: string	
        /// Например, ключевые слова контекстной рекламы.
        /// </summary>
        [JsonProperty(LeadFields.UtmTerm)]
        public string UtmTerm { get; set; }

        //TODO CrmMultiField
        /// <summary>
        /// URL ресурсов лида			
        /// Тип: crm_multifield	
        /// Множественное
        /// </summary>
        [JsonProperty(LeadFields.Web)]
        public List<CrmMultiField> Web { get; set; }

    }
}
