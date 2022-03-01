using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models.CrmUserFieldList;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Core.Models.CrmUserField
{
    public class UserField: IAbstractEntity
    {
        /// <summary>
        /// Идентификатор			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }

        [JsonProperty(UserFieldFields.FieldName)]
        public string FieldName { get; set; }

        [JsonProperty(UserFieldFields.EntityId)]
        public string EntityId { get; set; }

        [JsonProperty(UserFieldFields.UserTypeId)]
        public string UserTypeId { get; set; }

        [JsonProperty(UserFieldFields.List)]
        public List<UserFieldList> List { get; set; }
    }
}
