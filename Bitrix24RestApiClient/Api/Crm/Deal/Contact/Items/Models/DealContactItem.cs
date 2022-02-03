using Bitrix24RestApiClient.Models.Core.Attributes;
using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Api.Crm.Deal.Contact.Models
{
    public class DealContactItem
    {
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
        [CrmYesNoFieldType(DealContactItemFields.IsPrimary)]
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
