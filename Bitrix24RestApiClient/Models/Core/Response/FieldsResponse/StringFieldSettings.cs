namespace Bitrix24RestApiClient.Models.Core.Response.FieldsResponse
{
    public class StringFieldSettings
	{
        public int? Size { get; set; }
        public int? Rows { get; set; }
        public string RegExp { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public DefaultValue DefaultValue { get; set; }
    }
}
