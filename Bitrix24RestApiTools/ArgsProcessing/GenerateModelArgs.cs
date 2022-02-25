using PowerArgs;

namespace Bitrix24RestApiTools
{
    public class GenerateModelArgs
    {
        [ArgRequired, ArgDescription("WebhookUrl to access Bitrix24 REST API. For example: https://bitrix.persis.ru/rest/17/111/"), ArgPosition(1)]
        public string WebhookUrl { get; set; }

        [ArgRequired, ArgDescription("A fields entry point. For example: crm.deal.fields"), ArgPosition(2)]
        public string FieldsEntryPoint { get; set; }

        [ArgRequired, ArgDescription("A name of a generated class. For example: Deal"), ArgPosition(3)]
        public string ClassName { get; set; }

        [ArgRequired, ArgDescription("A model class description"), ArgPosition(4)]
        public string ClassDescription { get; set; }

        [ArgRequired, ArgDescription("An output path"), ArgPosition(5)]
        public string OutputPath { get; set; }

        [ArgDescription("EntityTypeId. An id that has to be passed into a request body for smart process fields."), ArgPosition(6)]
        public int? EntityTypeId { get; set; }

        public string ResponseClass { get; set; }
    }
}
