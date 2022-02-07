using Bitrix24RestApiClient.Models.Core.Attributes;
using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrix24RestApiClient.Api.Crm.Deal.Contact.Models
{
    public class DealContact
    {
        /// <summary>
        /// Идентификатор контакта(обязательное поле)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(DealContactFields.ContactId)]
        public int? ContactId { get; set; }

        /// <summary>
        /// Индекс сортировки
        /// Тип: integer	
        /// </summary>
        [JsonProperty(DealContactFields.Sort)]
        public int? Sort { get; set; }

        /// <summary>
        /// Флаг первичного контакта
        /// Тип: char	
        /// </summary>
        [JsonIgnore]
        [CrmField(DealContactFields.IsPrimary, CrmFieldSubTypeEnum.Char_YesNo)]
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
        [JsonProperty(DealContactFields.IsPrimary)]
        public string IsPrimaryExt { get; set; }
    }
}
