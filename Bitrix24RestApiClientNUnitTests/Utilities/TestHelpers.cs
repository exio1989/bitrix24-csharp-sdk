using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitrix24RestApiClientNUnitTests
{
    public static class TestHelpers
    {
        public static bool CompareJsons(string a, string b)
        {
            return JToken.DeepEquals(JsonConvert.DeserializeObject<JObject>(a), JsonConvert.DeserializeObject<JObject>(b));
        }

        public static bool CompareJsons(object a, string b)
        {
            return JToken.DeepEquals(JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(a)), JsonConvert.DeserializeObject<JObject>(b));
        }
    }
}
