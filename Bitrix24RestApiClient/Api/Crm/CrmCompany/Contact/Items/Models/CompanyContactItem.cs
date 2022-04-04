using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items.Models
{
    public class CompanyContactItem
    {
        /// <summary>
        /// Идентификатор сделки(обязательное поле)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(CompanyContactItemFields.Id)]
        public int? Id { get; set; }

        /// <summary>
        /// Идентификатор контакта
        /// Тип: integer	
        /// </summary>
        [JsonProperty(CompanyContactItemFields.ContactId)]
        public int? ContactId { get; set; }

        /// <summary>
        /// Идентификатор роли (зарезервировано)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(CompanyContactItemFields.RoleId)]
        public int? RoleId { get; set; }

        /// <summary>
        /// Индекс сортировки
        /// Тип: integer	
        /// </summary>
        [JsonProperty(CompanyContactItemFields.Sort)]
        public int? Sort { get; set; }

        /// <summary>
        /// Флаг первичного контакта
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(CompanyContactItemFields.IsPrimary, CrmFieldSubTypeEnum.Char_YesNo)]
        public bool IsPrimary
        {
            get
            {
                return IsPrimaryExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                IsPrimaryExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        /// <summary>
        /// Флаг первичного контакта
        /// Тип: char	
        /// </summary>
        [JsonProperty(CompanyContactItemFields.IsPrimary)]
        public string IsPrimaryExt { get; set; }
    }
}
