using Bitrix24ApiClient.src.Models.Crm.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class Contact
    {
        [JsonProperty(ContactFields.Id)]
        public int Id { get; set; }

        [JsonProperty(ContactFields.Name)]
        public string Name { get; set; }

        [JsonProperty(ContactFields.Email)]
        public List<Email> Emails { get; set; }

        [JsonProperty(ContactFields.Phone)]
        public List<Phone> Phones { get; set; }
        /*
        ADDRESS Адрес контакта string
        ADDRESS_2   Вторая страница адреса string В некоторых странах принято разбивать адрес на 2 части
        ADDRESS_CITY    Город string
        ADDRESS_COUNTRY     Страна string
        ADDRESS_COUNTRY_CODE    Код страны  string
        ADDRESS_POSTAL_CODE     Почтовый индекс string
        ADDRESS_PROVINCE    Область string
        ADDRESS_REGION  Район string
        ASSIGNED_BY_ID  Связано с пользователем по ID user
        BIRTHDATE Дата рождения date
        COMMENTS Комментарии string
        COMPANY_ID  Привязка контакта к компании    crm_company Устаревший.Сохраняется для совместимости.
        COMPANY_IDS Привязка контакта к нескольким компаниям.	crm_company Множественное.
        В методах crm.contact.update и crm.contact.add используется для подачи массива компаний. В методах crm.contact.list и crm.contact.get поля нет и необходимо использовать crm.contact.company.items.get для получения списка компаний.
        CREATED_DY_ID Кем создана user    Только для чтения
        DATE_CREATE     Дата создания   datetime Только для чтения
        DATE_MODIFY Дата изменения datetime    Только для чтения
        EMAIL   Адрес электронной почты crm_multifield  Множественное
        EXPORT  Участвует ли контакт в экспорте.Eсли N, то выгрузить его невозможно.	char Защита от сотрудников, которые хотят украсть базу клиентов.
        FACE_ID Привязка к лицам из модуля faceid integer
        HAS_EMAIL Проверка заполненности поля электронной почты   char Только для чтения
        HAS_PHONE Проверка заполненности поля телефон char Только для чтения
        HONORIFIC Вид обращения crm_status
        ID Идентификатор контакта integer Только для чтения
        IM  Мессенджеры crm_multifield  Множественное
        LAST_NAME   Фамилия string Обязательное
        LEAD_ID Идентификатор лида, связанного с контактом crm_lead    Только для чтения
        MODIFY_BY_ID    Идентификатор автора последнего изменения   user Только для чтения
        NAME Имя string Обязательное
        OPENED Доступен для всех   char
        ORIGINATOR_ID   Идентификатор источника данных  string Используется только для привязки к внешнему источнику.
        ORIGIN_ID Идентификатор элемента в источнике данных   string Используется только для привязки к внешнему источнику.
        ORIGIN_VERSION Оригинальная версия string Используется для защиты данных от случайного перетирания внешней системой. Если данные были импортированы и не изменялись во внешней системе, то такие данные могут быть редактированы в CRM без опасения, что следующая выгрузка приведет к перетиранию данных
        PHONE   Телефон контакта    crm_multifield Множественное
        PHOTO Фото контакта file
        POST Должность   string
        SECOND_NAME     Отчество    string Обязательное
        SOURCE_DESCRIPTION Описание источника  string Текстовое поле
        SOURCE_ID   Идентификатор источника crm_status Статус из справочника. Список возможных идентификаторов можно получить методом crm.status.list с фильтром filter[ENTITY_ID]= SOURCE
        TYPE_ID Идентификатор типа crm_status  Статус из справочника
        UTM_CAMPAIGN    Обозначение рекламной кампании  string
        UTM_CONTENT     Содержание кампании string Например, для контекстных объявлений.
        UTM_MEDIUM Тип трафика string CPC (объявления), CPM (баннеры)
        UTM_SOURCE  Рекламная система   string Yandex-Direct, Google-Adwords и другие.
        UTM_TERM Условие поиска кампании string Например, ключевые слова контекстной рекламы.
        WEB URL ресурсов контакта   crm_multifield Множественное*/
    }
}
