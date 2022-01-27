using Bitrix24ApiClient.src.Models.Crm.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.src.Models
{
    public class Company
    {
        [JsonProperty(CompanyFields.Id)]
        public string Id { get; set; }

        [JsonProperty(CompanyFields.Title)]
        public string Title { get; set; }

        [JsonProperty(CompanyFields.Email)]
        public List<Email> Email { get; set; }

        [JsonProperty(CompanyFields.Phone)]
        public List<Phone> Phone { get; set; }
    }
}
