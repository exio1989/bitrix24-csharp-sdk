﻿using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Attributes;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Api.Crm.CrmDeal.Contact.Models
{
    public class DealContact
    {
        /// <summary>
        /// Идентификатор сделки(обязательное поле)
        /// Тип: integer	
        /// </summary>
        [JsonProperty(DealContactFields.Id)]
        public int? Id { get; set; }

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
