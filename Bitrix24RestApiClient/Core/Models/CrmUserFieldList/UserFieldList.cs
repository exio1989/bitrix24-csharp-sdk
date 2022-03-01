using Newtonsoft.Json;
using Bitrix24RestApiClient.Core.Models.CrmUserFieldList;
using Bitrix24RestApiClient.Core.Models.CrmAbstractEntity;

namespace Bitrix24RestApiClient.Core.Models.CrmUserFieldList
{
    public class UserFieldList: IAbstractEntity
    {
        /// <summary>
        /// Идентификатор			
        /// Тип: integer	
        /// Только для чтения
        /// </summary>
        [JsonProperty(AbstractEntityFields.Id)]
        public int? Id { get; set; }

        [JsonProperty(UserFieldListFields.Value)]
        public string Value { get; set; }
    }
}
