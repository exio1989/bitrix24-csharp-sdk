using PowerArgs;

namespace Bitrix24RestApiTools
{
    public class GenerateAllModelsArgs
    {
        [ArgRequired, ArgDescription("WebhookUrl to access Bitrix24 REST API. For example: https://bitrix.persis.ru/rest/17/111/"), ArgPosition(1)]
        public string WebhookUrl { get; set; }

        [ArgRequired, ArgDescription("A model class prefix"), ArgPosition(2)]
        public string ClassPrefix { get; set; }
        
        [ArgRequired, ArgDescription("An output path"), ArgPosition(3)]
        public string OutputPath { get; set; }
    }
}
