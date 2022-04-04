using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Models
{
    public class CompanyContact
    {
        /// <summary>
        /// Идентификатор сделки(обязательное поле)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(CompanyContactFields.Id)]
        public int? Id { get; set; }

        /// <summary>
        /// Идентификатор контакта(обязательное поле)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(CompanyContactFields.ContactId)]
        public int? ContactId { get; set; }

        /// <summary>
        /// Индекс сортировки
        /// Тип: integer	
        /// </summary>
        [JsonProperty(CompanyContactFields.Sort)]
        public int? Sort { get; set; }

        /// <summary>
        /// Флаг первичного контакта
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(CompanyContactFields.IsPrimary, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(CompanyContactFields.IsPrimary)]
        public string IsPrimaryExt { get; set; }
    }
}
