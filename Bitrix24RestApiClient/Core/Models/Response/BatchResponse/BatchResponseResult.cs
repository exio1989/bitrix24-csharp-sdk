using Bitrix24RestApiClient.src.Models.Crm.Core.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class BatchResponseResult<TCmdResultItem>
    {
        [JsonIgnore]
        public Dictionary<string, TCmdResultItem> Result
        {
            get {
                string str = JsonConvert.SerializeObject(ResultExt);
                if (str == "[]")
                    return new Dictionary<string, TCmdResultItem>();

                return JsonConvert.DeserializeObject<Dictionary<string, TCmdResultItem>>(str);
            }
        }

        [JsonProperty("result")]
        public object ResultExt { get; set; }

        [JsonIgnore]
        public Dictionary<string, BatchResponseResultError> Error
        {
            get
            {
                string str = JsonConvert.SerializeObject(ErrorExt);
                if (str == "[]")
                    return new Dictionary<string, BatchResponseResultError>();

                return JsonConvert.DeserializeObject<Dictionary<string, BatchResponseResultError>>(str);
            }
        }

        [JsonProperty("result_error")]
        public object ErrorExt { get; set; }

        [JsonIgnore]
        public Dictionary<string, int> Total
        {
            get
            {
                string str = JsonConvert.SerializeObject(TotalExt);
                if (str == "[]")
                    return new Dictionary<string, int>();

                return JsonConvert.DeserializeObject<Dictionary<string, int>>(str);
            }
        }

        //TODO неизвестный формат
        [JsonProperty("result_total")]
        public object TotalExt { get; set; }

        [JsonIgnore]
        public Dictionary<string, int> Next
        {
            get
            {
                string str = JsonConvert.SerializeObject(NextExt);
                if (str == "[]")
                    return new Dictionary<string, int>();

                return JsonConvert.DeserializeObject<Dictionary<string, int>>(str);
            }
        }

        //TODO неизвестный формат
        [JsonProperty("result_next")]
        public object NextExt { get; set; }

        [JsonIgnore]
        public Dictionary<string, Time> Time
        {
            get
            {
                string str = JsonConvert.SerializeObject(TimeExt);
                if (str == "[]")
                    return new Dictionary<string, Time>();

                return JsonConvert.DeserializeObject<Dictionary<string, Time>>(str);
            }
        }

        [JsonProperty("result_time")]
        public object TimeExt { get; set; }
    }
}
