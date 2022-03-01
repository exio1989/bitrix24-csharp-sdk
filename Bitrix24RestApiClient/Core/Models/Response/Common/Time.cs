using Newtonsoft.Json;
using System;

namespace Bitrix24RestApiClient.Core.Models.Response.Common
{
    public class Time
	{
		[JsonProperty("start")]
		public decimal Start { get; set; }

		[JsonProperty("finish")]
		public decimal Finish { get; set; }

		[JsonProperty("duration")]
		public decimal Duration { get; set; }

		[JsonProperty("processing")]
		public decimal Processing { get; set; }

		[JsonProperty("date_start")]
		public DateTimeOffset DateStart { get; set; }

		[JsonProperty("date_finish")]
		public DateTimeOffset DateFinish { get; set; }
    }
}
