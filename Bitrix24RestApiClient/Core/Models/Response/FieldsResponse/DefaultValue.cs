using Newtonsoft.Json;

namespace Bitrix24RestApiClient.Models.Core.Response.FieldsResponse
{
    public class DefaultValue
	{
		[JsonProperty("TYPE")]
		public string Type { get; set; }

		[JsonProperty("VALUE")]
		public string Value { get; set; }
	}
}
