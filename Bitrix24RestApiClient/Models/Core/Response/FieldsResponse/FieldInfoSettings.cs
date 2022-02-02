using Bitrix24RestApiClient.Models.Core.Attributes;
using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bitrix24RestApiClient.Models.Core.Response.FieldsResponse
{
    public class FieldInfoSettings
	{
        //Для enumeration
		[JsonProperty("DISPLAY")]
		public string Display { get; set; }

		[JsonProperty("LIST_HEIGHT")]
		public int? ListHeight { get; set; }

		[JsonProperty("CAPTION_NO_VALUE")]
		public string CaptionNoValue { get; set; }

        [JsonIgnore]
        [CrmYesNoFieldType("SHOW_NO_VALUE")]
        public bool ShowNoValue
        {
            get
            {
                return ShowNoValueExt == YesNoEnum.Y.ToString("F");
            }
            set
            {
                ShowNoValueExt = value
                    ? YesNoEnum.Y.ToString("F")
                    : YesNoEnum.N.ToString("F");
            }
        }

        [JsonProperty("SHOW_NO_VALUE")]
		public string ShowNoValueExt { get; set; }

        //Для string
        [JsonProperty("SIZE")]
        public int? Size { get; set; }

        [JsonProperty("ROWS")]
        public int? Rows { get; set; }

        [JsonProperty("REGEXP")]
        public string RegExp { get; set; }

        [JsonProperty("MIN_LENGTH")]
        public int? MinLength { get; set; }

        [JsonProperty("MAX_LENGTH")]
        public int? MaxLength { get; set; }

        [JsonProperty("DEFAULT_VALUE")]
        public DefaultValue DefaultValue { get; set; } 
    }
}
