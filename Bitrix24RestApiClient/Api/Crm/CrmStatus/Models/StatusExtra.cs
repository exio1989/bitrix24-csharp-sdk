using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api.Crm.CrmStatus.Models;

namespace Bitrix24RestApiClient.Api.Crm.CrmStatus.Models
{
    public class StatusExtra
    {
		/// <summary>
		/// COLOR	
		/// Тип: string
		/// </summary>
		[JsonProperty(StatusExtraFields.Color)]
		public string Color { get; set; }

		//TODO
		/// <summary>
		/// SEMANTICS	
		/// Тип: char
		/// </summary>
		[JsonProperty(StatusExtraFields.Semantics)]
		public string Semantics { get; set; }
	}
}
