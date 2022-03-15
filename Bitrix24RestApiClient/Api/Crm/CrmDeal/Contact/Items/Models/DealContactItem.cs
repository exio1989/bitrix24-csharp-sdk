using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Items.Models
{
    public class DealContactItem
    {
        /// <summary>
        /// Идентификатор сделки(обязательное поле)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(DealContactItemFields.Id)]
        public int? Id { get; set; }

        /// <summary>
        /// Идентификатор контакта
        /// Тип: integer	
        /// </summary>
        [JsonProperty(DealContactItemFields.ContactId)]
        public int? ContactId { get; set; }

        /// <summary>
        /// Идентификатор роли (зарезервировано)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(DealContactItemFields.RoleId)]
        public int? RoleId { get; set; }

        /// <summary>
        /// Индекс сортировки
        /// Тип: integer	
        /// </summary>
        [JsonProperty(DealContactItemFields.Sort)]
        public int? Sort { get; set; }

        /// <summary>
        /// Флаг первичного контакта
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(DealContactItemFields.IsPrimary, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(DealContactItemFields.IsPrimary)]
        public string IsPrimaryExt { get; set; }
    }
}
